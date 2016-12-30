using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZHT.Data.Models
{
    public partial class Exhibition
    {
        public Exhibition()
        {
            this.exhibitiontag = new List<ExhibitionTag>();
            this.followmoment = new List<FollowMoment>();
            this.moment = new List<Moment>();
            this.schedule = new List<Schedule>();
            this.seatset = new List<SeatSet>();
            this.sellerorder = new List<SellerOrder>();
            this.ticketsset = new List<TicketsSet>();
            this.exhibitionproductclass = new List<ExhibitionProductClass>();
            this.myfavorites = new List<MyFavorites>();
            this.enrolluser = new List<EnrollUser>();
            this.settlement = new List<Settlement>();
        }
        #region 属性
        public string id { get; set; }
        public string exhibitionname { get; set; }
        public string basetypescode { get; set; }
        public string nocolumn { get; set; }
        public DateTime starttime { get; set; }
        public DateTime endtime { get; set; }
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string detailes { get; set; }
        public Nullable<int> recruitstatus { get; set; }
        public Nullable<int> enrollstatus { get; set; }
        public string businessid { get; set; }
        public string businessname { get; set; }
        public DateTime publishedtime { get; set; }
        public DateTime recruitendtime { get; set; }
        public DateTime enrollstarttime { get; set; }
        public DateTime enrollendtime { get; set; }
        public decimal lowdiscount { get; set; }
        public decimal saleproportion { get; set; }
        public string creater { get; set; }
        public DateTime creattime { get; set; }
        public string modifier { get; set; }
        public DateTime modifiytime { get; set; }
        public Nullable<int> isdel { get; set; }
        public string temp1 { get; set; }
        public string temp2 { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string area { get; set; }
        #endregion

        public virtual ICollection<ExhibitionTag> exhibitiontag { get; set; }
        public virtual BaseTypes basetypes { get; set; }
        public virtual ICollection<ExhibitionProductClass> exhibitionproductclass{get;set;}

        public virtual ICollection<MyFavorites> myfavorites { get; set; }

        public virtual ICollection<EnrollUser> enrolluser { get; set; }
        public virtual ICollection<FollowMoment> followmoment { get; set; }
        public virtual ICollection<Moment> moment { get; set; }
        public virtual ICollection<Schedule> schedule { get; set; }
        public virtual ICollection<SeatSet> seatset { get; set; }
        public virtual ICollection<SellerOrder> sellerorder { get; set; }
        public virtual ICollection<TicketsSet> ticketsset { get; set; }
        public virtual ICollection<Settlement> settlement { get; set; }
    }
}
