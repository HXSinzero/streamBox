using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WMProject
{
    public class ProjSetting
    {
        public static string baseServicepath = "/api/v1";
        public static List<string> SpecialPalletnoList = new List<string>() { "0", "0000", "9999", "00000000", "99999999" };//特殊的托盘号

        public static string PALLETCLASS_01 = "1";//单一托盘
        public static string PALLETCLASS_02 = "2";//复核托盘

        public static string PALLETTYPE_01 = "10";//托盘类型1       
        public static string PALLETTYPE_02 = "20";//托盘类型2

        public static int PALLETSTATE_INIT = 1;//托盘状态1(创建)
        public static int PALLETSTATE_CARRYING = 2;//托盘状态2(搬运锁定)
        public static int PALLETSTATE_CARRYOVER = 3;//托盘状态3(搬运完成)

        public static int PALLETDETAILLINESTATE_01 = 1;//托盘行状态1
        public static int PALLETDETAILLINESTATE_02 = 2;//托盘行状态2

        public static int BPCONTROLMODEL_01 = 1;//系统分配
        public static int BPCONTROLMODEL_02 = 2;//人工分配

        public static string LOCDETAIL_STORESTATE_EMPLTY = "0";             //空闲
        public static string LOCDETAIL_STORESTATE_ORDERIN = "1";            //入库分配
        public static string LOCDETAIL_STORESTATE_LOAD = "100";             //载货
        public static string LOCDETAIL_STORESTATE_ORDEROUT = "2";           //出库锁定


        public static string LOCDETAIL_USESTATE_DISABLE = "0";//停用
        public static string LOCDETAIL_USESTATE_ENABLE = "1";//启用

        public static string LOCDETAIL_LOCATIONSTATE_NORMAL = "normal";//正常
        public static string LOCDETAIL_LOCATIONSTATE_ERROR = "error";//故障

        public static int LOCGROUP_GROUPSTATE_EMPLTY = 0;//空闲
        public static int LOCGROUP_GROUPSTATE_LOADANDLEFT = 1;//载货有余位
        public static int LOCGROUP_GROUPSTATE_FULLLOADT = 2;//满载
        public static int LOCGROUP_GROUPSTATE_CLOSE = 3;//关闭

        public static string LOCGROUP_GROUPTYPE_AGVHJL = "B";//AGV货架L
        public static string LOCGROUP_GROUPTYPE_RGHJ = "R";//人工货架

        public static string INF_JOBDOWNLOAD_JOBTYPE_01 = "1";
        public static string INF_JOBDOWNLOAD_JOBTYPE_02 = "2";
        public static string INF_JOBDOWNLOAD_JOBTYPE_03 = "3";
        public static string INF_JOBDOWNLOAD_JOBTYPE_04 = "4";

        public static string TASKSTATE_WAIT = "-1";     //等待
        public static string TASKSTATE_NEW = "0";       //新任务
        public static string TASKSTATE_BEGIN = "1";     //装货完成
        public static string TASKSTATE_02 = "2";    //
        public static string TASKSTATE_CHANGE = "3";    //任务变更
        public static string TASKSTATE_CANCEL = "4";    //任务取消
        public static string TASKSTATE_OVER = "99";     //搬运完成

        public static string TASKCLASS_01 = "1";//入库
        public static string TASKCLASS_02 = "2";//出库
        public static string TASKCLASS_11 = "11";//人工入库
        public static string TASKCLASS_22 = "22";//人工出库

        public static string TASKCLASS_03 = "3";//人工移库
        public static string TASKCLASS_33 = "33";//自动出库

        public static string STATIONTYPE_00 = "0";
        public static string STATIONTYPE_01 = "1";
        public static string STATIONTYPE_02 = "2";
        public static string STATIONTYPE_03 = "3";
        public static string STATIONTYPE_04 = "4";
        public static string STATIONTYPE_05 = "5";

        public static string DATEDEF_01 = "TODAY";
        public static string DATEDEF_02 = "LAST7-DAYS";
        public static string DATEDEF_03 = "LAST30-DAYS";
        public static string DATEDEF_04 = "CUSTOMIZE";

        public static string QCSTATE_Q = "Q";
        public static string QCSTATE_S = "S";
        public static string QCSTATE_N = "N";

    }
}
