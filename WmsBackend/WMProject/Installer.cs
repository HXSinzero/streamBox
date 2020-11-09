using KR.CIMS;
using KR.CIMS.Interfaces;
using ServiceStack.Logging;
using ServiceStack.OrmLite;
using System;
using System.Data;


namespace WMProject
{
    /// <summary>
    /// 当前项目依赖的表创建及维护
    /// </summary>
    public class Installer : InterfaceInstall
    {
        private static ILog logger = LogManager.GetLogger(typeof(Installer));

        public void Install()
        {
            try
            {
                Installer.logger.Debug((object)"创建数据库表……");
                using (IDbConnection dbCon = HelperConnection.GetConnectionFactory().OpenDbConnection())
                {
                    using (IDbTransaction dbTransaction = dbCon.OpenTransaction())
                    {
                        dbCon.CreateTableIfNotExists<Entitys.INVENTORY>();
                        dbTransaction.Commit();
                    }
                    dbCon.Close();
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

        public void LoadSampleData()
        {
            throw new NotImplementedException();
        }

        public void UnInstall()
        {
            throw new NotImplementedException();
        }
    }
}
