using System.Collections.Generic;

namespace ZHT.Api.Models
{
    /// <summary>
    /// 基础类型
    /// </summary>
    public class BaseTypeModel
    {
        public string Id { get; set; }

        public string Value { get; set; }
    }

    /// <summary>
    /// 展会标签
    /// </summary>
    public class TagModel
    {
        public string Id { get; set; }          //展会标签ID

        public string Tag { get; set; }         //标签名称

        public string TagRemark { get; set; }   //标签备注
    }

    /// <summary>
    /// 展会分类
    /// </summary>
    public class BaseClassModel
    {
        public string Id { get; set; }          //展会分类ID

        public string Name { get; set; }        //展会分类名称
    }

    #region 一键新增展会

    public class ExhibitionRequestOnce
    {
        public string Name { get; set; }         //展会名称
        public string HeadImg { get; set; }     //封面图地址
        public string ClassId { get; set; }     //展会分类ID
        public string StartDate { get; set; }   //开始时间
        public string EndDate { get; set; }     //截至时间
        public string Address1 { get; set; }    //展会地址1-手动输入
        public string Address2 { get; set; }    //展会地址2-地图获取
        public string Longitude { get; set; }  //经度
        public string Latitude { get; set; }   //纬度
        public string Detailes { get; set; }    //展会详情
        public List<ImageAndVideoUrl> ImageUrls { get; set; }   //图片列表
        public List<ImageAndVideoUrl> VideoUrls { get; set; }   //视频列表
        public List<ExhibitionProductClassRequestModel> ExhibitionProClass { get; set; }  //展品分类
        public List<ExhibitionTagRequestModel> ExhibitionTagCode { get; set; }   //展会标签
        public string BusinessID { get; set; }      //主办方ID
        public string BusinessName { get; set; }    //主办方名称
        public string Creater { get; set; }         //创建人ID
        public string Province { get; set; }        //省
        public string City { get; set; }            //市
        public string Area { get; set; }            //区
        public ExhibitionApplyRequestModel Apply { get; set; }      //展位设置
        public ExhibitionTicketRequestModel Tickets { get; set; }   //门票设置
        public ExhibitionMarketDetailsModel Market { get; set; }    //销售设置
    }

    #endregion

    /// <summary>
    /// 新增展会
    /// </summary>
    public class ExhibitionRequestModel
    {
        public string Name { get; set; }         //展会名称

        public string HeadImg { get; set; }     //封面图地址

        public string ClassId { get; set; }     //展会分类ID

        public string StartDate { get; set; }   //开始时间

        public string EndDate { get; set; }     //截至时间

        public string Address1 { get; set; }    //展会地址1-手动输入

        public string Address2 { get; set; }    //展会地址2-地图获取

        public string Longitude { get; set; }  //经度

        public string Latitude { get; set; }   //纬度

        public string Detailes { get; set; }    //展会详情

        public List<ImageAndVideoUrl> ImageUrls { get; set; }   //图片列表

        public List<ImageAndVideoUrl> VideoUrls { get; set; }   //视频列表

        public List<ExhibitionProductClassRequestModel> ExhibitionProClass { get; set; }  //展品分类

        public List<ExhibitionTagRequestModel> ExhibitionTagCode { get; set; }   //展会标签

        public string BusinessID { get; set; }      //主办方ID

        public string BusinessName { get; set; }    //主办方名称

        public string Creater { get; set; }         //创建人ID

        public string Province { get; set; }        //省
        public string City { get; set; }            //市
        public string Area { get; set; }            //区
    }

    public class ImageAndVideoUrl
    {
        public string url { get; set; }
    }

    public class ExhibitionProductClassRequestModel
    {
        public string ClassId { get; set; }                //展品分类ID

        public string ClassName { get; set; }              //展品分类名称
    }

    public class ExhibitionTagRequestModel
    {
        public string TagName { get; set; }                  //展品标签名称 
    }

    /// <summary>
    /// 展位设置
    /// </summary>
    public class ExhibitionApplyRequestModel
    {
        public string ExhibitionCode { get; set; }  //展会ID

        public string RecruitEndTime { get; set; }  //招募截至时间(格式为 2016-09-23 12:30:45)

        public string DistributionMap { get; set; }  //展位分布图

        public string Creater { get; set; }         //创建人ID

        public List<SeatTypeRequestModel> seatSetTypes { get; set; }  //展位类型
    }
    public class SeatTypeRequestModel
    {
        public decimal SeatPrice { get; set; }       //展位费用

        public string SeatScale { get; set; }        //展位规格

        public List<SeatNoRequestModel> SeatNo { get; set; }     //展位号

        public string BaseTypeCode { get; set; }  //展位类型ID
    }
    public class SeatNoRequestModel
    {
        public string Seatno { get; set; }//展位号
    }
    /// <summary>
    /// 门票设置
    /// </summary>
    public class ExhibitionTicketRequestModel
    {
        public string ExhibitionId { get; set; }    //展会ID

        public string EnrollStartTime { get; set; } //报名开始时间

        public string EnrollEmdTime { get; set; }   //报名结束时间

