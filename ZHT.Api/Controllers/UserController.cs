/*
用户 控制器
*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using ZHT.Data.Models;
using ZHT.Framework;
using ZHT.Service;
using ZHT.Api.Models;
using System.Configuration;

namespace ZHT.Api.Controllers
{
    [AllowAnonymous]
    public class UserController : BaseApiController
    {
        private readonly IMyFavoritesService _myFavoritesService;
        private readonly IEnrollUserService _enrollUserService;
        private readonly IExhibitionService _exhibitionService;
        private readonly IExhibitionProductService _exhibitionProductService;
        private readonly IOrderService _orderService;
        private readonly ITicketsTypeService _ticketsTypeService;
        private readonly ISellerOrderService _sellerOrderService;
        private readonly ICompanyUserService _companyUserService;
        private readonly IUserInfoService _userInfoService;
        private readonly ITicketsSetService _ticketsSetService;
        private readonly IBaseTypesService _baseTypesService;
        private readonly IAttachmentService _attachmentService;
        private readonly IAttachmentTypeService _attachmentTypeService;
        private readonly IBusinessScopeTypeService _businessScopeTypeService;
        private readonly IMomentService _momentService;
        private readonly IMomentReplyService _momentReplyService;
        private readonly IFollowMomentService _followMomentService;
        private readonly IExhibitionProductClassService _exhibitionProductClassService;
        private readonly ICompanyService _companyService;
        private readonly IGoodsService _goodsService;


        private readonly string VerCodeCheckAddress = "http://www.yuanxin2015.com/MobileBusiness/MobileBusiness.Common/Services/PostSMSForDHST.asmx/CheckVerification?mobile={0}&sessionId={1}&markCode={2}";

        

        public UserController(IMyFavoritesService myFavoritesService, IEnrollUserService enrollUserService, IExhibitionService exhibitionService, IExhibitionProductService exhibitionProductService, IOrderService orderService, ITicketsTypeService ticketsTypeService, ISellerOrderService sellerOrderService, ICompanyUserService companyUserService, IUserInfoService userInfoService, ITicketsSetService ticketsSetService, IBaseTypesService baseTypesService, IAttachmentService attachmentService, IAttachmentTypeService attachmentTypeService, IBusinessScopeTypeService businessScopeTypeService, IMomentService momentService, IMomentReplyService momentReplyService, IFollowMomentService followMomentService, IExhibitionProductClassService exhibitionProductClassService, ICompanyService companyService, IGoodsService goodsService)
        {
            _myFavoritesService = myFavoritesService;
            _enrollUserService = enrollUserService;
            _exhibitionService = exhibitionService;
            _exhibitionProductService = exhibitionProductService;
            _orderService = orderService;
            _ticketsTypeService = ticketsTypeService;
            _sellerOrderService = sellerOrderService;
            _companyUserService = companyUserService;
            _userInfoService = userInfoService;
            _ticketsSetService = ticketsSetService;
            _baseTypesService = baseTypesService;
            _attachmentService = attachmentService;
            _attachmentTypeService = attachmentTypeService;
            _businessScopeTypeService = businessScopeTypeService;
            _momentService = momentService;
            _momentReplyService = momentReplyService;
            _followMomentService = followMomentService;
            _exhibitionProductClassService = exhibitionProductClassService;
            _companyService = companyService;
            _goodsService = goodsService;
        }

        /// <summary>
        /// 收藏展会或展品- typeId 1:展会 2：展品  根据目标ID和收藏人ID判断是否重复收藏
        /// </summary>
        /// <returns></returns>
        [Route("api/User/AddFavorites")]
        [HttpPost]
        public IHttpActionResult AddFavorite(AddFavoriteMode requestModel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                string modelId = string.Empty;
                var myFavorite = _myFavoritesService.GetModelByTargetIdAndUserId(requestModel.TargetId, requestModel.UserId);
                if (myFavorite != null)
                {
                    //如果已收藏，则提示
                    if (myFavorite.isdel == 0)
                    {
                        result.Flag = ResultFlag.Error;
                        result.Messages = "您已收藏，请勿重复操作!";
                        return Ok(result);
                    }
                    else
                    {
                        myFavorite.isdel = 0;
                        _myFavoritesService.Update(myFavorite);
                        modelId = myFavorite.id;
                    }
                }
                else
                {

                    //插入到我的收藏表
                    MyFavorites model = new MyFavorites()
                    {
                        id = CommonHelper.GetGuid(),
                        favoritestime = DateTime.Now,
                        usercode = requestModel.UserId,
                        favoritescode = requestModel.TargetId,
                        types = requestModel.TypeId,
                        creater = requestModel.UserId,
                        creattime = DateTime.Now,
                        modifier = requestModel.UserId,
                        modifiytime = DateTime.Now,
                        isdel = 0
                    };

                    _myFavoritesService.Insert(model);
                    modelId = model.id;
                }

                result.Flag = ResultFlag.Successful;
                result.Data = modelId;
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 取消收藏
        /// </summary>
        /// <param name="favoriteId"></param>
        /// <returns></returns>
        [Route("api/User/DeleteFavorite")]
        [HttpPost]
        public IHttpActionResult DeleteFavorite(Favorite favoriteModel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var favorite = _myFavoritesService.GetAllList().Where(t => t.usercode == favoriteModel.userId && t.favoritescode == favoriteModel.favoriteId).FirstOrDefault();

                if (favorite != null)
                {
                    favorite.isdel = 1;
                    _myFavoritesService.Update(favorite);
                    result.Flag = ResultFlag.Successful;
                    result.Data = true;
                }
                else
                {
                    result.Flag = ResultFlag.DataNotExist;
                    result.Data = false;
                }
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 报名参会--要验证是否接受报名以及门票数是否超出限制
        /// </summary>
        [Route("api/User/EnrollExibition")]
        [HttpPost]
        public IHttpActionResult EnrollExibition(EnrollUserModel requestModel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var exhibition = _exhibitionService.GetModelById(requestModel.ExhibitionId);
                var tickteType = _ticketsTypeService.GetModelById(requestModel.TicketTypeCode);

                if (exhibition != null && tickteType != null)
                {
                    int enrollStatus = exhibition.enrollstatus.HasValue ? exhibition.enrollstatus.Value : 1;
                    int ticketCount = tickteType.quota;

                    if (exhibition.endtime < DateTime.Now)
                    {
                        result.Flag = ResultFlag.Error;
                        result.Messages = "展会已结束";
                        return Ok(result);
                    }

                    if (exhibition.enrollstarttime > DateTime.Now)
                    {
                        result.Flag = ResultFlag.Error;
                        result.Messages = "报名尚未开始";
                        return Ok(result);
                    }

                    if (exhibition.enrollendtime < DateTime.Now || enrollStatus == 0)
                    {
                        result.Flag = ResultFlag.Error;
                        result.Messages = "报名已经截止";
                        return Ok(result);
                    }

                    if (ticketCount < 1)
                    {
                        result.Flag = ResultFlag.Error;
                        result.Messages = "门票已售完";
                        return Ok(result);
                    }

                    //从远鑫获取订单号
                    string orderNo = GetOrderNo;
                    if (string.IsNullOrEmpty(orderNo))
                    {
                        result.Flag = ResultFlag.Error;
                        result.Data = null;
                        result.Messages = "获取订单号失败!!";
                        return Ok(result);
                    }

                    string code = CommonHelper.GetGuid();

                    //向远鑫表插入数据
                    YXOrderRequest yxOrderRequest = new YXOrderRequest()
                    {
                        Code = code,
                        OrderNo = orderNo,
                        Total = tickteType.price.ToString(),
                        Creator = requestModel.UserId
                    };

                    if (!CreateYxOrder(yxOrderRequest))
                    {
                        result.Flag = ResultFlag.Error;
                        result.Data = null;
                        result.Messages = "插入远鑫订单表失败!";
                        return Ok(result);
                    }

                    //插入到报名表,门票状态为未验票
                    EnrollUser model = new EnrollUser()
                    {
                        id = code,
                        enrolltime = DateTime.Now,
                        exhibitioncode = requestModel.ExhibitionId,
                        nickname = requestModel.NickName,
                        sname = requestModel.Name,
                        sphone = requestModel.Phone,
                        ticketstatus = (int)EnrollOrderStatus.NoPay,
                        pwdticket = CommonHelper.GetTicketPwd(),
                        remark = requestModel.Remark,
                        creater = requestModel.UserId,
                        creattime = DateTime.Now,
                        modifier = requestModel.UserId,
                        modifiytime = DateTime.Now,
                        isdel = 0,
                        ticketTypeCode = requestModel.TicketTypeCode,
                        orderNo = orderNo
                    };

                    _enrollUserService.Insert(model);

                    //门票数-1
                    tickteType.quota -= 1;
                    _ticketsTypeService.Update(tickteType);

                    result.Flag = ResultFlag.Successful;
                    result.Data = model.id;
                }
                else
                {
                    result.Flag = ResultFlag.DataNotExist;
                }
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 获取我的门票
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [Route("api/User/GetMyTickets/{userId}/{status}")]
        [HttpGet]
        public IHttpActionResult GetMyTickets(string userId, int status)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {

                var ticket = _enrollUserService.GetAllList().Where(p => p.creater == userId && p.ticketstatus == status).ToList();

                if (ticket.Count > 0)
                {
                    List<TicketModel> model = new List<TicketModel>();

                    foreach (var p in ticket)
                    {
                        string logo = string.Empty;
                        // 获取封面图片
                        if (HasAttachmentType(AttType.ExhibitionLogo))
                        {
                            var logoImgAtt = _attachmentService.GetListByResourceIdAndType(p.exhibitioncode, CommonHelper.GetEnumValue<AttType>(AttType.ExhibitionLogo));
                            if (logoImgAtt.Count > 0)
                            {
                                logo = logoImgAtt.FirstOrDefault().URL;
                            }
                        }
                        model.Add(new TicketModel()
                        {
                            ExhibitionId = p.exhibitioncode,
                            ExhibitionName = p.exhibition.exhibitionname,
                            ExhibitionLogo = logo,
                            StartTime = p.exhibition.starttime.ToString(),
                            EndTime = p.exhibition.endtime.ToString(),
                            Longitude = p.exhibition.longitude,
                            Latitude = p.exhibition.latitude,
                            EnrollTime = p.enrolltime.ToString(),
                            TicketId = p.id,
                            Price = p.ticketsType.price,
                            TicketName = p.ticketsType.ticketname,
                            BusinessName = p.exhibition.businessname,
                            City = p.exhibition.city,
                            Area = p.exhibition.area,
                            OrderNo = p.orderNo
                        });
                    }

                    result.Flag = ResultFlag.Successful;
                    result.Data = model;
                }
                else
                {
                    result.Flag = ResultFlag.DataNotExist;
                }
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 获取门票详情
        /// </summary>
        /// <returns></returns>
        [Route("api/User/GetTicketDetails/{ticketId}")]
        [HttpGet]
        public IHttpActionResult GetTicketDetails(string ticketId)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {

                var ticket = _enrollUserService.GetModelById(ticketId);

                if (ticket != null)
                {
                    TicketDetailsModel model = new TicketDetailsModel()
                    {
                        ExhibitionId = ticket.exhibitioncode,
                        ExhibitionName = ticket.exhibition.exhibitionname,
                        PwdNumber = ticket.pwdticket,
                        NickName = ticket.nickname,
                        Phone = ticket.sphone,
                        Status = ticket.ticketstatus,
                        StartTime = ticket.exhibition.starttime.ToString(),
                        EndTime = ticket.exhibition.endtime.ToString(),
                        Address1 = ticket.exhibition.address1,
                        Address2 = ticket.exhibition.address2,
                        Longitude = ticket.exhibition.longitude,
                        Latitude = ticket.exhibition.latitude,
                        Detailes = ticket.exhibition.detailes,
                        OrderNo = ticket.orderNo
                    };

                    //获取图片和视频
                    model.ImageUrls = new List<ImageAndVideoUrlResponse>();
                    model.VideoUrls = new List<ImageAndVideoUrlResponse>();

                    if (HasAttachmentType(AttType.ExhibitionIntroImg))
                    {
                        var imgAtts = _attachmentService.GetListByResourceIdAndType(ticket.exhibitioncode, CommonHelper.GetEnumValue<AttType>(AttType.ExhibitionIntroImg));
                        imgAtts.ForEach(p =>
                        {
                            model.ImageUrls.Add(new ImageAndVideoUrlResponse { Id = p.Code, Url = p.URL });
                        });

                    }

                    if (HasAttachmentType(AttType.ExhibitionIntroVideo))
                    {
                        var videoAtts = _attachmentService.GetListByResourceIdAndType(ticket.exhibitioncode, CommonHelper.GetEnumValue<AttType>(AttType.ExhibitionIntroVideo));
                        videoAtts.ForEach(p =>
                        {
                            model.VideoUrls.Add(new ImageAndVideoUrlResponse { Id = p.Code, Url = p.URL });
                        });
                    }

                    result.Flag = ResultFlag.Successful;
                    result.Data = model;
                }
                else
                {
                    result.Flag = ResultFlag.DataNotExist;
                }
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 获取我的收藏-展会 
        /// </summary>
        /// <returns></returns>
        [Route("api/User/GetMyFavoriteExhibition/{userId}")]
        [HttpGet]
        public IHttpActionResult GetMyFavoriteExhibition(string userId)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var myExhibitions = _myFavoritesService.GetAllList().Where(t => t.creater == userId && t.types == 1 && t.isdel == 0).ToList();

                if (myExhibitions.Count > 0)
                {
                    List<MyExhibition> model = new List<MyExhibition>();

                    myExhibitions.ForEach(p =>
                    {
                        var exhibition = _exhibitionService.GetModelById(p.favoritescode);

                        string headImg = string.Empty;
                        if (HasAttachmentType(AttType.ExhibitionLogo))
                        {
                            var logoImgAtt = _attachmentService.GetListByResourceIdAndType(exhibition.id, CommonHelper.GetEnumValue<AttType>(AttType.ExhibitionLogo));
                            if (logoImgAtt.Count > 0)
                            {
                                headImg = logoImgAtt.FirstOrDefault().URL;
                            }
                        }

                        if (exhibition != null)
                        {
                            string tags = string.Empty;
                            exhibition.exhibitiontag.ToList().ForEach(w =>
                            {
                                tags += w.tagname + ",";
                            });
                            if (tags.Length > 0)
                            {
                                tags = tags.Substring(0, tags.Length - 1);
                            }
                            model.Add(new MyExhibition()
                            {
                                FavoriteId = p.id,
                                ExhibitionId = p.favoritescode,
                                HeadImg = headImg,
                                ExhibitionName = exhibition.exhibitionname,
                                StartTime = exhibition.starttime.ToString(),
                                EndTime = exhibition.endtime.ToString(),
                                Longitude = exhibition.longitude,
                                Latitude = exhibition.latitude,
                                LowestTicketPrice = 0,
                                Tags = tags,
                                LivingCount = -1,
                                City = exhibition.city,
                                Area = exhibition.area
                            });
                        }
                    });

                    result.Flag = ResultFlag.Successful;
                    result.Data = model;
                }
                else
                {
                    result.Flag = ResultFlag.DataNotExist;
                }
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 获取我的收藏-展品 
        /// </summary>
        /// <returns></returns>
        [Route("api/User/GetMyFavoriteProduct/{userId}")]
        [HttpGet]
        public IHttpActionResult GetMyFavoriteProduct(string userId)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var myProducts = _myFavoritesService.GetAllList().Where(t => t.creater == userId && t.types == 2 && t.isdel == 0).ToList();

                if (myProducts.Count > 0)
                {
                    List<MyProduct> model = new List<MyProduct>();

                    foreach (var p in myProducts)
                    {
                        var product = _exhibitionProductService.GetModelById(p.favoritescode);                        

                        bool isTimeOut = false;
                        if (p.exhibitions != null)
                        {
                            isTimeOut = p.exhibitions.endtime < DateTime.Now ? true : false;
                        }

                        if (product != null)
                        {
                            model.Add(new MyProduct()
                            {
                                FavoriteId = p.id,
                                ExhibitionId = product.exhibitioncode,
                                ProductId = product.id,
                                HeadImg = _goodsService.GetGoodHeadImg(product.yxproductcode, MaterialServiceUrl),
                                Name = product.productName,
                                OldPrice = product.oprice,
                                Price = product.nprice,
                                IsTimeOut = isTimeOut
                            });
                        }
                    }

                    result.Flag = ResultFlag.Successful;
                    result.Data = model;
                }
                else
                {
                    result.Flag = ResultFlag.DataNotExist;
                }
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 下单
        /// </summary>
        /// <returns></returns>
        [Route("api/User/BuyProduct")]
        [HttpPost]
        public IHttpActionResult BuyProduct(BuyGoodsModel requestModel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                //从远鑫获取订单号
                string orderNo = GetOrderNo;
                if (string.IsNullOrEmpty(orderNo))
                {
                    result.Flag = ResultFlag.Error;
                    result.Data = null;
                    result.Messages = "获取订单号失败!!";
                    return Ok(result);
                }

                string code = CommonHelper.GetGuid();

                //向远鑫表插入数据
                YXOrderRequest yxOrderRequest = new YXOrderRequest()
                {
                    Code = code,
                    OrderNo = orderNo,
                    Total = requestModel.TotalCharge.ToString(),
                    Creator = requestModel.BusinessUserCode
                };

                if (!CreateYxOrder(yxOrderRequest))
                {
                    result.Flag = ResultFlag.Error;
                    result.Data = null;
                    result.Messages = "插入远鑫订单表失败!";
                    return Ok(result);
                }

                Order model = new Order()
                {
                    code = code,
                    orderNumber = requestModel.OrderNumber,
                    businessUserCode = requestModel.BusinessUserCode,
                    customerName = requestModel.CustomerName,
                    sellerNumber = requestModel.ExhibitionId,                   //保存展会ID
                    telephone = requestModel.Telephone,
                    createTime = DateTime.Now,
                    pyteType = requestModel.PyteType,
                    status = (int)ProductOrderStatus.NoPay,                     //新建订单为1，提货后订单为2
                    totalCharge = requestModel.TotalCharge,
                    creator = requestModel.BusinessUserCode
                };

                foreach (var p in requestModel.OrderDetails)
                {

                    model.orderDetails.Add(new OrderDetail()
                    {
                        code = CommonHelper.GetGuid(),
                        goodsCode = p.GoodsCode,
                        goodsName = p.GoodsName,
                        goodsCount = p.GoodsCount,
                        charge = p.Charge,
                        createTime = DateTime.Now
                    });
                }

                _orderService.Insert(model);

                result.Flag = ResultFlag.Successful;
                result.Data = model.code;
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 我的订单 status: 1-正在进行 2-已完成
        /// </summary>
        /// <returns></returns>
        [Route("api/User/MyOrders/{userId}/{status}")]
        [HttpGet]
        public IHttpActionResult MyOrders(string userId, int status)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                List<OrderListModel> model = new List<OrderListModel>();
                var orders = _orderService.GetAllList().Where(p => p.businessUserCode == userId).ToList();
                if (status == 1)
                {
                    orders = orders.Where(p => p.status != (int)ProductOrderStatus.PickUp).ToList();
                }
                else
                {
                    orders = orders.Where(p => p.status == status).ToList();
                }

                if (orders.Count > 0)
                {
                    foreach (var p in orders)
                    {
                        string sName = string.Empty;
                        switch (p.status)
                        {
                            case (int)ProductOrderStatus.NoPay:
                                sName = "待支付";
                                break;
                            case (int)ProductOrderStatus.NoPickUp:
                                sName = "待提货";
                                break;
                            case (int)ProductOrderStatus.PickUp:
                                sName = "已提货";
                                break;
                        }

                        OrderListModel item = new OrderListModel();
                        item.OrderId = p.code;
                        item.Status = sName;
                        item.TotalPay = p.totalCharge.HasValue ? p.totalCharge.Value : 0;
                        item.CreateTime = p.createTime.ToString();
                        item.OrderNo = p.orderNumber;
                        item.Products = new List<ProductNameModel>();
                        foreach (var product in p.orderDetails)
                        {
                            item.Products.Add(new ProductNameModel()
                            {
                                Name = product.goodsName
                            });

                            if (string.IsNullOrWhiteSpace(item.SellerName))
                            {
                                //参展商信息
                                var sellerOrder = _sellerOrderService.GetModelBySellerId(p.sellerNumber, product.goods.creator);
                                if (sellerOrder != null)
                                {
                                    item.Seats = new List<SellerSeatModel>();
                                    sellerOrder.sellerOrderDetails.ToList().ForEach(w =>
                                    {
                                        item.Seats.Add(new SellerSeatModel()
                                        {
                                            SeatNo = w.seatno.seatno,
                                            Price = w.seatno.seatset.seatprice
                                        });
                                    });

                                    var companyUser = _companyUserService.GetModelByUserCode(sellerOrder.sellerid);
                                    if (companyUser != null)
                                    {
                                        item.SellerHeadImg = _companyService.GetHeadImg(companyUser.CompanyCode);
                                        item.SellerName = _companyService.GetCompanyName(companyUser.CompanyCode);
                                    }
                                }
                            }
                        }
                        if (string.IsNullOrWhiteSpace(item.SellerName))
                        {
                            item.SellerName = string.Empty;
                            item.Seats = new List<SellerSeatModel>();
                        }

                        model.Add(item);
                    }

                    result.Flag = ResultFlag.Successful;
                    result.Data = model;
                }
                else
                {
                    result.Flag = ResultFlag.DataNotExist;
                }

            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 订单详情
        /// </summary>
        /// <returns></returns>
        [Route("api/User/OrderDetail/{orderId}")]
        [HttpGet]
        public IHttpActionResult OrderDetail(string orderId)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                OrderDetailsInfoModel model = new OrderDetailsInfoModel();
                var order = _orderService.GetModelById(orderId);

                if (order != null)
                {
                    model.OrderNo = order.orderNumber;
                    model.TotalPay = order.totalCharge.HasValue ? order.totalCharge.Value : 0;
                    model.CreateTime = order.createTime.ToString();
                    model.Status = order.status == 1 ? "待提货" : "已提货";
                    model.OrderDetails = new List<OrderDetailsModel>();
                    var userInfo = _userInfoService.GetModelById(order.businessUserCode);
                    model.UserHeadImg = userInfo == null ? CommonHelper.TempHeadImg() : userInfo.HeadImage;
                    foreach (var product in order.orderDetails)
                    {
                        string productId = string.Empty;

                        if (string.IsNullOrWhiteSpace(model.SellerName))
                        {
                            //参展商信息
                            var sellerOrder = _sellerOrderService.GetModelBySellerId(order.sellerNumber, product.goods.creator);
                            if (sellerOrder != null)
                            {
                                var companyUser = _companyUserService.GetModelByUserCode(sellerOrder.sellerid);
                                model.SellerName = companyUser != null ? _companyService.GetCompanyName(companyUser.CompanyCode) : "";
                                model.Seats = new List<SellerSeatModel>();
                                sellerOrder.sellerOrderDetails.ToList().ForEach(w =>
                                {
                                    model.Seats.Add(new SellerSeatModel()
                                    {
                                        SeatNo = w.seatno.seatno,
                                        Price = w.seatno.seatset.seatprice
                                    });
                                });
                            }
                        }

                        var eProduct = _exhibitionProductService.GetModelByExhibitionIdAndPId(order.sellerNumber, product.goodsCode);                        

                        var detialsModel = new OrderDetailsModel();

                        detialsModel.ProductId = productId;
                        detialsModel.GoodsCode = product.goodsCode;
                        detialsModel.GoodsCount = product.goodsCount.HasValue ? product.goodsCount.Value : 0;
                        detialsModel.GoodsName = product.goodsName;
                        detialsModel.Charge = product.charge.HasValue ? product.charge.Value : 0;
                        detialsModel.ProductImg = _goodsService.GetGoodHeadImg(eProduct.yxproductcode, MaterialServiceUrl);

                        model.OrderDetails.Add(detialsModel);
                    }

                    if (string.IsNullOrWhiteSpace(model.SellerName))
                    {
                        model.SellerName = string.Empty;
                        model.Seats = new List<SellerSeatModel>();
                    }

                    result.Flag = ResultFlag.Successful;
                    result.Data = model;
                }
                else
                {
                    result.Flag = ResultFlag.DataNotExist;
                }

            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 获取我的消息列表
        /// </summary>
        /// <returns></returns>
        [Route("api/User/GetMyMsg/{userId}")]
        [HttpGet]
        public IHttpActionResult GetMyMsgList()
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                List<MsgListModel> model = new List<MsgListModel>();
                model.Add(new MsgListModel() { Title = "远鑫通告", SubTitle = "五讲四美", MsgDate = "3小时前" });
                model.Add(new MsgListModel() { Title = "订单助手", SubTitle = "下单成功", MsgDate = "3天前" });
                model.Add(new MsgListModel() { Title = "群聊", SubTitle = "我爱北京天安门:小米NOTE2", MsgDate = "昨天" });
                model.Add(new MsgListModel() { Title = "私信", SubTitle = "老鼠爱大米:今天几点集合", MsgDate = "3月前" });
                model.Add(new MsgListModel() { Title = "评论", SubTitle = "赞一个", MsgDate = "3小时前" });

                result.Flag = ResultFlag.Successful;
                result.Data = model;
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 获取消息 : msgType:1 远洋通告； 2 订单助手；3 群聊；4 私信；5 评论
        /// </summary>
        /// <returns></returns>
        [Route("api/User/GetMsg/{userId}/{msgType}")]
        [HttpGet]
        public IHttpActionResult GetMsg()
        {
            return Ok("");
        }

        /// <summary>
        /// 所有展会列表-- 新增未完 status 0-未结束 1-已结束  orderType:1 热门 2 最新 3 距离最近  
        /// ExhibitionType 0 不按类型筛选
        /// </summary>
        /// <returns></returns>
        [Route("api/User/ExhibitionList/{Longitude}/{Latitude}/{Status}/{OrderType}/{ExhibitionType}")]
        [HttpGet]
        public IHttpActionResult ExhibitionList(int Status, int OrderType, string ExhibitionType, string Longitude, string Latitude)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var exhibitions = new List<Exhibition>();
                if (Status == 0)
                {
                    if (OrderType == 1)//热门
                    {
                        if (ExhibitionType == "0")
                        {
                            exhibitions = _exhibitionService.GetAllList().Where(t => DateTime.Now < t.endtime).OrderByDescending(t => t.enrolluser.Count()).ToList();
                        }
                        else
                        {
                            exhibitions = _exhibitionService.GetAllList().Where(t => DateTime.Now < t.endtime && t.basetypescode == ExhibitionType).OrderByDescending(t => t.enrolluser.Count()).ToList();
                        }
                    }
                    else if (OrderType == 2)//最新
                    {
                        if (ExhibitionType == "0")
                        {
                            exhibitions = _exhibitionService.GetAllList().Where(t => DateTime.Now < t.endtime).OrderByDescending(t => t.starttime).ToList();
                        }
                        else
                        {
                            exhibitions = _exhibitionService.GetAllList().Where(t => DateTime.Now < t.endtime && t.basetypescode == ExhibitionType).OrderByDescending(t => t.starttime).ToList();
                        }
                    }
                    else if (OrderType == 3)//距离最近
                    {
                        if (ExhibitionType == "0")
                        {
                            exhibitions = _exhibitionService.GetAllList().Where(t => DateTime.Now < t.endtime && t.basetypescode == ExhibitionType).OrderByDescending(t => GetDistanseHelper.getDistance(double.Parse(Longitude), double.Parse(Latitude), double.Parse(t.longitude.ToString()), double.Parse(t.latitude.ToString()))).ToList();
                        }
                        else
                        {
                            exhibitions = _exhibitionService.GetAllList().Where(t => DateTime.Now < t.endtime).OrderByDescending(t => GetDistanseHelper.getDistance(double.Parse(Longitude), double.Parse(Latitude), double.Parse(t.longitude.ToString()), double.Parse(t.latitude.ToString()))).ToList();
                        }
                    }
                    else
                    {
                        exhibitions = _exhibitionService.GetAllList();
                    }
                }
                else if (Status == 1)
                {
                    if (OrderType == 1)
                    {
                        if (ExhibitionType == "0")
                        {
                            exhibitions = _exhibitionService.GetAllList().Where(t => DateTime.Now > t.endtime).OrderByDescending(t => t.enrolluser.Count()).ToList();
                        }
                        else
                        {
                            exhibitions = _exhibitionService.GetAllList().Where(t => DateTime.Now > t.endtime && t.basetypescode == ExhibitionType).OrderByDescending(t => t.enrolluser.Count()).ToList();
                        }
                    }
                    else if (OrderType == 2)
                    {
                        if (ExhibitionType == "0")
                        {
                            exhibitions = _exhibitionService.GetAllList().Where(t => DateTime.Now > t.endtime).OrderByDescending(t => t.starttime).ToList();
                        }
                        else
                        {
                            exhibitions = _exhibitionService.GetAllList().Where(t => DateTime.Now > t.endtime && t.basetypescode == ExhibitionType).OrderByDescending(t => t.starttime).ToList();
                        }
                    }
                    else if (OrderType == 3)
                    {
                        if (ExhibitionType == "0")
                        {
                            exhibitions = _exhibitionService.GetAllList().Where(t => DateTime.Now > t.endtime).OrderByDescending(t => GetDistanseHelper.getDistance(double.Parse(Longitude), double.Parse(Latitude), double.Parse(t.longitude.ToString()), double.Parse(t.latitude.ToString()))).ToList();
                        }
                        else
                        {
                            exhibitions = _exhibitionService.GetAllList().Where(t => DateTime.Now > t.endtime && t.basetypescode == ExhibitionType).OrderByDescending(t => GetDistanseHelper.getDistance(double.Parse(Longitude), double.Parse(Latitude), double.Parse(t.longitude.ToString()), double.Parse(t.latitude.ToString()))).ToList();
                        }
                    }
                    else
                    {
                        exhibitions = _exhibitionService.GetAllList();
                    }
                }
                List<SearchExhibitionResponseModel> model = new List<SearchExhibitionResponseModel>();

                if (exhibitions.Count > 0)
                {
                    foreach (var p in exhibitions)
                    {
                        string headImg = string.Empty;
                        if (HasAttachmentType(AttType.ExhibitionLogo))
                        {
                            var logoImgAtt = _attachmentService.GetListByResourceIdAndType(p.id, CommonHelper.GetEnumValue<AttType>(AttType.ExhibitionLogo));
                            if (logoImgAtt.Count > 0)
                            {
                                headImg = logoImgAtt.FirstOrDefault().URL;
                            }
                        }

                        if (p.endtime < DateTime.Now)
                        {
                            var item = new SearchExhibitionResponseModel()
                            {
                                ExhibitionId = p.id,
                                ExhibitionName = p.exhibitionname,
                                HeadImg = headImg,
                                CreationDate = p.creattime.ToString(),
                                Status = GetExhibitionStatusStr(p),
                                SellerNumber = p.sellerorder.Count,
                                UserNumber = p.enrolluser.Count,
                                City = p.city,
                                Area = p.area
                            };
                            item.Tags = new List<TagName>();
                            p.exhibitiontag.ToList().ForEach(w =>
                            {
                                item.Tags.Add(new TagName()
                                {
                                    Id = w.id,
                                    Name = w.tagname
                                });
                            }
                                );
                            model.Add(item);
                        }
                        else if (p.endtime > DateTime.Now)
                        {
                            var item = new SearchExhibitionResponseModel()
                            {
                                ExhibitionId = p.id,
                                ExhibitionName = p.exhibitionname,
                                HeadImg = headImg,
                                CreationDate = p.creattime.ToString(),
                                Status = GetExhibitionStatusStr(p),
                                SellerNumber = p.sellerorder.Count,
                                UserNumber = p.enrolluser.Count,
                                City = p.city,
                                Area = p.area
                            };
                            item.Tags = new List<TagName>();
                            p.exhibitiontag.ToList().ForEach(w =>
                            {
                                item.Tags.Add(new TagName()
                                {
                                    Id = w.id,
                                    Name = w.tagname
                                });
                            }
                                );
                            model.Add(item);
                        }
                    }
                    result.Flag = ResultFlag.Successful;
                    result.Data = model;
                }
                else
                {
                    result.Flag = ResultFlag.DataNotExist;
                }
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 根据展会获取展品分类
        /// </summary>
        /// <param name="exhibitionId"></param>
        /// <returns></returns>
        [Route("api/User/GetExhibitionProType/{exhibitionId}")]
        [HttpGet]
        public IHttpActionResult GetExhibitionProType(string exhibitionId)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var model = new List<ProductTypeModel>();

                var classes = _exhibitionProductClassService.GetAllList().Where(t => t.isdel == 0 && t.exhibitioncode == exhibitionId).ToList();

                if (classes != null)
                {
                    classes.ForEach(p =>
                    {
                        model.Add(new ProductTypeModel()
                        {
                            ProductTypeId = p.id,
                            ProductTypeName = p.classname
                        });
                    });

                    result.Flag = ResultFlag.Successful;
                    result.Data = model;
                }
                else
                {
                    result.Flag = ResultFlag.DataNotExist;
                }
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 查看已上架展品列表-- 根据展品分类id 展会id 
        /// </summary>
        /// <param name="exhibitionId"></param>
        /// <param name="productTypeId"></param>
        /// <returns></returns>
        [Route("api/User/SerchProducts/{exhibitionId}/{productTypeId}")]
        [HttpGet]
        public IHttpActionResult SerchProducts(string exhibitionId, string productTypeId)
        {
            ClientApiResult result = new ClientApiResult();
            List<ProductModel> model = new List<ProductModel>();
            try
            {
                var exhibitionProducts = _exhibitionProductService.GetAllList().Where(t => t.pstatus == 1 && t.exhibitioncode == exhibitionId && t.exhibitionproductclasscode == productTypeId).ToList();
                exhibitionProducts.ForEach(p =>
                {
                    ProductModel product = new ProductModel();
                    product.ExhibitonProductId = p.id;
                    product.ExhibitonProductName = p.productName;
                    product.OldPrice = p.oprice;
                    product.Price = p.nprice;
                    product.ProductImage = _goodsService.GetGoodHeadImg(p.yxproductcode, MaterialServiceUrl);
                    model.Add(product);
                });
                result.Flag = ResultFlag.Successful;
                result.Data = model;
            }
            catch (Exception ex)
            {

                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }
        /// <summary>
        /// 获取是否收藏
        /// </summary>
        /// <param name="userId">用户id</param>
        /// <param name="favoriteId">收藏id</param>
        /// <returns></returns>
        [Route("api/User/GetResultByUserId/{userId}/{favoriteId}")]
        [HttpGet]
        public IHttpActionResult GetResultByUserId(string userId, string favoriteId)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var myFavorite =
                    _myFavoritesService.GetAllList()
                        .Where(t => t.usercode == userId && t.favoritescode == favoriteId && t.isdel == 0)
                        .FirstOrDefault();
                if (myFavorite != null)
                {
                    result.Flag = ResultFlag.Successful;
                    result.Data = true;
                    result.Messages = "已收藏！";
                }
                else
                {
                    result.Flag = ResultFlag.DataNotExist;
                    result.Data = false;
                    result.Messages = "未收藏！";
                }
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 获取门票设置
        /// </summary>
        /// <returns></returns>
        [Route("api/User/GetExhibitionTicketSetDetails/{exhibitionTicketSetId}")]
        [HttpGet]
        public IHttpActionResult GetExhibitionTicketSetDetails(string exhibitionTicketSetId)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                ExhibitionTicketSetDetailsModel model = new ExhibitionTicketSetDetailsModel();
                //获取展会设置详情
                var ticketsSet = _ticketsSetService.GetMoelById(exhibitionTicketSetId);
                var exhibition = _exhibitionService.GetModelById(ticketsSet.exhibitioncode);
                model.ExhibitionId = exhibition.id;
                model.ExhibitionTicketId = ticketsSet.id;
                model.EnrollStartTime = exhibition.enrollstarttime.ToString();
                model.EnrollEmdTime = exhibition.enrollendtime.ToString();
                model.NameRequire = ticketsSet.namerequire;
                model.PhoneRequire = ticketsSet.phonerequire;
                //门票类型列表
                model.TicketTypes = new List<ExhibitionTicketsTypeDetailsModel>();
                ticketsSet.tickettype.ToList().ForEach(p =>
                {
                    var details = new ExhibitionTicketsTypeDetailsModel();
                    details.ticketsTypeID = p.id;
                    details.ticketName = p.ticketname;
                    details.price = p.price;
                    details.quota = p.quota;
                    details.privilege = p.privilege;
                    model.TicketTypes.Add(details);
                });
                result.Flag = ResultFlag.Successful;
                result.Data = model;
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 获取基础类型：1-展会类型 2-展位类型
        /// </summary>
        /// <returns></returns>
        [Route("api/User/GetBaseTypes/{typeId}")]
        [HttpGet]
        public IHttpActionResult GetBaseTypes(int typeId)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                List<BaseTypeModel> model = new List<BaseTypeModel>();
                //基础类型list
                var list = _baseTypesService.GetBaseTypesList().Where(p => p.typeid == typeId).ToList();
                list.ForEach(p =>
                {
                    model.Add(new BaseTypeModel() { Id = p.id, Value = p.typevalue });
                });

                result.Flag = ResultFlag.Successful;
                result.Data = model;
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 获取展会详情
        /// </summary>
        /// <param name="exhibitionId"></param>
        /// <returns></returns>
        [Route("api/User/GetExhibitionDetails/{exhibitionId}")]
        [HttpGet]
        public IHttpActionResult GetExhibitionDetails(string exhibitionId)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                ExhibitionDetailsModel model = new ExhibitionDetailsModel();

                //获取展会详情
                Exhibition exhibition = new Exhibition();
                exhibition = _exhibitionService.GetModelById(exhibitionId);
                model.ExhibitionId = exhibition.id;
                model.Name = exhibition.exhibitionname;
                model.ClassId = exhibition.basetypescode;
                model.ClassName = exhibition.basetypes.typevalue;
                model.StartDate = exhibition.starttime.ToString("yyyy-MM-dd");
                model.EndDate = exhibition.endtime.ToString("yyyy-MM-dd");
                model.Address1 = exhibition.address1;
                model.Address2 = exhibition.address2;
                model.Longitude = exhibition.longitude;
                model.Latitude = exhibition.latitude;
                model.Detailes = exhibition.detailes;
                model.LowDiscount = exhibition.lowdiscount;
                model.SaleProportion = exhibition.saleproportion;
                model.RecruitStatus = exhibition.recruitstatus.HasValue ? exhibition.recruitstatus.Value : 0;
                model.EnrollStatus = exhibition.enrollstatus.HasValue ? exhibition.enrollstatus.Value : 0;
                model.BusinessID = exhibition.businessid;
                model.BusinessName = exhibition.businessname;
                model.SellerCount = exhibition.sellerorder.Count;
                model.EnrollUserCount = exhibition.enrolluser.Count;
                model.LiveCount = -1;           //目前没数据
                model.Province = exhibition.province;
                model.City = exhibition.city;
                model.Area = exhibition.area;

                // 获取封面图片
                if (HasAttachmentType(AttType.ExhibitionLogo))
                {
                    var logoImgAtt = _attachmentService.GetListByResourceIdAndType(exhibitionId, CommonHelper.GetEnumValue<AttType>(AttType.ExhibitionLogo));
                    if (logoImgAtt.Count > 0)
                    {
                        model.HeadImg = logoImgAtt.FirstOrDefault().URL;
                    }
                }

                //获取图片和视频
                model.ImageUrls = new List<ImageAndVideoUrlResponse>();
                model.VideoUrls = new List<ImageAndVideoUrlResponse>();
                if (HasAttachmentType(AttType.ExhibitionIntroImg))
                {
                    var imgAtts = _attachmentService.GetListByResourceIdAndType(exhibitionId, CommonHelper.GetEnumValue<AttType>(AttType.ExhibitionIntroImg));
                    imgAtts.ForEach(p =>
                    {
                        model.ImageUrls.Add(new ImageAndVideoUrlResponse { Id = p.Code, Url = p.URL });
                    });

                }

                if (HasAttachmentType(AttType.ExhibitionIntroVideo))
                {
                    var videoAtts = _attachmentService.GetListByResourceIdAndType(exhibitionId, CommonHelper.GetEnumValue<AttType>(AttType.ExhibitionIntroVideo));
                    videoAtts.ForEach(p =>
                    {
                        model.VideoUrls.Add(new ImageAndVideoUrlResponse { Id = p.Code, Url = p.URL });
                    });
                }

                //展品分类
                model.ExhibitionProClass = new List<ExhibitionProductClassRequestModel>();
                exhibition.exhibitionproductclass.ToList().ForEach(p =>
                {
                    var classRequest = new ExhibitionProductClassRequestModel();
                    classRequest.ClassName = p.classname;
                    model.ExhibitionProClass.Add(classRequest);
                });
                //展会标签
                model.ExhibitionTagCodeName = new List<ExhibitionTagRequestModel>();
                exhibition.exhibitiontag.ToList().ForEach(p =>
                {
                    ExhibitionTagRequestModel tagModel = new ExhibitionTagRequestModel();
                    tagModel.TagName = p.tagname;
                    model.ExhibitionTagCodeName.Add(tagModel);
                });
                //展位设置
                ExhibitionApplyDetailsModel details = new ExhibitionApplyDetailsModel();
                // 获取展位分布图
                if (HasAttachmentType(AttType.ExhibitionIntroVideo))
                {
                    var dMapAtt = _attachmentService.GetListByResourceIdAndType(exhibitionId, CommonHelper.GetEnumValue<AttType>(AttType.DistributionMap));
                    if (dMapAtt.Count > 0)
                    {
                        details.distributionMap = dMapAtt.FirstOrDefault().URL;
                    }
                }
                details.editorId = exhibition.creater;
                //details.ExhibitionApplyCode = exhibition.seatset.Count() > 0 ? exhibition.seatset.FirstOrDefault().id :null;
                details.exhibitionId = exhibition.id;
                details.recruitEndTime = exhibition.recruitendtime.ToString("yyyy-MM-dd HH:mm:ss");
                var seatSet = exhibition.seatset.ToList();
                details.seatSetTypes = new List<SeatSetTypes>();
                seatSet.ForEach(p =>
                {
                    SeatSetTypes seatSetTypesModel = new SeatSetTypes();

                    seatSetTypesModel.seatPrice = p.seatprice;
                    seatSetTypesModel.seatScale = p.seatscale;
                    seatSetTypesModel.seatSetTypeId = p.id;
                    seatSetTypesModel.typeName = p.basetypescode;
                    seatSetTypesModel.baseTypeCode = p.basetypescode;
                    seatSetTypesModel.seatNo = new List<SeatSetNoModel>();
                    p.seatno.OrderBy(t => t.seatno).ToList().ForEach(w =>
                    {
                        seatSetTypesModel.seatNo.Add(new SeatSetNoModel()
                        {
                            noId = w.id,
                            seatno = w.seatno,
                            //seatSetId = w.seatsetcode
                        });
                    });
                    details.seatSetTypes.Add(seatSetTypesModel);
                    model.ExhibitionApplys = details;
                });
                //门票设置
                exhibition.ticketsset.ToList().ForEach(p =>
                {
                    model.ExhibitionTicketSet = new List<ExhibitionTicketSetDetailsModel>();
                    ExhibitionTicketSetDetailsModel ticketdetails = new ExhibitionTicketSetDetailsModel();
                    ticketdetails.TicketTypes = new List<ExhibitionTicketsTypeDetailsModel>();
                    ticketdetails.EditorId = p.creater;
                    ticketdetails.EnrollEmdTime = exhibition.enrollendtime.ToString("yyyy-MM-dd");
                    ticketdetails.EnrollStartTime = exhibition.enrollstarttime.ToString("yyyy-MM-dd");
                    ticketdetails.ExhibitionId = exhibition.id;
                    ticketdetails.ExhibitionTicketId = p.id;
                    ticketdetails.NameRequire = p.namerequire;
                    ticketdetails.PhoneRequire = p.phonerequire;

                    p.tickettype.ToList().ForEach(w =>
                    {
                        ticketdetails.TicketTypes.Add(new ExhibitionTicketsTypeDetailsModel()
                        {
                            // TicketsSetCode = w.ticketssetcode,
                            ticketsTypeID = w.id,
                            ticketName = w.ticketname,
                            price = w.price,
                            quota = w.quota,
                            privilege = w.privilege
                        });
                    });
                    model.ExhibitionTicketSet.Add(ticketdetails);
                });
                //展会日程
                model.ExhibitionSchedules = new List<ExhibitionScheduleDetailsModel>();
                exhibition.schedule.ToList().ForEach(p =>
                {
                    ExhibitionScheduleDetailsModel scheduledetails = new ExhibitionScheduleDetailsModel();
                    scheduledetails.EditorId = p.creater;
                    scheduledetails.ExhibitionScheduleId = p.id;
                    scheduledetails.ScheduleDesc = p.scheduledesc;
                    scheduledetails.ScheduleName = p.schedulename;
                    scheduledetails.StartTime = p.starttime.ToString("HH:mm:ss");
                    scheduledetails.EndTime = p.endtime.ToString("HH:mm:ss");
                    scheduledetails.STime = p.stime.ToString("yyyy-MM-dd");
                    model.ExhibitionSchedules.Add(scheduledetails);
                });
                result.Flag = ResultFlag.Successful;
                result.Data = model;
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 获取展品分类--所有
        /// </summary>
        /// <returns></returns>
        [Route("api/User/GetProductClass")]
        [HttpGet]
        public IHttpActionResult GetProductClass()
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                List<BaseClassModel> model = new List<BaseClassModel>();

                var scopeList = _businessScopeTypeService.GetAllList();

                if (scopeList.Count > 0)
                {
                    scopeList.ForEach(p =>
                    {
                        model.Add(new BaseClassModel()
                        {
                            Id = p.code,
                            Name = p.goodsTypeName
                        });
                    });

                    result.Flag = ResultFlag.Successful;
                    result.Data = model;
                }
                else
                {
                    result.Flag = ResultFlag.DataNotExist;
                }
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 获取展会所有动态
        /// </summary>
        /// <param name="exhibitionId"></param>
        /// <returns></returns>
        [Route("api/User/Moments/{exhibitionId}/{loginUserId}")]
        [HttpGet]
        public IHttpActionResult Moments(string exhibitionId, string loginUserId)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                List<MomentModel> model = new List<MomentModel>();

                var moments = _momentService.GetListByExhibitionId(exhibitionId);


                if (moments.Count > 0)
                {
                    foreach (var moment in moments)
                    {
                        var userInfo = _userInfoService.GetModelById(moment.creater);

                        MomentModel modelInfo = new MomentModel()
                        {
                            MomentId = moment.id,
                            PubTime = moment.pubtime.ToString(),
                            UserHeadImg = userInfo == null ? CommonHelper.TempHeadImg() : userInfo.HeadImage,
                            NickName = userInfo == null ? "" : userInfo.Nickname,
                            Content = moment.pubcontent,
                            FollowNumber = moment.followmoment.Count,
                            ReplayNumber = moment.momentreply.Count,
                            CreaterId = moment.creater,
                            MomentNoReadCount = 0
                        };

                        modelInfo.Replays = new List<ReplayList>();
                        moment.momentreply.Where(t => t.isdel == 0).ToList().ForEach(p =>
                        {
                            modelInfo.Replays.Add(new ReplayList()
                            {
                                ReplayId = p.id,
                                ReplyTime = p.replytime.ToString(),
                                ReplyContent = p.replycontent,
                                CreaterId = p.creater
                            });
                        });

                        modelInfo.Follows = new List<FollowList>();
                        moment.followmoment.Where(t => t.isdel == 0).ToList().ForEach(p =>
                        {
                            if (p.followusercode == loginUserId)
                            {
                                modelInfo.IsFollowMoment = true;
                            }

                            modelInfo.Follows.Add(new FollowList()
                            {
                                FollowId = p.id,
                                FollowTime = p.followtime.ToString(),
                                CreaterId = p.followusercode
                            });
                        });

                        //获取动态图片
                        modelInfo.ImageUrls = new List<ImageAndVideoUrlResponse>();

                        var atts = _attachmentService.GetListByResourceIdAndType(moment.id, CommonHelper.GetEnumValue<AttType>(AttType.MomentImg));

                        foreach (var att in atts)
                        {
                            modelInfo.ImageUrls.Add(new ImageAndVideoUrlResponse { Id = att.Code, Url = att.URL });
                        }

                        model.Add(modelInfo);
                    }
                }
                result.Flag = ResultFlag.Successful;
                result.Data = model;
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 获取展会未读动态条数
        /// </summary>
        /// <param name="exhibitionId"></param>
        /// <returns></returns>
        [Route("api/User/NoReadMountCount/{exhibitionId}/{loginUserId}")]
        [HttpGet]
        public IHttpActionResult NoReadMountCount(string exhibitionId, string loginUserId)
        {
            int noViewdCount = _momentService.GetNoViewdMomentCount(exhibitionId, loginUserId);
            ClientApiResult result = new ClientApiResult();
            try
            {
                result.Flag = ResultFlag.Successful;
                result.Data = noViewdCount;

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 标记所有未读动态
        /// </summary>
        /// <param name="exhibitionId"></param>
        /// <param name="loginUserId"></param>
        /// <returns></returns>
        [Route("api/User/RemarkAllMoment")]
        [HttpPost]
        public IHttpActionResult RemarkAllMoment(RemarkMomentModel requestModel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                if (requestModel != null)
                {
                    string addUserId = "," + requestModel.LoginUserId;

                    var momentList = _momentService.GetNoViewdMomentList(requestModel.ExhibitionId, requestModel.LoginUserId);

                    momentList.ForEach(p =>
                    {
                        p.viewUserIds += addUserId;
                        _momentService.Update(p);
                    });

                    result.Flag = ResultFlag.Successful;
                    result.Data = true;
                }
                else
                {
                    result.Flag = ResultFlag.DataNotExist;
                    result.Data = "传入参数为空";
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 动态回复
        /// </summary>
        /// <returns></returns>
        [Route("api/User/ReplyMoment")]
        [HttpPost]
        public IHttpActionResult ReplyMoment(ReplayMomentRequestModel requestModel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                MomentReply model = new MomentReply()
                {
                    id = CommonHelper.GetGuid(),
                    replytime = DateTime.Now,
                    replycontent = requestModel.Content,
                    momentcode = requestModel.MomentId,
                    creater = requestModel.CreaterId,
                    creattime = DateTime.Now,
                    modifier = requestModel.CreaterId,
                    modifiytime = DateTime.Now,
                    isdel = 0
                };

                _momentReplyService.Insert(model);

                result.Flag = ResultFlag.Successful;
                result.Data = model.id;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 删除动态
        /// </summary>
        /// <returns></returns>
        [Route("api/User/DeleteMoment")]
        [HttpPost]
        public IHttpActionResult DeleteMoment(DeleteMomentModel requestModel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var moment = _momentService.GetModelById(requestModel.MomentId);

                moment.isdel = 1;
                _momentService.Update(moment);

                result.Flag = ResultFlag.Successful;
                result.Data = true;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 动态点赞-关注
        /// </summary>
        /// <returns></returns>
        [Route("api/User/FollowMoment")]
        [HttpPost]
        public IHttpActionResult FollowMoment(FollowMomentModel requestModel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                string modelId = string.Empty;
                var followMoment = _followMomentService.GetModelByMomentIdAndUserId(requestModel.MomentId, requestModel.FollowUserId);
                if (followMoment == null)
                {
                    var moment = _momentService.GetModelById(requestModel.MomentId);

                    FollowMoment model = new FollowMoment()
                    {
                        id = CommonHelper.GetGuid(),
                        followtime = DateTime.Now,
                        followusercode = requestModel.FollowUserId,
                        exhibitioncode = moment.exhibitioncode,
                        momentcode = requestModel.MomentId,
                        isdel = 0
                    };

                    modelId = model.id;
                    _followMomentService.Insert(model);
                }
                else
                {
                    if (followMoment.isdel == 0)
                    {
                        result.Flag = ResultFlag.Error;
                        result.Messages = "您已关注动态，请勿重复关注";
                        return Ok(result);
                    }
                    else
                    {
                        followMoment.isdel = 0;
                        _followMomentService.Update(followMoment);
                        modelId = followMoment.id;
                    }
                }

                result.Flag = ResultFlag.Successful;
                result.Data = modelId;
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 删除动态回复
        /// </summary>
        /// <returns></returns>
        [Route("api/User/DeleteMomentReplay")]
        [HttpPost]
        public IHttpActionResult DeleteMomentReplay(DeleteMomentReplayModel requestModel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var momentReplay = _momentReplyService.GetModelById(requestModel.ReplayId);

                momentReplay.isdel = 1;
                _momentReplyService.Update(momentReplay);

                result.Flag = ResultFlag.Successful;
                result.Data = true;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 取消动态关注
        /// </summary>
        /// <returns></returns>
        [Route("api/User/DeleteMomentFollow")]
        [HttpPost]
        public IHttpActionResult DeleteMomentFollow(DeleteMomentFollowModel requestModel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var follow = _followMomentService.GetModelById(requestModel.FollowId);

                follow.isdel = 1;
                _followMomentService.Update(follow);

                result.Flag = ResultFlag.Successful;
                result.Data = true;
                return Ok(result);
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 参展展商列表-- 1:未确认 2:已确认 3:已拒绝
        /// </summary>
        /// <param name="exhibitionId"></param>
        /// <returns></returns>
        [Route("api/User/ExhibitionSellers/{exhibitionId}/{status}")]
        [HttpGet]
        public IHttpActionResult ExhibitionSellers(string exhibitionId, int status)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var sellerList = _sellerOrderService.GetAllList().Where(p => p.exhibitionid == exhibitionId && p.orderstatus != (int)SellerOrderStatus.NoPay && p.isdel == 0).ToList();
                if (status != 0)
                {
                    sellerList = sellerList.Where(p => p.orderstatus == status).ToList();
                }

                SellerListModel model = new SellerListModel();

                model.TotalNumber = sellerList.Count;
                model.NoConfirmNumber = sellerList.Where(t => t.orderstatus == (int)SellerOrderStatus.NoConfirm).Count();
                model.ConfirmedNumber = sellerList.Where(t => t.orderstatus == (int)SellerOrderStatus.Normal).Count();
                model.RefusedNumber = sellerList.Where(t => t.orderstatus == (int)SellerOrderStatus.Reject).Count();

                model.Sellers = new List<SearchSellerResponseModel>();

                string nameStr = string.Empty;

                if (sellerList.Count > 0)
                {
                    sellerList.ForEach(p =>
                    {
                        switch (p.orderstatus)
                        {
                            case (int)SellerOrderStatus.NoPay:
                                nameStr = "未支付";
                                break;
                            case (int)SellerOrderStatus.NoConfirm:
                                nameStr = "未确认";
                                break;
                            case (int)SellerOrderStatus.Normal:
                                nameStr = "已确认";
                                break;
                            case (int)SellerOrderStatus.Reject:
                                nameStr = "已拒绝";
                                break;
                        }

                        var searchSeller = new SearchSellerResponseModel()
                        {
                            ExhibitionId = exhibitionId,
                            SellerOrderId = p.id,
                            SellerCode = p.sellerid,
                            Status = nameStr,
                        };

                        var companyUser = _companyUserService.GetModelByUserCode(p.sellerid);
                        if (companyUser != null)
                        {
                            searchSeller.SellerHeadImg = _companyService.GetHeadImg(companyUser.CompanyCode);
                            searchSeller.SellerName = _companyService.GetCompanyName(companyUser.CompanyCode);
                        }

                        searchSeller.Seats = new List<SellerSeatModel>();

                        p.sellerOrderDetails.ToList().ForEach(w =>
                        {
                            searchSeller.Seats.Add(new SellerSeatModel()
                            {
                                SeatNo = w.seatno.seatno,
                                Price = w.seatno.seatset.seatprice
                            });
                        });

                        model.Sellers.Add(searchSeller);
                    });
                }
                result.Flag = ResultFlag.Successful;
                result.Data = model;
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 参展展商详情
        /// </summary>
        /// <param name="exhibitionId"></param>
        /// <returns></returns>
        [Route("api/User/SellersInfo/{sellerId}")]
        [HttpGet]
        public IHttpActionResult SellersInfo(string sellerId)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                SellerDetailsModel model = new SellerDetailsModel();
                var seller = _sellerOrderService.GetModelById(sellerId);


                string nameStr = string.Empty;
                switch (seller.orderstatus)
                {
                    case 1:
                        nameStr = "未确认";
                        break;
                    case 2:
                        nameStr = "已确认";
                        break;
                    case 3:
                        nameStr = "已拒绝";
                        break;
                }

                model.SellerOrderId = seller.id;
                model.SellerCode = seller.sellerid;
                model.Name = seller.sname;
                model.Phone = seller.sphone;
                model.Status = nameStr;
                model.SellerInfo = seller.sellerintro;

                var companyUser = _companyUserService.GetModelByUserCode(seller.sellerid);
                if (companyUser != null)
                {
                    model.SellerHeadImg = _companyService.GetHeadImg(companyUser.CompanyCode);
                    model.SellerName = _companyService.GetCompanyName(companyUser.CompanyCode);
                }

                model.Seats = new List<SellerSeatModel>();

                seller.sellerOrderDetails.ToList().ForEach(w =>
                {
                    model.Seats.Add(new SellerSeatModel()
                    {
                        SeatNo = w.seatno.seatno,
                        Price = w.seatno.seatset.seatprice
                    });
                });
                List<ExhibitionProduct> products = _exhibitionProductService.GetAllList().Where(p => p.sellercode == seller.sellerid && p.exhibitioncode == seller.exhibitionid).ToList();
                model.Products = new List<ExhibitonProductModel>();
                products.ToList().ForEach(p =>
                {                    
                    var product = new ExhibitonProductModel()
                    {
                        ExhibitonProductId = p.id,
                        ExhibitonProductName = p.productName,
                        ProductImage = _goodsService.GetGoodHeadImg(p.yxproductcode, MaterialServiceUrl),
                        OldPrice = p.oprice,
                        Price = p.nprice,
                        PStatus = p.pstatus,
                        ProductCode = p.yxproductcode,
                        Unit = p.unit,
                        Quantity = p.quantity,
                        ProductDetails = p.pdetails,
                        ProductTypeId = p.exhibitionproductclasscode,
                        ProductTypeName = _exhibitionProductClassService.GetModelById(p.exhibitionproductclasscode) != null ? _exhibitionProductClassService.GetModelById(p.exhibitionproductclasscode).classname : "",
                    };
                    model.Products.Add(product);
                });
                result.Flag = ResultFlag.Successful;
                result.Data = model;
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 用户报名列表
        /// </summary>
        /// <param name="exhibitionId"></param>
        /// <returns></returns>
        [Route("api/User/EnrollUsers/{exhibitionId}")]
        [HttpGet]
        public IHttpActionResult EnrollUsers(string exhibitionId)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                EnrollUserListModel model = new EnrollUserListModel();
                var enrollUsers = _enrollUserService.GetAllList().Where(p => p.exhibitioncode == exhibitionId && p.ticketstatus != (int)EnrollOrderStatus.NoPay && p.isdel == 0).ToList();

                model.EnrollUsers = new List<EnrolledlUserModel>();
                if (enrollUsers.Count > 0)
                {
                    decimal totalPrice = 0M;
                    model.TotalNumber = enrollUsers.Count;

                    enrollUsers.ForEach(p =>
                    {
                        string ticketStatus = string.Empty;

                        switch (p.ticketstatus)
                        {
                            case -1:
                                ticketStatus = "未支付";
                                break;
                            case 0:
                                ticketStatus = "未验票";
                                break;
                            case 1:
                                ticketStatus = "已验票";
                                break;
                        }

                        var userInfo = _userInfoService.GetModelById(p.creater);

                        model.EnrollUsers.Add(new EnrolledlUserModel()
                        {
                            NickName = p.nickname,
                            Name = p.sname,
                            Phone = p.sphone,
                            enrollDate = p.enrolltime.ToString(),
                            TicketName = p.ticketsType.ticketname,
                            Price = p.ticketsType.price,
                            Status = ticketStatus,
                            UserHeadImg = userInfo == null ? CommonHelper.TempHeadImg() : userInfo.HeadImage
                        });

                        totalPrice += p.ticketsType.price;
                    });


                    model.TotalPrice = totalPrice;
                    result.Flag = ResultFlag.Successful;
                    result.Data = model;
                }
                else
                {
                    result.Flag = ResultFlag.DataNotExist;
                }
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 获取展品详情--展品中间表
        /// </summary>
        /// <param name="exhibitionProductId"></param>
        /// <returns></returns>
        [Route("api/User/GetExhibitionProductDetails/{exhibitionProductId}")]
        [HttpGet]
        public IHttpActionResult GetExhibitionProductDetails(string exhibitionProductId)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                ExhibitonProductDetailModel model = new ExhibitonProductDetailModel();
                var product = _exhibitionProductService.GetModelById(exhibitionProductId);
                model.OldPrice = product.oprice;
                model.Price = product.nprice;
                model.ProductId = product.id;
                model.ProductCode = product.yxproductcode;
                model.ProductName = product.productName;
                model.ProductTypeId = product.exhibitionproductclasscode;
                model.Unit = product.unit;
                model.Quantity = product.quantity;

                //封面图
                model.ProductImage = _goodsService.GetGoodHeadImg(product.yxproductcode, MaterialServiceUrl);

                //多图
                model.PImages = new List<ImageAndVideoUrl>();
                var goodsImages = _goodsService.GetGoodsImgs(product.yxproductcode, MaterialServiceUrl);
                goodsImages.ForEach(w =>
                {
                    model.PImages.Add(new ImageAndVideoUrl() { url = w.ToString() });
                }
                    );

                //获取展商信息
                var sellerOrder = _sellerOrderService.GetModelBySellerId(product.exhibitioncode, product.sellercode);
                if (sellerOrder != null)
                {
                    var companyUser = _companyUserService.GetModelByUserCode(sellerOrder.sellerid);
                    model.SellerName = companyUser != null ? _companyService.GetCompanyName(companyUser.CompanyCode) : "";
                    model.SellerImg = companyUser != null ? _companyService.GetHeadImg(companyUser.CompanyCode) : "";
                    model.Seats = new List<SellerSeatModel>();
                    sellerOrder.sellerOrderDetails.ToList().ForEach(w =>
                    {
                        model.Seats.Add(new SellerSeatModel()
                        {
                            SeatNo = w.seatno.seatno,
                            Price = w.seatno.seatset.seatprice
                        });
                    });
                }

                if (string.IsNullOrWhiteSpace(model.SellerName))
                {
                    model.SellerName = string.Empty;
                    model.Seats = new List<SellerSeatModel>();
                }

                result.Flag = ResultFlag.Successful;
                result.Data = model;
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        /// <summary>
        /// 动态发布
        /// </summary>
        /// <returns></returns>
        [Route("api/User/CreateMoment")]
        [HttpPost]
        public IHttpActionResult CreateMoment(CreateMomentModel requestModel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                Moment moment = new Moment()
                {
                    id = CommonHelper.GetGuid(),
                    pubtime = DateTime.Now,
                    pubcontent = requestModel.Content,
                    types = requestModel.MomentType,
                    publishercode = requestModel.CreaterId,
                    exhibitioncode = requestModel.ExhibitionId,
                    creater = requestModel.CreaterId,
                    creattime = DateTime.Now,
                    modifier = requestModel.CreaterId,
                    modifiytime = DateTime.Now,
                    isdel = 0,
                    viewUserIds = requestModel.CreaterId
                };

                // 添加动态图片
                if (HasAttachmentType(AttType.MomentImg) && requestModel.ImageUrls != null)
                {
                    foreach (var imgItem in requestModel.ImageUrls)
                    {
                        Attachment attachment = new Attachment();

                        attachment.Code = CommonHelper.GetGuid();
                        attachment.ResourceID = moment.id;
                        attachment.CnName = "动态图片";
                        attachment.URL = imgItem.url;
                        attachment.Creator = requestModel.CreaterId;
                        attachment.VersionStartTime = DateTime.Now;
                        attachment.VersionEndTime = DateTime.MaxValue;
                        attachment.ValidStatus = true;
                        attachment.AttachmentTypeCode = CommonHelper.GetEnumValue<AttType>(AttType.MomentImg);

                        _attachmentService.InsertAttachment(attachment);
                    }
                }


                _momentService.Insert(moment);

                result.Flag = ResultFlag.Successful;
                result.Data = moment.id;
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
                if (ex.InnerException != null)
                {
                    result.Messages = ex.InnerException.ToString();
                }
            }
            return Ok(result);
        }

        /// <summary>
        /// 验证码验证
        /// </summary>
        /// <returns></returns>
        [Route("api/User/CheckVerCode/{mobile}/{sessionId}/{markcode}")]
        [HttpGet]
        public IHttpActionResult CheckVerCode(string mobile, string sessionId, string markcode)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                string uri = string.Format(VerCodeCheckAddress, mobile, sessionId, markcode);
                string checkResponse = HttpClientDoGet(uri, "application/xml");
                if (checkResponse.Contains("true"))
                {
                    result.Data = true;
                }
                else
                {
                    result.Data = false;
                }

                result.Flag = ResultFlag.Successful;
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
            }
            return Ok(result);
        }

        #region 私有方法

        //根据附件类型获取表结构是否存在该类型
        private bool HasAttachmentType(AttType type)
        {
            bool result = false;

            string typeValue = CommonHelper.GetEnumValue<AttType>(type);

            if (_attachmentTypeService.GetModelById(typeValue) != null)
            {
                result = true;
            }

            return result;
        }

        #endregion;
    }
}