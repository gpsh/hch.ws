using hch.definition;
using System;
using System.Collections.Generic;
using System.Text;

namespace hch.car.api.models
{
    public class ReqCar : PageParam
    {
        public ReqCar(string OpenId=null, string CorporationId=null, string CarId=null, CarSell CarSell=CarSell.Sale, CarBrandType BrandType=CarBrandType.None, string IndexCarId=null, string BrandId=null, string SeriesId=null,
             CarSeriesGrade SeriesGrade=CarSeriesGrade.None, CarBrandCountry BrandCountry=CarBrandCountry.None, CarActivity CarActivity=CarActivity.None, int CarAgeBegin=0, int CarAgeEnd=0,
             int MileageBegin=0, int MileageEnd=15, CarDrive CarDrive=CarDrive.None, CarEnergy CarEnergy=CarEnergy.None, CarGearbox CarGearbox=CarGearbox.None, CarSeat CarSeat=CarSeat.None)
        {
            this.OpenId = OpenId;
            this.CorporationId = CorporationId;
            this.CarId = CarId;
            this.CarSell = CarSell;
            this.BrandType = BrandType;
            this.IndexCarId = IndexCarId;
            this.BrandId = BrandId;
            this.SeriesId = SeriesId;
            this.SeriesGrade = SeriesGrade;
            this.BrandCountry = BrandCountry;
            this.CarActivity = CarActivity;
            this.CarAgeBegin = CarAgeBegin;
            this.CarAgeEnd = CarAgeEnd;
            this.MileageBegin = MileageBegin;
            this.MileageEnd = MileageEnd;
            this.CarDrive = CarDrive;
            this.CarEnergy = CarEnergy;
            this.CarGearbox = CarGearbox;
            this.CarSeat = CarSeat;
        }
        /// <summary>
        /// 用户openId
        /// </summary>
        public string OpenId { get; set; }
        /// <summary>
        /// 公司id(店铺)
        /// </summary>
        public string CorporationId { get; set; }

        /// <summary>
        /// 车辆id
        /// </summary>
        public string CarId { get; set; }
        /// <summary>
        /// 在售、下架
        /// </summary>
        public CarSell CarSell { get; set; }

        /// <summary>
        /// 热门品牌
        /// </summary>
        public CarBrandType BrandType { get; set; }

        /// <summary>
        /// 索引车辆ID,根据这个来查之后或之前的几台车，首次进来为空
        /// </summary>
        public string IndexCarId { get; set; }

        /// <summary>
        /// 品牌ID
        /// </summary>
        public string BrandId { get; set; }

        /// <summary>
        /// 车系ID
        /// </summary>
        public string SeriesId { get; set; }

        /// <summary>
        /// 车系级别
        /// </summary>
        public CarSeriesGrade SeriesGrade { get; set; }

        /// <summary>
        /// 国别
        /// </summary>
        public CarBrandCountry BrandCountry { get; set; }

        /// <summary>
        /// 活动类型
        /// </summary>
        public CarActivity CarActivity { get; set; }

        /// <summary>
        /// 开始车龄(上牌时间)是一个范围
        /// </summary>
        public int CarAgeBegin { get; set; }

        /// <summary>
        /// 截止车龄(上牌时间)是一个范围
        /// </summary>
        public int CarAgeEnd { get; set; }

        /// <summary>
        /// 开始表显里程
        /// </summary>
        public int MileageBegin { get; set; }

        /// <summary>
        /// 截止表显里程
        /// </summary>
        public int MileageEnd { get; set; }

        /// <summary>
        /// 开始排量
        /// </summary>
        public float EmissionBegin { get; set; }

        /// <summary>
        /// 截止排量
        /// </summary>
        public float EmissionEnd { get; set; }

        /// <summary>
        /// 驱动
        /// </summary>
        public CarDrive CarDrive { get; set; }

        /// <summary>
        /// 能源
        /// </summary>
        public CarEnergy CarEnergy { get; set; }

        /// <summary>
        /// 变速箱
        /// </summary>
        public CarGearbox CarGearbox { get; set; }

        /// <summary>
        /// 座位数
        /// </summary>
        public CarSeat CarSeat { get; set; }



    }
}
