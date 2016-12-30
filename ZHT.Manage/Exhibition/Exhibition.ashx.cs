using System.Collections.Generic;
using System.Web;
using System.Linq;
using ZHT.Service;
using Autofac;
using ZHT.Framework;
using ZHT.Manage.Models;
using System.Data;
using System;

namespace ZHT.Manage.Exhibition
{
    /// <summary>
    /// Summary description for Exhibition
    /// </summary>
    public class Exhibition : IHttpHandler
    {

        private int exhibitionType = 0;
        private readonly IExhibitionService _exhibitionService = DIConfig.container.Resolve<IExhibitionService>();
        private readonly IExhibitionProductClassService _exhibitionProductClassService = DIConfig.container.Resolve<IExhibitionProductClassService>();
        private readonly IEnrollUserService _enrollUserService = DIConfig.container.Resolve<IEnrollUserService>();
        private readonly IMomentService _momentService = DIConfig.container.Resolve<IMomentService>();
        private readonly IAttachmentTypeService _attachmentTypeService = DIConfig.container.Resolve<IAttachmentTypeService>();
        private readonly IAttachmentService _attachmentService = DIConfig.container.Resolve<IAttachmentService>();
        private readonly IUserInfoService _userInfoService = DIConfig.container.Resolve<IUserInfoService>();