        public bool NameRequire { get; set; }     //姓名是否必填

        public bool PhoneRequire { get; set; }      //手机是否必填

        public string Creater { get; set; }         //创建人ID

        public List<ExhibitionTicketsTypeRequestModel> TicketTypes { get; set; }//门票类型
    }

    /// <summary>
    /// 门票类型
    /// </summary>
    public class ExhibitionTicketsTypeRequestModel
    {
        public string ticketName { get; set; }     //门票名称

        public decimal price { get; set; }  //价格

        public int quota { get; set; }  //名额

        public string privilege { get; set; } //特权说明

        public string creater { get; set; }  //创建人ID
    }

    /// <summary>
    /// 销售设置
    /// </summary>
    public class ExhibitionMarketRequestModel
    {
        public string ExhibitionId { get; set; }    //展会ID

        public decimal LowDiscount { get; set; }     //展品最低促销比例

        public decimal SaleProportion { get; set; } //展品销售分成比例
    }

    /// <summary>
    /// 日程
    /// </summary>
    public class ExhibitionSchedule
    {
        public string ExhibitionId { get; set; } //展会ID
        public string STime { get; set; }       //日期  格式 2016-09-08

        public string StartTime { get; set; }   //开始时间 格式 09:23:21

        public string EndTime { get; set; }     //结束时间 格式 09:23:21

        public string ScheduleName { get; set; }    //日程名称

        public string ScheduleDesc { get; set; }    //日程描述

        public string Creater { get; set; }    //创建人ID
    }

    /// <summary>
    /// 展会列表
    /// </summary>
    public class MyExhibitionResponseModel
    {
        public string ExhibitionCode { get; set; }      //展会ID

        public string ExhibitionName { get; set; }      //展会名称

        public string PublishDate { get; set; }         //发布时间

        public int SellerNumber { get; set; }           //参展商个数

        public int EnrollNumber { get; set; }           //报名人数

        public string Status { get; set; }              //状态: 招展中|即将开始|已结束
    }

    /// <summary>
    /// 展会详情
    /// </summary>
    public class ExhibitionDetailsModel
    {
        public string ExhibitionId { get; set; }    //展会ID

        public string BusinessID { get; set; }      //主办方ID

        public string BusinessName { get; set; }    //主办方名称

        public string Name { get; set; }         //展会名称

        public string HeadImg { get; set; }     //封面图地址

        public string ClassId { get; set; }     //展会分类ID
        public string ClassName { get; set; }    //展会分类name

        public string StartDate { get; set; }   //开始时间

        public string EndDate { get; set; }     //截至时间

        public string Address1 { get; set; }    //展会地址1-手动输入

        public string Address2 { get; set; }    //展会地址2-地图获取

        public string Longitude { get; set; }  //经度

        public string Latitude { get; set; }   //纬度

        public string Detailes { get; set; }    //展会详情

        public decimal LowDiscount { get; set; }     //展品最低促销比例

        public decimal SaleProportion { get; set; } //展品销售分成比例

        public int RecruitStatus { get; set; }      //招募状态 0:否 1：是

        public int EnrollStatus { get; set; }       //报名状态 0:否 1：是

        public int SellerCount { get; set; }        //参展商数量

        public int EnrollUserCount { get; set; }    //用户报名数

        public int LiveCount { get; set; }          //直播互动数

        public string Province { get; set; }        //省

        public string City { get; set; }            //城市

        public string Area { get; set; }            //区域

        public List<ImageAndVideoUrlResponse> ImageUrls { get; set; }   //图片列表

        public List<ImageAndVideoUrlResponse> VideoUrls { get; set; }   //视频列表

        public List<ExhibitionProductClassRequestModel> ExhibitionProClass { get; set; }  //展品分类

        public List<ExhibitionTagRequestModel> ExhibitionTagCodeName { get; set; }   //展会标签

        public ExhibitionApplyDetailsModel ExhibitionApplys { get; set; } //展位设置列表-编辑时为空

        public List<ExhibitionTicketSetDetailsModel> ExhibitionTicketSet { get; set; } //门票设置列表-编辑时为空

        //public decimal SaleProportion { get; set; } //销售分成比例
        //public decimal LowDiscount { get; set; }    //促销比例
        public List<ExhibitionScheduleDetailsModel> ExhibitionSchedules { get; set; }   //展会日程

        public string EditorID { get; set; }      //编辑人名称：提交编辑的时候赋值
    }

    public class ImageAndVideoUrlResponse
    {
        public string Id { get; set; }

        public string Url { get; set; }
    }

    /// <summary>
    /// 管理展会
    /// </summary>
    public class ManageExhibitionRequestModel
    {
        public string ExhibitionId { get; set; }        //展会ID
        public int RecruitStatus { get; set; }         //是否接受招募 0:否 1：是
        public int EnrollStatus { get; set; }          //是否接受报名 0:否 1：是
        public string Creater { get; set; }            //创建人ID
        public string Modifier { get; set; }           //修改人
        public string EditorId { get; set; }            //修改人ID
    }

