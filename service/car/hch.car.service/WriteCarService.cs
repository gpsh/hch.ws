using hch.account.dbs;
using hch.car.api.models;
using hch.car.apis;
using hch.car.dba;
using hch.car.dbs;
using hch.definition;
using hch.model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Wx;

namespace hch.car.service
{
    public class WriteCarService : WxWebApiService, IWriteCar
    {
        public IWsModel<ReqAddBrand, ResBrand> AddCarBrand([FromBody] WsModel<ReqAddBrand, ResBrand> model)
        {
            if (model == null)
            {
                return new WsModel<ReqAddBrand, ResBrand>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (!model.Request.Valid4Enum())
            {
                return model.Fail(ErrorCode.PARAM_INVALID, "枚举参数无效");
            }
            if (!model.Request.Valid4AddBrand())
            {
                return model.Fail(ErrorCode.PARAM_INVALID, "参数无效");
            }
            var carBrand = new CarsBrandSeries(model.Request.Name, model.Request.Capital, model.Request.BrandLogo, ValidityState.Enabled, model.Request.BrandType, model.Request.BrandCountry);
            var retDetail = new DBaCar().AddBrandSeries(carBrand);
            if (retDetail == 0)
            {
                return model.Fail(ErrorCode.DB_SAVE_FAILED, "添加失败");
            }
            var ret = new ResBrand(carBrand);
            return model.Ok(ret);
        }

        public IWsModel<ReqAddCar, ResCarConciseInfo> AddCarInfo([FromBody] WsModel<ReqAddCar, ResCarConciseInfo> model)
        {
            if (model == null)
            {
                return new WsModel<ReqAddCar, ResCarConciseInfo>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (!model.Request.Valid4Enum())
            {
                return model.Fail(ErrorCode.PARAM_INVALID, "枚举参数无效");
            }
            if (!model.Request.Valid4AddCar())
            {
                return model.Fail(ErrorCode.PARAM_INVALID, "参数无效");
            }
            var dbscar = new DBsCar();
            if (dbscar.GetBrandSeriesDetail(model.Request.BrandId,ValidityState.Enabled)==null)
            {
                return model.Fail(ErrorCode.PARAM_INVALID, "参数BrandId无效");
            }
            if (dbscar.GetBrandSeriesDetail(model.Request.SeriesId, ValidityState.Enabled) == null)
            {
                return model.Fail(ErrorCode.PARAM_INVALID, "参数SeriesId无效");
            }
            var dbsaccount = new DbsAccount();
            if (dbsaccount.ByOpenId(model.Request.AccountId,ValidityState.Enabled) == null)
            {
                return model.Fail(ErrorCode.PARAM_INVALID, "参数AccountId无效");
            }
            if (dbsaccount.GetCorporationInfo(model.Request.CorporationId, ValidityState.Enabled) == null)
            {
                return model.Fail(ErrorCode.PARAM_INVALID, "参数CorporationId无效");
            }
            var carDetail = new CarsDetails(model.Request.CarDrive, model.Request.CarEnergy, model.Request.CarGearbox, model.Request.CarSeat, 
                model.Request.CarEmissionStandard,model.Request.Appearance,model.Request.Interior,model.Request.CarConfig,model.Request.CarLicenseTime,model.Request.CarAge,
                model.Request.Mileage,model.Request.Emission,model.Request.Images);
            var retDetail = new DBaCar().AddCarDetail(carDetail);
            if (retDetail == 0)
            {
                return model.Fail(ErrorCode.DB_SAVE_FAILED, "添加失败");
            }
            var carConcise = new CarsConcise(model.Request.AccountId, carDetail.Id, model.Request.CorporationId, model.Request.Name, model.Request.BrandId, model.Request.SeriesId, model.Request.GuidePrice,
                      model.Request.SellingPrice, model.Request.BasePrice, ValidityState.Enabled, (carDetail.Images==null)?"":carDetail.Images[0], CarSell.Sale, model.Request.CarActivity);
            var retConcise = new DBaCar().AddCarConcise(carConcise);
            if (retConcise == 0)
            {
                return model.Fail(ErrorCode.DB_SAVE_FAILED, "添加失败");
            }
            var ret = new ResCarConciseInfo(carConcise, carDetail.CarLicenseTime, carDetail.Mileage);
            return model.Ok(ret);
        }

        public IWsModel<ReqAddSeries, ResBrand> AddCarSeries([FromBody] WsModel<ReqAddSeries, ResBrand> model)
        {
            if (model == null)
            {
                return new WsModel<ReqAddSeries, ResBrand>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (!model.Request.Valid4Enum())
            {
                return model.Fail(ErrorCode.PARAM_INVALID, "枚举参数无效");
            }
            if (!model.Request.Valid4AddSeries())
            {
                return model.Fail(ErrorCode.PARAM_INVALID, "参数无效");
            }
            var dbscar = new DBsCar();
            if (dbscar.GetBrandSeriesDetail(model.Request.ParentId, ValidityState.Enabled) == null)
            {
                return model.Fail(ErrorCode.PARAM_INVALID, "参数ParentId无效");
            }
            var carBrand = new CarsBrandSeries(model.Request.ParentId, model.Request.Name, ValidityState.Enabled, model.Request.SeriesGrade);
            var retDetail = new DBaCar().AddBrandSeries(carBrand);
            if (retDetail == 0)
            {
                return model.Fail(ErrorCode.DB_SAVE_FAILED, "添加失败");
            }
            var ret = new ResBrand(carBrand);
            return model.Ok(ret);
        }

        public IWsModel<ReqAddBrand, ResBrand> UpdateCarBrand([FromBody] WsModel<ReqAddBrand, ResBrand> model)
        {
            if (model == null)
            {
                return new WsModel<ReqAddBrand, ResBrand>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (!model.Request.Valid4Enum())
            {
                return model.Fail(ErrorCode.PARAM_INVALID, "枚举参数无效");
            }
            if (string.IsNullOrWhiteSpace(model.Request.CarBrandId))
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            var carBrand = new DBsCar().GetBrandSeriesDetail(model.Request.CarBrandId);
            if (carBrand == null)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "数据不存在");
            }
            if (AlterModel(ref carBrand, model.Request))
            {
                var retDetail = new DBaCar().UpdateBrandSeries(carBrand);
                if (retDetail == 0)
                {
                    return model.Fail(ErrorCode.DB_SAVE_FAILED, "修改失败");
                }
            }
            var ret = new ResBrand(carBrand);
            return model.Ok(ret);
        }

        public IWsModel<ReqAddCar, ResCarConciseInfo> UpdateCarInfo([FromBody] WsModel<ReqAddCar, ResCarConciseInfo> model)
        {
            if (model == null)
            {
                return new WsModel<ReqAddCar, ResCarConciseInfo>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (!model.Request.Valid4Enum())
            {
                return model.Fail(ErrorCode.PARAM_INVALID, "枚举参数无效");
            }
            if (string.IsNullOrWhiteSpace(model.Request.CarInfoId))
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            var carconcise = new DBsCar().GetCarInfo(model.Request.CarInfoId, ValidityState.Enabled);
            if (carconcise == null)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "数据不存在");
            }
            var cardetail = new DBsCar().GetCarDetail(carconcise.CarsDetailsId);
            if (carconcise == null)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "数据不存在");
            }
            if (AlterModel(ref cardetail, model.Request))
            {
                var retDetail = new DBaCar().UpdateCarDetail(cardetail);
                if (retDetail == 0)
                {
                    return model.Fail(ErrorCode.DB_SAVE_FAILED, "修改失败");
                }
            }
            if (AlterModel(ref carconcise, model.Request))
            {
                var retConcise = new DBaCar().UpdateCarConcise(carconcise);
                if (retConcise == 0)
                {
                    return model.Fail(ErrorCode.DB_SAVE_FAILED, "修改失败");
                }
            }
            var ret = new ResCarConciseInfo(carconcise, cardetail.CarLicenseTime, cardetail.Mileage);
            return model.Ok(ret);
        }

