using hch.car.api.models;
using hch.car.apis;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Wx;

namespace hch.car.ctrl
{
    [Route("[controller]/[action]")]
    public class QueryCarController : WxApiController, IQueryCar
    {
        IQueryCar _srv_querycar;

        public QueryCarController(IQueryCar srv_querycar)
        {
            _srv_querycar = srv_querycar;
        }
        [HttpPost]
        public IWsModel<ReqCar, List<ResCarConciseInfo>> BeforeFilterCars([FromBody] WsModel<ReqCar, List<ResCarConciseInfo>> model)
        {
            return _srv_querycar.BeforeFilterCars(model);
        }
        [HttpPost]
        public IWsModel<ReqCar, List<ResCarConciseInfo>> BeforeStoreCars([FromBody] WsModel<ReqCar, List<ResCarConciseInfo>> model)
        {
            return _srv_querycar.BeforeStoreCars(model);
        }
        [HttpPost]
        public IWsModel<ReqCar, List<ResCarConciseInfo>> BeforeTodayCars([FromBody] WsModel<ReqCar, List<ResCarConciseInfo>> model)
        {
            return _srv_querycar.BeforeTodayCars(model);
        }
        [HttpPost]
        public IWsModel<ReqCar, List<ResCarConciseInfo>> BeforeUserCars([FromBody] WsModel<ReqCar, List<ResCarConciseInfo>> model)
        {
            return _srv_querycar.BeforeUserCars(model);
        }
        [HttpPost]
        public IWsModel<ReqCar, List<ResGroupBrand>> BrandAll([FromBody] WsModel<ReqCar, List<ResGroupBrand>> model)
        {
            return _srv_querycar.BrandAll(model);
        }
        [HttpPost]
        public IWsModel<ReqCar, List<ResBrand>> BrandHot([FromBody] WsModel<ReqCar, List<ResBrand>> model)
        {
            return _srv_querycar.BrandHot(model);
        }
        [HttpPost]
        public IWsModel<ReqCar, List<ResBrand>> BrandSeries([FromBody] WsModel<ReqCar, List<ResBrand>> model)
        {
            return _srv_querycar.BrandSeries(model);
        }
        [HttpPost]
        public IWsModel<ReqCar, ResCarDetail> CarInfo([FromBody] WsModel<ReqCar, ResCarDetail> model)
        {
            return _srv_querycar.CarInfo(model);
        }
        [HttpPost]
        public IWsModel<ReqCar, List<ResCarConciseInfo>> LaterFilterCars([FromBody] WsModel<ReqCar, List<ResCarConciseInfo>> model)
        {
            return _srv_querycar.LaterFilterCars(model);
        }
        [HttpPost]
        public IWsModel<ReqCar, List<ResCarConciseInfo>> LaterStoreCars([FromBody] WsModel<ReqCar, List<ResCarConciseInfo>> model)
        {
            return _srv_querycar.LaterStoreCars(model);
        }
        [HttpPost]
        public IWsModel<ReqCar, List<ResCarConciseInfo>> LaterTodayCars([FromBody] WsModel<ReqCar, List<ResCarConciseInfo>> model)
        {
            return _srv_querycar.LaterTodayCars(model);
        }
        [HttpPost]
        public IWsModel<ReqCar, List<ResCarConciseInfo>> LaterUserCars([FromBody] WsModel<ReqCar, List<ResCarConciseInfo>> model)
        {
            return _srv_querycar.LaterUserCars(model);
        }
    }
}
