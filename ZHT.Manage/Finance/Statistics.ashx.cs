using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZHT.Framework;
using ZHT.Service;
using Autofac;
using Webdiyer.WebControls.Mvc;
using ZHT.Manage.Models;
using ZHT.Data.Models;
using System.Data;

namespace ZHT.Manage.Finance
{
    /// <summary>
    /// Summary description for Statistics
    /// </summary>
    public class Statistics : IHttpHandler
    {

        private readonly IExhibitionService _exhibitionService = DIConfig.container.Resolve<IExhibitionService>();
        private readonly IOrderService _orderService = DIConfig.container.Resolve<IOrderService>();
        private readonly ISettlementService _settlementService = DIConfig.container.Resolve<ISettlementService>();

        public void ProcessRequest(HttpContext context)
        {
            string result = "";

            if (context.Request["type"] != null)
            {
                if (context.Request["type"].ToString().Equals("TicketList", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (context.Request["PageSize"] != null
                        && context.Request["PageIndex"] != null
                        && context.Request["Title"] != null
                        && context.Request["Status"] != null)
                    {
                        result = GetTickets(
                                  int.Parse(context.Request["PageSize"].ToString()),
                                  int.Parse(context.Request["PageIndex"].ToString()),
                                  context.Request["Title"].ToString(),
                                  context.Request["Status"].ToString());
                    }
                }
                else if (context.Request["type"].ToString().Equals("SaleInfoList", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (context.Request["PageSize"] != null
                        && context.Request["PageIndex"] != null
                        && context.Request["Title"] != null
                        && context.Request["Status"] != null)
                    {
                        result = GetSales(
                                  int.Parse(context.Request["PageSize"].ToString()),
                                  int.Parse(context.Request["PageIndex"].ToString()),
                                  context.Request["Title"].ToString(),
                                  context.Request["Status"].ToString());
                    }
                }
                else if (context.Request["type"].ToString().Equals("SettlementList", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (context.Request["PageSize"] != null
                        && context.Request["PageIndex"] != null
                        && context.Request["Title"] != null
                        && context.Request["SettleType"] != null)
                    {
                        result = GetSettlement(int.Parse(context.Request["PageSize"].ToString()),
                                  int.Parse(context.Request["PageIndex"].ToString()),
                                  context.Request["Title"].ToString(),
                                  context.Request["SettleType"].ToString());
                    }
                }
                else if (context.Request["type"].ToString().Equals("ModifyStatus", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (context.Request["ids"] != null)
                    {
                        if (context.Request["dataType"] != null)
                        {
                            result = EndExhibition(context.Request["ids"].ToString(), context.Request["dataType"].ToString());
                        }
                    }
                }
                else if (context.Request["type"].ToString().Equals("export", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (context.Request["listType"] != null && context.Request["ids"]!= null)
                    {
                        if (context.Request["listType"].ToString().Equals("ticket", StringComparison.InvariantCultureIgnoreCase))
                        {
                            ExportTickets(context.Request["ids"].ToString());
                        }
                        else if (context.Request["listType"].ToString().Equals("sales", StringComparison.InvariantCultureIgnoreCase))
                        {
                            ExportSales(context.Request["ids"].ToString());
                        }
                        else if (context.Request["listType"].ToString().Equals("settle", StringComparison.InvariantCultureIgnoreCase))
                        {
                            ExportSettle(context.Request["ids"].ToString());
                        }

                    }
                }
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
            context.Response.End();
        }

        #region 门票统计

        private string GetTickets(int pageSize, int pageIndex, string title, string status)
        {
            string rst = "";

            ListDataView view = new ListDataView();

            var exhibitionList = _exhibitionService.GetExhibitionListByStatusPage(1, pageIndex, pageSize, title);

            int totalpage = exhibitionList.TotalPageCount;

            if (pageIndex <= totalpage)
            {
                List<TicketInfoModel> viewModelList = new List<TicketInfoModel>();

                exhibitionList.ForEach(p =>
                {
                    bool isAdd = true;
                    var settmleModel = _settlementService.GetModelByExhibitionAndType(p.id, 1);

                    if (!string.IsNullOrWhiteSpace(status))
                    {
                        switch (status)
                        {
                            case "0":
                                if (settmleModel != null)
                                {
                                    isAdd = false;
                                }
                                break;
                            case "1":
                                if (settmleModel == null)
                                {
                                    isAdd = false;
                                }
                                break;
                        }
                    }

                    if (isAdd)
                    {

                        decimal totalAmount = 0M;
                        TicketInfoModel item = new TicketInfoModel();
                        item.ExhibitionId = p.id;
                        item.EndDate = p.endtime.ToString("yyyy-MM-dd");
                        item.ExhibitionName = p.exhibitionname;
                        item.TicketCount = p.enrolluser.Count.ToString();

                        p.enrolluser.ToList().ForEach(w =>
                        {
                            totalAmount += w.ticketsType.price;
                        });

                        item.TotalAmount = totalAmount.ToString();
                        item.SettleAmount = (totalAmount * p.saleproportion / 100).ToString();
                        item.Status = settmleModel == null ? "未结算" : "已结算";

                        viewModelList.Add(item);
                    }
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

        #endregion

        #region 销售统计

        private string GetSales(int pageSize, int pageIndex, string title, string status)
        {
            string rst = "";

            ListDataView view = new ListDataView();

            var exhibitionList = _exhibitionService.GetExhibitionListByStatusPage(1, pageIndex, pageSize, title);

            int totalpage = exhibitionList.TotalPageCount;


            if (pageIndex <= totalpage)
            {
                List<SaleInfoModel> viewModelList = new List<SaleInfoModel>();

                foreach(var p in exhibitionList)               
                {
                    bool isAdd = true;

                    var orders = _orderService.GetListByExhibitionId(p.id);
                    var settmleModel = _settlementService.GetModelByExhibitionAndType(p.id, 2);

                    if (!string.IsNullOrWhiteSpace(status))
                    {
                        switch (status)
                        {
                            case "0":
                                if (settmleModel != null)
                                {
                                    isAdd = false;
                                }
                                break;
                            case "1":
                                if (settmleModel == null)
                                {
                                    isAdd = false;
                                }
                                break;
                        }
                    }

                    if (isAdd)
                    {
                        decimal totalAmount = 0M;
                        SaleInfoModel item = new SaleInfoModel();
                        item.ExhibitionId = p.id;
                        item.EndDate = p.endtime.ToString("yyyy-MM-dd");
                        item.ExhibitionName = p.exhibitionname;
                        item.OrderCount = orders.Count;
                        if (orders.Any())
                        {
                            orders.ForEach(k =>
                            {
                                totalAmount += k.totalCharge.Value;
                            });
                        }

                        item.TotalAmount = totalAmount.ToString();
                        item.DivideAmount = (totalAmount * p.saleproportion).ToString();
                        item.SettleAmount = settmleModel == null ? "0" : item.DivideAmount;
                        item.Status = settmleModel == null ? "未结算" : "已结算";

                        viewModelList.Add(item);
                    }
                }

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

        #endregion

        #region 结算记录

        public string GetSettlement(int pageSize, int pageIndex, string exhibitionName, string type)
        {
            string rst = "";

            ListDataView view = new ListDataView();

            var settlementList = _settlementService.GetPagedList(pageIndex, pageSize, exhibitionName, type);

            int totalpage = settlementList.TotalPageCount;


            if (pageIndex <= totalpage)
            {
                List<SettlementModel> viewModelList = new List<SettlementModel>();
                decimal totalAmount = 0M;

                settlementList.ForEach(p =>
                {
                    SettlementModel item = new SettlementModel();
                    item.SettlementId = p.id;
                    item.SettlementTime = p.creatTime.ToString("yyyy-MM-dd");
                    item.ExhibitionName = p.exhibition.exhibitionname;

                    if (p.type == 1)
                    {
                        //门票销售
                        p.exhibition.enrolluser.ToList().ForEach(w =>
                        {
                            totalAmount += w.ticketsType.price;
                        });
                        item.TypeName = "门票收入";
                    }
                    else
                    {
                        //展品销售
                        var orders = _orderService.GetListByExhibitionId(p.id);
                        if (orders.Any())
                        {
                            orders.ForEach(k =>
                            {
                                totalAmount += k.totalCharge.Value;
                            });
                        }
                        item.TypeName = "销售分成";
                    }
                    item.Amount = totalAmount.ToString();

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

        #endregion

        #region 结算

        private string EndExhibition(string id, string type)
        {
            string result = string.Empty;

            int settlementType = 0;
            switch (type)
            {
                case "ticket":
                    settlementType = 1;
                    break;
                case "sale":
                    settlementType = 2;
                    break;
            }

            var exhibition = _exhibitionService.GetModelById(id);
            if (exhibition != null)
            {
                var settmleModel = _settlementService.GetModelByExhibitionAndType(id, settlementType);
                if (settmleModel != null)
                {
                    result = "展会已结算，请勿重复操作!";
                }
                else
                {
                    if (exhibition.endtime < DateTime.Now)
                    {


                        Settlement model = new Settlement();
                        model.id = CommonHelper.GetGuid();
                        model.exhibitionCode = id;
                        model.type = settlementType;
                        model.creater = "";
                        model.creatTime = DateTime.Now;

                        _settlementService.Insert(model);
                    }
                    else
                    {
                        result = "展会未结束!";
                    }
                }
            }
            else
            {
                result = "展会不存在!";
            }

            return JsonHelper.ConvertToJson(new { msg = result, status = "e" });
        }

        #endregion

        #region 导出

        private void ExportTickets(string ids)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("展会名称", typeof(string)));
            dt.Columns.Add(new DataColumn("完成时间", typeof(string)));
            dt.Columns.Add(new DataColumn("门票数量", typeof(decimal)));
            dt.Columns.Add(new DataColumn("总金额/元", typeof(decimal)));
            dt.Columns.Add(new DataColumn("结算金额", typeof(decimal)));
            dt.Columns.Add(new DataColumn("结算状态", typeof(string)));

            string[] idArray = ids.Split(',');

            foreach (var id in idArray)
            {
                var exhibition = _exhibitionService.GetModelById(id);
                var settmleModel = _settlementService.GetModelByExhibitionAndType(id, 1);

                if (exhibition != null)
                {
                    decimal totalAmount = 0M;

                    exhibition.enrolluser.ToList().ForEach(w =>
                    {
                        totalAmount += w.ticketsType.price;
                    });

                    DataRow dr = dt.NewRow();
                    dr["展会名称"] = exhibition.exhibitionname;
                    dr["完成时间"] = exhibition.endtime.ToString("yyyy-MM-dd");
                    dr["门票数量"] = exhibition.enrolluser.Count;
                    dr["总金额/元"] = totalAmount;
                    dr["结算金额"] = totalAmount * exhibition.saleproportion / 100;
                    dr["结算状态"] = settmleModel == null ? "未结算" : "已结算";
                    dt.Rows.Add(dr);
                }
            }

            ds.Tables.Add(dt);

            ExportHelper.ResponseExcel("门票收入列表.xls", ds);
        }

        private void ExportSales(string ids)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("展会名称", typeof(string)));
            dt.Columns.Add(new DataColumn("完成时间", typeof(string)));
            dt.Columns.Add(new DataColumn("订单数量", typeof(string)));
            dt.Columns.Add(new DataColumn("总金额/元", typeof(string)));
            dt.Columns.Add(new DataColumn("销售分成", typeof(string)));
            dt.Columns.Add(new DataColumn("结算金额", typeof(string)));
            dt.Columns.Add(new DataColumn("结算状态", typeof(string)));

            string[] idArray = ids.Split(',');

            foreach (var id in idArray)
            {
                var exhibition = _exhibitionService.GetModelById(id);
                var orders = _orderService.GetListByExhibitionId(id);
                var settmleModel = _settlementService.GetModelByExhibitionAndType(id, 1);

                decimal totalAmount = 0M;
                if (orders.Any())
                {
                    orders.ForEach(k =>
                    {
                        totalAmount += k.totalCharge.Value;
                    });
                }

                DataRow dr = dt.NewRow();
                dr["展会名称"] = exhibition.exhibitionname;
                dr["完成时间"] = exhibition.endtime.ToString("yyyy-MM-dd");
                dr["订单数量"] = orders.Count;
                dr["总金额/元"] = totalAmount.ToString();
                dr["销售分成"] = (totalAmount * exhibition.saleproportion / 100).ToString();
                dr["结算金额"] = totalAmount.ToString();
                dr["结算状态"] = settmleModel == null ? "未结算" : "已结算";
                dt.Rows.Add(dr);
            }

            ds.Tables.Add(dt);

            ExportHelper.ResponseExcel("销售收入列表.xls", ds);
        }

        private void ExportSettle(string ids)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("展会名称", typeof(string)));
            dt.Columns.Add(new DataColumn("收入类型", typeof(string)));
            dt.Columns.Add(new DataColumn("结算额/元", typeof(string)));
            dt.Columns.Add(new DataColumn("结算时间", typeof(string)));

            string[] idArray = ids.Split(',');

            foreach (var id in idArray)
            {
                var settle = _settlementService.GetModelById(id);
                if (settle != null)
                {
                    decimal totalAmount = 0M;

                    if (settle.type == 1)
                    {
                        //门票销售
                        settle.exhibition.enrolluser.ToList().ForEach(w =>
                        {
                            totalAmount += w.ticketsType.price;
                        });
                    }
                    else
                    {
                        //展品销售
                        var orders = _orderService.GetListByExhibitionId(settle.exhibitionCode);
                        if (orders.Any())
                        {
                            orders.ForEach(k =>
                            {
                                totalAmount += k.totalCharge.Value;
                            });
                        }
                    }

                    DataRow dr = dt.NewRow();
                    dr["展会名称"] = settle.exhibition.exhibitionname;
                    dr["收入类型"] = settle.type == 1?"门票收入":"销售分成";
                    dr["结算额/元"] = totalAmount.ToString();
                    dr["结算时间"] = settle.creatTime.ToString("yyyy-MM-dd");
                    //dt.Rows.Add(dr);
                }
            }

            ds.Tables.Add(dt);

            ExportHelper.ResponseExcel("结算记录列表.xls", ds);
        }

        #endregion

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}