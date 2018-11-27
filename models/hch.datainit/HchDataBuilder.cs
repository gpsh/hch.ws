using hch.model;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Text;
using Wx;

namespace hch.datainit
{
    public class HchDataBuilder : DataRunner
    {
        public HchDataBuilder(string connectionname, string connectionstring) : base(connectionname, connectionstring) { }
        public HchDataBuilder() : base() { }

        public override ICollection<Type> GetTables()
        {
            return new List<Type>()
            {
                typeof(Account),
                typeof(CarsBrandSeries),
                typeof(Corporation),
                typeof(CarsDetails),
                typeof(CarsConcise)
            };
        }

        public override ICollection<IDataInitializer> DataInitializers()
        {
            return new IDataInitializer[] {
                new DatainitAccount(),
                new DatainitBrandSeries()
            };
        }

        public override bool DataExists(IWxDbContext ctx)
        {
            using (var db=ctx.MyDB)
            {
                return db.Count<Account>() > 0
                    || db.Count<CarsBrandSeries>() > 0
                    || db.Count<Corporation>() > 0
                    || db.Count<CarsDetails>() > 0
                    || db.Count<CarsConcise>() > 0;
            }
        }
    }
}
