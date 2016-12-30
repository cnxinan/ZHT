using Autofac;
using System;
using ZHT.Core.Infrastructure;
using ZHT.Core.UnitOfWork;
using ZHT.Data;
using ZHT.Data.DbFactory;
using ZHT.Repository;
using ZHT.Repository.Base;
using ZHT.Service;

namespace ZHT.Manage
{
    public class DIConfig
    {
        public static IContainer container;

        public static void  Register()
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterModule(new EntityFrameworkModel(true));
            builder.RegisterModule(new RepositoryModel(true));
            builder.RegisterModule(new ServiceModel(true));

            builder.RegisterType<DataBaseFactory>().As<IDataBaseFactory>().SingleInstance();

            #region Repository

            builder.RegisterType<BaseTypesRepository>().As<IBaseTypesRepository>().SingleInstance();
            builder.RegisterType<BusinessScopeRepository>().As<IBusinessScopeRepository>().SingleInstance();
            builder.RegisterType<BusinessScopeTypeRepository>().As<IBusinessScopeTypeRepository>().SingleInstance();
            builder.RegisterType<EnrollUserRepository>().As<IEnrollUserRepository>().SingleInstance();
            builder.RegisterType<ExhibitionProductClassRepository>().As<IExhibitionProductClassRepository>().SingleInstance();
            builder.RegisterType<ExhibitionProductRepository>().As<IExhibitionProductRepository>().SingleInstance();
            builder.RegisterType<ExhibitionRepository>().As<IExhibitionRepository>().SingleInstance();
            builder.RegisterType<ExhibitionTagRepository>().As<IExhibitionTagRepository>().SingleInstance();
            builder.RegisterType<FollowMomentRepository>().As<IFollowMomentRepository>().SingleInstance();
            builder.RegisterType<Goods_BusinessScopeTypeRepository>().As<IGoods_BusinessScopeTypeRepository>().SingleInstance();
            builder.RegisterType<GoodsRepository>().As<IGoodsRepository>().SingleInstance();
            builder.RegisterType<MomentReplyRepository>().As<IMomentReplyRepository>().SingleInstance();
            builder.RegisterType<MomentRepository>().As<IMomentRepository>().SingleInstance();
            builder.RegisterType<MyFavoritesRepository>().As<IMyFavoritesRepository>().SingleInstance();
            builder.RegisterType<NotifyRepository>().As<INotifyRepository>().SingleInstance();
            builder.RegisterType<OrderDetailRepository>().As<IOrderDetailRepository>().SingleInstance();
            builder.RegisterType<OrderRepository>().As<IOrderRepository>().SingleInstance();
            builder.RegisterType<ScheduleRepository>().As<IScheduleRepository>().SingleInstance();
            builder.RegisterType<SeatNoRepository>().As<ISeatNoRepository>().SingleInstance();
            builder.RegisterType<SeatSetRepository>().As<ISeatSetRepository>().SingleInstance();
            builder.RegisterType<SellerOrderDetailsRepository>().As<ISellerOrderDetailsRepository>().SingleInstance();
            builder.RegisterType<SellerOrderRepository>().As<ISellerOrderRepository>().SingleInstance();
            builder.RegisterType<TicketsSetRepository>().As<ITicketsSetRepository>().SingleInstance();
            builder.RegisterType<TicketsTypeRepository>().As<ITicketsTypeRepository>().SingleInstance();
            builder.RegisterType<SettlementRepository>().As<ISettlementRepository>().SingleInstance();
            builder.RegisterType<AttachmentTypeRepository>().As<IAttachmentTypeRepository>().SingleInstance();
            builder.RegisterType<AttachmentRepository>().As<IAttachmentRepository>().SingleInstance();
            builder.RegisterType<CompanyUserRepository>().As<ICompanyUserRepository>().SingleInstance();
            builder.RegisterType<CompanyRepository>().As<ICompanyRepository>().SingleInstance();
            builder.RegisterType<UserInfoRepository>().As<IUserInfoRepository>().SingleInstance();

            #endregion

            #region Service
            builder.RegisterType<BaseTypesService>().As<IBaseTypesService>().SingleInstance();
            builder.RegisterType<BusinessScopeService>().As<IBusinessScopeService>().SingleInstance();
            builder.RegisterType<BusinessScopeTypeService>().As<IBusinessScopeTypeService>().SingleInstance();
            builder.RegisterType<EnrollUserService>().As<IEnrollUserService>().SingleInstance();
            builder.RegisterType<ExhibitionProductClassService>().As<IExhibitionProductClassService>().SingleInstance();
            builder.RegisterType<ExhibitionProductService>().As<IExhibitionProductService>().SingleInstance();
            builder.RegisterType<ExhibitionService>().As<IExhibitionService>().SingleInstance();
            builder.RegisterType<ExhibitionTagService>().As<IExhibitionTagService>().SingleInstance();
            builder.RegisterType<FollowMomentService>().As<IFollowMomentService>().SingleInstance();
            builder.RegisterType<Goods_BusinessScopeTypeService>().As<IGoods_BusinessScopeTypeService>().SingleInstance();
            builder.RegisterType<GoodsService>().As<IGoodsService>().SingleInstance();
            builder.RegisterType<MomentReplyService>().As<IMomentReplyService>().SingleInstance();
            builder.RegisterType<MomentService>().As<IMomentService>().SingleInstance();
            builder.RegisterType<MyFavoritesService>().As<IMyFavoritesService>().SingleInstance();
            builder.RegisterType<NotifyService>().As<INotifyService>().SingleInstance();
            builder.RegisterType<OrderDetailService>().As<IOrderDetailService>().SingleInstance();
            builder.RegisterType<OrderService>().As<IOrderService>().SingleInstance();
            builder.RegisterType<ScheduleService>().As<IScheduleService>().SingleInstance();
            builder.RegisterType<SeatNoService>().As<ISeatNoService>().SingleInstance();
            builder.RegisterType<SeatSetService>().As<ISeatSetService>().SingleInstance();
            builder.RegisterType<SellerOrderDetailsService>().As<ISellerOrderDetailsService>().SingleInstance();
            builder.RegisterType<SellerOrderService>().As<ISellerOrderService>().SingleInstance();
            builder.RegisterType<TicketsSetService>().As<ITicketsSetService>().SingleInstance();
            builder.RegisterType<TicketsTypeService>().As<ITicketsTypeService>().SingleInstance();
            builder.RegisterType<SettlementService>().As<ISettlementService>().SingleInstance();
            builder.RegisterType<AttachmentTypeService>().As<IAttachmentTypeService>().SingleInstance();
            builder.RegisterType<AttachmentService>().As<IAttachmentService>().SingleInstance();
            builder.RegisterType<CompanyService>().As<ICompanyService>().SingleInstance();
            builder.RegisterType<CompanyUserService>().As<ICompanyUserService>().SingleInstance();
            builder.RegisterType<UserInfoService>().As<IUserInfoService>().SingleInstance();

            #endregion

            #region Core
            builder.RegisterType<BaseUnitOfWork>().As<IUnitOfWork>().SingleInstance();

            #endregion

            container = builder.Build();
        }
    }
}