/*
动态 控制器 
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using ZHT.Service;
using ZHT.Api.Models;
using ZHT.Data.Models;
using ZHT.Framework;


namespace ZHT.Api.Controllers
{
    [Authorize]
    public class MomentController : BaseApiController
    {
        private readonly IMomentReplyService _momentReplyService;
        private readonly IMomentService _momentService;
        private readonly IFollowMomentService _followMomentService;
        private readonly IAttachmentService _attachmentService;
        private readonly IAttachmentTypeService _attachmentTypeService;
        private readonly IUserInfoService _userInfoService;

        public MomentController(IMomentReplyService momentReplyService, IMomentService momentServicem, IMomentReplyService myFavoritesService, IFollowMomentService followMomentService, IAttachmentService attachmentService, IAttachmentTypeService attachmentTypeService, IUserInfoService userInfoService)
        {
            _momentReplyService = momentReplyService;
            _momentService = momentServicem;
            _followMomentService = followMomentService;
            _attachmentService = attachmentService;
            _attachmentTypeService = attachmentTypeService;
            _userInfoService = userInfoService;
        }

        /// <summary>
        /// 动态发布
        /// </summary>
        /// <returns></returns>
        [Route("api/Moment/CreateMoment")]
        [HttpPost]
        public IHttpActionResult CreateMoment(CreateMomentModel requestModel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                requestModel.CreaterId = CurrentUserId;

                Moment moment = new Moment()
                {
                    id = CommonHelper.GetGuid(),
                    pubtime = DateTime.Now,
                    pubcontent = requestModel.Content,
                    types = requestModel.MomentType,
                    publishercode = requestModel.CreaterId,
                    exhibitioncode = requestModel.ExhibitionId,
                    creater = requestModel.CreaterId,
                    creattime = DateTime.Now,
                    modifier = requestModel.CreaterId,
                    modifiytime = DateTime.Now,
                    isdel = 0,
                    viewUserIds = requestModel.CreaterId
                };

                // 添加动态图片
                if (HasAttachmentType(AttType.MomentImg) && requestModel.ImageUrls != null)
                {
                    foreach (var imgItem in requestModel.ImageUrls)
                    {
                        Attachment attachment = new Attachment();

                        attachment.Code = CommonHelper.GetGuid();
                        attachment.ResourceID = moment.id;
                        attachment.CnName = "动态图片";
                        attachment.URL = imgItem.url;
                        attachment.Creator = requestModel.CreaterId;
                        attachment.VersionStartTime = DateTime.Now;
                        attachment.VersionEndTime = DateTime.MaxValue;
                        attachment.ValidStatus = true;
                        attachment.AttachmentTypeCode = CommonHelper.GetEnumValue<AttType>(AttType.MomentImg);

                        _attachmentService.InsertAttachment(attachment);
                    }
                }


                _momentService.Insert(moment);

                result.Flag = ResultFlag.Successful;
                result.Data = moment.id;
            }
            catch (Exception ex)
            {
                result.Flag = ResultFlag.Error;
                result.Data = null;
                result.Messages = ex.Message;
                if (ex.InnerException != null)
                {
                    result.Messages = ex.InnerException.ToString();
                }
            }
            return Ok(result);
        }

        /// <summary>
        /// 动态回复
        /// </summary>
        /// <returns></returns>
        [Route("api/Moment/ReplyMoment")]
        [HttpPost]
        public IHttpActionResult ReplyMoment(ReplayMomentRequestModel requestModel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                requestModel.CreaterId = CurrentUserId;

                MomentReply model = new MomentReply()
                {
                    id = CommonHelper.GetGuid(),
                    replytime = DateTime.Now,
                    replycontent = requestModel.Content,
                    momentcode = requestModel.MomentId,
                    creater = requestModel.CreaterId,
                    creattime = DateTime.Now,
                    modifier = requestModel.CreaterId,
                    modifiytime = DateTime.Now,
                    isdel = 0
                };

                _momentReplyService.Insert(model);

                result.Flag = ResultFlag.Successful;
                result.Data = model.id;
                return Ok(result);
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
        /// 删除动态
        /// </summary>
        /// <returns></returns>
        [Route("api/Moment/DeleteMoment")]
        [HttpPost]
        public IHttpActionResult DeleteMoment(DeleteMomentModel requestModel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var moment = _momentService.GetModelById(requestModel.MomentId);

                moment.isdel = 1;
                moment.modifiytime = DateTime.Now;
                moment.modifier = CurrentUserId;
                _momentService.Update(moment);

                result.Flag = ResultFlag.Successful;
                result.Data = true;
                return Ok(result);
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
        /// 动态点赞-关注
        /// </summary>
        /// <returns></returns>
        [Route("api/Moment/FollowMoment")]
        [HttpPost]
        public IHttpActionResult FollowMoment(FollowMomentModel requestModel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                requestModel.FollowUserId = CurrentUserId;

                string modelId = string.Empty;
                var followMoment = _followMomentService.GetModelByMomentIdAndUserId(requestModel.MomentId, requestModel.FollowUserId);
                if (followMoment == null)
                {
                    var moment = _momentService.GetModelById(requestModel.MomentId);

                    FollowMoment model = new FollowMoment()
                    {
                        id = CommonHelper.GetGuid(),
                        followtime = DateTime.Now,
                        followusercode = requestModel.FollowUserId,
                        exhibitioncode = moment.exhibitioncode,
                        momentcode = requestModel.MomentId,
                        isdel = 0
                    };

                    modelId = model.id;
                    _followMomentService.Insert(model);
                }
                else
                {
                    if (followMoment.isdel == 0)
                    {
                        result.Flag = ResultFlag.Error;
                        result.Messages = "您已关注动态，请勿重复关注";
                        return Ok(result);
                    }
                    else
                    {
                        followMoment.isdel = 0;
                        _followMomentService.Update(followMoment);
                        modelId = followMoment.id;
                    }
                }

                result.Flag = ResultFlag.Successful;
                result.Data = modelId;
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
        /// 删除动态回复
        /// </summary>
        /// <returns></returns>
        [Route("api/Moment/DeleteMomentReplay")]
        [HttpPost]
        public IHttpActionResult DeleteMomentReplay(DeleteMomentReplayModel requestModel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var momentReplay = _momentReplyService.GetModelById(requestModel.ReplayId);

                momentReplay.isdel = 1;
                momentReplay.modifier = CurrentUserId;
                momentReplay.modifiytime = DateTime.Now;
                _momentReplyService.Update(momentReplay);

                result.Flag = ResultFlag.Successful;
                result.Data = true;
                return Ok(result);
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
        /// 取消动态关注
        /// </summary>
        /// <returns></returns>
        [Route("api/Moment/DeleteMomentFollow")]
        [HttpPost]
        public IHttpActionResult DeleteMomentFollow(DeleteMomentFollowModel requestModel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                var follow = _followMomentService.GetModelById(requestModel.FollowId);

                follow.isdel = 1;
                _followMomentService.Update(follow);

                result.Flag = ResultFlag.Successful;
                result.Data = true;
                return Ok(result);
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
        /// 获取展会所有动态
        /// </summary>
        /// <param name="exhibitionId"></param>
        /// <returns></returns>
        [Route("api/Exhibition/Moments/{exhibitionId}/{loginUserId}")]
        [HttpGet]
        public IHttpActionResult Moments(string exhibitionId, string loginUserId)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                List<MomentModel> model = new List<MomentModel>();

                var moments = _momentService.GetListByExhibitionId(exhibitionId);


                if (moments.Count > 0)
                {
                    foreach (var moment in moments)
                    {
                        var userInfo = _userInfoService.GetModelById(moment.creater);

                        MomentModel modelInfo = new MomentModel()
                        {
                            MomentId = moment.id,
                            PubTime = moment.pubtime.ToString(),
                            UserHeadImg = userInfo == null ? CommonHelper.TempHeadImg() : userInfo.HeadImage,
                            Content = moment.pubcontent,
                            FollowNumber = moment.followmoment.Count,
                            ReplayNumber = moment.momentreply.Count,
                            CreaterId = moment.creater,
                            MomentNoReadCount = 0,
                            NickName = userInfo == null ? CurrentUserName : userInfo.Nickname
                        };

                        modelInfo.Replays = new List<ReplayList>();
                        moment.momentreply.Where(t => t.isdel == 0).ToList().ForEach(p =>
                        {
                            userInfo = _userInfoService.GetModelById(p.creater);

                            modelInfo.Replays.Add(new ReplayList()
                            {
                                ReplayId = p.id,
                                ReplyTime = p.replytime.ToString(),
                                ReplyContent = p.replycontent,
                                CreaterId = p.creater,
                                NickName = userInfo == null ? "" : userInfo.Nickname
                            });
                        });

                        modelInfo.Follows = new List<FollowList>();
                        moment.followmoment.Where(t => t.isdel == 0).ToList().ForEach(p =>
                        {
                            if (p.followusercode == loginUserId)
                            {
                                modelInfo.IsFollowMoment = true;
                            }

                            userInfo = _userInfoService.GetModelById(p.followusercode);

                            modelInfo.Follows.Add(new FollowList()
                            {
                                FollowId = p.id,
                                FollowTime = p.followtime.ToString(),
                                CreaterId = p.followusercode,
                                NickName = userInfo == null ? "" : userInfo.Nickname
                            });
                        });

                        //获取动态图片
                        modelInfo.ImageUrls = new List<ImageAndVideoUrlResponse>();

                        var atts = _attachmentService.GetListByResourceIdAndType(moment.id, ((int)AttType.MomentImg).ToString());

                        foreach (var att in atts)
                        {
                            modelInfo.ImageUrls.Add(new ImageAndVideoUrlResponse { Id = att.Code, Url = att.URL });
                        }

                        model.Add(modelInfo);
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
        /// 获取展会未读动态条数
        /// </summary>
        /// <param name="exhibitionId"></param>
        /// <returns></returns>
        [Route("api/Moments/NoReadMountCount/{exhibitionId}")]
        [HttpGet]
        public IHttpActionResult NoReadMountCount(string exhibitionId)
        {
            int noViewdCount = _momentService.GetNoViewdMomentCount(exhibitionId, CurrentUserId);
            ClientApiResult result = new ClientApiResult();
            try
            {
                result.Flag = ResultFlag.Successful;
                result.Data = noViewdCount;

                return Ok(result);
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
        /// 标记所有未读动态
        /// </summary>
        /// <param name="exhibitionId"></param>
        /// <param name="loginUserId"></param>
        /// <returns></returns>
        [Route("api/Exhibition/RemarkAllMoment")]
        [HttpPost]
        public IHttpActionResult RemarkAllMoment(RemarkMomentModel requestModel)
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                if (requestModel != null)
                {
                    string addUserId = "," + CurrentUserId;

                    var momentList = _momentService.GetNoViewdMomentList(requestModel.ExhibitionId, CurrentUserId);

                    momentList.ForEach(p =>
                    {
                        p.viewUserIds += addUserId;
                        p.modifier = CurrentUserId;
                        p.modifiytime = DateTime.Now;
                        _momentService.Update(p);
                    });

                    result.Flag = ResultFlag.Successful;
                    result.Data = true;
                }
                else
                {
                    result.Flag = ResultFlag.DataNotExist;
                    result.Data = "传入参数为空";
                }

                return Ok(result);
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
        /// 获取用户信息
        /// </summary>
        /// <returns></returns>
        [Route("api/Exhibition/GetUserInfo")]
        [HttpGet]
        public IHttpActionResult GetUserInfo()
        {
            ClientApiResult result = new ClientApiResult();
            try
            {
                UserInfoModel model = new UserInfoModel()
                {
                    UserId = CurrentUserId,
                    UserName = CurrentUserName,
                    UserLoginName = CurrentLoginName
                };

                var user = _userInfoService.GetModelById(model.UserId);
                model.NickName = user == null ? "" : user.Nickname;

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
