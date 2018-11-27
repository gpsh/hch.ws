using hch.definition;
using hch.model;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Text;
using Wx;

namespace hch.datainit
{
    public class DatainitAccount : IDataInitializer
    {
        public string Table => "Corporation Account";

        public int Build(IWxDbContext context, params string[] args)
        {

            using (var db =context.MyDB)
            {
                if (db.Count<Corporation>() == 0)
                {
                    var cor100 = new Corporation("北京京北会汽车销售有限公司", "北京市东城区金宝街", "新车二手车销售，我们以专业态度为您提供最优质的服务", "010-0000100", "", ValidityState.Enabled, DateTime.Now);
                    var cor200 = new Corporation("北京大马汽车销售有限公司", "北京市朝阳区弘燕东路", "高档豪华车销售", "010-0000200", "", ValidityState.Enabled, DateTime.Now);
                    var cors = new List<Corporation>() { cor100, cor200 };

                    var accounts = new List<Account>() {
                new Account("gps-shuai","无所不帅","odq8q5A0hyZra8i2H0DzRGbZeEpM",cor100.Id,Gender.MALE,"","15346316633","顾培帅",ValidityState.Enabled,Identity.admin,"",DateTime.Now),
                   };
                    db.InsertAll<Corporation>(cors);
                    db.InsertAll<Account>(accounts);
                    return cors.Count + accounts.Count;
                }

            }
            return 0;

        }

    }
}