        public IWsModel<ReqAddSeries, ResBrand> UpdateCarSeries([FromBody] WsModel<ReqAddSeries, ResBrand> model)
        {
            if (model == null)
            {
                return new WsModel<ReqAddSeries, ResBrand>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (!model.Request.Valid4Enum())
            {
                return model.Fail(ErrorCode.PARAM_INVALID, "枚举参数无效");
            }
            if (string.IsNullOrWhiteSpace(model.Request.CarSeriesId))
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            var carSeries = new DBsCar().GetBrandSeriesDetail(model.Request.CarSeriesId);
            if (carSeries == null)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "数据不存在");
            }
            if (AlterModel(ref carSeries, model.Request))
            {
                var retDetail = new DBaCar().UpdateBrandSeries(carSeries);
                if (retDetail == 0)
                {
                    return model.Fail(ErrorCode.DB_SAVE_FAILED, "修改失败");
                }
            }
            var ret = new ResBrand(carSeries);
            return model.Ok(ret);
        }

        private bool AlterModel(ref CarsDetails entity, ReqAddCar am)
        {
            int sign = 0;
            if (!string.IsNullOrWhiteSpace(am.Appearance))
            {
                entity.Appearance = am.Appearance;
                sign = 1;
            }
            if (!string.IsNullOrWhiteSpace(am.Interior))
            {
                entity.Interior = am.Interior;
                sign = 1;
            }
            if (!string.IsNullOrWhiteSpace(am.CarConfig))
            {
                entity.CarConfig = am.CarConfig;
                sign = 1;
            }
            if (am.CarLicenseTime != null)
            {
                entity.CarLicenseTime = am.CarLicenseTime;
                sign = 1;
            }
            if (am.CarAge != null)
            {
                entity.CarAge = am.CarAge;
                sign = 1;
            }
            if (am.Images != null && am.Images.Length != 0)
            {
                entity.Images = am.Images;
                sign = 1;
            }
            if (am.Mileage != 0)
            {
                entity.Mileage = am.Mileage;
                sign = 1;
            }
            if (am.Emission != 0)
            {
                entity.Emission = am.Emission;
                sign = 1;
            }
            if (Enum.IsDefined(typeof(CarDrive), am.CarDrive) && am.CarDrive != CarDrive.None)
            {
                entity.CarDrive = am.CarDrive;
                sign = 1;
            }
            if (Enum.IsDefined(typeof(CarEnergy), am.CarEnergy) && am.CarEnergy != CarEnergy.None)
            {
                entity.CarEnergy = am.CarEnergy;
                sign = 1;
            }
            if (Enum.IsDefined(typeof(CarGearbox), am.CarGearbox) && am.CarGearbox != CarGearbox.None)
            {
                entity.CarGearbox = am.CarGearbox;
                sign = 1;
            }
            if (Enum.IsDefined(typeof(CarSeat), am.CarSeat) && am.CarSeat != CarSeat.None)
            {
                entity.CarSeat = am.CarSeat;
                sign = 1;
            }
            if (Enum.IsDefined(typeof(CarEmissionStandard), am.CarEmissionStandard) && am.CarEmissionStandard != CarEmissionStandard.None)
            {
                entity.CarEmissionStandard = am.CarEmissionStandard;
                sign = 1;
            }

            return sign == 1 ? true : false;
        }
        private bool AlterModel(ref CarsConcise entity, ReqAddCar am)
        {
            int sign = 0;
            if (am.GuidePrice != 0)
            {
                entity.GuidePrice = am.GuidePrice;
                sign = 1;
            }
            if (am.SellingPrice != 0)
            {
                entity.SellingPrice = am.SellingPrice;
                sign = 1;
            }
            if (am.BasePrice != 0)
            {
                entity.BasePrice = am.BasePrice;
                sign = 1;
            }
            if (Enum.IsDefined(typeof(ValidityState), am.State) && am.State != ValidityState.None)
            {
                entity.State = am.State;
                sign = 1;
            }
            if (Enum.IsDefined(typeof(CarActivity), am.CarActivity) && am.CarActivity != CarActivity.None)
            {
                entity.CarActivity = am.CarActivity;
                sign = 1;
            }
            if (sign == 1)
            {
                entity.UpdateTime = DateTime.Now;
            }
            return sign == 1 ? true : false;
        }

        private bool AlterModel(ref CarsBrandSeries entity, ReqAddBrand am)
        {
            int sign = 0;
            if (!string.IsNullOrWhiteSpace(am.Name))
            {
                entity.Name = am.Name;
                sign = 1;
            }
            if (!string.IsNullOrWhiteSpace(am.Capital))
            {
                entity.Capital = am.Capital;
                sign = 1;
            }
            if (!string.IsNullOrWhiteSpace(am.BrandLogo))
            {
                entity.BrandLogo = am.BrandLogo;
                sign = 1;
            }
            if (Enum.IsDefined(typeof(ValidityState), am.State) && am.State != ValidityState.None)
            {
                entity.State = am.State;
                sign = 1;
            }
            if (Enum.IsDefined(typeof(CarBrandType), am.BrandType) && am.BrandType != CarBrandType.None)
            {
                entity.BrandType = am.BrandType;
                sign = 1;
            }
            if (Enum.IsDefined(typeof(CarBrandCountry), am.BrandCountry) && am.BrandCountry != CarBrandCountry.None)
            {
                entity.BrandCountry = am.BrandCountry;
                sign = 1;
            }
            if (sign == 1)
            {
                entity.TimeStamp = DateTime.Now;
            }
            return sign == 1 ? true : false;
        }

        private bool AlterModel(ref CarsBrandSeries entity, ReqAddSeries am)
        {
            int sign = 0;
            if (!string.IsNullOrWhiteSpace(am.Name))
            {
                entity.Name = am.Name;
                sign = 1;
            }
            if (!string.IsNullOrWhiteSpace(am.ParentId))
            {
                entity.ParentId = am.ParentId;
                sign = 1;
            }
            if (Enum.IsDefined(typeof(ValidityState), am.State) && am.State != ValidityState.None)
            {
                entity.State = am.State;
                sign = 1;
            }
            if (Enum.IsDefined(typeof(CarSeriesGrade), am.SeriesGrade) && am.SeriesGrade != CarSeriesGrade.None)
            {
                entity.SeriesGrade = am.SeriesGrade;
                sign = 1;
            }
            if (sign == 1)
            {
                entity.TimeStamp = DateTime.Now;
            }
            return sign == 1 ? true : false;
        }
    }
}
