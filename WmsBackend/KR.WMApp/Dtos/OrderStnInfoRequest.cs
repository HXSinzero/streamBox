using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.WMApp.Dtos
{
    /// <summary>
    /// 站台信息下达请求
    /// </summary>
    public class OrderStnInfoRequest
    {
        public string STATIONNO { get; set; }
        public int JOBID { get; set; }
        public string PALLETNO { get; set; }
        public string PALLETTYPE { get; set; }
        public string DESTINATION { get; set; }
        public int PRIORITY { get; set; }
    }
}
