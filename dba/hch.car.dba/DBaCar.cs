using hch.definition;
using hch.model;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using Wx;

namespace hch.car.dba
{
    public class DBaCar
    {
        /// <summary>
        /// 添加车辆详情
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public long AddCarDetail(CarsDetails cd)
        {
            using (var dba = WxDbFactory.GetDbContext("hch_dba").MyDB)
            {
                var ret = dba.Insert<CarsDetails>(cd);
                return ret;
            }
        }

        /// <summary>
        /// 添加车辆简洁
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public long AddCarConcise(CarsConcise cc)
        {
            using (var dba = WxDbFactory.GetDbContext("hch_dba").MyDB)
            {
                var ret = dba.Insert<CarsConcise>(cc);
                return ret;
            }
        }

        /// <summary>
        /// 添加品牌车系
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public long AddBrandSeries(CarsBrandSeries cbs)
        {
            using (var dba = WxDbFactory.GetDbContext("hch_dba").MyDB)
            {
                var ret = dba.Insert<CarsBrandSeries>(cbs);
                return ret;
            }
        }

        /// <summary>
        /// 修改车辆详情
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public long UpdateCarDetail(CarsDetails cd)
        {
            using (var dba = WxDbFactory.GetDbContext("hch_dba").MyDB)
            {
                var ret = dba.Update<CarsDetails>(cd);
                return ret;
            }
        }

        /// <summary>
        /// 修改车辆简洁
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public long UpdateCarConcise(CarsConcise cc)
        {
            using (var dba = WxDbFactory.GetDbContext("hch_dba").MyDB)
            {
                var ret = dba.Update<CarsConcise>(cc);
                return ret;
            }
        }


        /// <summary>
        /// 修改品牌车系
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public long UpdateBrandSeries(CarsBrandSeries cbs)
        {
            using (var dba = WxDbFactory.GetDbContext("hch_dba").MyDB)
            {
                var ret = dba.Update<CarsBrandSeries>(cbs);
                return ret;
            }
        }
    }
}
