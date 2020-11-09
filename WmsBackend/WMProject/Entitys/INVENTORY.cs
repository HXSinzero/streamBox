using KR.BaseApp;
using ServiceStack.DataAnnotations;
using System;
using WMProject.Dtos;

namespace WMProject.Entitys
{
    public class INVENTORY
    {
        [PrimaryKey]
        [AutoIncrement]
        public long ID { get; set; }

        [StringLength(100)]
        public string PH_ID { get; set; }

        public string PRODUCT_DATE { get; set; }

        public int QTY_ACCEPT { get; set; }

        public int QTY_MES { get; set; }

        public int QTY_LEFT { get; set; }

        public string lOCATION_ID { get; set; }

        public string STATUS { get; set; }


    }
}
