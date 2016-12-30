using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZHT.Manage.Models
{
    public class ProductListModel
    {
        public string ExhibitionProductId { get; set; } //展会通展品ID

        public string SellerName { get; set; }          //商家名称

        public string ProductName { get; set; }         //商品名称

        public string ProductClass { get; set; }        //商品分类

        public string NPrice { get; set; }              //现价

        public string HaveSales { get; set; }           //是否售罄
    }

    public class ProductModel
    {
        public string HeadImg { get; set; }             //商品图片

        public string ProductName { get; set; }         //商品名称

        public string Unit { get; set; }                //单位

        public string ProductClass { get; set; }        //商品分类

        public string NPrice { get; set; }              //现价

        public string OPrice { get; set; }              //原价

        public int Count { get; set; }                  //数量

        public string ProductIntro { get; set; }        //商品详情
    }
}