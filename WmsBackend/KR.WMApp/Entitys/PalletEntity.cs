using ServiceStack.DataAnnotations;
using System;

namespace KR.WMApp.Entitys
{
    [Serializable]
    /// <summary>
    /// 托盘主表
    /// </summary>
    [Alias("WM_PALLET")]
    public class PalletEntity
    {
        [PrimaryKeyAttribute]
        [RequiredAttribute]
        public long ID { get; set; }

        /// <summary>
        /// PALLETCLASS
        /// </summary>		
        private string _palletclass;
        [StringLength(100)]
        public string PALLETCLASS
        {
            get { return _palletclass; }
            set { _palletclass = value; }
        }
        /// <summary>
        /// PALLETNO
        /// </summary>
        private string _palletno;
        [StringLength(100)]
        public string PALLETNO
        {
            get { return _palletno; }
            set { _palletno = value; }
        }
        /// <summary>
        /// PALLETTYPE
        /// </summary>		
        private string _pallettype;
        [StringLength(100)]
        public string PALLETTYPE
        {
            get { return _pallettype; }
            set { _pallettype = value; }
        }
        /// <summary>
        /// IFFULLLOAD
        /// </summary>		
        private int _iffullload;
        public int IFFULLLOAD
        {
            get { return _iffullload; }
            set { _iffullload = value; }
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
        /// CREATEDATE
        /// </summary>		
        private DateTime _createdate;
        public DateTime CREATEDATE
        {
            get { return _createdate; }
            set { _createdate = value; }
        }
        /// <summary>
        /// MOVEINDATE
        /// </summary>		
        private DateTime _moveindate;
        public DateTime MOVEINDATE
        {
            get { return _moveindate; }
            set { _moveindate = value; }
        }
        /// <summary>
        /// MOVEINTYPE
        /// </summary>		
        private string _moveintype;
        [StringLength(100)]
        public string MOVEINTYPE
        {
            get { return _moveintype; }
            set { _moveintype = value; }
        }
        /// <summary>
        /// DYNAMICTYPE
        /// </summary>		
        private string _dynamictype;
        [StringLength(100)]
        public string DYNAMICTYPE
        {
            get { return _dynamictype; }
            set { _dynamictype = value; }
        }
        /// <summary>
        /// DYNAMICDATE
        /// </summary>		
        private DateTime _dynamicdate;
        public DateTime DYNAMICDATE
        {
            get { return _dynamicdate; }
            set { _dynamicdate = value; }
        }

        /// <summary>
        /// STOCKNO
        /// </summary>		
        private string _stockno;
        [StringLength(100)]
        public string STOCKNO
        {
            get { return _stockno; }
            set { _stockno = value; }
        }

        /// <summary>
        /// 托盘来源
        /// </summary>		
        private string _source;
        [StringLength(100)]
        public string SOURCE
        {
            get { return _source; }
            set { _source = value; }
        }

        /// <summary>
        /// 通道号
        /// </summary>
        [StringLength(100)]
        public string GROUPNO { get; set; }

        /// <summary>
        /// 当前位置
        /// </summary>		
        private string _locationno;
        [StringLength(100)]
        public string LOCATIONNO
        {
            get { return _locationno; }
            set { _locationno = value; }
        }

        /// <summary>
        /// STATE
        /// </summary>		
        private int _state;
        public int STATE
        {
            get { return _state; }
            set { _state = value; }
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
        /// PLANNO
        /// </summary>		
        private string _planno;
        [StringLength(100)]
        public string PLANNO
        {
            get { return _planno; }
            set { _planno = value; }
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
        /// 关联单号
        /// </summary>		
        private string _relateno;
        [StringLength(100)]
        public string RELATENO
        {
            get { return _relateno; }
            set { _relateno = value; }
        }

        [StringLength(200)]
        public string OPMESSAGE { get; set; }

        [StringLength(100)]
        public string OPDATE { get; set; }

        [StringLength(100)]
        public string OPBY { get; set; }

        /// <summary>
        /// CUSTOMCOL01
        /// </summary>		
        private string _customcol01;
        [StringLength(100)]
        public string CUSTOMCOL01
        {
            get { return _customcol01; }
            set { _customcol01 = value; }
        }
        /// <summary>
        /// CUSTOMCOL02
        /// </summary>		
        private string _customcol02;
        [StringLength(100)]
        public string CUSTOMCOL02
        {
            get { return _customcol02; }
            set { _customcol02 = value; }
        }
        /// <summary>
        /// CUSTOMCOL03
        /// </summary>		
        private string _customcol03;
        [StringLength(100)]
        public string CUSTOMCOL03
        {
            get { return _customcol03; }
            set { _customcol03 = value; }
        }
        /// <summary>
        /// CUSTOMCOL04
        /// </summary>		
        private string _customcol04;
        [StringLength(100)]
        public string CUSTOMCOL04
        {
            get { return _customcol04; }
            set { _customcol04 = value; }
        }
        /// <summary>
        /// CUSTOMCOL05
        /// </summary>		
        private string _customcol05;
        [StringLength(100)]
        public string CUSTOMCOL05
        {
            get { return _customcol05; }
            set { _customcol05 = value; }
        }
        /// <summary>
        /// CUSTOMCOL06
        /// </summary>		
        private string _customcol06;
        [StringLength(100)]
        public string CUSTOMCOL06
        {
            get { return _customcol06; }
            set { _customcol06 = value; }
        }
        /// <summary>
        /// CUSTOMCOL07
        /// </summary>		
        private string _customcol07;
        [StringLength(100)]
        public string CUSTOMCOL07
        {
            get { return _customcol07; }
            set { _customcol07 = value; }
        }
        /// <summary>
        /// CUSTOMCOL08
        /// </summary>		
        private string _customcol08;
        [StringLength(100)]
        public string CUSTOMCOL08
        {
            get { return _customcol08; }
            set { _customcol08 = value; }
        }
        /// <summary>
        /// CUSTOMCOL09
        /// </summary>		
        private string _customcol09;
        [StringLength(100)]
        public string CUSTOMCOL09
        {
            get { return _customcol09; }
            set { _customcol09 = value; }
        }
        /// <summary>
        /// CUSTOMCOL10
        /// </summary>		
        private string _customcol10;
        [StringLength(100)]
        public string CUSTOMCOL10
        {
            get { return _customcol10; }
            set { _customcol10 = value; }
        }

        [ServiceStack.DataAnnotations.Ignore]
        public string CREATEDATETIME
        {
            get
            {
                string str = null;
                if (this.CREATEDATE != null)
                {
                    str = this.CREATEDATE.ToString("yyyy-MM-dd HH:mm:ss");
                }
                return str;
            }
        }
    }
}