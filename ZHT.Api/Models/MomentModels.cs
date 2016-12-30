using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ZHT.Api.Models
{
    //创建动态
    public class CreateMomentModel
    {
        public string Content { get; set; }                     //动态内容

        public int MomentType { get; set; }                     //发布类型： 1-主办方 2-参展商 3-用户

        public string ExhibitionId { get; set; }                //展会ID

        public string CreaterId { get; set; }                   //创建人ID

        public List<ImageAndVideoUrl> ImageUrls { get; set; }   //图片列表 
    }

    //回复动态
    public class ReplayMomentRequestModel
    {
        public string MomentId { get; set; }            //动态ID

        public string Content { get; set; }             //回复内容

        public string CreaterId { get; set; }              //回复者ID
    }

    //删除动态
    public class DeleteMomentModel
    {
        public string MomentId { get; set; }            //动态ID
    }

    //动态详情
    public class MomentDeatilsModel
    {
        public string MomentId { get; set; }           //动态ID

        public string CreaterId { get; set; }           //创建人ID

        public string Content { get; set; }             //内容

        public bool FollowMoment { get; set; }          //是否关注

        public string PubTime { get; set; }             //发布时间

        public int FollowNumber { get; set; }           //收藏数

        public int ReplayNumber { get; set; }           //回复数

        public List<ImageAndVideoUrlResponse> ImageUrls { get; set; }   //图片列表

        public List<FollowList> Follows { get; set; }   //点赞列表

        public List<ReplayList> Replays { get; set; }   //回复列表

    }
    //回复
    public class ReplayList
    {
        public string ReplayId { get; set; }            //回复ID

        public string ReplyTime { get; set; }           //回复时间

        public string NickName { get; set; }            //点赞人昵称

        public string ReplyContent { get; set; }        //回复内容

        public string CreaterId { get; set; }           //回复人ID
    }

    //删除动态
    public class DeleteMomentReplayModel
    {
        public string ReplayId { get; set; }
    }

    //点赞
    public class FollowList
    {
        public string FollowId { get; set; }            //点赞ID

        public string CreaterId { get; set; }           //点赞人

        public string NickName { get; set; }            //点赞人昵称

        public string FollowTime { get; set; }          //点赞时间
    }

    //动态点赞
    public class FollowMomentModel
    {
        public string MomentId { get; set; }            //动态ID

        public string FollowUserId { get; set; }        //点赞人ID
    }

    //取消动态点赞
    public class DeleteMomentFollowModel
    {
        public string FollowId { get; set; }            //点赞ID
    }

    public class RemarkMomentModel
    {
        public string ExhibitionId { get; set; }        //展会ID

        public string LoginUserId { get; set; }         //登陆用户ID
    }

    public class UserInfoModel
    {
        public string UserId { get; set; }              //用户ID

        public string UserName { get; set; }            //用户名

        public string UserLoginName { get; set; }       //登录名

        public string NickName { get; set; }            //昵称
    }
}