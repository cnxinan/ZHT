using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using ZHT.Framework;
using ZHT.Service;
using Webdiyer.WebControls.Mvc;
using ZHT.Data.Models;
using ZHT.Manage.Models;

namespace ZHT.Manage.Exhibition
{
    /// <summary>
    /// 参展商
    /// </summary>
    public class Seller : IHttpHandler
    {
        private string exhibitionId;

        private readonly ISellerOrderService _sellerOrderService = DIConfig.container.Resolve<ISellerOrderService>();
        private readonly IAttachmentTypeService _attachmentTypeService = DIConfig.container.Resolve<IAttachmentTypeService>();
        private readonly IAttachmentService _attachmentService = DIConfig.container.Resolve<IAttachmentService>();
        private readonly ICompanyUserService _companyUserService = DIConfig.container.Resolve<ICompanyUserService>();
        private readonly ICompanyService _companyService = DIConfig.container.Resolve<ICompanyService>();

        public void ProcessRequest(HttpContext context)
        {
            string result = "";

            if (context.Request["ExhibitionId"] != null)
            {
                exhibitionId = context.Request["ExhibitionId"].ToString();
            }

            if (context.Request["type"] != null)
            {
                if (context.Request["type"].ToString().Equals("GetList", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (context.Request["PageSize"] != null
                        && context.Request["PageIndex"] != null
                        && context.Request["Title"] != null)
                    {
                        result = GetSellerList(
                                          int.Parse(context.Request["PageSize"].ToString()),
                                          int.Parse(context.Request["PageIndex"].ToString()),
                                          exhibitionId,
                                          context.Request["Title"].ToString(),
                                          context.Request["Status"].ToString()
                                          );
                    }
                }
                else if (context.Request["type"].ToString().Equals("getInfo"))
                {
                    if (context.Request["SellerOrderId"] != null)
                    {
                        result = GetSellerInfo(context.Request["SellerOrderId"].ToString());
                    }
                }
                else if (context.Request["type"].ToString().Equals("export"))
                {
                    if (context.Request["ids"] != null)
                        ExportExcel(context.Request["ids"].ToString());
                }
                else if (context.Request["type"].ToString().Equals("ModifyStatus"))
                {
                    if (context.Request["ids"] != null)
                        result = ModifyStatus(context.Request["ids"].ToString(),
                                    int.Parse((context.Request["statusType"].ToString())));
                }
                else if (context.Request["type"].ToString().Equals("delInfo"))
                {
                    if (context.Request["ids"] != null)
                        result = DeleteSeller(context.Request["ids"].ToString());
                }
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
            context.Response.End();
        }

        #region 获取参展商

        public string GetSellerList(int pageSize, int pageIndex, string exhibitionId, string searchKey, string status)
        {
            ListDataView view = new ListDataView();

            PagedList<SellerOrder> sellerList = _sellerOrderService.GetListPageByExhibition(exhibitionId, pageIndex, pageSize, searchKey, status);
            int totalpage = sellerList.TotalPageCount;

            if (pageIndex <= totalpage)
            {
                List<SellerListModel> viewModelList = new List<SellerListModel>();

                sellerList.ForEach(p =>
                {
                    SellerListModel item = new SellerListModel();
                    item.SellerOrderId = p.id;
                    var companyUser = _companyUserService.GetModelByUserCode(p.sellerid);
                    item.SellerName = companyUser == null ? _companyService.GetCompanyName(companyUser.CompanyCode) : "";
                    item.SName = p.sname;
                    item.SPhone = p.sphone;
                    switch (p.orderstatus)
                    {
                        case 0:
                            item.Status = "未确认";
                            break;
                        case 1:
                            item.Status = "已确认";
                            break;
                        case 2:
                            item.Status = "已拒绝";
                            break;
                    }

                    if (p.sellerOrderDetails.Any())
                    {
                        p.sellerOrderDetails.OrderBy(t => t.seatno.seatno).ToList().ForEach(w =>
                          {
                              item.SeatInfo += w.seatno.seatno + ",";
                          });
                        if (item.SeatInfo.Length > 0)
                        {
                            item.SeatInfo = item.SeatInfo.Substring(0, item.SeatInfo.Length - 1);
                        }
                    }

                    viewModelList.Add(item);
                });

                view.ListData = viewModelList;
            }
            else
            {
                view.ListData = "";
            }

            return JsonHelper.ConvertToJson(view);
        }

        public string GetSellerInfo(string sellerOrderId)
        {
            var sellerOrder = _sellerOrderService.GetModelById(sellerOrderId);
            SellerModel model = new SellerModel();
            if (sellerOrder != null)
            {
                var companyUser = _companyUserService.GetModelByUserCode(sellerOrder.sellerid);
                model.SellerName = companyUser == null ? _companyService.GetCompanyName(companyUser.CompanyCode) : "";
                model.SName = sellerOrder.sname;
                model.SPhone = sellerOrder.sphone;
                model.SellerInfo = sellerOrder.sellerintro;
                model.TotalPrice = sellerOrder.totalprice.ToString();
                if (sellerOrder.sellerOrderDetails.Any())
                {
                    sellerOrder.sellerOrderDetails.OrderBy(t => t.seatno.seatno).ToList().ForEach(w =>
                    {
                        model.SeatInfo += w.seatno.seatno + ",";
                    });
                    if (model.SeatInfo.Length > 0)
                    {
                        model.SeatInfo = model.SeatInfo.Substring(0, model.SeatInfo.Length - 1);
                    }
                }
            }

            return JsonHelper.ConvertToJson(model);

        }

        #endregion

        #region 导出

        public void ExportExcel(string ids)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("展商名称", typeof(string)));
            dt.Columns.Add(new DataColumn("展位信息", typeof(string)));
            dt.Columns.Add(new DataColumn("姓名", typeof(string)));
            dt.Columns.Add(new DataColumn("手机号", typeof(string)));
            dt.Columns.Add(new DataColumn("状态", typeof(string)));

            string[] idArray = ids.Split(',');

            foreach (var id in idArray)
            {
                var sellerOrder = _sellerOrderService.GetModelById(id);
                string status = string.Empty;
                string seatInfo = string.Empty;

                if (sellerOrder != null)
                {
                    switch (sellerOrder.orderstatus)
                    {
                        case 0:
                            status = "未确认";
                            break;
                        case 1:
                            status = "已确认";
                            break;
                        case 2:
                            status = "已拒绝";
                            break;
                    }

                    if (sellerOrder.sellerOrderDetails.Any())
                    {
                        sellerOrder.sellerOrderDetails.OrderBy(t => t.seatno.seatno).ToList().ForEach(w =>
                        {
                            seatInfo += w.seatno.seatno + ",";
                        });
                        if (seatInfo.Length > 0)
                        {
                            seatInfo = seatInfo.Substring(0, seatInfo.Length - 1);
                        }
                    }

                    string sellerName = string.Empty; ;
                    var companyUser = _companyUserService.GetModelByUserCode(sellerOrder.sellerid);
                    sellerName = companyUser == null ? _companyService.GetCompanyName(companyUser.CompanyCode) : "";

                    DataRow dr = dt.NewRow();
                    dr["展商名称"] = sellerName;
                    dr["展位信息"] = seatInfo;
                    dr["姓名"] = sellerOrder.sname;
                    dr["手机号"] = sellerOrder.sphone;
                    dr["状态"] = status;
                    dt.Rows.Add(dr);
                }
            }

            ds.Tables.Add(dt);

            ExportHelper.ResponseExcel("参展商列表.xls", ds);
        }

