using hch.car.api.models;
using hch.car.apis;
using hch.car.dbs;
using hch.definition;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Wx;

namespace hch.car.service
{
    public class QueryCarService : WxWebApiService, IQueryCar
    {
        public IWsModel<ReqCar, List<ResCarConciseInfo>> BeforeFilterCars([FromBody] WsModel<ReqCar, List<ResCarConciseInfo>> model)
        {
            if (model == null)
            {
                return new WsModel<ReqCar, List<ResCarConciseInfo>>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (string.IsNullOrWhiteSpace(model.Request.IndexCarId))
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数IndexCarId为空");
            }
            var pageParam = new PageParam(model.Request.PageSize, model.Request.SortType, model.Request.Ascending);
            var ret = new DBsCar().GetBeforeFilterCars(pageParam, model.Request.IndexCarId, model.Request.BrandId, model.Request.SeriesId, model.Request.CarActivity,
                model.Request.SeriesGrade, model.Request.BrandCountry, model.Request.CarDrive, model.Request.CarEnergy, model.Request.CarGearbox, model.Request.CarSeat);
            if (ret == null)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "数据不存在");
            }
            return model.Ok(ret);
        }

        public IWsModel<ReqCar, List<ResCarConciseInfo>> BeforeStoreCars([FromBody] WsModel<ReqCar, List<ResCarConciseInfo>> model)
        {
            if (model == null)
            {
                return new WsModel<ReqCar, List<ResCarConciseInfo>>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (string.IsNullOrWhiteSpace(model.Request.IndexCarId))
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数IndexCarId为空");
            }
            if (string.IsNullOrWhiteSpace(model.Request.CorporationId))
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数CorporationId为空");
            }
            var pageParam = new PageParam(model.Request.PageSize, model.Request.SortType, model.Request.Ascending);
            var ret = new DBsCar().GetBeforeStoreCars(model.Request.CorporationId, pageParam, model.Request.IndexCarId);
            if (ret == null)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "数据不存在");
            }
            return model.Ok(ret);
        }

        public IWsModel<ReqCar, List<ResCarConciseInfo>> BeforeTodayCars([FromBody] WsModel<ReqCar, List<ResCarConciseInfo>> model)
        {
            if (model == null)
            {
                return new WsModel<ReqCar, List<ResCarConciseInfo>>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (string.IsNullOrWhiteSpace(model.Request.IndexCarId))
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数IndexCarId为空");
            }
            var begintime = DateTime.Today;
            var endtime = DateTime.Today.AddDays(1).AddSeconds(-1);
            var pageParam = new PageParam(model.Request.PageSize, begintime, endtime);
            var ret = new DBsCar().GetBeforeTodayCars(pageParam, model.Request.IndexCarId);
            if (ret == null)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "数据不存在");
            }
            return model.Ok(ret);
        }

        public IWsModel<ReqCar, List<ResCarConciseInfo>> BeforeUserCars([FromBody] WsModel<ReqCar, List<ResCarConciseInfo>> model)
        {
            if (model == null)
            {
                return new WsModel<ReqCar, List<ResCarConciseInfo>>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (string.IsNullOrWhiteSpace(model.Request.IndexCarId))
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数IndexCarId为空");
            }
            if (string.IsNullOrWhiteSpace(model.Request.OpenId))
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数OpenId为空");
            }
            var pageParam = new PageParam(model.Request.PageSize, model.Request.SortType, model.Request.Ascending);
            var ret = new DBsCar().GetBeforeUserCars(model.Request.OpenId, model.Request.CarSell, pageParam, model.Request.IndexCarId);
            if (ret == null)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "数据不存在");
            }
            return model.Ok(ret);
        }

        public IWsModel<ReqCar, List<ResGroupBrand>> BrandAll([FromBody] WsModel<ReqCar, List<ResGroupBrand>> model)
        {
            if (model == null)
            {
                return new WsModel<ReqCar, List<ResGroupBrand>>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
           // var ret = new DBsCar().GetAllBrand(ValidityState.Enabled);

            var ret = new DBsCar().GetGroupBrand(ValidityState.Enabled);
            if (ret == null || ret.Count(i => i != null) == 0)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "品牌分组不存在");
            }
            foreach (var item in ret)
            {
                var list = new DBsCar().GetGroupBrandList(ValidityState.Enabled,item.Capital);
                if (ret != null && ret.Count(i => i != null) > 0)
                {
                    item.Values = list;
                }
            }
            return model.Ok(ret);
        }

        public IWsModel<ReqCar, List<ResBrand>> BrandHot([FromBody] WsModel<ReqCar, List<ResBrand>> model)
        {
            if (model == null)
            {
                return new WsModel<ReqCar, List<ResBrand>>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            var pageParam = new PageParam(model.Request.PageSize);
            var ret = new DBsCar().GetBrandHot(ValidityState.Enabled, pageParam);
            if (ret == null)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "数据不存在");
            }
            var result = new List<ResBrand>();
            foreach (var item in ret)
            {
                result.Add(new ResBrand(item));
            }
            return model.Ok(result);
        }

        public IWsModel<ReqCar, List<ResBrand>> BrandSeries([FromBody] WsModel<ReqCar, List<ResBrand>> model)
        {
            if (model == null)
            {
                return new WsModel<ReqCar, List<ResBrand>>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (string.IsNullOrWhiteSpace(model.Request.BrandId))
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数BrandId为空");
            }
            var ret = new DBsCar().GetBrandSeries(model.Request.BrandId, ValidityState.Enabled);
            if (ret == null)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "数据不存在");
            }
            var result = new List<ResBrand>();
            foreach (var item in ret)
            {
                result.Add(new ResBrand(item));
            }
            return model.Ok(result);
        }

        public IWsModel<ReqCar, ResCarDetail> CarInfo([FromBody] WsModel<ReqCar, ResCarDetail> model)
        {
            if (model == null)
            {
                return new WsModel<ReqCar, ResCarDetail>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (string.IsNullOrWhiteSpace(model.Request.CarId))
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数CarId为空");
            }
            var ret = new DBsCar().GetCarDetailToRes(model.Request.CarId);
            if (ret == null)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "数据不存在");
            }
            return model.Ok(ret);
        }

        public IWsModel<ReqCar, List<ResCarConciseInfo>> LaterFilterCars([FromBody] WsModel<ReqCar, List<ResCarConciseInfo>> model)
        {
            if (model == null)
            {
                return new WsModel<ReqCar, List<ResCarConciseInfo>>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            var pageParam = new PageParam(model.Request.PageSize, model.Request.SortType, model.Request.Ascending);
            var ret = new DBsCar().GetLaterFilterCars(pageParam, model.Request.IndexCarId, model.Request.BrandId, model.Request.SeriesId, model.Request.CarActivity,
                model.Request.SeriesGrade, model.Request.BrandCountry, model.Request.CarDrive, model.Request.CarEnergy, model.Request.CarGearbox, model.Request.CarSeat);
            if (ret == null)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "数据不存在");
            }
            return model.Ok(ret);
        }

        public IWsModel<ReqCar, List<ResCarConciseInfo>> LaterStoreCars([FromBody] WsModel<ReqCar, List<ResCarConciseInfo>> model)
        {
            if (model == null)
            {
                return new WsModel<ReqCar, List<ResCarConciseInfo>>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (string.IsNullOrWhiteSpace(model.Request.CorporationId))
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数CorporationId为空");
            }
            var pageParam = new PageParam(model.Request.PageSize, model.Request.SortType, model.Request.Ascending);
            var ret = new DBsCar().GetLaterStoreCars(model.Request.CorporationId, pageParam, model.Request.IndexCarId);
            if (ret == null)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "数据不存在");
            }
            return model.Ok(ret);
        }

        public IWsModel<ReqCar, List<ResCarConciseInfo>> LaterTodayCars([FromBody] WsModel<ReqCar, List<ResCarConciseInfo>> model)
        {
            if (model == null)
            {
                return new WsModel<ReqCar, List<ResCarConciseInfo>>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            var begintime = DateTime.Today;
            var endtime = DateTime.Today.AddDays(1).AddSeconds(-1);
            var pageParam = new PageParam(model.Request.PageSize, begintime, endtime);
            var ret = new DBsCar().GetLaterTodayCars(pageParam, model.Request.IndexCarId);
            if (ret == null)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "数据不存在");
            }
            return model.Ok(ret);
        }

        public IWsModel<ReqCar, List<ResCarConciseInfo>> LaterUserCars([FromBody] WsModel<ReqCar, List<ResCarConciseInfo>> model)
        {
            if (model == null)
            {
                return new WsModel<ReqCar, List<ResCarConciseInfo>>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (string.IsNullOrWhiteSpace(model.Request.OpenId))
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数OpenId为空");
            }
            var pageParam = new PageParam(model.Request.PageSize, model.Request.SortType, model.Request.Ascending);
            var ret = new DBsCar().GetLaterUserCars(model.Request.OpenId, model.Request.CarSell, pageParam, model.Request.IndexCarId);
            if (ret == null)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "数据不存在");
            }
            return model.Ok(ret);
        }
    }
}
