using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZHT.Api.Models
{
    //添加收藏
    public class AddFavoriteMode
    {
        public string TargetId { get; set; }        // 展会/展品ID

        public int TypeId { get; set; }             // 收藏类型 1:展会 2：展品

        public string UserId { get; set; }          // 用户ID
    }

    //报名表
    public class EnrollUserModel
    {
        public string ExhibitionId { get; set; }    //展会ID

        public string NickName { get; set; }        //昵称        

        public string Name { get; set; }            //姓名

        public string Phone { get; set; }           //手机

        public string Remark { get; set; }          //备注

        public string UserId { get; set; }          //用户ID

        public string TicketTypeCode { get; set; }  //门票类型ID
    }

    //下单
    public class BuyGoodsModel
    {
        public string ExhibitionId { get; set; }        //展会ID

        public string OrderNumber { get; set; }     //订单号

        public string BusinessUserCode { get; set; }    //下单人ID

        public string CustomerName { get; set; }    //下单人名称

        public string Telephone { get; set; }       //下单人电话

        public int PyteType { get; set; }           //支付方式

        public int TotalCharge { get; set; }        //总金额

        public List<OrderDetailsModel> OrderDetails { get; set; }   //产品明细

    }    

    public class OrderDetailsModel
    {
        public string ProductId { get; set; }       //展会通产品ID

        public string GoodsCode { get; set; }       //远鑫平台商品编码

        public string GoodsName { get; set; }       //产品名称

        public string ProductImg { get; set; }      //产品图片

        public int GoodsCount { get; set; }         //购买数量

        public int Charge { get; set; }             //小计        
    }

    //门票
    public class TicketModel
    {
        public string ExhibitionId { get; set; }    //展会ID
        public string ExhibitionLogo { get; set; }  //展会图片
        public string ExhibitionName { get; set; }  //展会名称
        public string StartTime { get; set; }       //展会开始时间
        public string EndTime { get; set; }         //展会结束时间
        public string Longitude { get; set; }      //经度
        public string Latitude { get; set; }       //纬度
        public string EnrollTime { get; set; }      //报名时间
        public string TicketId { get; set; }        //门票ID
        public decimal Price { get; set;}           //门票价格        
        public string TicketName { get; set; }      //门票名称
        public string BusinessName { get; set; }     //主办方名称
        public string City { get; set; }                //城市
        public string Area { get; set; }                //区域
        public string OrderNo { get; set; }             //订单号
    }

    //门票详情
    public class TicketDetailsModel
    {
        public string ExhibitionId { get; set; }    //展会ID
        public string ExhibitionName { get; set; }  //展会名称
        public string PwdNumber { get; set; }       //数字码
        public string NickName { get; set; }        //昵称
        public string Phone { get; set; }           //手机号
        public int Status { get; set; }             //门票状态：0-未验票 1-已验票 
        public string StartTime { get; set; }       //展会开始时间
        public string EndTime { get; set; }         //展会结束时间
        public string Address1 { get; set; }        //展会地址1-手动输入
        public string Address2 { get; set; }        //展会地址2-地图获取
        public string Longitude { get; set; }      //经度
        public string Latitude { get; set; }       //纬度
        public string Detailes { get; set; }        //展会详情
        public string OrderNo { get; set; }         //订单号
        public List<ImageAndVideoUrlResponse> ImageUrls { get; set; }   //图片列表
        public List<ImageAndVideoUrlResponse> VideoUrls { get; set; }   //视频列表
    }

    public class MyExhibition
    {
        public string FavoriteId { get; set; }      //收藏ID

        public string ExhibitionId { get; set; }    //展会ID

        public string HeadImg { get; set; }         //封面图

        public string ExhibitionName { get; set; }  //展会名称

        public string StartTime { get; set; }       //展会开始时间

        public string EndTime { get; set; }         //展会结束时间

        public string Longitude { get; set; }      //经度

        public string Latitude { get; set; }       //纬度

        public decimal LowestTicketPrice { get; set; } //最低票价

        public string Tags { get; set; }            //标签，逗号分割

        public int LivingCount { get; set; }        //互动人数

        public string City { get; set; }                //城市

        public string Area { get; set; }                //区域
    }

    public class MyProduct
    {
        public string FavoriteId { get; set; }      //收藏ID

        public string ExhibitionId { get; set; }    //展会ID

        public string ProductId { get; set; }       //展品ID

        public string HeadImg { get; set; }         //封面图

        public string Name { get; set; }            //展品名称

        public decimal OldPrice { get; set; }       //原价

        public decimal Price { get; set; }          //现价

        public bool IsTimeOut { get; set; }         //是否过期: true-过期 false-未过期
    }

    public class Favorite
    {
        public string userId { get; set; }    //用户id
        public string favoriteId { get; set; } //收藏的 展会id/展品id
    }

    //商品列表
    public class ProductModel
    {
        public string ExhibitonProductId { get; set; }  //展品ID

        public string ExhibitonProductName { get; set; }//展品名称 

        public string ProductImage { get; set; } //展品图片

        public decimal OldPrice { get; set; }           //原价

        public decimal Price { get; set; }              //现价

    }

    public class MsgListModel
    {
        public string Title { get; set; }           //消息标题

        public string SubTitle { get; set; }        //副标题

        public string MsgDate { get; set; }         //消息发布时间
    }
}