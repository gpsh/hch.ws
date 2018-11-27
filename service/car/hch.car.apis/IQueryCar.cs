using hch.car.api.models;
using hch.global;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Wx;

namespace hch.car.apis
{
    public interface IQueryCar
    {
        /// <summary>
        /// 查询所有品牌
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "QueryCar", "BrandAll", "查询所有品牌", "")]
        IWsModel<ReqCar, List<ResGroupBrand>> BrandAll([FromBody]WsModel<ReqCar, List<ResGroupBrand>> model);
        /// <summary>
        /// 查询热门品牌
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "QueryCar", "BrandHot", "查询热门品牌", "{PageSize:个数(可选，默认10)}")]
        IWsModel<ReqCar, List<ResBrand>> BrandHot([FromBody]WsModel<ReqCar, List<ResBrand>> model);

        /// <summary>
        /// 查询某个品牌下的车系
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "QueryCar", "BrandSeries", "查询某个品牌下的车系", "{BrandId:品牌id}")]
        IWsModel<ReqCar, List<ResBrand>> BrandSeries([FromBody]WsModel<ReqCar, List<ResBrand>> model);

        /// <summary>
        /// 筛选某台车辆之前的车辆 SeriesGrade:车系级别(可选),BrandCountry:国别(可选),CarAgeBegin:车龄(可选),CarAgeEnd:车龄(可选),MileageBegin:里程(可选),MileageEnd:里程(可选),EmissionBegin:排量(可选),EmissionEnd:排量(可选),CarDrive:驱动(可选),CarEnergy:能源(可选),CarGearbox:变速箱(可选),CarSeat:座位(可选),
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "QueryCar", "BeforeFilterCars", "筛选某台车辆之前的车辆", "{IndexCarId:索引车辆,BrandId:品牌id(可选),SeriesId:车系id(可选),CarActivity:活动类型(可选),SeriesGrade:车系级别(可选),BrandCountry:国别(可选),CarDrive:驱动(可选),CarEnergy:能源(可选),CarGearbox:变速箱(可选),CarSeat:座位(可选),PageSize:台数(可选，默认10),SortType:排序类型(默认按时间),Ascending:是否升序(默认降序)}")]
        IWsModel<ReqCar, List<ResCarConciseInfo>> BeforeFilterCars([FromBody]WsModel<ReqCar, List<ResCarConciseInfo>> model);

        /// <summary>
        /// 筛选某台太车辆之后的车辆(索引车辆为空，获取最新的几台车辆)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "QueryCar", "LaterFilterCars", "筛选某台太车辆之后的车辆(索引车辆为空，获取最新的几台车辆)", "{IndexCarId:索引车辆(可选),BrandId:品牌id(可选),SeriesId:车系id(可选),CarActivity:活动类型(可选),SeriesGrade:车系级别(可选),BrandCountry:国别(可选),CarDrive:驱动(可选),CarEnergy:能源(可选),CarGearbox:变速箱(可选),CarSeat:座位(可选),PageSize:台数(可选，默认10),SortType:排序类型(默认按时间),Ascending:是否升序(默认降序)}")]
        IWsModel<ReqCar, List<ResCarConciseInfo>> LaterFilterCars([FromBody]WsModel<ReqCar, List<ResCarConciseInfo>> model);

        /// <summary>
        /// 查询某个店铺下的某台太车辆之后的车辆(索引车辆为空，获取最新的几台车辆)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "QueryCar", "LaterStoreCars", "查询某个店铺下的某台太车辆之后的车辆(索引车辆为空，获取最新的几台车辆)", "{CorporationId:店铺,IndexCarId:索引车辆(可选),PageSize:台数(可选，默认10)}")]
        IWsModel<ReqCar, List<ResCarConciseInfo>> LaterStoreCars([FromBody]WsModel<ReqCar, List<ResCarConciseInfo>> model);

        /// <summary>
        /// 查询某个店铺下的某台太车辆之前的车辆
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "QueryCar", "BeforeStoreCars", "查询某个店铺下的某台太车辆之前的车辆", "{CorporationId:店铺,IndexCarId:索引车辆,PageSize:台数(可选，默认10)}")]
        IWsModel<ReqCar, List<ResCarConciseInfo>> BeforeStoreCars([FromBody]WsModel<ReqCar, List<ResCarConciseInfo>> model);

        /// <summary>
        /// 查询某个人发布的(在售、下架)某台太车辆之后的车辆(索引车辆为空，获取最新的几台车辆)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "QueryCar", "LaterUserCars", "查询某个人发布的(在售、下架)某台太车辆之后的车辆(索引车辆为空，获取最新的几台车辆)", "{OpenId:用户,CarSell:销售情况(可选，默认0在售),IndexCarId:索引车辆(可选),PageSize:台数(可选，默认10)}")]
        IWsModel<ReqCar, List<ResCarConciseInfo>> LaterUserCars([FromBody]WsModel<ReqCar, List<ResCarConciseInfo>> model);

        /// <summary>
        /// 查询某个人发布的(在售、下架)某台太车辆之前的车辆
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "QueryCar", "BeforeUserCars", "查询某个人发布的(在售、下架)某台太车辆之前的车辆", "{OpenId:用户,CarSell:销售情况(可选，默认0在售),IndexCarId:索引车辆,PageSize:台数(可选，默认10)}")]
        IWsModel<ReqCar, List<ResCarConciseInfo>> BeforeUserCars([FromBody]WsModel<ReqCar, List<ResCarConciseInfo>> model);

        /// <summary>
        /// 查询今天发布的某台太车辆之后的车辆(索引车辆为空，获取最新的几台车辆)
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "QueryCar", "LaterTodayCars", "查询今天发布的某台太车辆之后的车辆(索引车辆为空，获取最新的几台车辆)", "{IndexCarId:索引车辆(可选),PageSize:台数(可选，默认10)}")]
        IWsModel<ReqCar, List<ResCarConciseInfo>> LaterTodayCars([FromBody]WsModel<ReqCar, List<ResCarConciseInfo>> model);

        /// <summary>
        /// 查询今天发布的某台太车辆之前的车辆
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "QueryCar", "BeforeTodayCars", "查询今天发布的某台太车辆之前的车辆", "{IndexCarId:索引车辆,PageSize:台数(可选，默认10)}")]
        IWsModel<ReqCar, List<ResCarConciseInfo>> BeforeTodayCars([FromBody]WsModel<ReqCar, List<ResCarConciseInfo>> model);

        /// <summary>
        /// 查询某台太车辆的信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "QueryCar", "CarInfo", "查询某台太车辆的信息", "{CarId:车辆}")]
        IWsModel<ReqCar, ResCarDetail> CarInfo([FromBody]WsModel<ReqCar, ResCarDetail> model);
    }
}
