using KR.WMApp.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.WMApp.Domains
{
    /// <summary>
    /// 托盘域模型
    /// </summary>
    public class DPallet
    {
        PalletEntity palletEntity = new PalletEntity();
        List<PalletDetailEntity> palletDetailEntities = new List<PalletDetailEntity>();

        public PalletEntity PalletEntity { get => palletEntity; set => palletEntity = value; }
        public List<PalletDetailEntity> PalletDetailEntities { get => palletDetailEntities; set => palletDetailEntities = value; }

        public override string ToString()
        {
            string str = null;
            foreach (var item in palletDetailEntities)
            {
                str += item.PRODUCTNO + "/" + item.PRODUCTNAME + "/" + item.QUANTITY_LOAD + " ";
            }
            return str;
        }
    }
}
