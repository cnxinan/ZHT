using System;
using System.Collections.Generic;

namespace ZHT.Api.Models
{
    public class SearchExhibitionRequestModel
    {
        public string CreaterId { get; set; }           //主办方ID  可为空

        public string SellerId { get; set; }            //参展商ID  可为空

        public string UserId { get; set; }              //用户ID    可为空

        public string ExhibitionTypeId { get; set; }    //展会类型ID 可为空

        public int ExhibitionStatus { get; set; }       //展会状态：0-未结束 1-已结束 2-全部

        public int RecruitStatus { get; set; }          //招募状态: 0-未结束 1-已结束 2-所有

        public int EnrollStatus { get; set; }           //报名状态: 0-未结束 1-已结束 2-所有

        public int OrderType { get; set; }              //排序规则: 0-无规则 1-最新 2-热门 3-最近 百度地图
    }

    //展会搜索返回值
    public class SearchExhibitionResponseModel
    {
        public string ExhibitionId { get; set; }        //展会ID

        public string ExhibitionName { get; set; }      //展会名称

        public string HeadImg { get; set; }             //展会图片

        public string CreationDate { get; set; }        //创建时间

        public string Status { get; set; }              //展会状态

        public int SellerNumber { get; set; }           //参展商数量

        public int UserNumber { get; set; }             //报名数量

        public List<TagName> Tags { get; set; }         //展会标签

        public string City { get; set; }                //城市

        public string Area { get; set; }                //区域
    }

    public class TagName
    {
        public string Id { get; set; }                  //展会标签ID

        public string Name { get; set; }                //标签名称    
    }

    //展商列表
    public class SellerListModel
    {
        public int TotalNumber { get; set; }            //报名总数

        public int NoConfirmNumber { get; set; }        //待确认数

        public int ConfirmedNumber { get; set; }        //确认数

        public int RefusedNumber { get; set; }          //拒绝数

        public List<SearchSellerResponseModel> Sellers { get; set; }    //展商列表
    }

    //参展商列表返回值
    public class SearchSellerResponseModel
    {
        public string ExhibitionId { get; set; }        //展会ID

        public string SellerOrderId { get; set; }       //参展订单ID 

        public string SellerName { get; set; }          //展商名称

        public string SellerHeadImg { get; set; }       //展商头像

        public string SellerCode { get; set; }          //远鑫平台商家ID       

        public string Status { get; set; }              //报名状态 

        public List<SellerSeatModel> Seats { get; set; } //展位列表
    }

    //参展商详情
    public class SellerDetailsModel
    {
        public string SellerOrderId { get; set; }            //参展订单ID
        public string SellerName { get; set; }              //展商名称
        public string SellerCode { get; set; }          //远鑫平台商家ID
        public string SellerHeadImg { get; set; }       //展商头像
        public string Name { get; set; }                //姓名

        public string Phone { get; set; }               //电话

        public string Status { get; set; }              //报名状态 

        public string SellerInfo { get; set; }          //商家介绍

        public List<SellerSeatModel> Seats { get; set; }     //展位列表

        public List<ExhibitonProductModel> Products { get; set; } //展品列表
    }

    //展位号
    public class SellerSeatModel
    {
        public string SeatNo { get; set; }              //展位号

        public decimal Price { get; set; }              //展位费用
    }

    //用户报名列表
    public class EnrollUserListModel
    {
        public int TotalNumber { get; set; }                        //人数

        public decimal TotalPrice { get; set; }                     //总金额

        public List<EnrolledlUserModel> EnrollUsers { get; set; }         //报名列表
    }
    //用户
    public class EnrolledlUserModel
    {
        public string NickName { get; set; }            //昵称

        public string Name { get; set; }                //姓名

        public string UserHeadImg { get; set; }         //用户头像

        public string Phone { get; set; }               //手机号码

        public string enrollDate { get; set; }          //报名时间

        public string TicketName { get; set; }          //门票类型

        public decimal Price { get; set; }              //价格

        public string Status { get; set; }              //状态
    }

    //动态列表
    public class MomentModel
    {
        public string MomentId { get; set; }           //动态ID

        public string CreaterId { get; set; }          //创建人ID

        public string UserHeadImg { get; set; }		    //用户头像	

        public string NickName { get; set; }            //用户昵称

        public string Content { get; set; }             //内容

        public bool IsFollowMoment { get; set; }        //是否关注

        public string PubTime { get; set; }             //发布时间

        public int FollowNumber { get; set; }           //收藏数

        public int ReplayNumber { get; set; }           //回复数

        public int MomentNoReadCount { get; set; }      //动态未读条数

        public List<ImageAndVideoUrlResponse> ImageUrls { get; set; }   //图片列表

        public List<FollowList> Follows { get; set; }   //点赞列表

        public List<ReplayList> Replays { get; set; }   //回复列表
    }

    //我的订单列表
    public class OrderListModel
    {
        public string OrderId { get; set; }             //订单ID

        public string OrderNo { get; set;}              //订单号

        public string SellerName { get; set; }          //展商名称

        public string SellerHeadImg { get; set; }       //展商头像

        public int TotalPay { get; set; }               //总金额

        public string CreateTime { get; set; }          //创建时间        

        public string Status { get; set; }              //状态名称

        public List<ProductNameModel> Products { get; set; }              //展品列表

        public List<SellerSeatModel> Seats { get; set; }    //展位列表
    }

    public class ProductNameModel
    {
        public string Name { get; set; }                  //展品名称
    }

    //订单详情
    public class OrderDetailsInfoModel
    {
        public string OrderNo { get; set; }             //订单号

        public string UserHeadImg { get; set; }         //用户头像

        public string SellerName { get; set; }          //展商名称

        public int TotalPay { get; set; }               //总金额

        public string CreateTime { get; set; }          //创建时间

        public string Status { get; set; }              //去提货

        public List<OrderDetailsModel> OrderDetails { get; set; }   //订单明细

        public List<SellerSeatModel> Seats { get; set; }    //展位列表
    }
}