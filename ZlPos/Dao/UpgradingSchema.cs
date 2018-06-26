﻿using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using ZlPos.Models;
using ZlPos.Utils;

namespace ZlPos.Dao
{
    class UpgradingSchema
    {
        private static ILog logger = log4net.LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);


        public static void UpgradingVersion<T>(string[] newColumns)
            where T : class, new()
        {
            string tableName = typeof(T).Name;
            try
            {
                using (var db = SugarDao.GetInstance())
                {
                    //获取旧表数据
                    var oldDt = db.Ado.GetDataTable("select * from " + tableName);

                    //新表继承老数据
                    DataTable newDt = oldDt;
                    //添加新字段
                    foreach (string columnsName in newColumns)
                    {
                        newDt.Columns.Add(columnsName, Type.GetType("System.String"));
                    }

                    //老数据备份
                    db.DbMaintenance.BackupTable(tableName, tableName + DateTime.Now);
                    //删除老表
                    db.DbMaintenance.DropTable(tableName);

                    //创建新表
                    db.CodeFirst.InitTables(Type.GetType("ZlPos.Models." + tableName));
                    var ls = ConvertUtils.ToList<T>(newDt).ToArray();
                    db.Insertable(ls).Where(true, true).ExecuteCommand();


                }
            }
            catch (Exception e)
            {
                logger.Info("UpgradingVersion exception>>>table:" + tableName + ">>" + e.Message + e.StackTrace);
            }
        }

        public static void UpgradingVersion2()
        {
            try
            {
                using (var db = SugarDao.GetInstance())
                {
                    //获取旧表数据
                    var oldDt = db.Ado.GetDataTable("select * from CommodityEntity");

                    //新表继承老数据
                    DataTable newDt = oldDt;
                    //添加新字段
                    newDt.Columns.Add("validtime", Type.GetType("System.String"));

                    //老数据备份
                    db.DbMaintenance.BackupTable("CommodityEntity", "CommodityEntity" + DateTime.Now);
                    //删除老表
                    db.DbMaintenance.DropTable("CommodityEntity");

                    //创建新表
                    db.CodeFirst.InitTables(Type.GetType("ZlPos.Models.CommodityEntity"));
                    var ls = ConvertUtils.ToList<CommodityEntity>(newDt).ToArray();
                    db.Insertable(ls).Where(true, true).ExecuteCommand();


                }
            }
            catch (Exception e)
            {
                logger.Info("UpgradingVersion2 exception>>" + e.Message + e.StackTrace);
            }
        }

        public static void UpgradingVersion3()
        {
            try
            {
                using (var db = SugarDao.GetInstance())
                {
                    //获取旧表数据
                    var oldDt = db.Ado.GetDataTable("select * from ContextEntity");

                    //新表继承老数据
                    DataTable newDt = oldDt;
                    //添加新字段
                    newDt.Columns.Add("barcodeStyle", Type.GetType("System.String"));

                    //老数据备份
                    db.DbMaintenance.BackupTable("ContextEntity", "ContextEntity" + DateTime.Now);
                    //删除老表
                    db.DbMaintenance.DropTable("ContextEntity");

                    //创建新表
                    db.CodeFirst.InitTables(Type.GetType("ZlPos.Models.ContextEntity"));
                    var ls = ConvertUtils.ToList<ContextEntity>(newDt).ToArray();
                    db.Insertable(ls).Where(true, true).ExecuteCommand();


                }
            }
            catch (Exception e)
            {
                logger.Info("UpgradingVersion3 exception>>" + e.Message + e.StackTrace);
            }
        }

        internal static void UpgradingVersion4()
        {
            try
            {
                using (var db = SugarDao.GetInstance())
                {
                    //获取旧表数据
                    var oldDt = db.Ado.GetDataTable("select * from BillCommodityEntity");

                    //新表继承老数据
                    DataTable newDt = oldDt;
                    //添加新字段
                    newDt.Columns.Add("commission", Type.GetType("System.String"));

                    //老数据备份
                    db.DbMaintenance.BackupTable("BillCommodityEntity", "BillCommodityEntity" + DateTime.Now);
                    //删除老表
                    db.DbMaintenance.DropTable("BillCommodityEntity");

                    //创建新表
                    db.CodeFirst.InitTables(Type.GetType("ZlPos.Models.BillCommodityEntity"));
                    var ls = ConvertUtils.ToList<BillCommodityEntity>(newDt).ToArray();
                    db.Insertable(ls).Where(true, true).ExecuteCommand();


                }
            }
            catch (Exception e)
            {
                logger.Info("UpgradingVersion4 exception>>" + e.Message + e.StackTrace);
            }
        }
    }
}
