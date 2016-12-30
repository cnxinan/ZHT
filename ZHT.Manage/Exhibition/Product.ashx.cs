using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ZHT.Framework;
using Webdiyer.WebControls.Mvc;
using ZHT.Data.Models;
using Autofac;
using ZHT.Service;
using ZHT.Manage.Models;
using System.Data;

namespace ZHT.Manage.Exhibition
{
    /// <summary>
    /// Summary description for Product
    /// </summary>
    public class Product : IHttpHandler
    {

        private readonly IExhibitionProductService _exhibitionProductService = DIConfig.container.Resolve<IExhibitionProductService>();
        private readonly ISellerOrderService _sellerOrderService = DIConfig.container.Resolve<ISellerOrderService>();
        private readonly IBusinessScopeTypeService _businessScopeTypeService = DIConfig.container.Resolve<IBusinessScopeTypeService>();
        private readonly ICompanyUserService _companyUserService = DIConfig.container.Resolve<ICompanyUserService>();
        private readonly IAttachmentTypeService _attachmentTypeService = DIConfig.container.Resolve<IAttachmentTypeService>();
        private readonly IAttachmentService _attachmentService = DIConfig.container.Resolve<IAttachmentService>();
        private readonly ICompanyService _companyService = DIConfig.container.Resolve<ICompanyService>();

        public void ProcessRequest(HttpContext context)
        {
            string result = "";

            if (context.Request["type"] != null)
            {
                if (context.Request["type"].ToString().Equals("GetList", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (context.Request["PageSize"] != null
                        && context.Request["PageIndex"] != null
                        && context.Request["Title"] != null
                        && context.Request["ExhibitionId"] != null)
                    {
                        result = GetProductList(
                            int.Parse(context.Request["PageSize"].ToString()),
                            int.Parse(context.Request["PageIndex"].ToString()),
                            context.Request["ExhibitionId"].ToString(),
                            context.Request["Title"].ToString()
                            );
                    }
                }
                else if (context.Request["type"].ToString().Equals("getInfo", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (context.Request["ExhibitionProductId"] != null)
                    {
                        result = GetProduct(context.Request["ExhibitionProductId"].ToString());
                    }
                }
                else if (context.Request["type"].ToString().Equals("export"))
                {
                    if (context.Request["ids"] != null
                        && context.Request["ExhibitionId"] != null)
                        ExportExcel(context.Request["ids"].ToString(), context.Request["ExhibitionId"].ToString());
                }
            }

            context.Response.ContentType = "text/plain";
            context.Response.Write(result);
            context.Response.End();
        }

        #region 展品信息

        private string GetProductList(int pageSize, int pageIndex, string exhibitionId, string searchKey)
        {
            ListDataView view = new ListDataView();

            PagedList<ExhibitionProduct> productList = _exhibitionProductService.GetListPageByExhibitionId(exhibitionId, pageIndex, pageSize, searchKey);

            int totalpage = productList.TotalPageCount;

            if (pageIndex <= totalpage)
            {
                List<ProductListModel> model = new List<ProductListModel>();

                productList.ForEach(p =>
                {
                    ProductListModel item = new ProductListModel();
                    
                    var sellerOrder = _sellerOrderService.GetModelBySellerId(exhibitionId, p.sellercode);
                    item.ExhibitionProductId = p.id;
                    if (sellerOrder != null)
                    {
                        var companyUser = _companyUserService.GetModelByUserCode(sellerOrder.sellerid);
                        item.SellerName = companyUser == null ? _companyService.GetCompanyName(companyUser.CompanyCode) : "";
                    }
                    item.ProductName = p.productName;
                    var classModel = _businessScopeTypeService.GetModelById(p.exhibitionproductclasscode);
                    if (classModel != null)
                    {
                        item.ProductClass = classModel.goodsTypeName;
                    }
                    item.NPrice = p.nprice.ToString();
                    item.HaveSales = p.quantity > 0 ? "否" : "是";

                    model.Add(item);
                });

                view.ListData = model;
            }
            else
            {
                view.ListData = "";
            }

            return JsonHelper.ConvertToJson(view);
        }

        private string GetProduct(string exhibitionProductId)
        {
            var product = _exhibitionProductService.GetModelById(exhibitionProductId);

            ProductModel model = new ProductModel();
            if (product != null)
            {
                if (HasAttachmentType(AttType.ProductImage))
                {
                    var logoImgAtt = _attachmentService.GetListByResourceIdAndType(product.id, CommonHelper.GetEnumValue<AttType>(AttType.ProductImage));
                    if (logoImgAtt.Count > 0)
                    {
                        model.HeadImg = logoImgAtt.FirstOrDefault().URL;
                    }
                }
                model.ProductName = product.productName;
                model.Unit = product.unit;
                var classModel = _businessScopeTypeService.GetModelById(product.exhibitionproductclasscode);
                if (classModel != null)
                {
                    model.ProductClass = classModel.goodsTypeName;
                }
                model.NPrice = product.nprice.ToString();
                model.OPrice = product.oprice.ToString();
                model.Count = product.quantity;
                model.ProductIntro = product.pdetails;
            }

            return JsonHelper.ConvertToJson(model);
        }

        #endregion

        #region 导出

        public void ExportExcel(string ids,string exhibitionId)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            dt.Columns.Add(new DataColumn("展商名称", typeof(string)));
            dt.Columns.Add(new DataColumn("展品名称", typeof(string)));
            dt.Columns.Add(new DataColumn("展品分类", typeof(string)));
            dt.Columns.Add(new DataColumn("现价/元", typeof(decimal)));
            dt.Columns.Add(new DataColumn("售罄标识", typeof(string)));

            string[] idArray = ids.Split(',');

            foreach (var id in idArray)
            {
                var product = _exhibitionProductService.GetModelById(id);
                string sellerName = string.Empty;
                string className = string.Empty;

                if (product != null)
                {
                    var sellerOrder = _sellerOrderService.GetModelBySellerId(exhibitionId, product.sellercode);
                    if (sellerOrder != null)
                    {
                        var companyUser = _companyUserService.GetModelByUserCode(sellerOrder.sellerid);
                        sellerName = companyUser == null ? _companyService.GetCompanyName(companyUser.CompanyCode) : "";
                    }
                    var classModel = _businessScopeTypeService.GetModelById(product.exhibitionproductclasscode);
                    if (classModel != null)
                    {
                        className = classModel.goodsTypeName;
                    }

                    DataRow dr = dt.NewRow();
                    dr["展商名称"] = sellerName;
                    dr["展品名称"] = product.productName; ;
                    dr["展品分类"] = className;
                    dr["现价/元"] = product.nprice;
                    dr["售罄标识"] = product.quantity > 0 ? "否" : "是";
                    dt.Rows.Add(dr);
                }
            }

            ds.Tables.Add(dt);

            ExportHelper.ResponseExcel("展品列表.xlsx", ds);
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