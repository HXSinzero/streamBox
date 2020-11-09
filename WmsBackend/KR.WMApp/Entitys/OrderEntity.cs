using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;

namespace KR.WMApp.Entitys
{
    [Alias("WM_ORDER")]
    public class OrderEntity
    {
        private List<OrderDetailEntity> listOrderDetail = new List<OrderDetailEntity>();

        [PrimaryKey]
        [StringLength(100)]
        [Required]
        public string ID { get; set; }

        [Index(Unique = true)]
        [StringLength(100)]
        [Required]
        public string ORDERNO { get; set; }

        [Required]
        public DateTime? ORDERDATE { get; set; }

        [StringLength(100)]
        [Required]
        public string ORDERTYPE { get; set; }

        [StringLength(100)]
        public string REALTENO01 { get; set; }

        [StringLength(100)]
        public string REALTENO02 { get; set; }

        [StringLength(100)]
        public string REALTENO03 { get; set; }

        [StringLength(100)]
        public string REALTENO04 { get; set; }

        [StringLength(100)]
        public string REALTENO05 { get; set; }

        [StringLength(100)]
        public string NEWBILLID { get; set; }

        [StringLength(100)]
        [Required]
        public string BUSINESSTYPE { get; set; }

        [StringLength(100)]
        [Required]
        public string STATTYPE { get; set; }

        [StringLength(100)]
        [Required]
        public string STOCKNO { get; set; }

        [StringLength(200)]
        [Required]
        public string STOCKNAME { get; set; }

        [StringLength(100)]
        public string CUSTOMERNO { get; set; }

        [StringLength(200)]
        public string CUSTOMERNAME { get; set; }

        [StringLength(100)]
        public string VENDORNO { get; set; }

        [StringLength(200)]
        public string VENDORNAME { get; set; }

        [StringLength(100)]
        public string MASTERNO { get; set; }

        [StringLength(200)]
        public string MASTERNAME { get; set; }

        [StringLength(100)]
        public string PRODUCTERNO { get; set; }

        [StringLength(200)]
        public string PRODUCTERNAME { get; set; }

        [StringLength(100)]
        public string OPDEPTS { get; set; }

        [StringLength(100)]
        public string OPDEPTD { get; set; }

        [StringLength(100)]
        public string PAYMENTSTATE { get; set; }

        [StringLength(100)]
        public string PAYMENT { get; set; }

        public Decimal? PAYMENT_AMOUNT { get; set; }

        [StringLength(100)]
        public string OPUSER1 { get; set; }

        [StringLength(100)]
        public string OPUSER2 { get; set; }

        [StringLength(100)]
        public string OPUSER3 { get; set; }

        [StringLength(100)]
        public string OPUSER4 { get; set; }

        [StringLength(100)]
        public string OPUSER5 { get; set; }

        [StringLength(100)]
        public string OPUSER6 { get; set; }

        [StringLength(100)]
        public string OPUSER7 { get; set; }

        [StringLength(100)]
        public string OPUSER8 { get; set; }

        [StringLength(100)]
        public string OPUSER9 { get; set; }

        [StringLength(100)]
        public string OPUSER10 { get; set; }

        [StringLength(100)]
        public string STOREMAN { get; set; }

        [StringLength(100)]
        public string PRIORITY { get; set; }

        [StringLength(100)]
        public string DRIVER { get; set; }

        [StringLength(100)]
        public string TRUCKNO { get; set; }

        [StringLength(100)]
        public string STARTDATE { get; set; }

        [StringLength(100)]
        public string ENDDATE { get; set; }

        [StringLength(100)]
        public string INFRSPCODE { get; set; }

        [StringLength(100)]
        public string INFRSPDATE { get; set; }

        [StringLength(200)]
        public string INFRSPMESSAGE { get; set; }

        [StringLength(100)]
        public string ORDERSTATE { get; set; }

        [StringLength(100)]
        public string PRINTSTATE { get; set; }

        [StringLength(100)]
        public string PRINTDATE { get; set; }

        [StringLength(100)]
        public string CREATEDATE { get; set; }

        [StringLength(100)]
        public string CREATEBY { get; set; }

        [StringLength(1000)]
        public string MESSAGETEXT { get; set; }

        [StringLength(200)]
        public string REMARK { get; set; }

        public string FEEDBACKSTATE { get; set; }

        public int FEEDBACKQTY { get; set; }

        [Ignore]
        public List<OrderDetailEntity> ListOrderDetail
        {
            get
            {
                return this.listOrderDetail;
            }
            set
            {
                this.listOrderDetail = value;
            }
        }
    }
}
