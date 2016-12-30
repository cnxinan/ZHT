/*
展会 控制器 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ZHT.Data.Models;
using ZHT.Service;
using ZHT.Api.Models;
using ZHT.Framework;
using System.Net.Http;
using System.Net;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using System.Configuration;

namespace ZHT.Api.Controllers
{
    [Authorize]
    public class ExhibitionController : BaseApiController
    {
        private readonly IExhibitionTagService _exhibitionTagService;
        private readonly IBaseTypesService _baseTypesService;
        private readonly IExhibitionService _exhibitionService;
        private readonly ISeatSetService _seatSetService;
        private readonly ITicketsTypeService _ticketsTypeService;
        private readonly ITicketsSetService _ticketsSetService;
        private readonly IScheduleService _scheduleService;
        private readonly IBusinessScopeService _businessScopeService;
        private readonly IBusinessScopeTypeService _businessScopeTypeService;
        private readonly ISellerOrderService _sellerOrderService;
        private readonly IEnrollUserService _enrollUserService;
        private readonly IOrderService _orderService;
        private readonly IExhibitionProductClassService _exhibitionProductClassService;
        private readonly IExhibitionProductService _exhibitionProductService;
        private readonly ICompanyUserService _companyUserService;
        private readonly ICompanyService _companyService;
        private readonly IAttachmentService _attachmentService;
        private readonly IAttachmentTypeService _attachmentTypeService;
        private readonly IUserInfoService _userInfoService;
        private readonly IGoodsService _goodsService;
        private readonly ISeatNoService _seatNoService;

        private readonly string verCodeCheckAddress = "http://www.yuanxin2015.com/MobileBusiness/MobileBusiness.Common/Services/PostSMSForDHST.asmx/CheckVerification?mobile={0}&sessionId={1}&markCode={2}";

        //private readonly string mapApiAddress = "http://api.map.baidu.com/geocoder/v2/?callback=renderReverse&location={0},{1}&output=json&pois=1&ak=3AY7eMqHrZ1lkmG3bqu35q30zExqumVa";

        public ExhibitionController(IExhibitionTagService exhibitionTagService, IBaseTypesService baseTypesService, IExhibitionService exhibitionService, ISeatSetService seatSetService, ITicketsTypeService ticketsTypeService, ITicketsSetService ticketsSetService, IScheduleService scheduleService, IBusinessScopeService businessScopeService, IBusinessScopeTypeService businessScopeTypeService, ISellerOrderService sellerOrderService, IEnrollUserService enrollUserService, IOrderService orderService, IExhibitionProductClassService exhibitionProductClassService, IExhibitionProductService exhibitionProductService, ICompanyUserService companyUserService, ICompanyService companyService, IAttachmentService attachmentService, IAttachmentTypeService attachmentTypeService, IUserInfoService userInfoService, IGoodsService goodsService)
        {
            _exhibitionTagService = exhibitionTagService;
            _baseTypesService = baseTypesService;
            _exhibitionService = exhibitionService;
            _seatSetService = seatSetService;
            _ticketsTypeService = ticketsTypeService;
            _ticketsSetService = ticketsSetService;
            _scheduleService = scheduleService;
            _businessScopeService = businessScopeService;
            _businessScopeTypeService = businessScopeTypeService;
            _sellerOrderService = sellerOrderService;
            _enrollUserService = enrollUserService;
            _orderService = orderService;
            _exhibitionProductClassService = exhibitionProductClassService;
            _exhibitionProductService = exhibitionProductService;
            _companyUserService = companyUserService;
            _companyService = companyService;
            _attachmentService = attachmentService;
            _attachmentTypeService = attachmentTypeService;
            _userInfoService = userInfoService;
            _goodsService = goodsService;
        }

        /// <summary>
        /// 获取基础类型：1-展会类型 2-展位类型
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/GetBaseTypes/{typeId}")]
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
        /// 获取展品分类--所有
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/GetProductClass")]
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
        /// 新增展会-返回展会ID
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/AddExhibition")]
        [HttpPost]
        public IHttpActionResult AddExhibition(ExhibitionRequestModel model)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                model.BusinessID = CurrentUserId;
                model.BusinessName = CurrentUserName;
                model.Creater = CurrentUserId;

                Exhibition exhibition = new Exhibition();
                exhibition.id = CommonHelper.GetGuid();
                exhibition.exhibitionname = model.Name;
                exhibition.basetypescode = model.ClassId;
                exhibition.starttime = DateTime.Parse(model.StartDate);
                exhibition.endtime = DateTime.Parse(model.EndDate);
                exhibition.address1 = model.Address1;
                exhibition.address2 = model.Address2;
                exhibition.longitude = model.Longitude;
                exhibition.latitude = model.Latitude;
                exhibition.detailes = model.Detailes;
                exhibition.businessid = model.BusinessID;
                exhibition.businessname = model.BusinessName;
                exhibition.recruitstatus = 1;
                exhibition.enrollstatus = 1;
                exhibition.creater = model.Creater;
                exhibition.creattime = DateTime.Now;
                exhibition.modifiytime = DateTime.Now;
                exhibition.publishedtime = DateTime.Now;
                exhibition.recruitendtime = DateTime.Now;
                exhibition.enrollstarttime = DateTime.Now;
                exhibition.enrollendtime = DateTime.Now;
                model.ExhibitionProClass.ForEach(p =>
                {
                    ExhibitionProductClass productClass = new ExhibitionProductClass();
                    productClass.id = CommonHelper.GetGuid();
                    productClass.classname = p.ClassName;//展品分类名称
                    productClass.creater = model.Creater;
                    productClass.creattime = DateTime.Now;
                    productClass.modifiytime = DateTime.Now;
                    productClass.exhibitioncode = exhibition.id;//展会id
                    if (productClass != null)
                    {
                        exhibition.exhibitionproductclass.Add(productClass);
                    }
                });
                model.ExhibitionTagCode.ForEach(p =>
                {
                    ExhibitionTag tag = new ExhibitionTag();
                    tag.id = CommonHelper.GetGuid();
                    tag.tagname = p.TagName;//标签名称
                    tag.creater = model.Creater;
                    tag.creattime = DateTime.Now;
                    tag.modifiytime = DateTime.Now;
                    tag.exhibitioncode = exhibition.id;//展会id
                    if (tag != null)
                    {
                        exhibition.exhibitiontag.Add(tag);
                    }
                });

                // 保存封面图片
                if (HasAttachmentType(AttType.ExhibitionLogo))
                {
                    Attachment attachment = new Attachment();

                    attachment.Code = CommonHelper.GetGuid();
                    attachment.ResourceID = exhibition.id;
                    attachment.CnName = model.Name + " 封面图片";
                    attachment.URL = model.HeadImg;
                    attachment.Creator = model.Creater;
                    attachment.VersionStartTime = DateTime.Now;
                    attachment.VersionEndTime = DateTime.MaxValue;
                    attachment.ValidStatus = true;
                    attachment.AttachmentTypeCode = CommonHelper.GetEnumValue<AttType>(AttType.ExhibitionLogo);

                    _attachmentService.InsertAttachment(attachment);
                }

                // 保存详情图片
                if (HasAttachmentType(AttType.ExhibitionIntroImg) && model.ImageUrls != null)
                {
                    model.ImageUrls.ForEach(p =>
                    {
                        Attachment attachment = new Attachment();

                        attachment.Code = CommonHelper.GetGuid();
                        attachment.ResourceID = exhibition.id;
                        attachment.CnName = model.Name + " 详情图片";
                        attachment.URL = p.url;
                        attachment.Creator = model.Creater;
                        attachment.VersionStartTime = DateTime.Now;
                        attachment.VersionEndTime = DateTime.MaxValue; ;
                        attachment.ValidStatus = true;
                        attachment.AttachmentTypeCode = CommonHelper.GetEnumValue<AttType>(AttType.ExhibitionIntroImg);

                        _attachmentService.InsertAttachment(attachment);
                    });
                }

                // 保存详情视频
                if (HasAttachmentType(AttType.ExhibitionIntroVideo) && model.VideoUrls != null)
                {
                    model.VideoUrls.ForEach(p =>
                    {
                        Attachment attachment = new Attachment();

                        attachment.Code = CommonHelper.GetGuid();
                        attachment.ResourceID = exhibition.id;
                        attachment.CnName = model.Name + " 视频";
                        attachment.URL = p.url;
                        attachment.Creator = model.Creater;
                        attachment.VersionStartTime = DateTime.Now;
                        attachment.VersionEndTime = DateTime.MaxValue;
                        attachment.ValidStatus = true;
                        attachment.AttachmentTypeCode = CommonHelper.GetEnumValue<AttType>(AttType.ExhibitionIntroVideo);

                        _attachmentService.InsertAttachment(attachment);
                    });
                }

                //获取地图信息
                exhibition.province = model.Province;
                exhibition.city = model.City;
                exhibition.area = model.Area;

                _exhibitionService.InsertExhibition(exhibition);

                result.Flag = ResultFlag.Successful;
                result.Data = exhibition.id;
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
        /// 新增展位设置--返回展位设置ID
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/AddSeatSet")]
        [HttpPost]
        public IHttpActionResult AddSeatSet(ExhibitionApplyRequestModel model)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                model.Creater = CurrentUserId;

                SeatSet seatSet = new SeatSet();
                Exhibition exhibition = _exhibitionService.GetModelById(model.ExhibitionCode);
                exhibition.recruitendtime = DateTime.Parse(model.RecruitEndTime);

                // 保存展位分布图
                if (HasAttachmentType(AttType.DistributionMap))
                {
                    Attachment attachment = new Attachment();

                    attachment.Code = CommonHelper.GetGuid();
                    attachment.ResourceID = exhibition.id;
                    attachment.CnName = exhibition.exhibitionname + " 展位分布图";
                    attachment.URL = model.DistributionMap;
                    attachment.Creator = model.Creater;
                    attachment.VersionStartTime = DateTime.Now;
                    attachment.VersionEndTime = DateTime.MaxValue;
                    attachment.ValidStatus = true;
                    attachment.AttachmentTypeCode = CommonHelper.GetEnumValue<AttType>(AttType.DistributionMap);

                    _attachmentService.InsertAttachment(attachment);
                }

                model.seatSetTypes.ForEach(p =>
                {
                    seatSet = new SeatSet();
                    seatSet.id = CommonHelper.GetGuid();
                    seatSet.seatprice = p.SeatPrice;
                    seatSet.seatscale = p.SeatScale;
                    seatSet.basetypescode = p.BaseTypeCode;
                    seatSet.creater = model.Creater;
                    seatSet.creattime = DateTime.Now;
                    seatSet.modifiytime = DateTime.Now;
                    p.SeatNo.ForEach(s =>
                    {
                        SeatNo seatNo = new SeatNo();
                        seatNo.id = CommonHelper.GetGuid();
                        seatNo.seatno = s.Seatno;
                        seatNo.creattime = DateTime.Now;
                        seatNo.modifiytime = DateTime.Now;
                        seatNo.creater = model.Creater;
                        seatSet.seatno.Add(seatNo);
                    });
                    exhibition.seatset.Add(seatSet);
                });
                _exhibitionService.Update(exhibition);
                result.Flag = ResultFlag.Successful;
                result.Data = seatSet.id;
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
        /// 新增门票设置--返回门票设置ID
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/AddTicketSet")]
        [HttpPost]
        public IHttpActionResult AddTicketSet(ExhibitionTicketRequestModel model)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                model.Creater = CurrentUserId;

                TicketsSet ticketsSet = new TicketsSet();
                Exhibition exhibition = new Exhibition();
                ticketsSet.id = CommonHelper.GetGuid();
                ticketsSet.exhibitioncode = model.ExhibitionId;
                exhibition = _exhibitionService.GetModelById(model.ExhibitionId);
                exhibition.enrollstarttime = DateTime.Parse(model.EnrollStartTime);
                exhibition.enrollendtime = DateTime.Parse(model.EnrollEmdTime);
                ticketsSet.namerequire = model.NameRequire;
                ticketsSet.phonerequire = model.PhoneRequire;
                ticketsSet.creater = model.Creater;
                ticketsSet.creattime = DateTime.Now;
                ticketsSet.modifiytime = DateTime.Now;
                model.TicketTypes.ForEach(p =>
                {
                    TicketsType type = new TicketsType();
                    type.id = CommonHelper.GetGuid();
                    type.creater = model.Creater;
                    type.creattime = DateTime.Now;
                    type.modifiytime = DateTime.Now;
                    type.price = p.price;
                    type.privilege = p.privilege;
                    type.quota = p.quota;
                    type.ticketname = p.ticketName;
                    ticketsSet.tickettype.Add(type);

                });
                _ticketsSetService.InsertTicketsSet(ticketsSet);
                result.Flag = ResultFlag.Successful;
                result.Data = ticketsSet.id;
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
        /// 新增日程-返回日程ID
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/AddExhibitionSchedule")]
        [HttpPost]
        public IHttpActionResult AddExhibitionSchedule(ExhibitionSchedule model)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                model.Creater = CurrentUserId;

                Schedule schedule = new Schedule();
                schedule.id = CommonHelper.GetGuid();
                schedule.stime = DateTime.Parse(model.STime);
                schedule.starttime = DateTime.Parse(model.StartTime);
                schedule.endtime = DateTime.Parse(model.EndTime);
                schedule.schedulename = model.ScheduleName;
                schedule.scheduledesc = model.ScheduleDesc;
                schedule.creater = model.Creater;
                schedule.creattime = DateTime.Now;
                schedule.modifiytime = DateTime.Now;
                schedule.exhibitioncode = model.ExhibitionId;
                _scheduleService.InsertSchedule(schedule);
                result.Flag = ResultFlag.Successful;
                result.Data = schedule.id;
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
        /// 添加展会，一次添加所有信息
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/AddExhibitionByOne")]
        [HttpPost]
        public IHttpActionResult AddExhibitionByOnce(ExhibitionRequestOnce model)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                if (model == null)
                {
                    result.Flag = ResultFlag.Error;
                    result.Messages = "传入实体为空!";
                    return Ok(result);
                }

                //验证实体数据是否完整
                if (model.ExhibitionProClass == null || model.ExhibitionProClass.Count == 0)
                {
                    result.Flag = ResultFlag.Error;
                    result.Messages = "展品分类数据不完整!";
                    return Ok(result);
                }
                if (model.Apply==null || model.Apply.seatSetTypes==null | model.Apply.seatSetTypes.Count == 0)
                {
                    result.Flag = ResultFlag.Error;
                    result.Messages = "展位设置数据不完整!";
                    return Ok(result);
                }
                if (model.Tickets == null || model.Tickets.TicketTypes == null | model.Tickets.TicketTypes.Count == 0)
                {
                    result.Flag = ResultFlag.Error;
                    result.Messages = "门票设置数据不完整!";
                    return Ok(result);
                }
                if (model.Market == null)
                {
                    result.Flag = ResultFlag.Error;
                    result.Messages = "销售数据不完整!";
                    return Ok(result);
                }

                //验证时间设置是否正确 展会发布>参展商报名截止>开始时间>结束时间
                if (DateTime.Parse(model.EndDate) < DateTime.Now)
                {
                    result.Flag = ResultFlag.Error;
                    result.Messages = "展会时间错误，结束时间不能早于当前时间!";
                    return Ok(result);
                }
                if (DateTime.Parse(model.StartDate) > DateTime.Parse(model.EndDate))
                {
                    result.Flag = ResultFlag.Error;
                    result.Messages = "展会时间错误，开始时间不能早于展会结束时间!";
                    return Ok(result);
                }
                if (DateTime.Parse(model.Apply.RecruitEndTime) < DateTime.Now)
                {
                    result.Flag = ResultFlag.Error;
                    result.Messages = "参展商报名截至时间错误，不能早于展会发布时间!";
                    return Ok(result);
                }
                if (DateTime.Parse(model.StartDate) < DateTime.Parse(model.Apply.RecruitEndTime))
                {
                    result.Flag = ResultFlag.Error;
                    result.Messages = "展会开始时间错误，不能早于参展商报名截至时间!";
                    return Ok(result);
                }
                if (DateTime.Parse(model.EndDate) < DateTime.Parse(model.StartDate))
                {
                    result.Flag = ResultFlag.Error;
                    result.Messages = "展会结束时间错误，不能早于展会开始时间!";
                    return Ok(result);
                }
                if (DateTime.Parse(model.Tickets.EnrollEmdTime) < DateTime.Parse(model.Tickets.EnrollStartTime))
                {
                    result.Flag = ResultFlag.Error;
                    result.Messages = "用户报名时间错误，结束时间不能早于开始时间!";
                    return Ok(result);
                }
                if (DateTime.Parse(model.Tickets.EnrollStartTime) < DateTime.Parse(model.Apply.RecruitEndTime))
                {
                    result.Flag = ResultFlag.Error;
                    result.Messages = "用户报名时间错误，开始时间不能早于招展时间!";
                    return Ok(result);
                }
                if (DateTime.Parse(model.Tickets.EnrollStartTime) > DateTime.Parse(model.StartDate))
                {
                    result.Flag = ResultFlag.Error;
                    result.Messages = "用户报名时间错误，结束时间不能晚于展会开始时间!";
                    return Ok(result);
                }
                

                model.BusinessID = CurrentUserId;
                model.BusinessName = CurrentUserName;
                model.Creater = CurrentUserId;

                Exhibition exhibition = new Exhibition();
                exhibition.id = CommonHelper.GetGuid();
                exhibition.exhibitionname = model.Name;
                exhibition.basetypescode = model.ClassId;
                exhibition.starttime = DateTime.Parse(model.StartDate);
                exhibition.endtime = DateTime.Parse(model.EndDate);
                exhibition.address1 = model.Address1;
                exhibition.address2 = model.Address2;
                exhibition.longitude = model.Longitude;
                exhibition.latitude = model.Latitude;
                exhibition.detailes = model.Detailes;
                exhibition.businessid = model.BusinessID;
                exhibition.businessname = model.BusinessName;
                exhibition.recruitstatus = 1;
                exhibition.enrollstatus = 1;
                exhibition.creater = model.Creater;
                exhibition.creattime = DateTime.Now;
                exhibition.modifiytime = DateTime.Now;
                exhibition.publishedtime = DateTime.Now;
                exhibition.recruitendtime = DateTime.Now;
                exhibition.enrollstarttime = DateTime.Now;
                exhibition.enrollendtime = DateTime.Now;
                model.ExhibitionProClass.ForEach(p =>
                {
                    ExhibitionProductClass productClass = new ExhibitionProductClass();
                    productClass.id = CommonHelper.GetGuid();
                    productClass.classname = p.ClassName;//展品分类名称
                    productClass.creater = model.Creater;
                    productClass.creattime = DateTime.Now;
                    productClass.modifiytime = DateTime.Now;
                    productClass.exhibitioncode = exhibition.id;//展会id
                    if (productClass != null)
                    {
                        exhibition.exhibitionproductclass.Add(productClass);
                    }
                });
                model.ExhibitionTagCode.ForEach(p =>
                {
                    ExhibitionTag tag = new ExhibitionTag();
                    tag.id = CommonHelper.GetGuid();
                    tag.tagname = p.TagName;//标签名称
                    tag.creater = model.Creater;
                    tag.creattime = DateTime.Now;
                    tag.modifiytime = DateTime.Now;
                    tag.exhibitioncode = exhibition.id;//展会id
                    if (tag != null)
                    {
                        exhibition.exhibitiontag.Add(tag);
                    }
                });

                // 保存封面图片
                if (HasAttachmentType(AttType.ExhibitionLogo))
                {
                    Attachment attachment = new Attachment();

                    attachment.Code = CommonHelper.GetGuid();
                    attachment.ResourceID = exhibition.id;
                    attachment.CnName = model.Name + " 封面图片";
                    attachment.URL = model.HeadImg;
                    attachment.Creator = model.Creater;
                    attachment.VersionStartTime = DateTime.Now;
                    attachment.VersionEndTime = DateTime.MaxValue;
                    attachment.ValidStatus = true;
                    attachment.AttachmentTypeCode = CommonHelper.GetEnumValue<AttType>(AttType.ExhibitionLogo);

                    _attachmentService.InsertAttachment(attachment);
                }

                // 保存详情图片
                if (HasAttachmentType(AttType.ExhibitionIntroImg) && model.ImageUrls != null)
                {
                    model.ImageUrls.ForEach(p =>
                    {
                        Attachment attachment = new Attachment();

                        attachment.Code = CommonHelper.GetGuid();
                        attachment.ResourceID = exhibition.id;
                        attachment.CnName = model.Name + " 详情图片";
                        attachment.URL = p.url;
                        attachment.Creator = model.Creater;
                        attachment.VersionStartTime = DateTime.Now;
                        attachment.VersionEndTime = DateTime.MaxValue; ;
                        attachment.ValidStatus = true;
                        attachment.AttachmentTypeCode = CommonHelper.GetEnumValue<AttType>(AttType.ExhibitionIntroImg);

                        _attachmentService.InsertAttachment(attachment);
                    });
                }

                // 保存详情视频
                if (HasAttachmentType(AttType.ExhibitionIntroVideo) && model.VideoUrls != null)
                {
                    model.VideoUrls.ForEach(p =>
                    {
                        Attachment attachment = new Attachment();

                        attachment.Code = CommonHelper.GetGuid();
                        attachment.ResourceID = exhibition.id;
                        attachment.CnName = model.Name + " 视频";
                        attachment.URL = p.url;
                        attachment.Creator = model.Creater;
                        attachment.VersionStartTime = DateTime.Now;
                        attachment.VersionEndTime = DateTime.MaxValue;
                        attachment.ValidStatus = true;
                        attachment.AttachmentTypeCode = CommonHelper.GetEnumValue<AttType>(AttType.ExhibitionIntroVideo);

                        _attachmentService.InsertAttachment(attachment);
                    });
                }

                //获取地图信息
                exhibition.province = model.Province;
                exhibition.city = model.City;
                exhibition.area = model.Area;

                //-------新增展位设置-----------------
                SeatSet seatSet = new SeatSet();
                exhibition.recruitendtime = DateTime.Parse(model.Apply.RecruitEndTime);

                // 保存展位分布图
                if (HasAttachmentType(AttType.DistributionMap))
                {
                    Attachment attachment = new Attachment();

                    attachment.Code = CommonHelper.GetGuid();
                    attachment.ResourceID = exhibition.id;
                    attachment.CnName = exhibition.exhibitionname + " 展位分布图";
                    attachment.URL = model.Apply.DistributionMap;
                    attachment.Creator = model.Creater;
                    attachment.VersionStartTime = DateTime.Now;
                    attachment.VersionEndTime = DateTime.MaxValue;
                    attachment.ValidStatus = true;
                    attachment.AttachmentTypeCode = CommonHelper.GetEnumValue<AttType>(AttType.DistributionMap);

                    _attachmentService.InsertAttachment(attachment);
                }

                model.Apply.seatSetTypes.ForEach(p =>
                {
                    seatSet = new SeatSet();
                    seatSet.id = CommonHelper.GetGuid();
                    seatSet.seatprice = p.SeatPrice;
                    seatSet.seatscale = p.SeatScale;
                    seatSet.basetypescode = p.BaseTypeCode;
                    seatSet.creater = model.Creater;
                    seatSet.creattime = DateTime.Now;
                    seatSet.modifiytime = DateTime.Now;
                    p.SeatNo.ForEach(s =>
                    {
                        SeatNo seatNo = new SeatNo();
                        seatNo.id = CommonHelper.GetGuid();
                        seatNo.seatno = s.Seatno;
                        seatNo.creattime = DateTime.Now;
                        seatNo.modifiytime = DateTime.Now;
                        seatNo.creater = model.Creater;
                        seatSet.seatno.Add(seatNo);
                    });
                    exhibition.seatset.Add(seatSet);
                });

                //--------门票设置------------
                TicketsSet ticketsSet = new TicketsSet();
                ticketsSet.id = CommonHelper.GetGuid();
                ticketsSet.exhibitioncode = exhibition.id;
                exhibition.enrollstarttime = DateTime.Parse(model.Tickets.EnrollStartTime);
                exhibition.enrollendtime = DateTime.Parse(model.Tickets.EnrollEmdTime);
                ticketsSet.namerequire = model.Tickets.NameRequire;
                ticketsSet.phonerequire = model.Tickets.PhoneRequire;
                ticketsSet.creater = model.Creater;
                ticketsSet.creattime = DateTime.Now;
                ticketsSet.modifiytime = DateTime.Now;
                model.Tickets.TicketTypes.ForEach(p =>
                {
                    TicketsType type = new TicketsType();
                    type.id = CommonHelper.GetGuid();
                    type.creater = model.Creater;
                    type.creattime = DateTime.Now;
                    type.modifiytime = DateTime.Now;
                    type.price = p.price;
                    type.privilege = p.privilege;
                    type.quota = p.quota;
                    type.ticketname = p.ticketName;
                    ticketsSet.tickettype.Add(type);
                });
                exhibition.ticketsset.Add(ticketsSet);

                //--------销售设置-------------
                exhibition.lowdiscount = model.Market.LowDiscount;
                exhibition.saleproportion = model.Market.SaleProportion;
                exhibition.modifier = model.Creater;
                exhibition.modifiytime = DateTime.Now;

                _exhibitionService.InsertExhibition(exhibition);

                result.Flag = ResultFlag.Successful;
                result.Data = exhibition.id;
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
        [Route("api/Exhibition/GetExhibitionDetails/{exhibitionId}")]
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
                model.LiveCount = -1;                                   //目前没数据
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
                    classRequest.ClassId = p.id;
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
                if (HasAttachmentType(AttType.DistributionMap))
                {
                    var dMapAtt = _attachmentService.GetListByResourceIdAndType(exhibitionId, CommonHelper.GetEnumValue<AttType>(AttType.DistributionMap));
                    if (dMapAtt.Count > 0)
                    {
                        details.distributionMap = dMapAtt.FirstOrDefault().URL;
                    }
                }
                details.editorId = exhibition.creater;
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
                    ticketdetails.EnrollEmdTime = exhibition.enrollendtime.ToString("yyyy-MM-dd HH:mm:ss");
                    ticketdetails.EnrollStartTime = exhibition.enrollstarttime.ToString("yyyy-MM-dd HH:mm:ss");
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
        /// 管理展会
        /// </summary>
        /// <param name="exhibitionId"></param>
        /// <returns></returns>
        [Route("api/Exhibition/ManageExhibition")]
        [HttpPost]
        public IHttpActionResult ManageExhibition(ManageExhibitionRequestModel model)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                model.Modifier = CurrentUserId;
                //更新展会
                Exhibition exhibition = _exhibitionService.GetModelById(model.ExhibitionId);
                exhibition.recruitstatus = model.RecruitStatus;
                exhibition.enrollstatus = model.EnrollStatus;
                exhibition.modifier = model.Modifier;
                exhibition.modifiytime = DateTime.Now;
                _exhibitionService.Update(exhibition);

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
        /// 更新展会基础信息
        /// </summary>
        /// <param name="exhibitionId"></param>
        /// <returns></returns>
        [Route("api/Exhibition/UpdateExhibition")]
        [HttpPost]
        public IHttpActionResult EditExhibition(ExhibitionDetailsModel model)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                model.EditorID = CurrentUserId;
                //更新展会基础信息
                Exhibition exhibition = _exhibitionService.GetModelById(model.ExhibitionId);

                exhibition.exhibitionname = model.Name;
                exhibition.basetypescode = model.ClassId;
                exhibition.nocolumn = model.ClassId;
                exhibition.starttime = DateTime.Parse(model.StartDate);
                exhibition.endtime = DateTime.Parse(model.EndDate);
                exhibition.address1 = model.Address1;
                exhibition.address2 = model.Address2;
                exhibition.longitude = model.Longitude;
                exhibition.latitude = model.Latitude;
                exhibition.detailes = model.Detailes;
                exhibition.modifier = model.EditorID;

                //更新展会详情图片
                if (HasAttachmentType(AttType.ExhibitionIntroImg))
                {
                    var imgAtts = _attachmentService.GetListByResourceIdAndType(model.ExhibitionId, CommonHelper.GetEnumValue<AttType>(AttType.ExhibitionIntroImg));
                    var imgList = imgAtts.ToList();
                    for (int i = 0; i < imgList.Count; i++)
                    {
                        var imgatt = imgList[i];
                        _attachmentService.Delete(imgatt);
                    }

                    if (model.ImageUrls != null)
                    {
                        model.ImageUrls.ForEach(p =>
                        {
                            Attachment attachment = new Attachment();

                            attachment.Code = CommonHelper.GetGuid();
                            attachment.ResourceID = exhibition.id;
                            attachment.CnName = model.Name + " 详情图片";
                            attachment.URL = p.Url;
                            attachment.Creator = model.EditorID;
                            attachment.VersionStartTime = DateTime.Now;
                            attachment.VersionEndTime = DateTime.MaxValue; ;
                            attachment.ValidStatus = true;
                            attachment.AttachmentTypeCode = CommonHelper.GetEnumValue<AttType>(AttType.ExhibitionIntroImg);

                            _attachmentService.InsertAttachment(attachment);
                        });
                    }
                }

                //更新展会详情视频
                if (HasAttachmentType(AttType.ExhibitionIntroVideo))
                {
                    var videoAtts = _attachmentService.GetListByResourceIdAndType(model.ExhibitionId, CommonHelper.GetEnumValue<AttType>(AttType.ExhibitionIntroVideo));
                    var videoList = videoAtts.ToList();
                    for (int i = 0; i < videoList.Count; i++)
                    {
                        var videoatt = videoList[i];
                        _attachmentService.Delete(videoatt);
                    }

                    if (model.VideoUrls != null)
                    {
                        model.VideoUrls.ForEach(p =>
                        {
                            Attachment attachment = new Attachment();

                            attachment.Code = CommonHelper.GetGuid();
                            attachment.ResourceID = exhibition.id;
                            attachment.CnName = model.Name + " 视频";
                            attachment.URL = p.Url;
                            attachment.Creator = model.EditorID;
                            attachment.VersionStartTime = DateTime.Now;
                            attachment.VersionEndTime = DateTime.MaxValue;
                            attachment.ValidStatus = true;
                            attachment.AttachmentTypeCode = CommonHelper.GetEnumValue<AttType>(AttType.ExhibitionIntroVideo);

                            _attachmentService.InsertAttachment(attachment);
                        });
                    }
                }

                _exhibitionService.Update(exhibition);
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
        /// 更新展位设置
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/EditExhibitionApply")]
        [HttpPost]
        public IHttpActionResult EditExhibitionApply(ExhibitionApplyDetailsModel model)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                if (model == null)
                {
                    result.Flag = ResultFlag.Error;
                    result.Messages = "参数传入有错！";
                    return Ok(result);
                }

                model.editorId = CurrentUserId;

                var exhibition = _exhibitionService.GetModelById(model.exhibitionId);
                exhibition.recruitendtime = DateTime.Parse(model.recruitEndTime);
                exhibition.modifier = model.editorId;
                exhibition.modifiytime = DateTime.Now;
                _exhibitionService.Update(exhibition);

                // 更新或插入展位分布图
                if (HasAttachmentType(AttType.DistributionMap))
                {
                    var dMapAtt = _attachmentService.GetListByResourceIdAndType(model.exhibitionId, CommonHelper.GetEnumValue<AttType>(AttType.DistributionMap));
                    if (dMapAtt.Count > 0)
                    {
                        foreach (var dmap in dMapAtt)
                        {
                            _attachmentService.Delete(dmap);
                        }
                    }

                    Attachment attachment = new Attachment();

                    attachment.Code = CommonHelper.GetGuid();
                    attachment.ResourceID = exhibition.id;
                    attachment.CnName = exhibition.exhibitionname + " 展位分布图";
                    attachment.URL = model.distributionMap;
                    attachment.Creator = model.editorId;
                    attachment.VersionStartTime = DateTime.Now;
                    attachment.VersionEndTime = DateTime.MaxValue;
                    attachment.ValidStatus = true;
                    attachment.AttachmentTypeCode = CommonHelper.GetEnumValue<AttType>(AttType.DistributionMap);

                    _attachmentService.InsertAttachment(attachment);

                }

                // 清除已有的展位设置
                var seatSetList = exhibition.seatset.ToList();

                for (int i = 0; i < seatSetList.Count; i++)
                {
                    var seatset = seatSetList[i];
                    _seatSetService.Delete(seatset);
                }

                model.seatSetTypes.ToList().ForEach(p =>
                {
                    //新增展位设置
                    var seatSet = new SeatSet()
                    {
                        id = CommonHelper.GetGuid(),
                        seatprice = p.seatPrice,
                        seatscale = p.seatScale,
                        basetypescode = p.baseTypeCode,
                        exhibitioncode = exhibition.id,
                        creater = model.editorId,
                        creattime = DateTime.Now,
                        modifier = model.editorId,
                        modifiytime = DateTime.Now,
                        isdel = 0,
                    };

                    p.seatSetTypeId = seatSet.id;

                    p.seatNo.ForEach(w =>
                    {
                        var seatNo = new SeatNo()
                        {
                            id = CommonHelper.GetGuid(),
                            seatno = w.seatno,
                            creater = model.editorId,
                            creattime = DateTime.Now,
                            modifier = model.editorId,
                            modifiytime = DateTime.Now,
                            isdel = 0,
                        };
                        w.noId = seatNo.id;
                        seatSet.seatno.Add(seatNo);
                    });
                    _seatSetService.InsertSeatSet(seatSet);
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
        /// 删除展会设置
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/DeleteExhibitionApply")]
        [HttpPost]
        public IHttpActionResult DeleteExhibitionApply(ExhibitionApply model)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                //删除展会设置
                var seatSet = _seatSetService.GetModelById(model.exhibitionApplyId);
                if (seatSet != null)
                {
                    seatSet.isdel = 1;
                    seatSet.modifier = CurrentUserId;
                    seatSet.modifiytime = DateTime.Now;
                    _seatSetService.Update(seatSet);

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
        /// 删除展位号
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("api/Exhibition/DeleteSeatNo")]
        [HttpPost]
        public IHttpActionResult DeleteSeatNo(SeatNoId model)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                //删除展会设置
                var seatSet = _seatNoService.GetModelById(model.seatNoId);
                if (seatSet != null)
                {
                    seatSet.isdel = 1;
                    seatSet.modifier = CurrentUserId;
                    seatSet.modifiytime = DateTime.Now;
                    _seatNoService.Update(seatSet);

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
        /// 获取门票设置
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/GetExhibitionTicketSetDetails/{exhibitionTicketSetId}")]
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
        /// 更新门票设置
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/EditTicketsSet")]
        [HttpPost]
        public IHttpActionResult EditExhibitionTicketSet(ExhibitionTicketSetDetailsModel model)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                model.EditorId = CurrentUserId;

                var exhibition = _exhibitionService.GetModelById(model.ExhibitionId);
                var ticketsSet = exhibition.ticketsset.FirstOrDefault();
                exhibition.enrollstarttime = DateTime.Parse(model.EnrollStartTime);
                exhibition.enrollendtime = DateTime.Parse(model.EnrollEmdTime);
                ticketsSet.namerequire = model.NameRequire;
                ticketsSet.phonerequire = model.PhoneRequire;
                if (model.TicketTypes != null && model.TicketTypes.Any())
                {
                    model.TicketTypes.ForEach(p =>
                    {
                        var oldTicket = ticketsSet.tickettype.Where(t => t.id == p.ticketsTypeID).FirstOrDefault();
                        if (oldTicket != null)
                        {
                            oldTicket.ticketname = p.ticketName;
                            oldTicket.price = p.price;
                            oldTicket.quota = p.quota;
                            oldTicket.privilege = p.privilege;
                            oldTicket.modifier = model.EditorId;
                            oldTicket.modifiytime = DateTime.Now;
                        }
                        else
                        {
                            TicketsType NewTicket = new TicketsType();
                            NewTicket.id = CommonHelper.GetGuid();
                            NewTicket.ticketname = p.ticketName;
                            NewTicket.price = p.price;
                            NewTicket.quota = p.quota;
                            NewTicket.privilege = p.privilege;
                            NewTicket.creater = model.EditorId;
                            NewTicket.creattime = DateTime.Now;
                            NewTicket.modifier = model.EditorId;
                            NewTicket.modifiytime = DateTime.Now;
                            ticketsSet.tickettype.Add(oldTicket);
                        }
                    });
                }

                _exhibitionService.Update(exhibition);
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
        /// 删除门票设置
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/DeleteExhibitionTicketSet")]
        [HttpPost]
        public IHttpActionResult DeleteExhibitionTicketSet(TicketSetId model)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                //删除门票设置详情
                var ticketSet = _ticketsSetService.GetMoelById(model.exhibitionTicketSetId);
                if (ticketSet != null)
                {
                    ticketSet.isdel = 1;
                    ticketSet.modifier = CurrentUserId;
                    ticketSet.modifiytime = DateTime.Now;
                    _ticketsSetService.Update(ticketSet);

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
        /// 获取销售设置详情
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/GetExhibitionMarketDetails/{exhibitionMarketId}")]
        [HttpGet]
        public IHttpActionResult GetExhibitionMarketDetails(string exhibitionMarketId)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                ExhibitionMarketDetailsModel model = new ExhibitionMarketDetailsModel();
                //展会实体??
                var exhibition = _exhibitionService.GetModelById(exhibitionMarketId);
                model.ExhibitionId = exhibition.id;
                model.LowDiscount = exhibition.lowdiscount;
                model.SaleProportion = exhibition.saleproportion;

                //获取销售设置详情

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
        /// 更新销售设置
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/EditExhibitionMarket")]
        [HttpPost]
        public IHttpActionResult EditExhibitionMarket(ExhibitionMarketDetailsModel model)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                model.EditorId = CurrentUserId;
                //更新销售设置
                var exhibition = _exhibitionService.GetModelById(model.ExhibitionId);
                exhibition.lowdiscount = model.LowDiscount;
                exhibition.saleproportion = model.SaleProportion;
                exhibition.modifier = model.EditorId;
                exhibition.modifiytime = DateTime.Now;
                _exhibitionService.Update(exhibition);
                result.Flag = ResultFlag.Successful;
                result.Data = true;
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
        /// 获取展会日程
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/GetExhibitionSchedule/{exhibitionId}")]
        [HttpGet]
        public IHttpActionResult GetExhibitionSchedule(string exhibitionId)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var exhibition = _exhibitionService.GetModelById(exhibitionId);

                if (exhibition != null)
                {
                    var model = new List<ExhibitionScheduleDetailsModel>();

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
                        model.Add(scheduledetails);
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
        /// 更新日程
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/EditExhibitionSchedule")]
        [HttpPost]
        public IHttpActionResult EditExhibitionSchedule(ExhibitionScheduleDetailsModel model)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                model.EditorId = CurrentUserId;
                //更新日程
                var schedule = _scheduleService.GetModelById(model.ExhibitionScheduleId);
                schedule.stime = DateTime.Parse(model.STime);
                schedule.starttime = DateTime.Parse(model.StartTime);
                schedule.endtime = DateTime.Parse(model.EndTime);
                schedule.schedulename = model.ScheduleName;
                schedule.scheduledesc = model.ScheduleDesc;
                schedule.modifier = model.EditorId;
                schedule.modifiytime = DateTime.Now;
                _scheduleService.Update(schedule);
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
        /// 删除日程
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/DeleteExhibitionSchedule")]
        [HttpPost]
        public IHttpActionResult DeleteExhibitionSchedule(ScheduleId model)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                //删除日程
                var schedule = _scheduleService.GetModelById(model.exhibitionScheduleId);
                if (schedule != null)
                {
                    schedule.isdel = 1;
                    schedule.modifier = CurrentUserId;
                    schedule.modifiytime = DateTime.Now;
                    _scheduleService.Update(schedule);
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
        /// 所有展会 0-未结束 1-已结束
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/ExhibitionList/{status}")]
        [HttpGet]
        public IHttpActionResult ExhibitionList(int status)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var exhibitions = _exhibitionService.GetAllList();
                List<SearchExhibitionResponseModel> model = new List<SearchExhibitionResponseModel>();

                if (exhibitions.Count > 0)
                {
                    foreach (var p in exhibitions)
                    {
                        if (status == 1 && p.endtime < DateTime.Now)
                        {
                            model.Add(new SearchExhibitionResponseModel()
                            {
                                ExhibitionId = p.id,
                                CreationDate = p.creattime.ToString(),
                                Status = GetExhibitionStatusStr(p),
                                SellerNumber = p.sellerorder.Count,
                                UserNumber = p.enrolluser.Count
                            });
                        }
                        else if (status == 0 && p.endtime > DateTime.Now)
                        {
                            model.Add(new SearchExhibitionResponseModel()
                            {
                                ExhibitionId = p.id,
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
        /// 我发布的展会
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/MyExhibitions/{createrId}/{status}")]
        [HttpGet]
        public IHttpActionResult MyExhibitions(string createrId, int status)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                createrId = CurrentUserId;

                var exhibitions = _exhibitionService.GetAllList().Where(p => p.creater == createrId).OrderByDescending(p => p.creattime).ToList();
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

                        if (status == 1)
                        {
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
                        }
                        else if (status == 0)
                        {
                            if (p.endtime > DateTime.Now)
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
        /// 我参加的展会--status：0 未结束 1 已结束
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/MyJoinExhibition/{sellerId}/{status}")]
        [HttpGet]
        public IHttpActionResult MyJoinExhibition(string sellerId, int status)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                sellerId = CurrentUserId;

                var sellOrders = _sellerOrderService.GetAllList().Where(p => p.creater == sellerId).ToList();
                List<SearchExhibitionResponseModel> model = new List<SearchExhibitionResponseModel>();

                if (sellOrders.Count > 0)
                {
                    foreach (var p in sellOrders)
                    {
                        var exhibition = p.exhibition;
                        string headImg = string.Empty;
                        if (HasAttachmentType(AttType.ExhibitionLogo))
                        {
                            var logoImgAtt = _attachmentService.GetListByResourceIdAndType(exhibition.id, CommonHelper.GetEnumValue<AttType>(AttType.ExhibitionLogo));
                            if (logoImgAtt.Count > 0)
                            {
                                headImg = logoImgAtt.FirstOrDefault().URL;
                            }
                        }

                        if (status == 1 && p.exhibition.endtime < DateTime.Now)
                        {
                            model.Add(new SearchExhibitionResponseModel()
                            {
                                ExhibitionId = p.exhibition.id,
                                ExhibitionName = p.exhibition.exhibitionname,
                                HeadImg = headImg,
                                CreationDate = p.creattime.ToString(),
                                Status = "已结束",
                                SellerNumber = exhibition.sellerorder.Count,
                                UserNumber = exhibition.enrolluser.Count
                            });
                        }
                        else if (status == 0 && p.exhibition.endtime > DateTime.Now)
                        {
                            model.Add(new SearchExhibitionResponseModel()
                            {
                                ExhibitionId = p.exhibition.id,
                                ExhibitionName = p.exhibition.exhibitionname,
                                HeadImg = headImg,
                                CreationDate = p.creattime.ToString(),
                                Status = "正在进行",
                                SellerNumber = exhibition.sellerorder.Count,
                                UserNumber = exhibition.enrolluser.Count
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
        /// 根据数字码验票
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/CheckTicketByPwdNumber/{pwdNumber}")]
        [HttpGet]
        public IHttpActionResult CheckTicketByPwdNumber(string pwdNumber)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var ticket = _enrollUserService.GetModelByPwdNumber(pwdNumber);

                result.Flag = ResultFlag.Successful;
                if (ticket != null)
                {
                    if (ticket.ticketstatus == (int)EnrollOrderStatus.NoConfirm)
                    {
                        ticket.ticketstatus = (int)EnrollOrderStatus.Confirmed;
                        ticket.modifier = CurrentUserId;
                        ticket.modifiytime = DateTime.Now;
                        _enrollUserService.Update(ticket);
                        result.Flag = ResultFlag.Successful;
                        result.Data = true;
                        result.Messages = "验票成功";
                    }
                    else if (ticket.ticketstatus == (int)EnrollOrderStatus.NoPay)
                    {
                        result.Flag = ResultFlag.Error;
                        result.Data = null;
                        result.Messages = "门票未支付";
                    }
                }
                else
                {
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
        /// 订单统计
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/OrderTotalInfo/{exhibitionId}")]
        [HttpGet]
        public IHttpActionResult OrderTotalInfo(string exhibitionId)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                //订单统计
                var exhibition = _exhibitionService.GetModelById(exhibitionId);
                var orders = _orderService.GetAllList().Where(t => t.sellerNumber == exhibitionId).ToList();
                OrderTotalInfo model = new Models.OrderTotalInfo();

                model.OrderCount = orders.Count;
                model.TotalInCome = 0M;
                int totalCharge = 0;
                if (orders.Count > 0)
                {
                    foreach (var p in orders)
                    {
                        totalCharge += p.totalCharge.HasValue ? p.totalCharge.Value : 0;
                    }
                    model.TotalInCome = Convert.ToDecimal(totalCharge);
                    model.SalesCommissions = model.TotalInCome * exhibition.saleproportion;

                    result.Flag = ResultFlag.Successful;
                    result.Data = model;
                }
                else
                {
                    result.Flag = ResultFlag.DataNotExist;
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
        /// 订单列表
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/Orders/{exhibitionId}")]
        [HttpGet]
        public IHttpActionResult ExhibitionOrders(string exhibitionId)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                List<ExhibitionOrderListModel> model = new List<ExhibitionOrderListModel>();
                var orders = _orderService.GetAllList().Where(t => t.sellerNumber == exhibitionId).ToList();

                if (orders.Count > 0)
                {
                    foreach (var p in orders)
                    {
                        ExhibitionOrderListModel item = new ExhibitionOrderListModel();
                        item.OrderId = p.code;
                        item.UserName = p.customerName;
                        item.SellerName = p.sellerName;
                        item.Status = p.status == 1 ? "待提货" : "已提货";
                        item.TotalPay = p.totalCharge.HasValue ? p.totalCharge.Value : 0;
                        item.CreateTime = p.createTime.ToString();
                        item.Products = new List<ProductNameModel>();
                        var userInfo = _userInfoService.GetModelById(p.creator);
                        if (userInfo != null)
                        {
                            item.UserHeadImg = userInfo.HeadImage;
                        }
                        else
                        {
                            item.UserHeadImg = CommonHelper.TempHeadImg();
                        }
                        foreach (var product in p.orderDetails)
                        {
                            item.Products.Add(new ProductNameModel()
                            {
                                Name = product.goodsName
                            });
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
        /// 参展展商列表-- 1:未确认 2:已确认 3:已拒绝
        /// </summary>
        /// <param name="exhibitionId"></param>
        /// <returns></returns>
        [Route("api/Exhibition/ExhibitionSellers/{exhibitionId}/{status}")]
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
        [Route("api/Exhibition/SellersInfo/{sellerId}")]
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
        /// 处理参展商报名 status:2-确认 3-拒绝
        /// </summary>
        /// <param name="exhibitionId"></param>
        /// <returns></returns>
        [Route("api/Exhibition/CheckSellerOrder")]
        [HttpPost]
        public IHttpActionResult CheckSellerOrder(SellerOrderCheck model)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var sellerOrder = _sellerOrderService.GetModelById(model.sellerOrderId);

                if (sellerOrder != null)
                {
                    if (sellerOrder.orderstatus == (int)SellerOrderStatus.NoConfirm)
                    {
                        sellerOrder.orderstatus = (model.status - 1);

                        foreach (var p in sellerOrder.sellerOrderDetails)
                        {
                            p.isdel = 1;
                        }

                        sellerOrder.modifier = CurrentUserId;
                        sellerOrder.modifiytime = DateTime.Now;

                        _sellerOrderService.Update(sellerOrder);

                        result.Flag = ResultFlag.Successful;
                        result.Data = true;
                    }
                    else if (sellerOrder.orderstatus == (int)SellerOrderStatus.NoPay)
                    {
                        result.Flag = ResultFlag.Error;
                        result.Data = false;
                        result.Messages = "该订单未支付!";
                    }
                    else
                    {
                        result.Flag = ResultFlag.Error;
                        result.Data = false;
                        result.Messages = "该订单已经处理过!";
                    }
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
        /// 用户报名列表
        /// </summary>
        /// <param name="exhibitionId"></param>
        /// <returns></returns>
        [Route("api/Exhibition/EnrollUsers/{exhibitionId}")]
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
        /// 支付成功回调接口
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("api/Exhibition/PaySuccess/{orderNo}/{payStatus}")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult PaySuccess(string orderNo, int payStatus)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                bool hasError = true;
                bool statsuError = false;

                if (!string.IsNullOrEmpty(orderNo))
                {
                    if (payStatus == 1)
                    {
                        var sellerOrder = _sellerOrderService.GetModelByOrderNo(orderNo);
                        var enrollOrder = _enrollUserService.GetModelByOrderNo(orderNo);
                        var productOrder = _orderService.GetModelByOrderNo(orderNo);

                        if (sellerOrder != null)
                        {
                            if (sellerOrder.orderstatus == (int)SellerOrderStatus.NoPay)
                            {
                                sellerOrder.orderstatus = (int)SellerOrderStatus.NoConfirm;
                                _sellerOrderService.Update(sellerOrder);
                                hasError = false;
                            }
                            else
                            {
                                statsuError = true;
                            }
                        }
                        else if (enrollOrder != null)
                        {
                            if (enrollOrder.ticketstatus == (int)EnrollOrderStatus.NoPay)
                            {
                                enrollOrder.ticketstatus = (int)EnrollOrderStatus.NoConfirm;
                                _enrollUserService.Update(enrollOrder);
                                hasError = false;
                            }
                            else
                            {
                                statsuError = true;
                            }
                        }
                        else if (productOrder != null)
                        {
                            if (productOrder.status == (int)ProductOrderStatus.NoPay)
                            {
                                productOrder.status = (int)ProductOrderStatus.NoPickUp;
                                _orderService.Update(productOrder);
                                hasError = false;
                            }
                            else
                            {
                                statsuError = true;
                            }
                        }
                    }
                }

                if (statsuError)
                {
                    result.Flag = ResultFlag.Error;
                    result.Messages = "订单已处理过，请勿重复处理!";
                }
                else if (!hasError)
                {
                    result.Flag = ResultFlag.Successful;
                    result.Data = true;
                }
                else if (payStatus == 0)
                {
                    result.Flag = ResultFlag.Successful;
                    result.Messages = "订单支付失败!";
                }
                else
                {
                    result.Flag = ResultFlag.Error;
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
        /// 获取共享连接
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/GetSharedLink")]
        [HttpGet]
        [AllowAnonymous]
        public IHttpActionResult GetSharedLink()
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                result.Flag = ResultFlag.Successful;
                var uri = Request.RequestUri;
                result.Data = uri.AbsoluteUri.Replace("api/Exhibition/GetSharedLink", "share/index.html?id=");
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
        /// 验证码验证
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/CheckVerCode/{mobile}/{sessionId}/{markcode}")]
        [HttpGet]
        public IHttpActionResult CheckVerCode(string mobile, string sessionId, string markcode)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                string uri = string.Format(verCodeCheckAddress, mobile, sessionId, markcode);
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
