using System.Data.Entity;
using ZHT.Data.Models.Mapping;

namespace ZHT.Data.Models
{
    public partial class ZHTDataContext : DbContext
    {
        static ZHTDataContext()
        {
            Database.SetInitializer<ZHTDataContext>(null);
        }

        public ZHTDataContext()
            : base("Name=ZHT")
        {
        }

        public DbSet<BaseTypes> basetypes { get; set; }
        public DbSet<EnrollUser> enrolluser { get; set; }
        public DbSet<Exhibition> exhibition { get; set; }
        public DbSet<ExhibitionTag> exhibitionTag { get; set; }
        public DbSet<ExhibitionProduct> exhibitionProduct { get; set; }
        public DbSet<ExhibitionProductClass> exhibitionProductClass { get; set; }
        public DbSet<FollowMoment> followMoment { get; set; }
        public DbSet<Moment> moment { get; set; }
        public DbSet<MomentReply> momentReply { get; set; }
        public DbSet<MyFavorites> myfavorites { get; set; }
        public DbSet<Notify> notify { get; set; }
        public DbSet<Schedule> schedule { get; set; }
        public DbSet<SeatNo> seatNo { get; set; }
        public DbSet<SeatSet> seatSet { get; set; }
        public DbSet<SellerOrder> sellerOrder { get; set; }
        public DbSet<SellerOrderDetails> sellerOrderDetails { get; set; }
        public DbSet<TicketsSet> ticketsSet { get; set; }
        public DbSet<TicketsType> ticketsType { get; set; }
        public DbSet<BusinessScope> businessScope { get; set; }
        public DbSet<BusinessScopeType> businessScopeType { get; set; }
        public DbSet<Goods> goods { get; set; }
        public DbSet<Goods_BusinessScopeType> goods_BusinessScopeType { get; set; }
        public DbSet<Goods_Material> goods_Material { get; set; }
        public DbSet<GoodsUnit> goodsUnit { get; set; }
        public DbSet<Material> material { get; set; }
        public DbSet<Order> order { get; set; }
        public DbSet<OrderDetail> orderDetail { get; set; }
        public DbSet<Settlement> settlement { get; set; }
        public DbSet<Attachment> attachments { get; set; }
        public DbSet<AttachmentType> attachmentTypes { get; set; }
        public DbSet<AuditStatu> auditStatus { get; set; }
        public DbSet<BankCard> bankCards { get; set; }
        public DbSet<BusinessType> businessTypes { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<CompanyUser> companyUsers { get; set; }
        public DbSet<ContentInfo> contentInfoes { get; set; }
        public DbSet<ContentType> contentTypes { get; set; }
        public DbSet<UserInfo> userInfo { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new BaseTypesMap());
            modelBuilder.Configurations.Add(new EnrollUserMap());
            modelBuilder.Configurations.Add(new ExhibitionMap());
            modelBuilder.Configurations.Add(new ExhibitionTagMap());
            modelBuilder.Configurations.Add(new ExhibitionProductMap());
            modelBuilder.Configurations.Add(new ExhibitionProductClassMap());
            modelBuilder.Configurations.Add(new FollowMomentMap());
            modelBuilder.Configurations.Add(new MomentMap());
            modelBuilder.Configurations.Add(new MomentReplyMap());
            modelBuilder.Configurations.Add(new MyFavoritesMap());
            modelBuilder.Configurations.Add(new ScheduleMap());
            modelBuilder.Configurations.Add(new SeatNoMap());
            modelBuilder.Configurations.Add(new SeatSetMap());
            modelBuilder.Configurations.Add(new SellerOrderMap());
            modelBuilder.Configurations.Add(new SellerOrderDetailsMap());
            modelBuilder.Configurations.Add(new TicketsSetMap());
            modelBuilder.Configurations.Add(new TicketsTypeMap());
            modelBuilder.Configurations.Add(new SettlementMap());
            modelBuilder.Configurations.Add(new BusinessScopeMap());
            modelBuilder.Configurations.Add(new BusinessScopeTypeMap());
            modelBuilder.Configurations.Add(new GoodsMap());
            modelBuilder.Configurations.Add(new Goods_BusinessScopeTypeMap());
            modelBuilder.Configurations.Add(new GoodsUnitMap());
            modelBuilder.Configurations.Add(new Goods_MaterialMap());
            modelBuilder.Configurations.Add(new MaterialMap());
            modelBuilder.Configurations.Add(new OrderMap());
            modelBuilder.Configurations.Add(new OrderDetailMap());
            modelBuilder.Configurations.Add(new AttachmentMap());
            modelBuilder.Configurations.Add(new AttachmentTypeMap());
            modelBuilder.Configurations.Add(new AuditStatuMap());
            modelBuilder.Configurations.Add(new BankCardMap());
            modelBuilder.Configurations.Add(new BusinessTypeMap());
            modelBuilder.Configurations.Add(new CompanyMap());
            modelBuilder.Configurations.Add(new CompanyUserMap());
            modelBuilder.Configurations.Add(new ContentInfoMap());
            modelBuilder.Configurations.Add(new ContentTypeMap());
            modelBuilder.Configurations.Add(new UserInfoMap());
        }
    }
}
