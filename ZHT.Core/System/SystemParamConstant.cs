using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Core.System
{
    public class SystemParamConstant
    {
        public static readonly int Page_PageSize = 12;

        public static readonly int Takeaway_Default_Step = 30;

        public static readonly int RefreshTokenLifeTime = 86400;
        /// <summary>
        /// 大图尺寸(宽*高)
        /// </summary>
        public static readonly Tuple<int, int> BigImageSize = new Tuple<int, int>(500, 500);
        /// <summary>
        /// 产品小图尺寸(宽*高)
        /// </summary>
        public static readonly Tuple<int, int> ProductSmallImageSize = new Tuple<int, int>(90, 60);


        /// <summary>
        /// 商家编码方式
        /// </summary>
        public static readonly string businessesCode_titlecode = "BUSINESSESCODE";
        /// <summary>
        /// 商家编码
        /// </summary>
        public static readonly string businessesCode_uniqueCode = "BUSINESSES_UC";


        /// <summary>
        /// 登录状态
        /// </summary>
        public static readonly string LoginStatus_titlecode = "LOGINSTATUS";
        /// <summary>
        /// 在线
        /// </summary>
        public static readonly string LoginStatus_online = "LOGINSTATUS_ONLINE";
        /// <summary>
        /// 离线
        /// </summary>
        public static readonly string LoginStatus_offline = "LOGINSTATUS_OFFLINE";
        /// <summary>
        /// 锁屏
        /// </summary>
        public static readonly string LoginStatus_lock = "LOGINSTATUS_LOCK";


        /// <summary>
        /// 公众号类型
        /// </summary>
        public static readonly string WeixinAccountType_titlecode = "WEIXINACCOUNTTYPE";
        /// <summary>
        /// 订阅号
        /// </summary>
        public static readonly string WeixinAccountType_subscribe = "WEIXINACCOUNTTYPE_SUB";

        /// <summary>
        /// 服务号
        /// </summary>
        public static readonly string WeixinAccountType_service = "WEIXINACCOUNTTYPE_SER";


        /// <summary>
        /// 营业时间类型
        /// </summary>
        public static readonly string timename_titlecode = "TIMENAME";
        /// <summary>                
        /// 早市                    
        /// </summary>               
        public static readonly string timename_morning = "TIMENAME_MORNING";

        /// <summary>                
        /// 午市                    
        /// </summary>               
        public static readonly string timename_afternoon = "TIMENAME_AFTERNOON";

        /// <summary>                
        /// 晚市                    
        /// </summary>               
        public static readonly string timename_evening = "TIMENAME_EVENING";


        #region 餐台状态
        /// <summary>
        /// 餐台状态
        /// </summary>
        public static readonly string DiningTableStatus_titlecode = "DININGTABLESTATUS";
        /// <summary>                
        /// 空闲                    
        /// </summary>               
        public static readonly string DiningTableStatus_free = "DININGTABLESTATUS_FREE";

        /// <summary>                
        /// 就餐                    
        /// </summary>               
        public static readonly string DiningTableStatus_busy = "DININGTABLESTATUS_EAT";
        /// <summary>                
        /// 已开台                    
        /// </summary>               
        public static readonly string DiningTableStatus_open = "DININGTABLESTATUS_OPEN";

        /// <summary>                
        /// 预定                    
        /// </summary>               
        public static readonly string DiningTableStatus_booking = "DININGTABLESTATUS_BOOKING";


        #endregion

        #region 订单状态

        /// <summary>
        /// 新单
        /// </summary>
        public static readonly string OrderStatus_new = "ORDERSTATUS_NEW";

        /// <summary>
        /// 已受理
        /// </summary>
        public static readonly string OrderStatus_accept = "ORDERSTATUS_ACCEPT";

        /// <summary>
        /// 已取消
        /// </summary>
        public static readonly string OrderStatus_cancel = "ORDERSTATUS_CANCEL";

        /// <summary>
        ///  制作中                                              
        /// </summary>
        public static readonly string OrderStatus_make = "ORDERSTATUS_MAKE";

        /// <summary>
        ///  制作完成                                              
        /// </summary>
        public static readonly string OrderStatus_make_complete = "ORDERSTATUS_MAKE_COMPLETE";

        /// <summary>
        ///  完成                                              
        /// </summary>
        public static readonly string OrderStatus_success = "ORDERSTATUS_SUCCESS";

     
        /// <summary>
        /// 送货中
        /// </summary>
        public static readonly string OrderStatus_deliver = "ORDERSTATUS_DELIVER";
        /// <summary>
        /// 等叫
        /// </summary>
        public static readonly string OrderStatus_waitcall = "ORDERSTATUS_WATICALL";

       
        /// <summary>
        /// 未使用
        /// </summary>
        public static readonly string OrderStatus_unused = "ORDERSTATUS_UNUSED";

        /// <summary>
        /// 已送达
        /// </summary>
        public static readonly string OrderStatus_arrive = "ORDERSTATUS_ARRIVE";




        #endregion

        #region 订单来源
        /// <summary>
        /// 订单来源
        /// </summary>
        public static readonly string OrderFrom_titlecode = "ORDERFROM";
        /// <summary>                
        /// 线上                    
        /// </summary>               
        public static readonly string OrderFrom_lin = "ORDERFROM_LIN";
        /// <summary>                
        /// 线下                    
        /// </summary>               
        public static readonly string OrderFrom_off = "ORDERFROM_OFF";
        #endregion

        #region 微活动任务金额分配方式
        /// <summary>
        /// 微活动任务金额分配方式
        /// </summary>
        public static readonly string allocationType_titlecode = "ALLOCATIONTYPE";
        /// <summary>
        /// 只给领取者奖励：任务金额起作用
        /// </summary>
        public static readonly string allocationType_PA = "ALLOCATIONTYPE_PA";
        /// <summary>
        /// 按照层级奖励：任务分配方式 表起作用
        /// </summary>
        public static readonly string allocationType_LA = "ALLOCATIONTYPE_LA";
        #endregion

        #region 微活动奖励类型
        /// <summary>
        /// 微活动奖励类型
        /// </summary>
        public static readonly string rewardType_titlecode = "REWARDTYPE";

        /// <summary>
        /// 虚拟（可线下兑换）
        /// </summary>
        public static readonly string rewardType_VIR = "REWARDTYPE_VIR";
        /// <summary>
        /// 红包
        /// </summary>
        public static readonly string rewardType_WRP = "REWARDTYPE_WRP";
        /// <summary>
        /// 券
        /// </summary>
        //public static readonly string rewardType_QU = "REWARDTYPE_QU";

        #endregion

        /// <summary>
        /// 单位类型
        /// </summary>
        public static readonly string unitType_titlecode = "UNITTYPE";
        /// <summary>                
        /// 菜品                    
        /// </summary>               
        public static readonly string unitType_dishes = "UNITTYPE_DI";

        /// <summary>                
        /// 物料                    
        /// </summary>               
        public static readonly string unitType_material = "UNITTYPE_MA";

        #region 回复消息类型
        /// <summary>
        /// 回复消息类型
        /// </summary>
        public static readonly string replyMessageType_titlecode = "REPLYMESSAGETYPE";
        /// <summary>                
        /// 文本                    
        /// </summary>               
        public static readonly string replyMessageType_text = "REPLYMESSAGETYPE_TEXT";
        /// <summary>                
        /// 图文                    
        /// </summary>               
        public static readonly string replyMessageType_graphics = "REPLYMESSAGETYPE_GRAPHICS";
        #endregion

		
		#region 响应类型
        /// <summary>
        /// 响应类型
        /// </summary>
        public static readonly string respondtype_titlecode = "RESPONDTYPE";
        /// <summary>                
        /// 文本                    
        /// </summary>               
        public static readonly string respondtype_text = "RESPONDTYPE_TEXT";
        /// <summary>                
        /// 图文                    
        /// </summary>               
        public static readonly string respondtype_graphics = "RESPONDTYPE_GRAPHICS";
        #endregion
		
		#region 触发类型
        /// <summary>
        /// 触发类型
        /// </summary>
        public static readonly string triggertype_titlecode = "TRIGGERTYPE";
        /// <summary>                
        /// 关注                    
        /// </summary>               
        public static readonly string triggertype_focus = "TRIGGERTYPE_FOCUS";
        /// <summary>                
        /// 默认                    
        /// </summary>               
        public static readonly string triggertype_default = "TRIGGERTYPE_DEFAULT";
        #endregion
		
		#region 按钮类型
        /// <summary>
        /// 按钮类型
        /// </summary>
        public static readonly string buttontype_titlecode = "BUTTONTYPE";
        /// <summary>                
        /// 点击推事件                    
        /// </summary>               
        public static readonly string buttontype_click = "BUTTONTYPE_CLICK";
        /// <summary>                
        /// 跳转URL                    
        /// </summary>               
        public static readonly string buttontype_view = "BUTTONTYPE_VIEW";
		 /// <summary>                
        /// 扫码                    
        /// </summary>               
        public static readonly string buttontype_scan = "BUTTONTYPE_SCAN";
        #endregion
		

        #region 微信活动类型
        /// <summary>
        /// 微信活动类型
        /// </summary>
        public static readonly string activityType = "WEIXINTOOLTYPE";
        /// <summary>
        /// 红包
        /// </summary>
        public static readonly string activityType_red = "WEIXINTOOLTYPE_RED";
        /// <summary>
        /// 任务
        /// </summary>
        public static readonly string activityType_Task = "WEIXINTOOLTYPE_TK";
        /// <summary>
        /// 优惠券
        /// </summary>
        public static readonly string activityType_Coupon = "WEIXINTOOLTYPE_CN";
        /// <summary>
        /// 微砍价
        /// </summary>
        public static readonly string activityType_Bargain = "WEIXINTOOLTYPE_BN";
        #endregion

        #region 微任务类型

        /// <summary>
        /// 微任务类型
        /// </summary>
        public static readonly string taskType_titlecode = "TASKTYPE";
        /// <summary>
        /// 红包任务
        /// </summary>
        public static readonly string taskType_Red = "TASKTYPE_RED";
        /// <summary>
        /// 二维码任务
        /// </summary>
        public static readonly string taskType_Follow = "TASKTYPE_FOL";

        #endregion

        /// <summary>
        /// 开放日类型
        /// </summary>
        public static readonly string openDay_titlecode = "OPENDAY";
        /// <summary>                
        /// 每周                    
        /// </summary>               
        public static readonly string openDay_wee = "OPENDAY_WEE";

        /// <summary>                
        /// 每月                    
        /// </summary>               
        public static readonly string openDay_mon = "OPENDAY_MON";

        #region 职位类型
        public static readonly string position_type = "POSITIONTYPE";
        /// <summary>
        /// 收银员
        /// </summary>
        public static readonly string position_cashier = "POSITION_CASHIER";

        /// <summary>
        /// 服务员
        /// </summary>
        public static readonly string position_waiter = "POSITION_WAITER";


        /// <summary>
        /// 配送员
        /// </summary>
        public static readonly string position_deliver = "POSITION_DELIVER";

        /// <summary>
        /// 后台业务管理者
        /// </summary>
        public static readonly string position_sysmanager = "POSITION_SYSMANAGER";

        /// <summary>
        /// 店主
        /// </summary>
        public static readonly string position_storemanager = "POSITION_STOREMANAGER";

        /// <summary>
        /// 经理
        /// </summary>
        public static readonly string position_manager = "POSITION_MANAGER";

        /// <summary>
        /// 厨师
        /// </summary>
        public static readonly string position_kitchener = "POSITION_KITCHENER";

        #endregion

        #region 产品类型
        /// <summary>
        ///  产品类型
        /// </summary>
        public static readonly string productType_titlecode = "PRODUCTTYPE";
        /// <summary>
        ///  餐饮
        /// </summary>
        public static readonly string producttype_dining = "PRODUCTTYPE_DINING";
        /// <summary>
        ///  其他
        /// </summary>
        public static readonly string producttype_other = "PRODUCTTYPE_OTHER";
        #endregion

        #region 产品图片用途
        /// <summary>
        ///  产品图片用途
        /// </summary>
        public static readonly string productimageuse_titlecode = "PRODUCTIMAGEUSE";
        /// <summary>
        /// 列表展示
        /// </summary>
        public static readonly string productimageuse_list = "PRODUCTIMAGEUSE_LIST";
        /// <summary>
        ///  详情展示
        /// </summary>
        public static readonly string productimageuse_detail = "PRODUCTIMAGEUSE_DETAIL";
       
        #endregion

        #region 推广二维码反馈消息
        /// <summary>
        /// 推广二维码反馈消息
        /// </summary>
        public static readonly string qrcodetask_titlecode = "QRCODETASK";
        /// <summary>
        /// 发起者反馈消息
        /// </summary>
        public static readonly string qrcodetask_sponsor = "QRCODETASK_SPONSOR";
        /// <summary>
        /// 关注者反馈消息
        /// </summary>
        public static readonly string qrcodetask_new = "QRCODETASK_NEW";

        #endregion


        /// <summary>
        /// 支付类型
        /// </summary>
        public static readonly string paymentType_titlecode = "PAYMENTTYPE";
        /// <summary>                
        /// 收款                    
        /// </summary>               
        public static readonly string paymentType_online= "PAYMENTTYPE_RECEIPTS";

        /// <summary>                
        /// 支付                    
        /// </summary>               
        public static readonly string paymentType_offline = "PAYMENTTYPE_PAYMENT";   


        #region 单据编码类型

        public static readonly string codeSchemeType_titlecode = "CODESCHEMETYPE";

        /// <summary>
        /// 结账单
        /// </summary>
        public static readonly string codeSchemeType_cash = "CODESCHEMETYPE_CASH";

        /// <summary>
        /// 退款单
        /// </summary>
        public static readonly string codeSchemeType_refund = "CODESCHEMETYPE_REFUND";

        /// <summary>
        /// 送货单
        /// </summary>
        public static readonly string codeschemetype_delivery = "CODESCHEMETYPE_DELIVERY";

        /// <summary>
        /// 会员卡充值单
        /// </summary>
        public static readonly string codeschemetype_memrecharge = "CODESCHEMETYPE_MEMRECHARGE";


        /// <summary>
        /// 临时卡充值单
        /// </summary>
        public static readonly string codeschemetype_tempcardrecharge = "CODESCHEMETYPE_TEMPCARDRECHARGE";


        /// <summary>
        /// 临时卡退款单
        /// </summary>
        public static readonly string codeschemetype_tempcardrefund = "CODESCHEMETYPE_TEMPCARDREFUND";


        /// <summary>
        /// 微信充值单
        /// </summary>
        public static readonly string codeSchemeType_recharge = "CODESCHEMETYPE_RECHARGE";



        #endregion

        #region 单据编码方式
        /// <summary>
        /// 编码方式
        /// </summary>
        public static readonly string CodeType_titlecode = "CODETYPE";
        /// <summary>
        /// 流水号
        /// </summary>
        public static readonly string CodeType_seq = "CODETYPE_SN";
        /// <summary>
        /// 年编号
        /// </summary>
        public static readonly string CodeType_yea = "CODETYPE_YN";
        /// <summary>
        /// 月编号
        /// </summary>
        public static readonly string CodeType_mon = "CODETYPE_MN";
        /// <summary>
        /// 日编号
        /// </summary>
        public static readonly string CodeType_day = "CODETYPE_DN";
        #endregion


        #region 产品营销
        #region 营销类型
        /// <summary>
        /// 营销类型
        /// </summary>
        public static readonly string marketingType_titlecode = "MARKETINGTYPE";
        /// <summary>                
        /// 首次关注                    
        /// </summary>               
        public static readonly string marketingType_first = "MARKETINGTYPE_FIRST";    

        /// <summary>                
        /// 累计次数                    
        /// </summary>               
        public static readonly string marketingType_addcount = "MARKETINGTYPE_ADDCOUNT";

        /// <summary>                
        /// 累计金额                    
        /// </summary>               
        public static readonly string marketingType_addamount = "MARKETINGTYPE_ADDAMOUNT";

        /// <summary>                
        /// 微信支付                    
        /// </summary>               
        public static readonly string marketingtype_weipay = "MARKETINGTYPE_WEIPAY";
        #endregion

        #region 优惠方式
        /// <summary>
        /// 优惠方式
        /// </summary>
        public static readonly string discountType_titlecode = "DISCOUNTTYPE";
        /// <summary>                
        /// 特价                    
        /// </summary>               
        public static readonly string discountType_special = "DISCOUNTTYPE_SPECIAL";

        /// <summary>                
        /// 打折                   
        /// </summary>               
        public static readonly string discountType_discount = "DISCOUNTTYPE_DISCOUNT";

		/// <summary>                
        /// 送金额                   
        /// </summary>               
        public static readonly string discounttype_giveamount = "DISCOUNTTYPE_GIVEAMOUNT";
		
        /// <summary>                
        /// 送积分                    
        /// </summary>               
        public static readonly string discounttype_givepoint = "DISCOUNTTYPE_GIVEPOINT";



        #endregion

        #region 营销使用类型
        /// <summary>
        /// 营销使用类型
        /// </summary>
        public static readonly string marketingUseType_titlecode = "MARKETINGUSETYPE";
        /// <summary>                
        /// 会员卡                    
        /// </summary>               
        public static readonly string marketingusetype_card = "MARKETINGUSETYPE_CARD";

        /// <summary>                
        /// 消费                    
        /// </summary>               
        public static readonly string marketingusetype_sale = "MARKETINGUSETYPE_SALE";
      
        #endregion

        #endregion    
        

        #region 微信菜单URL类型
        /// <summary>
        /// 菜单URL类型
        /// </summary>
        public static readonly string menuUrlType_titlecode = "MENUTYPE_CUSTOM";
        /// <summary>
        /// 商家入口
        /// </summary>
        public static readonly string menuUrlType_Cashier = "MENUTYPE_CASHIER";
        /// <summary>
        /// 个人中心
        /// </summary>
        public static readonly string menuUrlType_PersonalCenter = "MENUTYPE_PERSONAL_CENTER";
        /// <summary>
        /// 在线购票
        /// </summary>
        public static readonly string menuUrlType_Myticket = "MENUTYPE_MYTICKET";
        /// <summary>
        /// 快速支付
        /// </summary>
        public static readonly string menuUrlType_FastPay= "MENUTYPE_FASTPAY";
        #endregion

        #region 会员消费提成
        /// <summary>
        /// 会员消费提成类型
        /// </summary>
        public static readonly string commissionSpendType_titlecode = "COMMISSIONSPENDTYPE";
        /// <summary>
        /// 按次提成
        /// </summary>
        public static readonly string commissionSpendType_CIT = "COMMISSIONSPENDTYPE_CIT";
        /// <summary>
        /// 按消费金额提成
        /// </summary>
        public static readonly string commissionSpendType_XFT = "COMMISSIONSPENDTYPE_XFT";
        /// <summary>
        /// 按充值金额提成
        /// </summary>
        public static readonly string commissionSpendType_CHO = "COMMISSIONSPENDTYPE_CHO";

        /// <summary>
        /// 会员消费提成金额类型
        /// </summary>
        public static readonly string commissionAmountType_titlecode = "COMMISSIONAMOUNTTYPE";
        /// <summary>
        /// 固定金额
        /// </summary>
        public static readonly string commissionAmountType_FIX = "COMMISSIONAMOUNTTYPE_FIX";
        /// <summary>
        /// 百分比
        /// </summary>
        public static readonly string commissionAmountType_PER = "COMMISSIONAMOUNTTYPE_PER";

        #endregion

        /// <summary>
        ///小票类型 
        /// </summary>
        public static readonly string receiptType_titlecode = "RECEIPTTYPE";

        /// <summary>
        /// 充值小票  
        /// </summary>
        public static readonly string receiptType_recharge = "RECEIPTTYPE_RECHARGE";

        /// <summary>
        /// 结账小票  
        /// </summary>
        public static readonly string receiptType_settle = "RECEIPTTYPE_SETTLE";


        /// <summary>
        /// 物流小票  
        /// </summary>
        public static readonly string receiptType_delivery = "RECEIPTTYPE_DELIVERY";


        #region 评价类型
        /// <summary>
        ///评价类型 
        /// </summary>
        public static readonly string ratingType_titlecode = "RATINGTYPE";

        /// <summary>
        /// 质量  
        /// </summary>
        public static readonly string ratingType_quality = "RATINGTYPE_QUALITY";


        /// <summary>
        /// 物流  
        /// </summary>
        public static readonly string ratingType_logistics = "RATINGTYPE_LOGISTICS";


        /// <summary>
        /// 服务态度  
        /// </summary>
        public static readonly string ratingType_manner = "RATINGTYPE_MANNER";
        #endregion  
        

        #region 性别
        /// <summary>
        ///性别 
        /// </summary>
        public static readonly string gender_titlecode = "GENDER";

        /// <summary>
        /// 男  
        /// </summary>
        public static readonly string gender_male = "GENDER_MALE";
        /// <summary>
        /// 女
        /// </summary>
        public static readonly string gender_female = "GENDER_FEMALE";
        #endregion


        #region 门店类型

        /// <summary>
        ///门店类型 
        /// </summary>
        public static readonly string storeType_titlecode = "STORETYPE";

        /// <summary>
        /// 租赁
        /// </summary>
        public static readonly string storeType_leasing = "STORETYPE_LEASING";

        /// <summary>
        /// 联营
        /// </summary>
        public static readonly string storeType_related = "STORETYPE_RELATED";

        /// <summary>
        /// 自营
        /// </summary>
        public static readonly string storeType_self = "STORETYPE_SELF";


        #endregion

        #region 行业类型

        /// <summary>
        ///行业类型 
        /// </summary>
        public static readonly string industryType_titlecode = "INDUSTRYTYPE";

        /// <summary>
        ///餐饮 
        /// </summary>
        public static readonly string industryType_dining = "INDUSTRYTYPE_DINING";

        /// <summary>
        ///酒店 
        /// </summary>
        public static readonly string industryType_hotel = "INDUSTRYTYPE_HOTEL";

        /// <summary>
        ///百货 
        /// </summary>
        public static readonly string industryType_mall = "INDUSTRYTYPE_MALL";

        /// <summary>
        ///票务 
        /// </summary>
        public static readonly string industryType_amusement = "INDUSTRYTYPE_AMUSEMENT";

        /// <summary>
        ///售卡店
        /// </summary>
        public static readonly string industrytype_cardselling = "INDUSTRYTYPE_CARDSELLING";

        /// <summary>
        ///快速收款(没有具体的商品，只记录交易金额) 
        /// </summary>
        public static readonly string industrytype_other = "INDUSTRYTYPE_OTHER";


        /// <summary>
        ///快速开单
        /// </summary>
        public static readonly string industrytype_quickorder = "INDUSTRYTYPE_QUICKORDER";

        /// <summary>
        ///酒吧
        /// </summary>
        public static readonly string industrytype_bar = "INDUSTRYTYPE_BAR";


        /// <summary>
        ///茶艺
        /// </summary>
        public static readonly string industrytype_tea = "INDUSTRYTYPE_TEA";


        #endregion

        #region 统计类型

        /// <summary>
        ///统计类型 
        /// </summary>
        public static readonly string statisticaltype_titlecode = "STATISTICALTYPE";

        /// <summary>
        ///餐饮 
        /// </summary>
        public static readonly string statisticaltype_dining = "STATISTICALTYPE_DINING";

        /// <summary>
        ///酒店 
        /// </summary>
        public static readonly string statisticaltype_hotel = "STATISTICALTYPE_HOTEL";

        /// <summary>
        ///百货 
        /// </summary>
        public static readonly string statisticaltype_mall = "STATISTICALTYPE_MALL";

        /// <summary>
        ///票务 
        /// </summary>
        public static readonly string statisticaltype_ticket = "STATISTICALTYPE_TICKET";

        /// <summary>
        ///售卡
        /// </summary>
        public static readonly string statisticaltype_cardselling = "STATISTICALTYPE_CARDSELLING";

        /// <summary>
        ///酒吧
        /// </summary>
        public static readonly string statisticaltype_bar = "STATISTICALTYPE_BAR";


        /// <summary>
        ///茶艺
        /// </summary>
        public static readonly string statisticaltype_tea = "STATISTICALTYPE_TEA";

      


        #endregion


        #region 餐饮模式
        /// <summary>
        ///餐饮模式 
        /// </summary>
        public static readonly string diningModel_titlecode = "DININGMODEL";
        /// <summary>
        ///自助&快餐 
        /// </summary>
        public static readonly string diningModel_buffetfast = "DININGMODEL_BUFFETFAST";

        /// <summary>
        ///堂吃
        /// </summary>
        public static readonly string diningModel_eat = "DININGMODEL_EAT";

        /// <summary>
        ///混合
        /// </summary>
        public static readonly string diningModel_compound = "DININGMODEL_COMPOUND";
        #endregion

        #region 设备类型
        /// <summary>
        ///设备类型 
        /// </summary>
        public static readonly string deviceTypeModel_titlecode = "DEVICETYPE";
        /// <summary>
        ///POS
        /// </summary>
        public static readonly string deviceTypeModel_post = "DEVICETYPE_POS";
        /// <summary>
        /// 扫描器
        /// </summary>
        public static readonly string deviceTypeModel_scanner = "DEVICETYPE_SCANNER";
        /// <summary>
        /// 门禁
        /// </summary>
        public static readonly string deviceTypeModel_barriergate = "DEVICETYPE_BARRIERGATE";
        #endregion

        #region 评价用途

        /// <summary>
        ///评价用途 
        /// </summary>
        public static readonly string ratinguser_titlecode = "RATINGUSER";
        /// <summary>
        ///订单
        /// </summary>
        public static readonly string ratinguser_order = "RATINGUSER_ORDER";
        /// <summary>
        /// 物料订单
        /// </summary>
        public static readonly string ratinguser_bomorder = "RATINGUSER_BOMORDER";

        #endregion

        #region 拒绝类型

        /// <summary>
        ///拒绝类型 
        /// </summary>
        public static readonly string refusetype_titlecode = "REFUSETYPE";
        /// <summary>
        ///订单
        /// </summary>
        public static readonly string refusetype_order = "REFUSETYPE_ORDER";
        /// <summary>
        /// 物料订单
        /// </summary>
        public static readonly string refusetype_bomorder = "REFUSETYPE_BOMORDER";

        #endregion 

        #region 业务要求 要求类型

        /// <summary>
        ///业务要求 要求类型
        /// </summary>
        public static readonly string demandtype_titlecode = "DEMANDTYPE";
        /// <summary>
        ///补打
        /// </summary>
        public static readonly string demandtype_repairprint = "DEMANDTYPE_REPAIRPRINT";
        /// <summary>
        /// 特殊
        /// </summary>
        public static readonly string demandtype_exceptive = "DEMANDTYPE_EXCEPTIVE";

        #endregion

        #region 门店图片 图片用途

        /// <summary>
        ///门店图片 图片用途
        /// </summary>
        public static readonly string storephototype_titlecode = "STOREPHOTOTYPE";
        /// <summary>
        ///轮播
        /// </summary>
        public static readonly string storephototype_carousel = "STOREPHOTOTYPE_CAROUSEL";
        /// <summary>
        ///   票据背景
        /// </summary>
        public static readonly string storephototype_ticketback = "STOREPHOTOTYPE_TICKETBACK";

        #endregion

        #region 微信模板消息 模板类型

        /// <summary>
        ///微信模板消息 模板类型
        /// </summary>
        public static readonly string templatetype_titlecode = "TEMPLATETYPE";

        /// <summary>
        ///供应商使用
        /// </summary>
        public static readonly string templatetype_supplier = "TEMPLATETYPE_SUPPLIER";

        /// <summary>
        /// 门店使用
        /// </summary>
        public static readonly string templatetype_store = "TEMPLATETYPE_STORE";

        /// <summary>
        /// 商家使用
        /// </summary>
        public static readonly string templatetype_businesses = "TEMPLATETYPE_BUSINESSES";

        #endregion

		#region 订单状态 状态类型

        /// <summary>
        ///订单状态 状态类型
        /// </summary>
        public static readonly string statustype_titlecode = "STATUSTYPE";

        /// <summary>
        ///普通订单状态
        /// </summary>
        public static readonly string statustype_normal = "STATUSTYPE_NORMAL";

        /// <summary>
        /// 物料订单状态
        /// </summary>
        public static readonly string statustype_bom = "STATUSTYPE_BOM";

        #endregion

        #region 订单类型

        /// <summary>
        /// 订单类型
        /// </summary>
        public static readonly string ordertype_titlecode = "ORDERTYPE";

        /// <summary>
        ///堂吃
        /// </summary>
        public static readonly string ordertype_store = "ORDERTYPE_STORE";

        /// <summary>
        /// 快餐
        /// </summary>
        public static readonly string ordertype_fast = "ORDERTYPE_FAST";

        /// <summary>
        /// 外卖
        /// </summary>
        public static readonly string ordertype_takeout = "ORDERTYPE_TAKEOUT";

        /// <summary>
        /// 百货
        /// </summary>
        public static readonly string ordertype_goods = "ORDERTYPE_GOODS";

        /// <summary>
        /// 娱乐
        /// </summary>
        public static readonly string ordertype_recreation = "ORDERTYPE_RECREATION";  

        /// <summary>
        /// 快速消费(没有具体的商品，只记录交易金额)
        /// </summary>
        public static readonly string ordertype_other = "ORDERTYPE_OTHER";

        #endregion

        #region 联系人类别
        /// <summary>
        ///联系人类别 联系人类别
        /// </summary>
        public static readonly string contacttype_titlecode = "CONTACTTYPE";
        /// <summary>
        /// 会员
        /// </summary>
        public static readonly string contacttype_member = "CONTACTTYPE_MEMBER";
        /// <summary>
        /// 签单客户
        /// </summary>
        public static readonly string contacttype_sign = "CONTACTTYPE_SIGN";
        /// <summary>
        /// 门店
        /// </summary>
        public static readonly string contacttype_store = "CONTACTTYPE_STORE";
        #endregion

        #region 抹零方式
        /// <summary>
        ///抹零方式 抹零方式
        /// </summary>
        public static readonly string loosechangettype_titlecode = "LOOSECHANGETTYPE";
        /// <summary>
        ///四舍五入到角
        /// </summary>
        public static readonly string loosechangettype_roundingoff_angle = "LOOSECHANGETTYPE_ROUNDINGOFF_ANGLE";
        /// <summary>
        ///四舍五入到元
        /// </summary>
        public static readonly string loosechangettype_roundingoff_yuan = "LOOSECHANGETTYPE_ROUNDINGOFF_YUAN";
        /// <summary>
        ///向下抹零到角
        /// </summary>
        public static readonly string loosechangettype_downward_angle = "LOOSECHANGETTYPE_DOWNWARD_ANGLE";
        /// <summary>
        ///向下抹零到元
        /// </summary>
        public static readonly string loosechangettype_downward_yuan = "LOOSECHANGETTYPE_DOWNWARD_YUAN";
        /// <summary>
        ///向上抹零到角
        /// </summary>
        public static readonly string loosechangettype_upward_angle = "LOOSECHANGETTYPE_UPWARD_ANGLE";
        /// <summary>
        ///向上抹零到元
        /// </summary>
        public static readonly string loosechangettype_upward_yuan = "LOOSECHANGETTYPE_UPWARD_YUAN";
        /// <summary>
        ///不使用
        /// </summary>
        public static readonly string loosechangettype_nonuse = "LOOSECHANGETTYPE_NONUSE";
        #endregion

        #region 模块类型
        /// <summary>
        ///模块类型
        /// </summary>
        public static readonly string moduletype_titlecode = "MODULETYPE";
        /// <summary>
        /// 商家端
        /// </summary>
        public static readonly string moduletype_business = "MODULETYPE_BUSINESS";
        /// <summary>
        /// 门店端
        /// </summary>
        public static readonly string moduletype_store = "MODULETYPE_STORE";
        /// <summary>
        /// 供应商端
        /// </summary>
        public static readonly string moduletype_vendor = "MODULETYPE_VENDOR";
        #endregion

        #region 菜单类型
        /// <summary>
        ///菜单类型
        /// </summary>
        public static readonly string menutype_titlecode = "MENUTYPE";
        /// <summary>
        /// 分类
        /// </summary>
        public static readonly string menutype_nav = "MENUTYPE_NAV";
        /// <summary>
        /// 链接
        /// </summary>
        public static readonly string menutype_href = "MENUTYPE_HREF";

        #endregion

        #region 临时卡状态
        ///<summary>
        ///临时卡状态
        /// </summary>
        public static readonly string tempcardStatus_titlecode = "TEMPCARDSTATUS";
        /// <summary>
        /// 正常
        /// </summary>
        public static readonly string tempcardStatus_normal = "TEMPCARDSTATUS_NORMAL";
        /// <summary>
        /// 失效
        /// </summary>
        public static readonly string tempcardStatus_expire = "TEMPCARDSTATUS_EXPIRE";

        /// <summary>
        /// 空闲
        /// </summary>
        public static readonly string tempcardstatus_free = "TEMPCARDSTATUS_FREE";


        #endregion

        #region 临时卡操作类型
        ///<summary>
        ///临时卡操作类型
        /// </summary>
        public static readonly string tempcardhandtype_titlecode = "TEMPCARDHANDTYPE";
        /// <summary>
        /// 开卡
        /// </summary>
        public static readonly string tempcardhandtype_open = "TEMPCARDHANDTYPE_OPEN";
        /// <summary>
        /// 退卡
        /// </summary>
        public static readonly string tempcardhandtype_return = "TEMPCARDHANDTYPE_RETURN";



        #endregion

        #region 卡片类型
        ///<summary>
        ///卡片类型
        /// </summary>
        public static readonly string cardtype_titlecode = "CARDTYPE";

        /// <summary>
        /// 储值卡
        /// </summary>
        public static readonly string cardtype_valuecard = "CARDTYPE_VALUECARD";

        /// <summary>
        /// 打折卡
        /// </summary>
        public static readonly string cardtype_discountcard = "CARDTYPE_DISCOUNTCARD";

        /// <summary>
        /// 临时卡
        /// </summary>
        public static readonly string cardtype_tempcard = "CARDTYPE_TEMPCARD";


        #endregion

        #region 卡片种类
        ///<summary>
        ///卡片种类
        /// </summary>
        public static readonly string cardcategory_titlecode = "CARDCATEGORY";

        /// <summary>
        /// ID
        /// </summary>
        public static readonly string cardcategory_id = "CARDCATEGORY_ID";

        /// <summary>
        /// IC
        /// </summary>
        public static readonly string cardcategory_ic = "CARDCATEGORY_IC";

        /// <summary>
        /// NFC
        /// </summary>
        public static readonly string cardcategory_nfc = "CARDCATEGORY_NFC";


        #endregion

        #region 打印单据
        ///<summary>
        ///打印单据
        /// </summary>
        public static readonly string printdocument_titlecode = "PRINTDOCUMENT";

        /// <summary>
        /// 结账单
        /// </summary>
        public static readonly string printdocument_cash = "PRINTDOCUMENT_CASH";

        /// <summary>
        /// 暂结单
        /// </summary>
        public static readonly string printdocument_suspense = "PRINTDOCUMENT_SUSPENSE";

        /// <summary>
        /// 厨打单
        /// </summary>
        public static readonly string printdocument_kitchen = "PRINTDOCUMENT_KITCHEN";

        /// <summary>
        /// 传菜单
        /// </summary>
        public static readonly string printdocument_pass = "PRINTDOCUMENT_PASS";

        /// <summary>
        /// 点菜单
        /// </summary>
        public static readonly string printdocument_choose = "PRINTDOCUMENT_CHOOSE";

        /// <summary>
        /// 转台单
        /// </summary>
        public static readonly string printdocument_vary = "PRINTDOCUMENT_VARY";

        /// <summary>
        /// 叫起单
        /// </summary>
        public static readonly string printdocument_wakeup = "PRINTDOCUMENT_WAKEUP";

        /// <summary>
        /// 催菜单
        /// </summary>
        public static readonly string printdocument_urge = "PRINTDOCUMENT_URGE";


        /// <summary>
        /// 订单退款单
        /// </summary>
        public static readonly string printdocument_orderrefund = "PRINTDOCUMENT_ORDERREFUND";

        /// <summary>
        /// 交接班单
        /// </summary>
        public static readonly string printdocument_shifts = "PRINTDOCUMENT_SHIFTS";

        /// <summary>
        /// 送货单
        /// </summary>
        public static readonly string printdocument_delivery = "PRINTDOCUMENT_DELIVERY";

        /// <summary>
        /// 充值单
        /// </summary>
        public static readonly string printdocument_recharge = "PRINTDOCUMENT_RECHARGE";

        /// <summary>
        /// 临时卡退款单
        /// </summary>
        public static readonly string printdocument_temprecharge = "PRINTDOCUMENT_TEMPRECHARGE";


        /// <summary>
        /// 营业日报
        /// </summary>
        public static readonly string printdocument_dailybusiness = "PRINTDOCUMENT_DAILYBUSINESS";


        #endregion

        #region 积分类型
        ///<summary>
        ///积分类型
        /// </summary>
        public static readonly string pointtype_titlecode = "POINTTYPE";

        /// <summary>
        /// 订单消费
        /// </summary>
        public static readonly string pointtype_ordersale = "POINTTYPE_ORDERSALE";

        /// <summary>
        /// 会员营销
        /// </summary>
        public static readonly string pointtype_memmarketing = "POINTTYPE_MEMMARKETING";

        /// <summary>
        /// 充值赠送
        /// </summary>
        public static readonly string pointtype_rechargegive = "POINTTYPE_RECHARGEGIVE";


        #endregion
    }


}