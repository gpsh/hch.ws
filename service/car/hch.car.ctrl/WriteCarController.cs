using hch.car.api.models;
using hch.car.apis;
using hch.frame.runtime;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Wx;

namespace hch.car.ctrl
{

    [Route("[controller]/[action]")]
    [AuthenticationToken]
    public class WriteCarController : WxApiController, IWriteCar
    {
        IWriteCar _srv_qriteycar;

        public WriteCarController(IWriteCar srv_writecar)
        {
            _srv_qriteycar = srv_writecar;
        }
        [AuthorizeAccount(definition.Identity.admin)]
        [HttpPost]
        public IWsModel<ReqAddBrand, ResBrand> AddCarBrand([FromBody] WsModel<ReqAddBrand, ResBrand> model)
        {
            return _srv_qriteycar.AddCarBrand(model);
        }
        [AuthorizeAccount(definition.Identity.Staff)]
        [HttpPost]
        public IWsModel<ReqAddCar, ResCarConciseInfo> AddCarInfo([FromBody] WsModel<ReqAddCar, ResCarConciseInfo> model)
        {
            return _srv_qriteycar.AddCarInfo(model);
        }
        [AuthorizeAccount(definition.Identity.admin)]
        [HttpPost]
        public IWsModel<ReqAddSeries, ResBrand> AddCarSeries([FromBody] WsModel<ReqAddSeries, ResBrand> model)
        {
            return _srv_qriteycar.AddCarSeries(model);
        }
        [AuthorizeAccount(definition.Identity.admin)]
        [HttpPost]
        public IWsModel<ReqAddBrand, ResBrand> UpdateCarBrand([FromBody] WsModel<ReqAddBrand, ResBrand> model)
        {
            return _srv_qriteycar.UpdateCarBrand(model);
        }
        [AuthorizeAccount(definition.Identity.Staff)]
        [HttpPost]
        public IWsModel<ReqAddCar, ResCarConciseInfo> UpdateCarInfo([FromBody] WsModel<ReqAddCar, ResCarConciseInfo> model)
        {
            return _srv_qriteycar.UpdateCarInfo(model);
        }
        [AuthorizeAccount(definition.Identity.admin)]
        [HttpPost]
        public IWsModel<ReqAddSeries, ResBrand> UpdateCarSeries([FromBody] WsModel<ReqAddSeries, ResBrand> model)
        {
            return _srv_qriteycar.UpdateCarSeries(model);
        }
    }
}
