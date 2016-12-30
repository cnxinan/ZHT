using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Webdiyer.WebControls.Mvc;
using ZHT.Framework;
using Autofac;
using ZHT.Service;
using ZHT.Manage.Models;
using System.Data;

namespace ZHT.Manage.Exhibition
{
    /// <summary>
    /// Summary description for Order
    /// </summary>
    public class Order : IHttpHandler
    {

        private readonly ISellerOrderService _sellerOrderService = DIConfig.container.Resolve<ISellerOrderService>();
        private readonly IOrderService _orderService = DIConfig.container.Resolve<IOrderService>();

        public void ProcessRequest(HttpContext context)
        {
            string result = "";

            if (context.Request["type"] != null)
            {
                if (context.Request["type"].ToString().Equals("GetList"))
                {
                    if (context.Request["PageSize"] != null
                        && context.Request["PageIndex"] != null
                        && context.Request["OrderNo"] != null)
                    {
                        result = GetOrderList(
                                          int.Parse(context.Request["PageSize"].ToString()),
                                          int.Parse(context.Request["PageIndex"].ToString()),
                                          context.Request["ExhibitionId"],
                                          context.Request["OrderNo"].ToString(),
                                          context.Request["Mobile"].ToString(),
                                          context.Request["Status"].ToString()
                                          );
                    }
                }
                else if (context.Request["type"].ToString().Equals("getInfo"))
                {
                    if (context.Request["OrderId"] != null)
                    {
                        result = GetOrderInfo(context.Request["OrderId"].ToString());
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

        #region 订单信息

        private string GetOrderList(int pageSize, int pageIndex, string exhibitionId, string orderNo,string mobile, string status)
        {
            ListDataView view = new ListDataView();

            PagedList<ZHT.Data.Models.Order> orderList = _orderService.GetListPageByExhibitionId(exhibitionId, pageIndex, pageSize, orderNo, mobile, status);
            int totalpage = orderList.TotalPageCount;

            if (pageIndex <= totalpage)
            {
                List<OrderListModel> viewModelList = new List<OrderListModel>();

                orderList.ForEach(p =>
                {
                    OrderListModel item = new OrderListModel();
                    item.OrderId = p.code;
                    item.OrderNo = p.orderNumber;
                    item.Name = p.customerName;
                    item.Phone = p.telephone;
                    item.TotalAmount = p.totalCharge.ToString();
                    item.SellerName =p.sellerName;

                    switch (p.status)
                    {
                        case 1:
                            item.Status = "未提货";
                            break;
                        case 2:
                            item.Status = "已提货";
                            break;
                    }

                    //if (p.orderDetails.Count > 0)
                    //{
                    //    var sellerOrder = _sellerOrderService.GetModelBySellerId(exhibitionId, p.orderDetails.FirstOrDefault().goods.creator);
                    //}

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

        private string GetOrderInfo(string orderId)
        {
            var p = _orderService.GetModelById(orderId);

            OrderModel item = new OrderModel();
            item.OrderNo = p.orderNumber;
            item.Name = p.customerName;
            item.Phone = p.telephone;
            item.TotalAmount = p.totalCharge.ToString();
            item.SellerName = "参展商";                    //需要从远洋数据库取
            item.CreateDate = p.createTime.Value.ToString("yyyy-MM-dd HHmmss");

            if (p.orderDetails.Any())
            {
                item.orderDetails = new List<OrderDetailsModel>();
                p.orderDetails.ToList().ForEach(w =>
                {
                    OrderDetailsModel details = new OrderDetailsModel()
                    {
                        ProductName = w.goodsName,
                        Count = w.goodsCount.HasValue ? w.goodsCount.Value.ToString() : "",
                        Charge = w.charge.HasValue ? w.charge.Value.ToString() : ""
                    };

                    item.orderDetails.Add(details);
                });
            }

            return JsonHelper.ConvertToJson(item);
        }

        #endregion

        #region 导出

        public void ExportExcel(string ids)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("展商名称", typeof(string)));
            dt.Columns.Add(new DataColumn("订单号", typeof(string)));
            dt.Columns.Add(new DataColumn("用户名称", typeof(string)));
            dt.Columns.Add(new DataColumn("手机号", typeof(string)));
            dt.Columns.Add(new DataColumn("金额", typeof(string)));
            dt.Columns.Add(new DataColumn("提货状态", typeof(string)));

            string[] idArray = ids.Split(',');

            foreach (var id in idArray)
            {
                var order = _orderService.GetModelById(id);
                string status = string.Empty;
                string seatInfo = string.Empty;

                if (order != null)
                {
                    var sellerOrder = _sellerOrderService.GetModelBySellerId(order.sellerNumber, order.orderDetails.FirstOrDefault().goods.creator);

                    DataRow dr = dt.NewRow();
                    dr["展商名称"] = order.sellerName;
                    dr["订单号"] = order.orderNumber;
                    dr["用户名称"] = order.customerName;
                    dr["手机号"] = order.telephone;
                    dr["金额"] = order.totalCharge.ToString();
                    dr["提货状态"] = order.status == 1 ? "未提货" : "已提货";
                    dt.Rows.Add(dr);
                }
            }

            ds.Tables.Add(dt);

            ExportHelper.ResponseExcel("订单列表.xls", ds);
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