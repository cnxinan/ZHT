using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZHT.Api.Models
{
    //新增参展订单
    public class CreateSellerOrderModel
    {
        public string SeatSetTypeId { get; set; }       //展位设置ID

        public string SellerName { get; set; }          //展商名称

        public string SName { get; set; }                 //姓名

        public string SellerPhone { get; set; }         //手机号

        public decimal Amount { get; set; }             //总价格

        public string PayType { get; set; }             //支付方式

        public string PayAccount { get; set; }          //支付账号?

        public string SellerID { get; set; }            //远鑫平台报名商家ID

        public string OrderNo { get; set; }             //订单号

        public string ExhibitionId { get; set; }        //展会ID

        public string Sellerintro { get; set; }         //参展商介绍

        public string Creater { get; set; }             //创建人ID

        public List<SeatModel> Seats { get; set; }      //所选展位号
    }

    public class SeatModel
    {
        public string SeatId { get; set; }              //展位号ID
    }

    //展品分类
    public class ProductTypeModel
    {
        public string ProductTypeId { get; set; }       //展品分类ID

        public string ProductTypeName { get; set; }     //展品分类名称
    }

    //产品列表
    public class GoodsistModel
    {
        public string GoodsCode { get; set; }           //远鑫产品ID
        public string GoodsName { get; set; }         //产品名称 
        public int? OldPrice { get; set; }              //产品原价
        public int? Price { get; set; }                 //产品价格
        public int GoodsNumber { get; set; }          //产品数量
        public string GoodsTypeCode { get; set; }       //产品分类ID
        public string GoodsTypeName { get; set; }     //产品分类名称
        public string UnitCode { get; set; }            //产品单位编码
        public string UnitName { get; set; }            //产品单位名称
        public string HeadImg { get; set; }             //产品图片
        public string GoodsIntro { get; set; }        //产品详情 
        public List<ImageAndVideoUrl> GoodsImgs { get; set; } //产品图集
    }

    //添加参展商品
    public class CreateProductModel
    {
        public string ExhibitionId { get; set; }        //展会ID
        public string ProductTypeId { get; set; }       //产品类型ID
        public string ProductId { get; set; }           //远鑫产品ID
        public decimal Price { get; set; }              //现价
        public int Quantity { get; set; }               //数量
    }

    public class EditProductModel
    {
        public string ProductId { get; set; }           //展品ID
        public string ProductTypeId { get; set; }       //产品类型ID
        public decimal Price { get; set; }              //现价
        public int Quantity { get; set; }               //数量
    }

    //参展商品
    public class ExhibitonProductModel
    {
        public string ExhibitonProductId { get; set; }  //展品ID

        public string ExhibitonProductName { get; set; }//展品名称 

        public string ProductImage { get; set; } //展品图片

        public List<ImageAndVideoUrl> PImages { get; set; } //展品多图

        public decimal OldPrice { get; set; }           //原价

        public decimal Price { get; set; }              //现价

        public int PStatus { get; set; }                 //上下架状态  0 下架 1 上架

        public string ProductCode { get; set; }         //远鑫平台产品ID

        public string Unit { get; set; }                //单位

        public int Quantity { get; set; }               //数量

        public string ProductDetails { get; set; }      //展品详情

        public string ProductTypeId { get; set; }       //产品类型ID

        public string ProductTypeName { get; set; }    //产品类型名称
    }

    //展品详情
    public class ExhibitonProductDetailModel
    {
        public string ProductName { get; set; }         //展品名称

        public string ProductImage { get; set; }        //展品图片

        public List<ImageAndVideoUrl> PImages { get; set; } //展品多图

        public string ProductTypeId { get; set; }       //产品类型ID

        public string ProductId { get; set; }           //产品ID

        public string ProductCode { get; set; }         //远鑫平台产品ID

        public string Unit { get; set; }                //单位

        public decimal OldPrice { get; set; }           //原价

        public decimal Price { get; set; }              //现价

        public int Quantity { get; set; }               //数量

        public string ProductDetails { get; set; }      //新增展品详情

        public string SellerName { get; set; }          //展商名称

        public string SellerImg { get; set; }           //展商图片

        public List<SellerSeatModel> Seats { get; set; } //展位列表
    }

    public class DeleteProduct
    {
        public string exhibitionProductId { get; set; } //展品ID
    }

    //订单统计
    public class SellerOrderTotalInfo
    {
        public int OrderCount { get; set; }         //订单数

        public decimal TotalInCome { get; set; }    //总金额

        public decimal SalesCommissions { get; set; }   //销售提成

        public List<SellerOrderListModel> Orders { get; set; }  //订单列表
    }

    //订单列表
    public class SellerOrderListModel
    {
        public string OrderId { get; set; }             //订单ID

        public string SellerName { get; set; }          //展商名称

        public string UserHeadImg { get; set; }		    //用户头像	

        public string UserName { get; set; }            //用户名称

        public int TotalPay { get; set; }               //总金额

        public string CreateTime { get; set; }          //创建时间

        public string Status { get; set; }              //去提货

        public int ProductCount { get; set; }           //展品数量

        public string ProductName { get; set; }         //展品名称
    }

    public class EditSellerIntroModel
    {
        public string ExhibitionId { get; set; }        //展会ID

        public string SellerIntro { get; set; }         //展商介绍
    }
}