        #endregion

        #region 修改状态

        public string ModifyStatus(string id, int statusType)
        {
            string result = string.Empty;

            var sellerOrder = _sellerOrderService.GetModelById(id);

            if (sellerOrder != null)
            {
                if (sellerOrder.orderstatus == (int)SellerOrderStatus.NoConfirm)
                {
                    sellerOrder.orderstatus = statusType;

                    foreach (var p in sellerOrder.sellerOrderDetails)
                    {
                        p.isdel = 1;
                    }

                    _sellerOrderService.Update(sellerOrder);

                }
                else if (sellerOrder.orderstatus == (int)SellerOrderStatus.NoPay)
                {
                    result = "该订单未支付!";
                }
                else
                {
                    result = "该订单已经处理过!";
                }
            }

            return JsonHelper.ConvertToJson(new { msg = result });
        }

        #endregion

        #region 删除

        public string DeleteSeller(string id)
        {
            string result = string.Empty;

            var sellerOrder = _sellerOrderService.GetModelById(id);

            if (sellerOrder != null)
            {
                sellerOrder.isdel = 1;
                _sellerOrderService.Update(sellerOrder);
                result = "参展商已删除!";
            }
            else
            {
                result = "参展商不存在！";
            }

            return JsonHelper.ConvertToJson(new { msg = result }); ;
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