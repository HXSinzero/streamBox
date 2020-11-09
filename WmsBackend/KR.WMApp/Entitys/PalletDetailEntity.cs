using KR.BaseApp;
using ServiceStack.DataAnnotations;
using System;

namespace KR.WMApp.Entitys
{
    [Serializable]
    /// <summary>
    /// 托盘明细表
    /// </summary>
    [Alias("WM_PALLET_DETAIL")]
    [CompositeIndex(new string[] { "PALLETID", "LINENUM" })]
    public class PalletDetailEntity : BaseExtend20
    {
        [Reference]
        public PalletEntity PalletEntity { get; set; }

        [PrimaryKey]
        [AutoIncrement]
        public long ID { get; set; }

        /// <summary>
        /// PALLETID
        /// </summary>		
        private long _palletid;
        [Required]
        public long PALLETID
        {
            get { return _palletid; }
            set { _palletid = value; }
        }

        /// <summary>
        /// LINENUM
        /// </summary>		
        private int _linenum;
        [Required]
        public int LINENUM
        {
            get { return _linenum; }
            set { _linenum = value; }
        }

        public long BOMID { get; set; }
        [StringLength(100)]
        public string BOMNO { get; set; }
        [StringLength(200)]
        public string BOMNAME { get; set; }
        [StringLength(100)]
        public string BOMBATCHNO { get; set; }

        public long PRODUCTID { get; set; }
        [StringLength(100)]
        public string PRODUCTNO { get; set; }
        [StringLength(200)]
        public string PRODUCTNAME { get; set; }
        [StringLength(100)]
        public string PRODUCTSPEC { get; set; }
        [StringLength(100)]
        public string PRODUCTCLASS { get; set; }
        [StringLength(100)]
        public string PRODUCTTYPE { get; set; }

        [Description("批次号")]
        [StringLength(100)]
        public string BATCHNO { get; set; }

        [Description("QC状态")]
        [StringLength(100)]
        public string QCSTATE { get; set; }

        [StringLength(100)]
        public string BATCHNO01 { get; set; }
        [StringLength(100)]
        public string BATCHNO02 { get; set; }
        [StringLength(100)]
        public string BATCHNO03 { get; set; }
        [StringLength(100)]
        public string BATCHNO04 { get; set; }
        [StringLength(100)]
        public string BATCHNO05 { get; set; }
        [StringLength(100)]
        public string BATCHNO06 { get; set; }
        [StringLength(100)]
        public string BATCHNO07 { get; set; }
        [StringLength(100)]
        public string BATCHNO08 { get; set; }
        [StringLength(100)]
        public string BATCHNO09 { get; set; }
        [StringLength(100)]
        public string BATCHNO10 { get; set; }

        /// <summary>
        /// QUANTITY_INIT
        /// </summary>		
        private decimal _quantity_init;
        [DecimalLength(10, 4)]
        public decimal QUANTITY_INIT
        {
            get { return _quantity_init; }
            set { _quantity_init = value; }
        }

        /// <summary>
        /// QUANTITY_COUNT
        /// </summary>		
        private decimal _quantity_count;
        [DecimalLength(10, 4)]
        public decimal QUANTITY_COUNT
        {
            get { return _quantity_count; }
            set { _quantity_count = value; }
        }

        /// <summary>
        /// QUANTITY_LOAD
        /// </summary>
        [Required]
        private decimal _quantity_load;
        [DecimalLength(10, 4)]
        public decimal QUANTITY_LOAD
        {
            get { return _quantity_load; }
            set { _quantity_load = value; }
        }

        /// <summary>
        /// QUANTITY_WEIGHT
        /// </summary>		
        private decimal _quantity_weight;
        [DecimalLength(10, 4)]
        public decimal QUANTITY_WEIGHT
        {
            get { return _quantity_weight; }
            set { _quantity_weight = value; }
        }

