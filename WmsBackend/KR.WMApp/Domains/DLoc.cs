using KR.WMApp.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.WMApp.Domains
{
    /// <summary>
    /// 位置域模型
    /// </summary>
    public class DLoc
    {
        LocStationInfoEntity locStation;
        LocDetailEntity locDetail;

        public LocStationInfoEntity LocStation { get => locStation; set => locStation = value; }
        public LocDetailEntity LocDetail { get => locDetail; set => locDetail = value; }
    }
}
