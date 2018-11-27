using hch.car.api.models;
using hch.definition;
using hch.model;
using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wx;

namespace hch.car.dbs
{
    public class DBsCar
    {
        /// <summary>
        /// 获取所有品牌
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public List<CarsBrandSeries> GetAllBrand(ValidityState state)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                var ret = dbs.Select<CarsBrandSeries>(s => s.ParentId == null && s.State == state && s.SeriesGrade == CarSeriesGrade.None).OrderBy(x => x.Capital).ToList();
                return ret;
            }
        }

        /// <summary>
        /// 获取品牌分组
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public List<ResGroupBrand> GetGroupBrand(ValidityState state)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                var sql = $" SELECT Capital,count(Capital) AS Total FROM CarsBrandSeries " +
                         $" WHERE ParentId IS NULL AND State={(int)state} AND SeriesGrade =0 group BY Capital ASC ";
                var ret = dbs.Select<ResGroupBrand>(sql);

                return ret;
            }
        }

        /// <summary>
        /// 获取某个分组下的品牌
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public List<ResBrand> GetGroupBrandList(ValidityState state, string capital)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                var sql = $"SELECT Id, Capital,`Name`,BrandLogo,BrandType,BrandCountry,State,`TimeStamp` FROM CarsBrandSeries " +
                          $" WHERE ParentId IS NULL AND State={(int)state} AND SeriesGrade =0 AND Capital='{capital}' ORDER BY `Name`";

                var ret = dbs.Select<ResBrand>(sql);
                return ret;
            }
        }

        /// <summary>
        /// 获取热门品牌
        /// </summary>
        /// <param name="state"></param>
        /// <returns></returns>
        public List<CarsBrandSeries> GetBrandHot(ValidityState state, PageParam pageParam)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                var ret = dbs.Select<CarsBrandSeries>(s => s.BrandType == CarBrandType.Hot && s.State == state).OrderBy(x => x.Capital).Take(pageParam.PageSize).ToList();
                return ret;
            }
        }

        /// <summary>
        /// 获得品牌下的车系
        /// </summary>
        /// <param name="BrandSeriesId"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public List<CarsBrandSeries> GetBrandSeries(string BrandSeriesId, ValidityState state)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                var ret = dbs.Select<CarsBrandSeries>(s => s.ParentId == BrandSeriesId && s.State == state).OrderBy(x => x.Name).ToList();
                return ret;
            }
        }

        /// <summary>
        /// 获取品牌、车系信息
        /// </summary>
        /// <param name="BrandSeriesId"></param>
        /// <returns></returns>
        public CarsBrandSeries GetBrandSeriesDetail(string BrandSeriesId)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                var ret = dbs.Single<CarsBrandSeries>(s => s.Id == BrandSeriesId);
                return ret;
            }
        }
        public CarsBrandSeries GetBrandSeriesDetail(string BrandSeriesId, ValidityState state)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                var ret = dbs.Single<CarsBrandSeries>(s => s.Id == BrandSeriesId && s.State == state);
                return ret;
            }
        }
        /// <summary>
        /// 获取车辆的简介信息
        /// </summary>
        /// <param name="carinfoid"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public CarsConcise GetCarInfo(string carinfoid, ValidityState state)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                var ret = dbs.Single<CarsConcise>(s => s.Id == carinfoid && s.State == state);
                return ret;
            }
        }

        /// <summary>
        /// 获取车辆的详情
        /// </summary>
        /// <param name="cardetailid"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public CarsDetails GetCarDetail(string cardetailid)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                var ret = dbs.Single<CarsDetails>(s => s.Id == cardetailid);
                return ret;
            }
        }


        /// <summary>
        /// 筛选某台车辆之前的车辆( CarSeriesGrade seriesGrade = CarSeriesGrade.None, CarBrandCountry brandCountry = CarBrandCountry.None, CarDrive carDrive = CarDrive.None, CarEnergy carEnergy = CarEnergy.None, CarGearbox carGearbox = CarGearbox.None, CarSeat carSeat = CarSeat.None,DateTime ? carAgeBegin = null, DateTime? CarAgeEnd = null, float mileageBegin = 0, float mileageEnd = 0, float emissionBegin = 0, float emissionEnd = 0)
        /// </summary>
        /// <param name="pageParam"></param>
        /// <param name="indexCarId"></param>
        /// <param name="brandId"></param>
        /// <param name="seriesId"></param>
        /// <param name="seriesGrade"></param>
        /// <param name="carActivity"></param>
        /// <param name="brandCountry"></param>
        /// <param name="carAgeBegin"></param>
        /// <param name="CarAgeEnd"></param>
        /// <param name="mileageBegin"></param>
        /// <param name="mileageEnd"></param>
        /// <param name="emissionBegin"></param>
        /// <param name="emissionEnd"></param>
        /// <param name="carDrive"></param>
        /// <param name="carEnergy"></param>
        /// <param name="carGearbox"></param>
        /// <param name="carSeat"></param>
        /// <returns></returns>
        public List<ResCarConciseInfo> GetBeforeFilterCars(PageParam pageParam, string indexCarId, string brandId = null, string seriesId = null, CarActivity carActivity = CarActivity.None,
                               CarSeriesGrade seriesGrade = CarSeriesGrade.None, CarBrandCountry brandCountry = CarBrandCountry.None, CarDrive carDrive = CarDrive.None,
                               CarEnergy carEnergy = CarEnergy.None, CarGearbox carGearbox = CarGearbox.None, CarSeat carSeat = CarSeat.None)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                //var ret = dbs.From<CarsConcise>().Join<CarsConcise, CarsDetails>((cc, cd) => cc.CarsDetailsId == cd.Id).Where<CarsConcise>(x => x.State == ValidityState.Enabled && x.CarSell == CarSell.Sale && x.Id.CompareTo(indexCarId) < 0
                // && (string.IsNullOrWhiteSpace(brandId) || x.BrandId == brandId) && (string.IsNullOrWhiteSpace(seriesId) || x.SeriesId == seriesId) && (carActivity == CarActivity.None || x.CarActivity == carActivity))
                //.Select<CarsConcise, CarsDetails>((cc, cd) => new { CarInfoId = cc.Id, cc.Name, cc.BrandId, cc.CarsDetailsId, cc.AccountId, cc.CorporationId, cc.GuidePrice, cc.SellingPrice, cc.SurfaceImage, cc.CarActivity, cc.UpdateTime, cd.CarLicenseTime, cd.Mileage });
                //if (pageParam.SortType == SortType.Price)
                //{
                //    if (pageParam.Ascending == true)
                //    {
                //        var list = dbs.Select<ResCarConciseInfo>(ret).OrderBy(x => x.SellingPrice).Take(pageParam.PageSize).ToList();
                //        return list;
                //    }
                //    else
                //    {
                //        var list = dbs.Select<ResCarConciseInfo>(ret).OrderByDescending(x => x.SellingPrice).Take(pageParam.PageSize).ToList();
                //        return list;
                //    }
                //}
                //else
                //{
                //    if (pageParam.Ascending == true)
                //    {
                //        var list = dbs.Select<ResCarConciseInfo>(ret).OrderBy(x => x.UpdateTime).Take(pageParam.PageSize).ToList();
                //        return list;
                //    }
                //    else
                //    {
                //        var list = dbs.Select<ResCarConciseInfo>(ret).OrderByDescending(x => x.UpdateTime).Take(pageParam.PageSize).ToList();
                //        return list;
                //    }
                //}

                var sql = new StringBuilder(" SELECT cc.Id,cc.Id as CarInfoId, cc.`Name`,cc.CarsDetailsId,cc.GuidePrice,cc.SellingPrice,cc.SurfaceImage,cc.CarActivity,cc.UpdateTime,cd.CarLicenseTime,cd.Mileage FROM " +
                                   " ( SELECT carc.Id,carc.`Name`,carc.SeriesId, carc.CarsDetailsId, carc.GuidePrice, carc.SellingPrice,  carc.SurfaceImage, carc.CarActivity, carc.UpdateTime FROM CarsConcise as carc ");

                if (seriesGrade != CarSeriesGrade.None || brandCountry != CarBrandCountry.None)
                {
                    sql.Append(" INNER JOIN ( SELECT Id FROM CarsBrandSeries WHERE 1=1 ");
                    if (seriesGrade != CarSeriesGrade.None)
                    {
                        sql.Append(" and SeriesGrade= " + (int)seriesGrade);
                    }
                    if (brandCountry != CarBrandCountry.None)
                    {
                        sql.Append(" and BrandCountry= " + (int)brandCountry);
                    }
                    sql.Append(" ) AS cbs ON cbs.Id = carc.SeriesId ");
                }
                sql.Append("WHERE carc.CarSell = 0 and carc.State=1 ");
                if (!string.IsNullOrWhiteSpace(indexCarId))
                {
                    sql.Append(" and carc.Id < '" + indexCarId + "'");
                }
                if (!string.IsNullOrWhiteSpace(brandId))
                {
                    sql.Append(" and carc.BrandId ='" + brandId + "'");
                }
                if (!string.IsNullOrWhiteSpace(seriesId))
                {
                    sql.Append(" and carc.SeriesId = '" + seriesId + "'");
                }
                if (carActivity != CarActivity.None)
                {
                    sql.Append(" and carc.CarActivity =" + (int)carActivity);
                }
                sql.Append(" ) AS cc  INNER JOIN(SELECT Id, CarLicenseTime, Mileage FROM CarsDetails where 1=1 ");

                if (carDrive != CarDrive.None)
                {
                    sql.Append(" and  CarDrive= " + (int)carDrive);
                }
                if (carEnergy != CarEnergy.None)
                {
                    sql.Append(" and  CarEnergy= " + (int)carEnergy);
                }
                if (carGearbox != CarGearbox.None)
                {
                    sql.Append(" and CarGearbox= " + (int)carGearbox);
                }
                if (carSeat != CarSeat.None)
                {
                    sql.Append(" and CarSeat= " + (int)carSeat);
                }
                sql.Append(" )AS cd  ON cd.Id = cc.CarsDetailsId ");

                if (pageParam.SortType == SortType.Time)
                {
                    if (pageParam.Ascending == true)
                    {
                        sql.Append(" ORDER BY cc.UpdateTime ");
                    }
                    else
                    {
                        sql.Append(" ORDER BY cc.UpdateTime desc");
                    }
                }
                else
                {
                    if (pageParam.Ascending == true)
                    {
                        sql.Append(" ORDER BY cc.SellingPrice ");
                    }
                    else
                    {
                        sql.Append(" ORDER BY cc.SellingPrice desc");
                    }
                }
                //var ss = sql.ToString();
                var query = dbs.Select<ResCarConciseInfo>(sql.ToString()).Take(pageParam.PageSize).ToList();
                return query;
            }
        }

        /// <summary>
        /// 筛选某台太车辆之后的车辆(索引车辆为空，获取最新的几台车辆)
        /// </summary>
        /// <param name="pageParam"></param>
        /// <param name="indexCarId"></param>
        /// <param name="brandId"></param>
        /// <param name="seriesId"></param>
        /// <param name="seriesGrade"></param>
        /// <param name="carActivity"></param>
        /// <param name="brandCountry"></param>
        /// <param name="carAgeBegin"></param>
        /// <param name="CarAgeEnd"></param>
        /// <param name="mileageBegin"></param>
        /// <param name="mileageEnd"></param>
        /// <param name="emissionBegin"></param>
        /// <param name="emissionEnd"></param>
        /// <param name="carDrive"></param>
        /// <param name="carEnergy"></param>
        /// <param name="carGearbox"></param>
        /// <param name="carSeat"></param>
        /// <returns></returns>
        public List<ResCarConciseInfo> GetLaterFilterCars(PageParam pageParam, string indexCarId = null, string brandId = null, string seriesId = null, CarActivity carActivity = CarActivity.None,
                               CarSeriesGrade seriesGrade = CarSeriesGrade.None, CarBrandCountry brandCountry = CarBrandCountry.None, CarDrive carDrive = CarDrive.None,
                               CarEnergy carEnergy = CarEnergy.None, CarGearbox carGearbox = CarGearbox.None, CarSeat carSeat = CarSeat.None)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                var sql = new StringBuilder(" SELECT cc.Id,cc.Id as CarInfoId, cc.`Name`,cc.CarsDetailsId,cc.GuidePrice,cc.SellingPrice,cc.SurfaceImage,cc.CarActivity,cc.UpdateTime,cd.CarLicenseTime,cd.Mileage FROM " +
                                  " ( SELECT carc.Id,carc.`Name`,carc.SeriesId, carc.CarsDetailsId, carc.GuidePrice, carc.SellingPrice,  carc.SurfaceImage, carc.CarActivity, carc.UpdateTime FROM CarsConcise as carc ");

                if (seriesGrade != CarSeriesGrade.None || brandCountry != CarBrandCountry.None)
                {
                    sql.Append(" INNER JOIN ( SELECT Id FROM CarsBrandSeries WHERE 1=1 ");
                    if (seriesGrade != CarSeriesGrade.None)
                    {
                        sql.Append(" and SeriesGrade= " + (int)seriesGrade);
                    }
                    if (brandCountry != CarBrandCountry.None)
                    {
                        sql.Append(" and BrandCountry= " + (int)brandCountry);
                    }
                    sql.Append(" ) AS cbs ON cbs.Id = carc.SeriesId ");
                }
                sql.Append("WHERE carc.CarSell = 0 and carc.State=1 ");
                if (!string.IsNullOrWhiteSpace(indexCarId))
                {
                    sql.Append(" and carc.Id > '" + indexCarId + "'");
                }
                if (!string.IsNullOrWhiteSpace(brandId))
                {
                    sql.Append(" and carc.BrandId ='" + brandId + "'");
                }
                if (!string.IsNullOrWhiteSpace(seriesId))
                {
                    sql.Append(" and carc.SeriesId = '" + seriesId + "'");
                }
                if (carActivity != CarActivity.None)
                {
                    sql.Append(" and carc.CarActivity =" + (int)carActivity);
                }
                sql.Append(" ) AS cc  INNER JOIN(SELECT Id, CarLicenseTime, Mileage FROM CarsDetails where 1=1 ");

                if (carDrive != CarDrive.None)
                {
                    sql.Append(" and  CarDrive= " + (int)carDrive);
                }
                if (carEnergy != CarEnergy.None)
                {
                    sql.Append(" and  CarEnergy= " + (int)carEnergy);
                }
                if (carGearbox != CarGearbox.None)
                {
                    sql.Append(" and CarGearbox= " + (int)carGearbox);
                }
                if (carSeat != CarSeat.None)
                {
                    sql.Append(" and CarSeat= " + (int)carSeat);
                }
                sql.Append(" )AS cd  ON cd.Id = cc.CarsDetailsId ");

                if (pageParam.SortType == SortType.Time)
                {
                    if (pageParam.Ascending == true)
                    {
                        sql.Append(" ORDER BY cc.UpdateTime ");
                    }
                    else
                    {
                        sql.Append(" ORDER BY cc.UpdateTime desc");
                    }
                }
                else
                {
                    if (pageParam.Ascending == true)
                    {
                        sql.Append(" ORDER BY cc.SellingPrice ");
                    }
                    else
                    {
                        sql.Append(" ORDER BY cc.SellingPrice desc");
                    }
                }
                //var ss = sql.ToString();
                var query = dbs.Select<ResCarConciseInfo>(sql.ToString()).Take(pageParam.PageSize).ToList();
                return query;

            }
        }

        /// <summary>
        /// 查询某个店铺下的某台太车辆之后的车辆(索引车辆为空，获取最新的几台车辆)
        /// </summary>
        /// <param name="corporationId"></param>
        /// <param name="pageParam"></param>
        /// <param name="indexCarId"></param>
        /// <returns></returns>
        public List<ResCarConciseInfo> GetLaterStoreCars(string corporationId, PageParam pageParam, string indexCarId = null)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                var q = dbs.From<CarsConcise>().Join<CarsConcise, CarsDetails>((cc, cd) => cc.CarsDetailsId == cd.Id).Where(x => x.State == ValidityState.Enabled && x.CarSell == CarSell.Sale && x.CorporationId == corporationId).Select<CarsConcise, CarsDetails>((cc, cd) => new { cc.Id, CarInfoId = cc.Id, cc.CarsDetailsId, cc.Name, cc.GuidePrice, cc.SellingPrice, cc.SurfaceImage, cc.CarActivity, cc.UpdateTime, cd.CarLicenseTime, cd.Mileage });
                var ret = dbs.Select<ResCarConciseInfo>(q).Where(x => (string.IsNullOrWhiteSpace(indexCarId) || x.Id.CompareTo(indexCarId) > 0)).OrderByDescending(x => x.UpdateTime).Take(pageParam.PageSize).ToList();
                return ret;
            }

        }

        /// <summary>
        /// 查询某个店铺下的某台太车辆之前的车辆
        /// </summary>
        /// <param name="corporationId"></param>
        /// <param name="pageParam"></param>
        /// <param name="indexCarId"></param>
        /// <returns></returns>
        public List<ResCarConciseInfo> GetBeforeStoreCars(string corporationId, PageParam pageParam, string indexCarId)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                var q = dbs.From<CarsConcise>().Join<CarsConcise, CarsDetails>((cc, cd) => cc.CarsDetailsId == cd.Id).Where(x => x.State == ValidityState.Enabled && x.CarSell == CarSell.Sale && x.CorporationId == corporationId).Select<CarsConcise, CarsDetails>((cc, cd) => new { cc.Id, CarInfoId = cc.Id, cc.CarsDetailsId, cc.Name, cc.GuidePrice, cc.SellingPrice, cc.SurfaceImage, cc.CarActivity, cc.UpdateTime, cd.CarLicenseTime, cd.Mileage });
                var ret = dbs.Select<ResCarConciseInfo>(q).Where(x => x.Id.CompareTo(indexCarId) < 0).OrderByDescending(x => x.UpdateTime).Take(pageParam.PageSize).ToList();
                return ret;
            }

        }

        /// <summary>
        /// 查询某个人发布的(在售、下架)某台太车辆之后的车辆(索引车辆为空，获取最新的几台车辆)
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="carSell"></param>
        /// <param name="pageParam"></param>
        /// <param name="indexCarId"></param>
        /// <returns></returns>
        public List<ResCarConciseInfo> GetLaterUserCars(string openId, CarSell carSell, PageParam pageParam, string indexCarId = null)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                var q = dbs.From<CarsConcise>().Join<CarsConcise, CarsDetails>((cc, cd) => cc.CarsDetailsId == cd.Id).Where(x => x.State == ValidityState.Enabled && x.CarSell == carSell && x.AccountId == openId).Select<CarsConcise, CarsDetails>((cc, cd) => new { cc.Id, CarInfoId = cc.Id, cc.CarsDetailsId, cc.Name, cc.GuidePrice, cc.SellingPrice, cc.SurfaceImage, cc.CarActivity, cc.UpdateTime, cd.CarLicenseTime, cd.Mileage });
                var ret = dbs.Select<ResCarConciseInfo>(q).Where(x => (string.IsNullOrWhiteSpace(indexCarId) || x.Id.CompareTo(indexCarId) > 0)).OrderByDescending(x => x.UpdateTime).Take(pageParam.PageSize).ToList();
                return ret;
            }

        }

        /// <summary>
        /// 查询某个人发布的(在售、下架)某台太车辆之前的车辆
        /// </summary>
        /// <param name="openId"></param>
        /// <param name="carSell"></param>
        /// <param name="pageParam"></param>
        /// <param name="indexCarId"></param>
        /// <returns></returns>

        public List<ResCarConciseInfo> GetBeforeUserCars(string openId, CarSell carSell, PageParam pageParam, string indexCarId)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                var q = dbs.From<CarsConcise>().Join<CarsConcise, CarsDetails>((cc, cd) => cc.CarsDetailsId == cd.Id).Where(x => x.State == ValidityState.Enabled && x.CarSell == carSell && x.AccountId == openId).Select<CarsConcise, CarsDetails>((cc, cd) => new { cc.Id, CarInfoId = cc.Id, cc.CarsDetailsId, cc.Name, cc.GuidePrice, cc.SellingPrice, cc.SurfaceImage, cc.CarActivity, cc.UpdateTime, cd.CarLicenseTime, cd.Mileage });
                var ret = dbs.Select<ResCarConciseInfo>(q).Where(x => x.Id.CompareTo(indexCarId) < 0).OrderByDescending(x => x.UpdateTime).Take(pageParam.PageSize).ToList();
                return ret;
            }

        }

        /// <summary>
        /// 查询今天发布的某台太车辆之后的车辆(索引车辆为空，获取最新的几台车辆)，需要开始时间和结束时间
        /// </summary>
        /// <param name="pageParam"></param>
        /// <param name="indexCarId"></param>
        /// <returns></returns>
        public List<ResCarConciseInfo> GetLaterTodayCars(PageParam pageParam, string indexCarId = null)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                var q = dbs.From<CarsConcise>().Join<CarsConcise, CarsDetails>((cc, cd) => cc.CarsDetailsId == cd.Id).Where(x => x.State == ValidityState.Enabled && x.CarSell == CarSell.Sale && x.UpdateTime >= pageParam.BeginTime && x.UpdateTime <= pageParam.Endtime).Select<CarsConcise, CarsDetails>((cc, cd) => new { cc.Id, CarInfoId = cc.Id, cc.CarsDetailsId, cc.Name, cc.GuidePrice, cc.SellingPrice, cc.SurfaceImage, cc.CarActivity, cc.UpdateTime, cd.CarLicenseTime, cd.Mileage });
                var ret = dbs.Select<ResCarConciseInfo>(q).Where(x => (string.IsNullOrWhiteSpace(indexCarId) || x.Id.CompareTo(indexCarId) > 0)).OrderByDescending(x => x.UpdateTime).Take(pageParam.PageSize).ToList();
                return ret;
            }

        }

        /// <summary>
        /// 查询今天发布的某台太车辆之前的车辆
        /// </summary>
        /// <param name="pageParam"></param>
        /// <param name="indexCarId"></param>
        /// <returns></returns>
        public List<ResCarConciseInfo> GetBeforeTodayCars(PageParam pageParam, string indexCarId)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                var q = dbs.From<CarsConcise>().Join<CarsConcise, CarsDetails>((cc, cd) => cc.CarsDetailsId == cd.Id).Where(x => x.State == ValidityState.Enabled && x.CarSell == CarSell.Sale && x.UpdateTime >= pageParam.BeginTime && x.UpdateTime <= pageParam.Endtime).Select<CarsConcise, CarsDetails>((cc, cd) => new { cc.Id, CarInfoId = cc.Id, cc.CarsDetailsId, cc.Name, cc.GuidePrice, cc.SellingPrice, cc.SurfaceImage, cc.CarActivity, cc.UpdateTime, cd.CarLicenseTime, cd.Mileage });
                var ret = dbs.Select<ResCarConciseInfo>(q).Where(x => x.Id.CompareTo(indexCarId) < 0).OrderByDescending(x => x.UpdateTime).Take(pageParam.PageSize).ToList();
                return ret;
            }

        }

        /// <summary>
        /// 获取某台车辆的详细信息，包括低价
        /// </summary>
        /// <param name="carId"></param>
        /// <returns></returns>
        public ResCarDetail GetCarDetailToRes(string carId)
        {
            using (var dbs = WxDbFactory.GetDbContext("hch_dbs").MyDB)
            {
                var q = dbs.From<CarsConcise>().Join<CarsDetails>((cc, cd) => cc.CarsDetailsId == cd.Id).Where(x => x.State == ValidityState.Enabled && x.Id == carId).Select<CarsConcise, CarsDetails>((cc, cd) => new { CarInfoId = cc.Id, cc.CarsDetailsId, cc.Name, cc.GuidePrice, cc.SellingPrice, cc.BasePrice, cc.SurfaceImage, cc.CarActivity, cc.UpdateTime, cd.CarLicenseTime, cd.Mileage, cc.AccountId, cc.CorporationId, cd.Appearance, cd.Interior, cd.CarConfig, cd.Emission, cd.Images, cd.CarDrive, cd.CarEnergy, cd.CarGearbox, cd.CarSeat, cd.CarEmissionStandard });
                var ret = dbs.Single<ResCarDetail>(q);
                return ret;
            }

        }
    }
}