        public void ProcessRequest(HttpContext context)
        {
            string result = "";

            if (context.Request["type"] != null)
            {
                if (context.Request["type"].ToString().Equals("GetList", System.StringComparison.InvariantCultureIgnoreCase))
                {
                    if (context.Request["ExhibitionType"] != null)
                    {
                        exhibitionType = int.Parse(context.Request["ExhibitionType"]);
                    }

                    if (context.Request["PageSize"] != null
                        && context.Request["PageIndex"] != null
                        && context.Request["Title"] != null)
                    {
                        result = GetExhibitionList(
                                  int.Parse(context.Request["PageSize"].ToString()),
                                  int.Parse(context.Request["PageIndex"].ToString()),
                                  context.Request["Title"].ToString());
                    }
                }
                else if (context.Request["type"].ToString().Equals("getEInfo", System.StringComparison.InvariantCultureIgnoreCase))
                {
                    if (context.Request["ExhibitionId"] != null)
                    {
                        result = GetExhibitionInfo(context.Request["ExhibitionId"].ToString());
                    }
                }
                else if (context.Request["type"].ToString().Equals("GetClassList", System.StringComparison.InvariantCultureIgnoreCase))
                {
                    if (context.Request["ExhibitionId"] != null
                        && context.Request["PageSize"] != null
                        && context.Request["PageIndex"] != null
                        && context.Request["Title"] != null)
                    {
                        result = GetBaseTypeList(
                            int.Parse(context.Request["PageSize"].ToString()),
                            int.Parse(context.Request["PageIndex"].ToString()),
                            context.Request["ExhibitionId"].ToString(),
                            context.Request["Title"].ToString()
                            );
                    }
                }
                else if (context.Request["type"].ToString().Equals("GetEnrollList", System.StringComparison.InvariantCultureIgnoreCase))
                {
                    if (context.Request["ExhibitionId"] != null
                        && context.Request["PageSize"] != null
                        && context.Request["PageIndex"] != null
                        && context.Request["Title"] != null)
                    {
                        result = GetEnrollList(
                            int.Parse(context.Request["PageSize"].ToString()),
                            int.Parse(context.Request["PageIndex"].ToString()),
                            context.Request["ExhibitionId"].ToString(),
                            context.Request["Title"].ToString(),
                            context.Request["Status"].ToString()
                            );
                    }
                }
                else if (context.Request["type"].ToString().Equals("GetMomentList", System.StringComparison.InvariantCultureIgnoreCase))
                {
                    if (context.Request["ExhibitionId"] != null
                        && context.Request["PageSize"] != null
                        && context.Request["PageIndex"] != null
                        && context.Request["Title"] != null)
                    {
                        result = GetMomentList(
                            int.Parse(context.Request["PageSize"].ToString()),
                            int.Parse(context.Request["PageIndex"].ToString()),
                            context.Request["ExhibitionId"].ToString(),
                            context.Request["Title"].ToString()
                            );
                    }
                }
                else if (context.Request["type"].ToString().Equals("export"))
                {
                    if (context.Request["ids"] != null)
                        ExportExcel(context.Request["ids"].ToString());
                }
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
            context.Response.End();
        }

        #region 展会管理

        private string GetExhibitionList(int pageSize, int pageIndex, string title)
        {
            string rst = "";

            ListDataView view = new ListDataView();

            var exhibitionList = _exhibitionService.GetExhibitionListByStatusPage(exhibitionType, pageIndex, pageSize, title.Trim());

            int totalpage = exhibitionList.TotalPageCount;


            if (pageIndex <= totalpage)
            {
                List<ExhibitionListModel> viewModelList = new List<ExhibitionListModel>();

                exhibitionList.ForEach(p =>
                {
                    string headImg = string.Empty;
                    // 获取封面图片
                    if (HasAttachmentType(AttType.ExhibitionLogo))
                    {
                        var logoImgAtt = _attachmentService.GetListByResourceIdAndType(p.id, CommonHelper.GetEnumValue<AttType>(AttType.ExhibitionLogo));
                        if (logoImgAtt.Count > 0)
                        {
                            headImg = logoImgAtt.FirstOrDefault().URL;
                        }
                    }

                    ExhibitionListModel item = new ExhibitionListModel();
                    item.ExhibitionCode = p.id;
                    item.HeadImg = headImg;
                    item.Address = p.address1;
                    item.SellerNumber = p.sellerorder.Count;
                    item.MomentCount = p.moment.Count;
                    item.EnrollNumber = p.enrolluser.Count;
                    item.ExhibitionName = p.exhibitionname;
                    item.FollowCount = p.followmoment.Count;
                    item.PublishDate = p.creattime.ToString();
                    item.SellerNumber = p.sellerorder.Count;
                    item.Status = p.endtime < DateTime.Now ? "已结束" : "未结束";
                    item.TimeRange = p.starttime.ToString("yyyyMMdd") + " 至 " + p.endtime.ToString("yyyyMMdd");

                    viewModelList.Add(item);
                });

                view.ListData = viewModelList;
            }
            else
            {
                view.ListData = "";
            }
            view.PageIndex = pageIndex;
            view.PageCount = totalpage;

            rst = JsonHelper.ConvertToJson(view);

            return rst;
        }

        private string GetExhibitionInfo(string exhibitionId)
        {
            var exhibition = _exhibitionService.GetModelById(exhibitionId);

            ExhibitionDeatils model = new ExhibitionDeatils();

            if (exhibition != null)
            {
                model.Name = exhibition.exhibitionname;
                model.TimeRange = exhibition.starttime.ToString("yyyyMMdd") + " 至 " + exhibition.endtime.ToString("yyyyMMdd");
                model.Address = exhibition.address1;
                model.SellerCount = exhibition.sellerorder.Count;
                model.UserCount = exhibition.enrolluser.Count;
                model.MomentCount = exhibition.moment.Count;
                model.FollowCount = exhibition.myfavorites.Count;
                model.LowDiscount = exhibition.lowdiscount;
                model.SaleProportion = exhibition.saleproportion;
                model.ExhibitionIntro = exhibition.detailes;

                // 获取封面图片
                if (HasAttachmentType(AttType.ExhibitionLogo))
                {
                    var logoImgAtt = _attachmentService.GetListByResourceIdAndType(exhibitionId, CommonHelper.GetEnumValue<AttType>(AttType.ExhibitionLogo));
                    if (logoImgAtt.Count > 0)
                    {
                        model.HeadImg = logoImgAtt.FirstOrDefault().URL;
                    }
                }

                //展会详情图片
                model.IntroImgs = new List<IntroImg>();     
                if (HasAttachmentType(AttType.ExhibitionIntroImg))
                {
                    var imgAtts = _attachmentService.GetListByResourceIdAndType(exhibitionId, CommonHelper.GetEnumValue<AttType>(AttType.ExhibitionIntroImg));
                    imgAtts.ForEach(p =>
                    {
                        model.IntroImgs.Add(new IntroImg { ImgUr = p.URL });
                    });
                }

                // 获取展位分布图
                if (HasAttachmentType(AttType.DistributionMap))
                {
                    var dMapAtt = _attachmentService.GetListByResourceIdAndType(exhibitionId, CommonHelper.GetEnumValue<AttType>(AttType.DistributionMap));
                    if (dMapAtt.Count > 0)
                    {
                        model.SeatSetImg = dMapAtt.FirstOrDefault().URL;
                    }
                }

                //展位类型
                model.SeatSets = new List<SeatSet>();
                exhibition.seatset.ToList().ForEach(p=> 
                {
                    SeatSet seat = new SeatSet();
                    seat.SeatName = p.basetypescode;
                    seat.SeatPrice = p.seatprice.ToString();
                    seat.SeatNos = new List<SeatNo>();
                    p.seatno.ToList().ForEach(w =>
                    {
                        seat.SeatNos.Add(new SeatNo()
                        {
                            SeatNoName = w.seatno
                        });
                    });

                    model.SeatSets.Add(seat);
                });

                //门票详情
                model.TicketIntros = new List<TicketIntro>();
                exhibition.ticketsset.ToList().ForEach(p=> 
                {
                    p.tickettype.ToList().ForEach(w=> 
                    {
                        model.TicketIntros.Add(new TicketIntro()
                        {
                            TicketTypeName = w.ticketname,
                            TicketPrivilege = w.privilege,
                            TicktePrice = w.price.ToString()
                        });
                    });
                });    
            }

            return JsonHelper.ConvertToJson(model);

        }
        #endregion

        #region 展品分类

        private string GetBaseTypeList(int pageSize, int pageIndex, string exhibitionId, string searchKey)
        {
            ListDataView view = new ListDataView();

            var baseClassList = _exhibitionProductClassService.GetListPageByExhibitionId(exhibitionId, pageIndex, pageSize, searchKey);

            int totalpage = baseClassList.TotalPageCount;


            if (pageIndex <= totalpage)
            {
                List<BaseTypeModel> viewModelList = new List<BaseTypeModel>();

                baseClassList.ForEach(p =>
                {
                    BaseTypeModel item = new BaseTypeModel();
                    item.TypeId = p.id;
                    item.ClassName = p.classname;

                    viewModelList.Add(item);
                });

                view.ListData = viewModelList;
            }
            else
            {
                view.ListData = "";
            }
            view.PageIndex = pageIndex;
            view.PageCount = totalpage;

            return JsonHelper.ConvertToJson(view);
        }

        #endregion

        #region 报名管理

        private string GetEnrollList(int pageSize, int pageIndex, string exhibitionId, string searchKey,string status)
        {
            ListDataView view = new ListDataView();

            var enrollUserList = _enrollUserService.GetListPageByExhibitionId(exhibitionId, pageIndex, pageSize, searchKey, status);

            int totalpage = enrollUserList.TotalPageCount;


            if (pageIndex <= totalpage)
            {
                List<EnrollUserListModel> viewModelList = new List<EnrollUserListModel>();

                enrollUserList.ForEach(p =>
                {
                    EnrollUserListModel item = new EnrollUserListModel();
                    item.EnrollUserId = p.id;
                    item.Name = p.sname;
                    item.Phone = p.sphone;
                    item.TicketName = p.ticketsType.ticketname;
                    item.Price = p.ticketsType.price.ToString();
                    item.CreateDate = p.creattime.ToString();
                    item.Status = p.ticketstatus == 0 ? "未验票" : "已验票";

                    viewModelList.Add(item);
                });

                view.ListData = viewModelList;
            }
            else
            {
                view.ListData = "";
            }
            view.PageIndex = pageIndex;
            view.PageCount = totalpage;

            return JsonHelper.ConvertToJson(view);
        }
        #endregion

        #region 动态管理

        private string GetMomentList(int pageSize, int pageIndex, string exhibitionId, string searchKey)
        {
            ListDataView view = new ListDataView();

            var momentList = _momentService.GetListPageByExhibitionId(exhibitionId, pageIndex, pageSize, searchKey);

            int totalpage = momentList.TotalPageCount;


            if (pageIndex <= totalpage)
            {
                List<MomentListModel> viewModelList = new List<MomentListModel>();
                momentList.ForEach(p =>
                {
                    var userInfo = _userInfoService.GetModelById(p.creater);

                    MomentListModel item = new MomentListModel();
                    item.NickName = userInfo != null ? userInfo.Nickname : "";
                    item.Logo = userInfo != null ? userInfo.HeadImage : "";
                    item.Moment = p.pubcontent;
                    item.PublishTime = p.creattime.ToString("yyyy-MM-dd HHssmm");
                    item.FollowCount = p.followmoment.Count;
                    item.ReplayCount = p.momentreply.Count;

                    //获取动态图片
                    item.Imgs = new List<ImgUrl>();

                    var atts = _attachmentService.GetListByResourceIdAndType(p.id, ((int)AttType.MomentImg).ToString());

                    foreach (var att in atts)
                    {
                        item.Imgs.Add(new ImgUrl() { Url = att.URL });
                    }

                    viewModelList.Add(item);
                });

                view.ListData = viewModelList;
            }
            else
            {
                view.ListData = "";
            }
            view.PageIndex = pageIndex;
            view.PageCount = totalpage;

            return JsonHelper.ConvertToJson(view);
        }
        #endregion

        #region 导出

        public void ExportExcel(string ids)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("姓名", typeof(string)));
            dt.Columns.Add(new DataColumn("手机号", typeof(string)));
            dt.Columns.Add(new DataColumn("门票", typeof(string)));
            dt.Columns.Add(new DataColumn("价格/元", typeof(string)));
            dt.Columns.Add(new DataColumn("报名时间", typeof(string)));
            dt.Columns.Add(new DataColumn("验票状态", typeof(string)));

            string[] idArray = ids.Split(',');

            foreach (var id in idArray)
            {
                var enrollUser = _enrollUserService.GetModelById(id);

                if (enrollUser != null)
                {
                    DataRow dr = dt.NewRow();
                    dr["姓名"] = enrollUser.sname;
                    dr["手机号"] = enrollUser.sphone;
                    dr["门票"] = enrollUser.ticketsType.ticketname;
                    dr["价格/元"] = enrollUser.ticketsType.price.ToString();
                    dr["报名时间"] = enrollUser.creattime.ToString();
                    dr["验票状态"] = enrollUser.ticketstatus == 0 ? "未验票" : "已验票";
                    dt.Rows.Add(dr);
                }
            }

            ds.Tables.Add(dt);

            ExportHelper.ResponseExcel("报名列表.xls", ds);
        }

        #endregion

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

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}