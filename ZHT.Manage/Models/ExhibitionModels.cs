using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZHT.Manage.Models
{
    public class ExhibitionListModel
    {
        public string ExhibitionCode { get; set; }      //展会ID
        public string HeadImg { get; set; }             //展会logo
        public string ExhibitionName { get; set; }      //展会名称
        public string TimeRange { get; set; }           //发布时间
        public string Address { get; set; }             //展会地址
        public int SellerNumber { get; set; }           //参展商个数
        public int EnrollNumber { get; set; }           //报名人数
        public int MomentCount { get; set; }            //动态数
        public int FollowCount { get; set; }            //收藏数
        public string Status { get; set; }              //状态: 招展中|即将开始|已结束
        public string PublishDate { get; set; }         //发布时间
    }

    public class ExhibitionDeatils
    {
        public string ExhibitionId { get; set; }        //展会ID
        public string Name { get; set; }                //展会名称
        public string TimeRange { get; set; }           //展会时间段
        public string Address { get; set; }             //展会地点
        public int SellerCount { get; set; }            //参展商家数
        public int UserCount { get; set; }              //报名用户数
        public int MomentCount { get; set; }            //动态数
        public int FollowCount { get; set; }            //收藏数
        public decimal LowDiscount { get; set; }        //展品最低折扣
        public decimal SaleProportion { get; set; }     //销售分成比例
        public string HeadImg { get; set; }             //展会LOGO
        public string ExhibitionIntro { get; set; }     //展会详情文字
        public List<IntroImg> IntroImgs { get; set; }   //详情图片列表
        public string SeatSetImg { get; set; }          //展位分布图
        public List<SeatSet> SeatSets { get; set; }     //展位类型  
        public List<TicketIntro> TicketIntros { get; set; } //门票详情
    }

    public class IntroImg
    {
        public string ImgUr { get; set; }               //展会详情图片
    }

    public class SeatSet
    {
        public string SeatName { get; set; }            //展位类型名称
        public string SeatPrice { get; set; }           //展位价格
        public List<SeatNo> SeatNos { get; set; }       //展位号
    }

    public class SeatNo
    {
        public string SeatNoName { get; set; }
    }

    public class TicketIntro
    {
        public string TicketTypeName { get; set; }      //门票类型名
        public string TicktePrice { get; set; }         //门票价格
        public string TicketPrivilege { get; set; }     //门票说明
    }

    public class BaseTypeModel
    {
        public string TypeId { get; set; }              //类型主键
        public string ClassCode { get; set; }           //分类code
        public string ClassName { get; set; }            //分类名称
    }

    public class EnrollUserListModel
    {
        public string EnrollUserId { get; set; }        //ID
        public string Name { get; set; }                //姓名
        public string Phone { get; set; }               //手机号
        public string TicketName { get; set; }          //门票名称
        public string Price { get; set; }               //价格
        public string CreateDate { get; set; }          //报名时间
        public string Status { get; set; }              //门票状态
    }

    public class MomentListModel
    {
        public string NickName { get; set; }            //用户昵称
        public string Logo { get; set; }                //用户头像
        public string Moment { get; set; }              //动态详情
        public List<ImgUrl> Imgs { get; set; }          //动态图片
        public string PublishTime { get; set; }          //发布时间
        public int FollowCount { get; set; }            //关注数
        public int ReplayCount { get; set; }            //回复数
    }

    public class ImgUrl
    {
        public string Url { get; set; }
    }
}