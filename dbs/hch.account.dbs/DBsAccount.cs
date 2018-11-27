using hch.account.api.models;
using hch.definition;
using hch.model;
using ServiceStack.OrmLite;
using System;
using Wx;

namespace hch.account.dbs
{
    public class DbsAccount
    {
        public Account ByOpenId(string openid, ValidityState state)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                return dbs.Single<Account>(a => a.OpenId == openid && a.State == state);
            }

        }
        public Account GetAccount(string openid)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                return dbs.Single<Account>(a => a.OpenId == openid);
            }

        }

        public Account ById(string id)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                return dbs.SingleById<Account>(id);
            }

        }
        public Account ByWeChat(string wechat, ValidityState state)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                return dbs.Single<Account>(a => a.Wechat == wechat && a.State == state);
            }

        }
        /// <summary>
        /// 获取用户信息包含公司信息
        /// </summary>
        /// <param name="openid"></param>
        /// <returns></returns>
        public ResAccount GetAccountInfo(string openid, ValidityState state)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {

                ResAccount ret = dbs.Single<ResAccount>("SELECT acc.*,c.`Name`as CorporationName FROM ( SELECT * FROM Account WHERE OpenId=@openid and State=@state) AS acc INNER JOIN Corporation as c ON c.Id= acc.corporation where c.State=@state ", new { openid = openid, state = state });
                //var q = dbs.From<Account>().LeftJoin<Corporation>((a, c) => a.Corporation == c.Id).Where<Account>(a => a.Id == openid).Select<Account, Corporation>((x, c) => new { x,CorporationName=c.Name });
                //var ret = dbs.Single<dynamic>(q);

                //foreach (dynamic item in accret)
                //{
                //    string id = item.Id;

                //}
                return ret;
            }
        }

        /// <summary>
        /// 根据用户openid获取公司信息（含个人信息）
        /// </summary>
        /// <param name="opendid"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public ResCorporation GetCorporation(string openid, ValidityState state)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {

                ResCorporation ret = dbs.Single<ResCorporation>("SELECT ac.`Name`AS AccountName,ac.OpenId,ac.Phone,ac.Wechat,ac.WechatName,co.`Name` as CorporationName,co.Address,co.FixPhone,co.Id,co.Presentation,co.Image AS CorporationImage FROM"
                                             + " (SELECT Wechat, WechatName, OpenId, Phone,`Name`, Corporation FROM Account WHERE OpenId = @openid AND State=@state) AS ac"
                                             + " INNER JOIN Corporation AS co ON co.Id = ac.Corporation AND co.State=@state", new { openid = openid, state = state });
                return ret;
            }
        }
        /// <summary>
        /// 查询公司信息
        /// </summary>
        /// <param name="id"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public Corporation GetCorporationInfo(string id, ValidityState state)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                return dbs.Single<Corporation>(x => x.Id == id && x.State == state);
            }

        }

        public Corporation GetCorporationInfo(string id)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                return dbs.Single<Corporation>(x => x.Id == id);
            }

        }

        public Corporation GetCorporationInfoByName(string name)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                return dbs.Single<Corporation>(x => x.Name == name);
            }

        }
    }
}
