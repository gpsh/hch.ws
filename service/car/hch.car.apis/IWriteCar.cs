using hch.car.api.models;
using hch.global;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Wx;

namespace hch.car.apis
{
    public interface IWriteCar
    {
        /// <summary>
        /// 添加车辆信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "WriteCar", "AddCarInfo", "添加车辆信息", "{BrandId:品牌,SeriesId:车系,AccountId:创建者,CorporationId:公司,Name: 品牌车系车型,GuidePrice:指导价," +
            "SellingPrice:售价,BasePrice:低价,CarDrive:驱动,CarEnergy:能源,CarGearbox:变速箱,CarSeat:座位数,CarEmissionStandard:排放标准,CarActivity:活动类型(可空)," +
            "Appearance:外观(可空),Interior:内饰(可空),CarConfig:配置(可空),CarLicenseTime:上牌时间(可空),CarAge:出产日期(可空),Mileage:表显里程(可空),Emission:排量(可空),Images:图片数组(可空)}")]
        IWsModel<ReqAddCar, ResCarConciseInfo> AddCarInfo([FromBody]WsModel<ReqAddCar, ResCarConciseInfo> model);

        /// <summary>
        /// 修改车辆信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "WriteCar", "UpdateCarInfo", "修改车辆信息", "{CarInfoId:车辆id,GuidePrice:指导价(可空),State:状态(可空)," +
            "SellingPrice:售价(可空),BasePrice:低价(可空),CarDrive:驱动(可空),CarEnergy:能源(可空),CarGearbox:变速箱(可空),CarSeat:座位数(可空),CarEmissionStandard:排放标准(可空),CarActivity:活动类型(可空)," +
            "Appearance:外观(可空),Interior:内饰(可空),CarConfig:配置(可空),CarLicenseTime:上牌时间(可空),CarAge:出产日期(可空),Mileage:表显里程(可空),Emission:排量(可空),Images:图片数组(可空)}")]
        IWsModel<ReqAddCar, ResCarConciseInfo> UpdateCarInfo([FromBody]WsModel<ReqAddCar, ResCarConciseInfo> model);


        /// <summary>
        /// 添加汽车品牌
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "WriteCar", "AddCarBrand", "添加汽车品牌", "{Name:品牌名,Capital:首字母,BrandLogo:品牌图片,BrandType: 品牌类别,BrandCountry:国别}")]
        IWsModel<ReqAddBrand, ResBrand> AddCarBrand([FromBody]WsModel<ReqAddBrand, ResBrand> model);

        /// <summary>
        /// 修改汽车品牌
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "WriteCar", "UpdateCarBrand", "修改汽车品牌", "{CarBrandId:品牌Id,Name:品牌名(可空),Capital:首字母(可空),BrandLogo:品牌图片(可空),BrandType: 品牌类别(可空),BrandCountry:国别(可空),State:状态(可空)}")]
        IWsModel<ReqAddBrand, ResBrand> UpdateCarBrand([FromBody]WsModel<ReqAddBrand, ResBrand> model);

        /// <summary>
        /// 添加汽车车系
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "WriteCar", "AddCarSeries", "添加汽车车系", "{Name:车系名,ParentId:品牌Id,SeriesGrade:车系级别}")]
        IWsModel<ReqAddSeries, ResBrand> AddCarSeries([FromBody]WsModel<ReqAddSeries, ResBrand> model);

        /// <summary>
        /// 修改汽车车系
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "WriteCar", "UpdateCarSeries", "修改汽车车系", "{CarSeriesId:车系Id,Name:车系名(可空),ParentId:品牌Id(可空),SeriesGrade:车系级别(可空),State:状态(可空)}")]
        IWsModel<ReqAddSeries, ResBrand> UpdateCarSeries([FromBody]WsModel<ReqAddSeries, ResBrand> model);

    }
}
