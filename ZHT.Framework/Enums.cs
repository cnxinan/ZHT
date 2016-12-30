using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Framework
{
    public enum SellerOrderStatus
    {
        NoPay = -1,         //未支付

        NoConfirm = 0,      //未确认

        Normal = 1,         //正常

        Reject = 2          //已拒绝
    }

    public enum EnrollOrderStatus
    {
        NoPay = -1,         //未支付

        NoConfirm = 0,      //未验票

        Confirmed = 1       //已验票
    }

    public enum ProductOrderStatus
    {
        NoPay = -1,         //未支付

        NoPickUp = 1,       //未提货

        PickUp = 2          //已提货
    }

    public enum OrderType
    {
        SellerOrder = 1,   //参展订单

        EnroolOrder = 2,   //门票订单

        ProductOrder = 3,  //购物订单
    }

    public enum AttType
    {
        ExhibitionLogo = 19,        //展会封面图

        DistributionMap = 20,       //展位分布图

        ExhibitionIntroImg = 21,    //展会详情图片

        ExhibitionIntroVideo = 22,  //展会详情视频

        ProductImage = 23,          //展品封面图

        MomentImg = 24              //动态多图
    }
}
