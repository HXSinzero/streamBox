using KR.BaseApp;
using ServiceStack.DataAnnotations;
using System;

namespace KR.WMApp.Entitys
{
    [Alias("WM_PALLETINFO")]
    public class PalletInfoEntity : BaseExtend10
    {
        private int _id;
        private string _palletno;
        private string _pallettype;
        private int _state;
        private string _createdate;
        private string _createby;

        private decimal _weight_net;
        private decimal _weight_load;
        private decimal _shape_length;
        private decimal _shape_width;
        private decimal _shape_height;

        private string _color1;
        private string _color2;

        private decimal _temperature;
        private decimal _humidity;

        private int _usagecount;
        private DateTime _lastusedate;

        /// <summary>
        /// ID
        /// </summary>	
        [DescriptionAttribute("ID")]
        [PrimaryKeyAttribute]
        [RequiredAttribute]
        public int ID
        {
            get { return _id; }
            set { _id = value; }
        }


        /// <summary>
        /// 容器编号
        /// </summary>
        [DescriptionAttribute("容器编号")]
        [RequiredAttribute]
        [IndexAttribute(Unique = true)]
        [StringLength(100)]
        public string PALLETNO
        {
            get { return _palletno; }
            set { _palletno = value; }
        }

        /// <summary>
        /// 容器类型
        /// </summary>	
        [DescriptionAttribute("容器类型")]
        [RequiredAttribute]
        [StringLength(100)]
        public string PALLETTYPE
        {
            get { return _pallettype; }
            set { _pallettype = value; }
        }

        /// <summary>
        /// 状态
        /// </summary>
        [DescriptionAttribute("状态")]
        [Default(0)]
        public int STATE
        {
            get
            {
                return _state;
            }

            set
            {
                _state = value;
            }
        }

        /// <summary>
        /// 创建时间
        /// </summary>		
        [DescriptionAttribute("创建时间")]
        [StringLength(100)]
        public string CREATEDATE
        {
            get { return _createdate; }
            set { _createdate = value; }
        }

        /// <summary>
        /// 创建人
        /// </summary>		
        [DescriptionAttribute("创建人")]
        [StringLength(100)]
        public string CREATEBY
        {
            get { return _createby; }
            set { _createby = value; }
        }


        [DescriptionAttribute("净重")]
        [DecimalLength(10, 4)]
        [Default(0)]
        public decimal WEIGHT_NET
        {
            get
            {
                return _weight_net;
            }

            set
            {
                _weight_net = value;
            }
        }

        [DescriptionAttribute("载重")]
        [DecimalLength(10, 4)]
        [Default(0)]
        public decimal WEIGHT_LOAD
        {
            get
            {
                return _weight_load;
            }

            set
            {
                _weight_load = value;
            }
        }

        [DescriptionAttribute("外形长")]
        [DecimalLength(10, 4)]
        [Default(0)]
        public decimal SHAPE_LENGTH
        {
            get
            {
                return _shape_length;
            }

            set
            {
                _shape_length = value;
            }
        }

        [DescriptionAttribute("外形宽")]
        [DecimalLength(10, 4)]
        [Default(0)]
        public decimal SHAPE_WIDTH
        {
            get
            {
                return _shape_width;
            }

            set
            {
                _shape_width = value;
            }
        }

        [DescriptionAttribute("外形高")]
        [DecimalLength(10, 4)]
        [Default(0)]
        public decimal SHAPE_HEIGHT
        {
            get
            {
                return _shape_height;
            }

            set
            {
                _shape_height = value;
            }
        }

        [DescriptionAttribute("颜色1")]
        [StringLength(100)]
        public string COLOR1
        {
            get
            {
                return _color1;
            }

            set
            {
                _color1 = value;
            }
        }

        [DescriptionAttribute("颜色2")]
        [StringLength(100)]
        public string COLOR2
        {
            get
            {
                return _color2;
            }

            set
            {
                _color2 = value;
            }
        }

        [DescriptionAttribute("温度")]
        [DecimalLength(10, 4)]
        [Default(0)]
        public decimal TEMPERATURE
        {
            get
            {
                return _temperature;
            }

            set
            {
                _temperature = value;
            }
        }

        [DescriptionAttribute("湿度")]
        [DecimalLength(10, 4)]
        [Default(0)]
        public decimal HUMIDITY
        {
            get
            {
                return _humidity;
            }

            set
            {
                _humidity = value;
            }
        }

        [DescriptionAttribute("使用次数")]
        [Default(0)]
        public int USAGECOUNT
        {
            get
            {
                return _usagecount;
            }

            set
            {
                _usagecount = value;
            }
        }

        [DescriptionAttribute("最后使用时间")]
        public DateTime LASTUSEDATE
        {
            get
            {
                return _lastusedate;
            }

            set
            {
                _lastusedate = value;
            }
        }
    }
}
