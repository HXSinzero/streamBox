﻿using ServiceStack.DataAnnotations;
using System;

namespace KR.WMApp.Entitys
{
    /// <summary>
    /// 供应商信息
    /// </summary>
    [Alias("WM_BA_VENDOR")]
    public class BasicVendorEntity : BASEEntity
    {
        [PrimaryKey]
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(100)]
        [Index(Unique = true)]
        public string VENDORNO { get; set; }

        [Required]
        [StringLength(200)]
        public string VENDORNAME { get; set; }

        [StringLength(1000)]
        public string VENDORDESC { get; set; }

        [StringLength(100)]
        public string VENDORSUBDESC { get; set; }

        [Required]
        [StringLength(100)]
        public string VENDORSTATE { get; set; }

        [StringLength(100)]
        public string CONTACT { get; set; }

        [StringLength(100)]
        public string TELPHONE { get; set; }

        [StringLength(200)]
        public string ADDRESS { get; set; }

        [StringLength(100)]
        public string CATEGORY { get; set; }

        [StringLength(100)]
        public string GRADE { get; set; }

        [StringLength(100)]
        public string FRIENDLY { get; set; }

        [Default(0)]
        public Decimal? COEFFICIENT1 { get; set; }

        [Default(0)]
        public Decimal? COEFFICIENT2 { get; set; }

        [Default(0)]
        public Decimal? COEFFICIENT3 { get; set; }

        [Default(0)]
        public Decimal? COEFFICIENT4 { get; set; }

        [Default(0)]
        public Decimal? COEFFICIENT5 { get; set; }

        [Default(0)]
        public Decimal? COEFFICIENT6 { get; set; }

        [StringLength(100)]
        public string CREATEDATE { get; set; }

        [StringLength(100)]
        public string CREATEBY { get; set; }

        [StringLength(200)]
        public string REMARK { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL01 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL02 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL03 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL04 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL05 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL06 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL07 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL08 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL09 { get; set; }

        [StringLength(100)]
        public string CUSTOMCOL10 { get; set; }

        [StringLength(100)]
        public string MASTERNO { get; set; }

        [StringLength(200)]
        public string MASTERNAME { get; set; }
    }
}
