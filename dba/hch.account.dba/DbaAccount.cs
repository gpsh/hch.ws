using hch.model;
using ServiceStack.OrmLite;
using System;
using Wx;

namespace hch.account.dba
{
    public class DbaAccount
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public long AddAccount(Account ac)
        {
            using (var dba = WxDbFactory.GetDbContext("hch_dba").MyDB)
            {
                var ret = dba.Insert<Account>(ac);
                return ret;
            }
        }

        /// <summary>
        /// 添加公司
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public long AddCorporation(Corporation co)
        {
            using (var dba = WxDbFactory.GetDbContext("hch_dba").MyDB)
            {
                var ret = dba.Insert<Corporation>(co);
                return ret;
            }
        }

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public long UpdateAccount(Account ac)
        {
            using (var dba = WxDbFactory.GetDbContext("hch_dba").MyDB)
            {
                var ret = dba.Update<Account>(ac);
                return ret;
            }
        }

        /// <summary>
        /// 修改公司
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public long UpdateCorporation(Corporation co)
        {
            using (var dba = WxDbFactory.GetDbContext("hch_dba").MyDB)
            {
                var ret = dba.Update<Corporation>(co);
                return ret;
            }
        }
    }
}
