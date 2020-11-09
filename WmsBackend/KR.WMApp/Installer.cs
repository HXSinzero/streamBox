using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Linq.Expressions;
using ServiceStack.Logging;
using ServiceStack.OrmLite;
using KR.CIMS.Interfaces;
using KR.CIMS;
using KR.WMApp.Entitys;

namespace KR.WMApp
{
    /// <summary>
    /// 项目安装类
    /// </summary>
    public class Installer : InterfaceInstall
    {
        private static ILog logger = LogManager.GetLogger(typeof(Installer));

        public void Install()
        {
            try
            {
                Installer.logger.Debug((object)"创建数据库表……");
                using (IDbConnection dbConn = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    using (IDbTransaction dbTransaction = dbConn.OpenTransaction())
                    {
                        #region wcs接口表
                        dbConn.CreateTableIfNotExists<INF_EQUIPMENTREQUESTEntity>();
                        dbConn.CreateTableIfNotExists<INF_EQUIPMENTSTATUSEntity>();
                        dbConn.CreateTableIfNotExists<INF_JOBDOWNLOADEntity>();
                        dbConn.CreateTableIfNotExists<INF_JOBFEEDBACKEntity>();
                        dbConn.CreateTableIfNotExists<INF_LEDINFOEntity>();
                        #endregion

                        #region 位置管理
                        dbConn.CreateTableIfNotExists<LocDetailEntity>();
                        dbConn.CreateTableIfNotExists<LocGroupEntity>();
                        dbConn.CreateTableIfNotExists<LocLimitEntity>();
                        dbConn.CreateTableIfNotExists<LocRelateEntity>();
                        dbConn.CreateTableIfNotExists<LocStockEntity>();
                        dbConn.CreateTableIfNotExists<LocStorehouseEntity>();
                        dbConn.CreateTableIfNotExists<LocStationInfoEntity>();
                        dbConn.CreateTableIfNotExists<LocStationRelateEntity>();
                        #endregion

                        #region 托盘管理
                        dbConn.CreateTableIfNotExists<PalletTypeEntity>();
                        dbConn.CreateTableIfNotExists<PalletInfoEntity>();
                        dbConn.CreateTableIfNotExists<PalletEntity>();
                        dbConn.CreateTableIfNotExists<PalletDetailEntity>();
                        dbConn.CreateTableIfNotExists<PalletMvInfoEntity>();
                        #endregion

                        #region 物料管理
                        dbConn.CreateTableIfNotExists<ProductEntity>();
                        dbConn.CreateTableIfNotExists<ProductExtendEntity>();
                        dbConn.CreateTableIfNotExists<ProductBOMEntity>();
                        dbConn.CreateTableIfNotExists<ProductBOMITEMEntity>();
                        dbConn.CreateTableIfNotExists<ProductBOMCheckEntity>();
                        dbConn.CreateTableIfNotExists<ProductSKUEntity>();
                        dbConn.CreateTableIfNotExists<ProductSKUTransferEntity>();
                        dbConn.CreateTableIfNotExists<ProductBatchnoEntity>();
                        #endregion

                        #region 订单管理
                        dbConn.CreateTableIfNotExists<OrderEntity>();
                        dbConn.CreateTableIfNotExists<OrderDetailEntity>();
                        #endregion

                        #region 计划管理
                        dbConn.CreateTableIfNotExists<PlanEntity>();
                        dbConn.CreateTableIfNotExists<PlanDetailEntity>();
                        dbConn.CreateTableIfNotExists<PlanDetailPalletEntity>();
                        #endregion

                        #region 基础信息
                        dbConn.CreateTableIfNotExists<BasicBuniessTypeEntity>();
                        dbConn.CreateTableIfNotExists<BasicCustomerEntity>();
                        dbConn.CreateTableIfNotExists<BasicMasterEntity>();
                        dbConn.CreateTableIfNotExists<BasicProducerEntity>();
                        dbConn.CreateTableIfNotExists<BasicVendorEntity>();
                        #endregion

                        #region 搬运任务管理
                        dbConn.CreateTableIfNotExists<TaskEntity>();
                        dbConn.CreateTableIfNotExists<TaskStepEntity>();
                        dbConn.CreateTableIfNotExists<TaskStatEntity>();
                        #endregion

                        #region 系统配置表
                        dbConn.CreateTableIfNotExists<SysRuleEntity>();
                        dbConn.CreateTableIfNotExists<SysRuleRouteEntity>();
                        dbConn.CreateTableIfNotExists<SysRuleRouteDetailEntity>();
                        dbConn.CreateTableIfNotExists<SysCheckEntity>();
                        dbConn.CreateTableIfNotExists<SysSceneEntity>();
                        dbConn.CreateTableIfNotExists<SysAlterInfoEntity>();
                        #endregion

                        #region 看板管理
                        dbConn.CreateTableIfNotExists<ViewLayoutEntity>();
                        #endregion

                        #region 历史记录表
                        //dbConn.CreateTableIfNotExists<ZHISPalletEntity>();
                        //dbConn.CreateTableIfNotExists<ZHISPalletInfoEntity>();
                        dbConn.CreateTableIfNotExists<ZHISTaskEntity>();
                        #endregion

                        #region 设备管理
                        dbConn.CreateTableIfNotExists<EQTypeEntity>();
                        dbConn.CreateTableIfNotExists<EQInstanceEntity>();
                        #endregion

                        #region 操作日志
                        dbConn.CreateTableIfNotExists<SysOplogEntity>();
                        #endregion

                        #region 添加字段
                        if (!dbConn.ColumnExists<LocGroupEntity>(x => x.GROUPMODEL))
                        {
                            dbConn.AddColumn<LocGroupEntity>(x => x.GROUPMODEL);
                        }
                        if (!dbConn.ColumnExists<LocGroupEntity>(x => x.DIRECTIONENTRY))
                        {
                            dbConn.AddColumn<LocGroupEntity>(x => x.DIRECTIONENTRY);
                        }
                        if (!dbConn.ColumnExists<LocDetailEntity>(x => x.REMARK))
                        {
                            dbConn.AddColumn<LocDetailEntity>(x => x.REMARK);
                        }

                        if (!dbConn.ColumnExists<LocStationInfoEntity>(x => x.PRIORITY))
                        {
                            dbConn.AddColumn<LocStationInfoEntity>(x => x.PRIORITY);
                        }

                        if (!dbConn.ColumnExists<LocStationInfoEntity>(x => x.TASKCOUNT))
                        {
                            dbConn.AddColumn<LocStationInfoEntity>(x => x.TASKCOUNT);
                        }

                        if (!dbConn.ColumnExists<PlanDetailPalletEntity>(x => x.BATCHNO))
                        {
                            dbConn.AddColumn<PlanDetailPalletEntity>(x => x.BATCHNO);
                        }

                        if (!dbConn.ColumnExists<PlanDetailPalletEntity>(x => x.PALLETCREATEDATE))
                        {
                            dbConn.AddColumn<PlanDetailPalletEntity>(x => x.PALLETCREATEDATE);
                        }

                        if (!dbConn.ColumnExists<TaskEntity>(x => x.CREATEDATETIME))
                        {
                            dbConn.AddColumn<TaskEntity>(x => x.CREATEDATETIME);
                        }

                        if (!dbConn.ColumnExists<ZHISTaskEntity>(x => x.CREATEDATETIME))
                        {
                            dbConn.AddColumn<ZHISTaskEntity>(x => x.CREATEDATETIME);
                        }
                        #endregion

                        dbTransaction.Commit();
                    }
                    dbConn.Close();
                }
                Installer.logger.Debug((object)"创建表结束!");
            }
            catch (Exception ex)
            {
                Installer.logger.Error((object)ex.ToString());
                throw ex;
            }
        }

        public void LoadBaseData()
        {
            throw new NotImplementedException();
        }

        public void UnInstall()
        {
            throw new NotImplementedException();
        }

        public void LoadSampleData()
        {
            throw new NotImplementedException();
        }
    }
}