        /// <summary>
        /// QUANTITY_OUT
        /// </summary>		
        private decimal _quantity_out;
        [DecimalLength(10, 4)]
        public decimal QUANTITY_OUT
        {
            get { return _quantity_out; }
            set { _quantity_out = value; }
        }
        /// <summary>
        /// QUANTITY_IN
        /// </summary>		
        private decimal _quantity_in;
        [DecimalLength(10, 4)]
        public decimal QUANTITY_IN
        {
            get { return _quantity_in; }
            set { _quantity_in = value; }
        }
        /// <summary>
        /// QUANTITY_LEFT
        /// </summary>		
        private decimal _quantity_left;
        [DecimalLength(10,4)]
        public decimal QUANTITY_LEFT
        {
            get { return _quantity_left; }
            set { _quantity_left = value; }
        }

        [StringLength(100)]
        [Required]
        public string MAINUNIT { get; set; }

        [StringLength(100)]
        [Required]
        public string BASICUNIT { get; set; }

        /// <summary>
        /// SERIALNO
        /// </summary>		
        private string _serialno;
        [StringLength(200)]
        public string SERIALNO
        {
            get { return _serialno; }
            set { _serialno = value; }
        }
        /// <summary>
        /// ORDERNO
        /// </summary>		
        private string _orderno;
        [StringLength(100)]
        public string ORDERNO
        {
            get { return _orderno; }
            set { _orderno = value; }
        }
        /// <summary>
        /// ORDER_LINENUM
        /// </summary>		
        private string _order_linenum;
        [StringLength(100)]
        public string ORDER_LINENUM
        {
            get { return _order_linenum; }
            set { _order_linenum = value; }
        }
        /// <summary>
        /// OVERDUEDATE
        /// </summary>		
        private string _overduedate;
        [StringLength(100)]
        public string OVERDUEDATE
        {
            get { return _overduedate; }
            set { _overduedate = value; }
        }
        /// <summary>
        /// INVENTORYTYPE
        /// </summary>		
        private int _inventorytype;
        public int INVENTORYTYPE
        {
            get { return _inventorytype; }
            set { _inventorytype = value; }
        }
        /// <summary>
        /// QUALITYSTATE
        /// </summary>		
        private int _qualitystate;
        [StringLength(100)]
        public int QUALITYSTATE
        {
            get { return _qualitystate; }
            set { _qualitystate = value; }
        }
        /// <summary>
        /// INVENTORYSTATE
        /// </summary>		
        private int _inventorystate;
        [StringLength(100)]
        public int INVENTORYSTATE
        {
            get { return _inventorystate; }
            set { _inventorystate = value; }
        }
        /// <summary>
        /// INVENTORYVISIBLE
        /// </summary>		
        private int _inventoryvisible;
        public int INVENTORYVISIBLE
        {
            get { return _inventoryvisible; }
            set { _inventoryvisible = value; }
        }
        /// <summary>
        /// CREATEDATE
        /// </summary>		
        private DateTime _createdate;
        public DateTime CREATEDATE
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
        /// <summary>
        /// CREATEBY
        /// </summary>		
        private string _createby;
        [StringLength(100)]
        public string CREATEBY
        {
            get { return _createby; }
            set { _createby = value; }
        }
        /// <summary>
        /// BOXNO
        /// </summary>		
        private string _boxno;
        [StringLength(100)]
        public string BOXNO
        {
            get { return _boxno; }
            set { _boxno = value; }
        }
        /// <summary>
        /// PRODUCTDATE
        /// </summary>		
        private string _productdate;
        [StringLength(100)]
        public string PRODUCTDATE
        {
            get { return _productdate; }
            set { _productdate = value; }
        }
        /// <summary>
        /// SHIFTNO
        /// </summary>		
        private string _shiftno;
        [StringLength(100)]
        public string SHIFTNO
        {
            get { return _shiftno; }
            set { _shiftno = value; }
        }
        /// <summary>
        /// TEAMNO
        /// </summary>		
        private string _teamno;
        [StringLength(100)]
        public string TEAMNO
        {
            get { return _teamno; }
            set { _teamno = value; }
        }
        /// <summary>
        /// LINESTATE
        /// </summary>		
        private int _linestate;
        public int LINESTATE
        {
            get { return _linestate; }
            set { _linestate = value; }
        }
        /// <summary>
        /// EXTENDID
        /// </summary>		
        private int _extendid;
        public int EXTENDID
        {
            get { return _extendid; }
            set { _extendid = value; }
        }

    }
}