    /// <summary>
    /// 展位设置详情
    /// </summary>
    public class ExhibitionApplyDetailsModel
    {
        public string exhibitionId { get; set; }        //展会ID
        public string recruitEndTime { get; set; }  //招募截至时间(格式为 2016-09-23 12:30:45)
        public string distributionMap { get; set; }  //展位分布图
        public string editorId { get; set; }        //编辑人ID： 提交编辑的时候赋值
        public List<SeatSetTypes> seatSetTypes { get; set; }//展位类型

    }
    /// <summary>
    /// 展位类型
    /// </summary>
    public class SeatSetTypes
    {
        public string seatSetTypeId { get; set; }   //展位类型ID
        public decimal seatPrice { get; set; }       //展位费用
        public string seatScale { get; set; }        //展位规格
        public List<SeatSetNoModel> seatNo { get; set; }     //展位号
        public string baseTypeCode { get; set; }   //展位分类ID
        public string typeName { get; set; }  //展位类型名称
    }

    public class SeatSetNoModel
    {
        public string noId { get; set; }            //展位号id
        public string seatno { get; set; }          //展位号名称

        //public string seatSetId { get; set; }       //展位类型ID
    }

    /// <summary>
    /// 门票设置详情
    /// </summary>
    public class ExhibitionTicketSetDetailsModel
    {
        public string ExhibitionId { get; set; }    //展会ID

        public string ExhibitionTicketId { get; set; }  //门票设置ID

        public string EnrollStartTime { get; set; } //报名开始时间

        public string EnrollEmdTime { get; set; }   //报名结束时间

        public bool NameRequire { get; set; }     //姓名是否必填

        public bool PhoneRequire { get; set; }      //手机是否必填

        public string EditorId { get; set; }        //编辑人ID： 提交编辑的时候赋值

        public List<ExhibitionTicketsTypeDetailsModel> TicketTypes { get; set; }  //门票类型列表
    }

    /// <summary>
    /// 门票类型详情
    /// </summary>
    public class ExhibitionTicketsTypeDetailsModel
    {
        public string ticketsTypeID { get; set; }   //门票类型ID

        public string ticketName { get; set; }      //门票类型名称

        public decimal price { get; set; }          //售价

        public int quota { get; set; }              //名额

        public string privilege { get; set; }       //特权说明
    }
    
    /// <summary>
    /// 销售设置详情
    /// </summary>
    public class ExhibitionMarketDetailsModel
    {
        public string ExhibitionId { get; set; }    //展会IDyouku

        public decimal LowDiscount { get; set; }     //展品最低促销比例

        public decimal SaleProportion { get; set; } //展品销售分成比例

        public string EditorId { get; set; }        //编辑人ID： 提交编辑的时候赋值
    }

    /// <summary>
    /// 日程详情
    /// </summary>
    public class ExhibitionScheduleDetailsModel
    {
        public string ExhibitionScheduleId { get; set; }  //展会日程ID

        public string STime { get; set; }       //日期  格式 2016-09-08

        public string StartTime { get; set; }   //开始时间 格式 09:23:21

        public string EndTime { get; set; }     //结束时间 格式 09:23:21

        public string ScheduleName { get; set; }    //日程名称

        public string ScheduleDesc { get; set; }    //日程描述

        public string EditorId { get; set; }        //编辑人ID： 提交编辑的时候赋值
    }

    //订单统计
    public class OrderTotalInfo
    {
        public int OrderCount { get; set; }         //订单数

        public decimal TotalInCome { get; set; }    //总金额

        public decimal SalesCommissions { get; set; }   //销售提成

        public List<ExhibitionOrderListModel> Orders { get; set; }  //订单列表
    }

    //订单列表
    public class ExhibitionOrderListModel
    {
        public string OrderId { get; set; }           //订单ID

        public string SellerName { get; set; }        //展商名称

        public string UserName { get; set; }          //用户名称

        public string UserHeadImg { get; set; }       //用户头像

        public int TotalPay { get; set; }             //总金额

        public string CreateTime { get; set; }          //创建时间

        public string Status { get; set; }              //去提货

        public List<ProductNameModel> Products { get; set; }              //展品列表
    }

    public class ExhibitionApply
    {
        public string exhibitionApplyId { get; set; }       //展位设置ID
    }

    public class SeatNoId
    {
        public string seatNoId { get; set; }                //展位号ID
    }

    public class TicketSetId
    {
        public string exhibitionTicketSetId { get; set; }   //门票设置ID
    }

    public class ScheduleId
    {
        public string exhibitionScheduleId { get; set; }    //日程ID
    }

    public class SellerOrderCheck
    {
        public string sellerOrderId { get; set; }       //参展商id

        public int status { get; set; }                 //状态2-确认 3-拒绝
    }

    public class PaySuccessRequest
    {
        public string OrderNo { get; set; }             //订单号:订单号

        public int OrderType { get; set; }              //订单类型:随便传

        public int PayStatus { get; set; }              //支付状态：0 支付失败 1 支付成功; 
    }

    public class YXOrderRequest
    {
        public string Code { get; set; }

        public string Total { get; set; }

        public string OrderNo { get; set; }

        public string Creator { get; set; }
    }
}