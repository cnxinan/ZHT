/*
参展商 控制器 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ZHT.Service;
using ZHT.Api.Models;
using ZHT.Data.Models;
using ZHT.Framework;
using System.Configuration;

namespace ZHT.Api.Controllers
{
    [Authorize]
    public class SellerController : BaseApiController
    {

        private readonly IExhibitionService _exhibitionService;
        private readonly ISellerOrderService _sellerOrderService;
        private readonly IBusinessScopeService _businessScopeService;
        private readonly IBusinessScopeTypeService _businessScopeTypeService;
        private readonly IGoodsService _goodsService;
        private readonly IGoods_BusinessScopeTypeService _good_businessScopeTypeService;
        private readonly IExhibitionProductService _exhibitionProductService;
        private readonly IExhibitionProductClassService _exhibitionProductClassService;
        private readonly IBaseTypesService _baseTypesService;
        private readonly IOrderService _orderService;
        private readonly ISellerOrderDetailsService _sellerOrderDetailsService;
        private readonly ISeatSetService _seatSetService;
        private readonly IUserInfoService _userInfoService;
        private readonly ICompanyUserService _companyUserService;
        private readonly IAttachmentService _attachmentService;
        private readonly IAttachmentTypeService _attachmentTypeService;
        private readonly ICompanyService _companyService;
        private readonly IGoodsUnitService _goodsUnitService;

        public SellerController(IExhibitionService exhibitionService, ISellerOrderService sellerOrderService, IBusinessScopeService businessScopeService, IBusinessScopeTypeService businessScopeTypeService, IGoodsService goodsService, IGoods_BusinessScopeTypeService good_businessScopeTypeService, IExhibitionProductService exhibitionProductService, IBaseTypesService baseTypesService, IOrderService orderService, ISeatSetService seatSetService, ISellerOrderDetailsService sellerOrderDetailsService, IExhibitionProductClassService exhibitionProductClassService, IUserInfoService userInfoService, ICompanyUserService companyUserService, IAttachmentService attachmentService, IAttachmentTypeService attachmentTypeService, ICompanyService companyService, IGoodsUnitService goodsUnitService)
        {
            _exhibitionService = exhibitionService;
            _sellerOrderService = sellerOrderService;
            _businessScopeService = businessScopeService;
            _businessScopeTypeService = businessScopeTypeService;
            _goodsService = goodsService;
            _good_businessScopeTypeService = good_businessScopeTypeService;
            _exhibitionProductService = exhibitionProductService;
            _baseTypesService = baseTypesService;
            _orderService = orderService;
            _seatSetService = seatSetService;
            _sellerOrderDetailsService = sellerOrderDetailsService;
            _exhibitionProductClassService = exhibitionProductClassService;
            _userInfoService = userInfoService;
            _companyUserService = companyUserService;
            _attachmentService = attachmentService;
            _attachmentTypeService = attachmentTypeService;
            _companyService = companyService;
            _goodsUnitService = goodsUnitService;
        }

        /// <summary>
        /// 获取展位设置--过滤已占用展位
        /// </summary>
        /// <param name="exhibitionApplyId"></param>
        /// <returns></returns>
        [Route("api/Seller/GetExhibitionApplyDetails/{exhibitionId}")]
        [HttpGet]
        public IHttpActionResult GetExhibitionApplyDetails(string exhibitionId)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                ExhibitionApplyDetailsModel model = new ExhibitionApplyDetailsModel();
                var exhibition = _exhibitionService.GetModelById(exhibitionId);
                if (exhibition != null)
                {
                    model.exhibitionId = exhibition.id;
                    model.recruitEndTime = exhibition.recruitendtime.ToString();
                    model.seatSetTypes = new List<SeatSetTypes>();

                    // 获取展位分布图
                    var dMapType = _attachmentTypeService.GetModelById(((int)AttType.DistributionMap).ToString());
                    if (dMapType != null)
                    {
                        var dMapAtt = _attachmentService.GetListByResourceIdAndType(model.exhibitionId, dMapType.Code);
                        if (dMapAtt.Count > 0)
                        {
                            model.distributionMap = dMapAtt.FirstOrDefault().URL;
                        }
                    }

                    foreach (var p in exhibition.seatset)
                    {
                        var baseType = _baseTypesService.GetModelById(p.basetypescode);
                        SeatSetTypes type = new SeatSetTypes();
                        type.seatSetTypeId = p.id;
                        type.typeName = baseType.typevalue;
                        type.seatPrice = p.seatprice;
                        type.seatScale = p.seatscale;
                        type.baseTypeCode = p.basetypescode;
                        type.seatNo = new List<SeatSetNoModel>();
                        p.seatno.ToList().ForEach(s =>
                        {
                            var seatNoOrder = _sellerOrderDetailsService.GetModelBySeatNoCode(s.id);
                            if (seatNoOrder == null || seatNoOrder.isdel == 1)
                            {
                                type.seatNo.Add(new SeatSetNoModel()
                                {
                                    noId = s.id,
                                    seatno = s.seatno,
                                    //seatSetId = s.seatsetcode
                                });
                            }
                        });
                        model.seatSetTypes.Add(type);
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
        /// 创建参展商订单
        /// </summary>
        /// <returns></returns>
        [Route("api/Seller/CreateSellerOrder")]
        [HttpPost]
        public IHttpActionResult CreateSellerOrder(CreateSellerOrderModel requestModel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                requestModel.Creater = CurrentUserId;

                var exhibition = _exhibitionService.GetModelById(requestModel.ExhibitionId);

                if (exhibition.endtime < DateTime.Now)
                {
                    result.Flag = ResultFlag.Error;
                    result.Messages = "展会已结束";
                    return Ok(result);
                }
                if (exhibition.recruitendtime < DateTime.Now)
                {
                    result.Flag = ResultFlag.Error;
                    result.Messages = "展会招募时间已过";
                    return Ok(result);
                }
                if (exhibition.recruitstatus == 0)
                {
                    result.Flag = ResultFlag.Error;
                    result.Messages = "展会截止招募";
                    return Ok(result);
                }

                string orderNo = GetOrderNo;
                if (string.IsNullOrEmpty(orderNo))
                {
                    result.Flag = ResultFlag.Error;
                    result.Data = null;
                    result.Messages = "从远鑫获取订单号失败!";
                    return Ok(result);
                }

                string code = CommonHelper.GetGuid();
                //向远洋表插入数据
                YXOrderRequest yxOrderRequest = new YXOrderRequest()
                {
                    Code = code,
                    OrderNo = orderNo,
                    Total = requestModel.Amount.ToString(),
                    Creator = requestModel.Creater
                };

                if (!CreateYxOrder(yxOrderRequest))
                {
                    result.Flag = ResultFlag.Error;
                    result.Data = null;
                    result.Messages = "插入远鑫订单表失败!";
                    return Ok(result);
                }

                SellerOrder model = new SellerOrder()
                {
                    id = code,
                    enrolltime = DateTime.Now,
                    seatsetcode = requestModel.SeatSetTypeId,
                    sname = requestModel.SName,
                    sphone = requestModel.SellerPhone,
                    totalprice = requestModel.Amount,
                    paytype = requestModel.PayType,
                    payaccount = requestModel.PayAccount,
                    sellerid = requestModel.SellerID,
                    orderno = orderNo,
                    exhibitionid = requestModel.ExhibitionId,
                    sellerintro = requestModel.Sellerintro,
                    orderstatus = (int)SellerOrderStatus.NoPay,
                    creattime = DateTime.Now,
                    creater = requestModel.Creater,
                    modifiytime = DateTime.Now,
                    isdel = 0
                };


                foreach (var p in requestModel.Seats)
                {
                    var details = new SellerOrderDetails()
                    {
                        id = CommonHelper.GetGuid(),
                        sellerordercode = model.id,
                        seatnocode = p.SeatId,
                        creater = requestModel.Creater,
                        creattime = DateTime.Now,
                        modifier = requestModel.Creater,
                        modifiytime = DateTime.Now,
                        isdel = 0
                    };
                    model.sellerOrderDetails.Add(details);
                }
                _sellerOrderService.Insert(model);

                result.Flag = ResultFlag.Successful;
                result.Data = model.id;
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
        /// 更新展商介绍
        /// </summary>
        /// <param name="requestModel"></param>
        /// <returns></returns>
        [Route("api/Seller/EditSellerIntro")]
        [HttpPost]
        public IHttpActionResult EditSellerIntro(EditSellerIntroModel requestModel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                //修改展商介绍
                var model = _sellerOrderService.GetModelBySellerId(requestModel.ExhibitionId, CurrentUserId);
                if (model != null)
                {
                    model.sellerintro = requestModel.SellerIntro;
                    model.modifier = CurrentUserId;
                    model.modifiytime = DateTime.Now;
                    _sellerOrderService.Update(model);
                    result.Flag = ResultFlag.Successful;
                    result.Data = true;
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
        /// 获取展品分类--参展商的所有分类
        /// </summary>
        /// <returns></returns>
        [Route("api/Seller/GetProductClass")]
        [HttpGet]
        public IHttpActionResult GetProductClass()
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                List<BaseClassModel> model = new List<BaseClassModel>();

                var companyUser = _companyUserService.GetModelByUserCode(CurrentUserId);
                if (companyUser != null)
                {

                    var goodsTypes = _goodsService.GetGoodsByCreator(companyUser.CompanyCode).Select(t => t.goodsTypeCode).Distinct().ToList();

                    if (goodsTypes.Count > 0)
                    {
                        goodsTypes.ForEach(p =>
                        {
                            var goodType = _businessScopeTypeService.GetModelById(p.ToString());
                            if (goodType != null)
                            {
                                model.Add(new BaseClassModel()
                                {
                                    Id = goodType.code,
                                    Name = goodType.goodsTypeName
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
                else
                {
                    result.Flag = ResultFlag.Error;
                    result.Messages = "不存在该商家!";
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
        [Route("api/Seller/GetExhibitionProType/{exhibitionId}")]
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
        /// 根据展品分类获取现有展品
        /// </summary>
        [Route("api/Seller/GetProductType/{sellerId}/{productTypeId}")]
        [HttpGet]
        public IHttpActionResult GetProductByType(string sellerId, string productTypeId)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                sellerId = CurrentUserId;

                List<GoodsistModel> model = new List<GoodsistModel>();

                var companyUser = _companyUserService.GetModelByUserCode(CurrentUserId);

                var goods = _goodsService.GetAllList().Where(t => t.goodsTypeCode == productTypeId && t.sellerCode == companyUser.CompanyCode).ToList();

                if (goods.Count > 0)
                {
                    goods.ForEach(p =>
                    {
                        GoodsistModel product = new GoodsistModel()
                        {
                            GoodsCode = p.code,
                            GoodsName = p.goodsName,
                            OldPrice = p.oldPrice,
                            Price = p.Price,
                            GoodsNumber = p.stockCount.HasValue ? p.stockCount.Value : 0,
                            GoodsTypeCode = p.goodsTypeCode,
                            GoodsTypeName = p.businessScopeType.goodsTypeName,
                            UnitCode = p.goodsUnitCode,
                            UnitName = p.goodsUnit.goodsUnitName,
                            HeadImg = _goodsService.GetGoodHeadImg(p.code, MaterialServiceUrl),
                            GoodsIntro = p.intruduction,
                            GoodsImgs = new List<ImageAndVideoUrl>()
                        };
                        var goodsImages = _goodsService.GetGoodsImgs(p.code, MaterialServiceUrl);
                        goodsImages.ForEach(w =>
                                {
                                    product.GoodsImgs.Add(new ImageAndVideoUrl() { url = w.ToString() });
                                }
                            );

                        model.Add(product);
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
        /// 新增展品-插入到展品中间表
        /// </summary>
        /// <returns></returns>
        [Route("api/Seller/CreateProduct")]
        [HttpPost]
        public IHttpActionResult CreateProduct(CreateProductModel requestModel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var yxProduct = _goodsService.GetModelById(requestModel.ProductId);
                if (yxProduct != null)
                {
                    ExhibitionProduct product = new ExhibitionProduct()
                    {
                        id = CommonHelper.GetGuid(),
                        sellercode = CurrentUserId,
                        exhibitioncode = requestModel.ExhibitionId,
                        productName = yxProduct.goodsName,
                        exhibitionproductclasscode = requestModel.ProductTypeId,
                        yxproductcode = requestModel.ProductId,
                        pdetails = yxProduct.intruduction,
                        unit = yxProduct.goodsUnitCode,
                        oprice = yxProduct.oldPrice.HasValue ? decimal.Parse(yxProduct.oldPrice.Value.ToString()) : 0M,
                        nprice = requestModel.Price,
                        quantity = requestModel.Quantity,
                        creattime = DateTime.Now,
                        modifiytime = DateTime.Now,
                        creater = CurrentUserId,
                        pstatus = 1
                    };
                    _exhibitionProductService.Insert(product);
                    result.Flag = ResultFlag.Successful;
                    result.Data = product.id;
                }
                else
                {
                    result.Flag = ResultFlag.DataNotExist;
                    result.Messages = "远鑫产品不存在！";
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
        /// 获取参展商品列表-0 下架 1 上架
        /// </summary>
        /// <returns></returns>
        [Route("api/Seller/GetExhibitionProduct/{pstatus}/{exhibitionId}/{sellerId}")]
        [HttpGet]
        public IHttpActionResult GetExhibitionProduct(int pstatus, string exhibitionId, string sellerId)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                sellerId = CurrentUserId;

                List<ExhibitonProductModel> model = new List<ExhibitonProductModel>();
                var exhibitionProducts = _exhibitionProductService.GetAllList().Where(t => t.exhibitioncode == exhibitionId && t.sellercode == sellerId && t.pstatus == pstatus && t.isdel == 0).ToList();
                exhibitionProducts.ForEach(p =>
                {  
                    ExhibitonProductModel product = new ExhibitonProductModel();
                    product.ExhibitonProductId = p.id;
                    product.ExhibitonProductName = p.productName;
                    product.OldPrice = p.oprice;
                    product.Price = p.nprice;
                    product.PStatus = p.pstatus;
                    product.ProductImage = _goodsService.GetGoodHeadImg(p.yxproductcode, MaterialServiceUrl);
                    product.ProductCode = p.yxproductcode;
                    product.Unit = _goodsUnitService.GetModelById(p.unit).goodsUnitName;
                    product.Quantity = p.quantity;
                    product.ProductTypeId = p.exhibitionproductclasscode;
                    if (!string.IsNullOrEmpty(p.exhibitionproductclasscode))
                    {
                        var eClass = _exhibitionProductClassService.GetModelById(p.exhibitionproductclasscode);

                        product.ProductTypeName = eClass != null ? eClass.classname : "";
                    }
                    product.ProductDetails = p.pdetails;

                    product.PImages = new List<ImageAndVideoUrl>();
                    var goodsImages = _goodsService.GetGoodsImgs(p.yxproductcode, MaterialServiceUrl);
                    goodsImages.ForEach(w =>
                    {
                        product.PImages.Add(new ImageAndVideoUrl() { url = w.ToString() });
                    }
                        );

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
        /// 获取展品详情--展品中间表
        /// </summary>
        /// <param name="exhibitionProductId"></param>
        /// <returns></returns>
        [Route("api/Seller/GetExhibitionProductDetails/{exhibitionProductId}")]
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
        /// 编辑展品--展品中间表
        /// </summary>
        /// <returns></returns>
        [Route("api/Seller/EditExhibitionProduct")]
        [HttpPost]
        public IHttpActionResult EditExhibitionProduct(EditProductModel requestModel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var exhibitionProduct = _exhibitionProductService.GetModelById(requestModel.ProductId);
                if (exhibitionProduct != null)
                {
                    exhibitionProduct.exhibitionproductclasscode = requestModel.ProductTypeId;
                    exhibitionProduct.nprice = requestModel.Price;
                    exhibitionProduct.quantity = requestModel.Quantity;
                    exhibitionProduct.modifier = CurrentUserId;
                    exhibitionProduct.modifiytime = DateTime.Now;

                    _exhibitionProductService.Update(exhibitionProduct);
                    result.Flag = ResultFlag.Successful;
                    result.Data = requestModel;
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
        /// 删除展品--展品中间表
        /// </summary>
        /// <returns></returns>
        [Route("api/Seller/DeleteExhibitionProduct")]
        [HttpPost]
        public IHttpActionResult DeleteExhibitionProduct(DeleteProduct dmodel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var model = _exhibitionProductService.GetModelById(dmodel.exhibitionProductId);
                if (model != null)
                {
                    model.isdel = 1;
                    model.modifier = CurrentUserId;
                    model.modifiytime = DateTime.Now;
                    _exhibitionProductService.Update(model);

                    result.Flag = ResultFlag.Successful;
                    result.Data = true;
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
        /// 上/下 架展品--展品中间表
        /// </summary>
        /// <returns></returns>
        [Route("api/Seller/ChangePStatusOfExhibitionProduct")]
        [HttpPost]
        public IHttpActionResult ChangePStatusOfExhibitionProduct(DeleteProduct dmodel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                //修改展品的上/下架状态
                var model = _exhibitionProductService.GetModelById(dmodel.exhibitionProductId);
                if (model != null)
                {
                    model.pstatus = (model.pstatus + 1) % 2;
                    model.modifier = CurrentUserId;
                    model.modifiytime = DateTime.Now;
                    _exhibitionProductService.Update(model);

                    result.Flag = ResultFlag.Successful;
                    result.Data = true;
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
        /// 订单统计
        /// </summary>
        /// <returns></returns>
        [Route("api/Seller/OrderTotalInfo/{exhibitionId}/{sellerId}")]
        [HttpGet]
        public IHttpActionResult OrderTotalInfo(string exhibitionId, string sellerId)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                sellerId = CurrentUserId;

                //订单统计
                var exhibition = _exhibitionService.GetModelById(exhibitionId);
                var seller = _sellerOrderService.GetModelBySellerId(exhibitionId, sellerId);
                var orders = _orderService.GetAllList().Where(t => t.sellerNumber == exhibitionId);

                SellerOrderTotalInfo model = new SellerOrderTotalInfo();

                int count = 0;
                decimal income = 0M;

                if (seller != null || true)
                {
                    model.Orders = new List<SellerOrderListModel>();

                    foreach (var p in orders)
                    {
                        var orderDetails = p.orderDetails.Where(w => w.goods.creator == seller.sellerid).ToList();
                        var userInfo = _userInfoService.GetModelById(p.businessUserCode);

                        if (orderDetails.Count > 0)
                        {
                            count++;
                            foreach (var q in orderDetails)
                            {
                                SellerOrderListModel item = new SellerOrderListModel();
                                item.OrderId = p.code;
                                item.UserName = p.customerName;
                                item.Status = p.status == (int)ProductOrderStatus.NoPickUp ? "待提货" : "已提货";
                                item.TotalPay = q.charge.HasValue ? q.charge.Value : 0;
                                item.CreateTime = p.createTime.ToString();
                                item.ProductCount = q.goodsCount.HasValue ? q.goodsCount.Value : 0;
                                item.ProductName = q.goodsName;
                                model.Orders.Add(item);
                                income += item.TotalPay;
                                item.UserHeadImg = userInfo == null ? CommonHelper.TempHeadImg() : userInfo.HeadImage;
                            }
                        }
                    }

                    model.OrderCount = count;
                    model.TotalInCome = income;
                    model.SalesCommissions = model.TotalInCome * exhibition.saleproportion;

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
        /// 所有展会列表-- status 0-未结束 1-已结束  orderType:1 热门 2 最新 3 距离最近
        /// </summary>
        /// <returns></returns>
        [Route("api/Seller/ExhibitionList/{Longitude}/{Latitude}/{Status}/{OrderType}")]
        [HttpGet]
        public IHttpActionResult ExhibitionList(int Status, int OrderType, string Longitude, string Latitude)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var exhibitions = new List<Exhibition>();
                if (Status == 0)
                {
                    if (OrderType == 1)//热门
                    {
                        exhibitions = _exhibitionService.GetAllList().Where(t => DateTime.Now < t.endtime).OrderByDescending(t => t.enrolluser.Count()).ToList();
                    }
                    else if (OrderType == 2)//最新
                    {
                        exhibitions = _exhibitionService.GetAllList().Where(t => DateTime.Now < t.endtime).OrderByDescending(t => t.starttime).ToList();
                    }
                    else if (OrderType == 3)//距离最近
                    {
                        exhibitions = _exhibitionService.GetAllList().Where(t => DateTime.Now < t.endtime).OrderByDescending(t => GetDistanseHelper.getDistance(double.Parse(Longitude), double.Parse(Latitude), double.Parse(t.longitude.ToString()), double.Parse(t.latitude.ToString()))).ToList();
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
                        exhibitions = _exhibitionService.GetAllList().Where(t => DateTime.Now > t.endtime).OrderByDescending(t => t.enrolluser.Count()).ToList();
                    }
                    else if (OrderType == 2)
                    {
                        exhibitions = _exhibitionService.GetAllList().Where(t => DateTime.Now > t.endtime).OrderByDescending(t => t.starttime).ToList();
                    }
                    else if (OrderType == 3)
                    {
                        exhibitions = _exhibitionService.GetAllList().Where(t => DateTime.Now > t.endtime).OrderByDescending(t => GetDistanseHelper.getDistance(double.Parse(Longitude), double.Parse(Latitude), double.Parse(t.longitude.ToString()), double.Parse(t.latitude.ToString()))).ToList();
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
                            model.Add(new SearchExhibitionResponseModel()
                            {
                                ExhibitionId = p.id,
                                ExhibitionName = p.exhibitionname,
                                HeadImg = headImg,
                                CreationDate = p.creattime.ToString(),
                                Status = GetExhibitionStatusStr(p),
                                SellerNumber = p.sellerorder.Count,
                                UserNumber = p.enrolluser.Count
                            });
                        }
                        else if (p.endtime > DateTime.Now)
                        {
                            model.Add(new SearchExhibitionResponseModel()
                            {
                                ExhibitionId = p.id,
                                ExhibitionName = p.exhibitionname,
                                HeadImg = headImg,
                                CreationDate = p.creattime.ToString(),
                                Status = GetExhibitionStatusStr(p),
                                SellerNumber = p.sellerorder.Count,
                                UserNumber = p.enrolluser.Count
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
        /// 取货--根据订单号
        /// </summary>
        /// <returns></returns>
        [Route("api/Seller/PickUpGoods/{orderNo}")]
        [HttpPost]
        public IHttpActionResult PickUpGoods(string orderNo)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var order = _orderService.GetModelByOrderNo(orderNo);

                if (order.status == (int)ProductOrderStatus.PickUp)
                {
                    result.Flag = ResultFlag.Error;
                    result.Messages = "该订单已提货!";
                }
                else if (order.status == (int)ProductOrderStatus.NoPay)
                {
                    result.Flag = ResultFlag.Error;
                    result.Messages = "订单未支付!";
                }
                else
                {
                    order.status = (int)ProductOrderStatus.PickUp;
                    order.modifier = CurrentUserId;
                    order.modifyTime = DateTime.Now;
                    _orderService.Update(order);
                    result.Flag = ResultFlag.Successful;
                    result.Data = true;
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
    }
}
