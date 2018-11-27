using hch.definition;
using System;
using System.Collections.Generic;
using System.Text;

namespace hch.car.api.models
{
    public class ReqAddCar
    {
        /// <summary>
        /// 车辆信息Id
        /// </summary>
        public string CarInfoId { get; set; }
        /// <summary>
        /// 品牌ID
        /// </summary>
        public string BrandId { get; set; }

        /// <summary>
        /// 车系ID
        /// </summary>
        public string SeriesId { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        public string AccountId { get; set; }

        /// <summary>
        /// 公司ID
        /// </summary>
        public string CorporationId { get; set; }

        /// <summary>
        /// 品牌、车系、车辆
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 指导价
        /// </summary>
        public Decimal GuidePrice { get; set; }

        /// <summary>
        /// 销售价
        /// </summary>
        public Decimal SellingPrice { get; set; }

        /// <summary>
        /// 底价
        /// </summary>
        public Decimal BasePrice { get; set; }
                
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

        /// <summary>
        /// 排放标准
        /// </summary>
        public CarEmissionStandard CarEmissionStandard { get; set; }

        /// <summary>
        /// 活动类型(可空)
        /// </summary>
        public CarActivity CarActivity { get; set; }

        /// <summary>
        /// 外观（可空）
        /// </summary>
        public string Appearance { get; set; }

        /// <summary>
        /// 内饰（可空）
        /// </summary>
        public string Interior { get; set; }
        /// <summary>
        /// 输入配置（可空）
        /// </summary>
        public string CarConfig { get; set; }

        /// <summary>
        /// 上牌时间（可空）
        /// </summary>
        public DateTime? CarLicenseTime { get; set; }

        /// <summary>
        /// 出产日期（可空）
        /// </summary>
        public DateTime? CarAge { get; set; }

        /// <summary>
        /// 表显里程(万公里)（可空）
        /// </summary>
        public float Mileage { get; set; }

        /// <summary>
        /// 排量,新能源的是0,（可空）
        /// </summary>
        public float Emission { get; set; }

        /// <summary>
        /// 车辆图片（可空）
        /// </summary>
        public string[] Images { get; set; }

        /// <summary>
        /// 状态（可空）
        /// </summary>
        public ValidityState State { get; set; }


        public bool Valid4AddCar()
        {
            return !(string.IsNullOrWhiteSpace(BrandId)
                || string.IsNullOrWhiteSpace(SeriesId)
                || string.IsNullOrWhiteSpace(AccountId)
                || string.IsNullOrWhiteSpace(CorporationId)
                || string.IsNullOrWhiteSpace(Name)
                || GuidePrice==0
                || SellingPrice == 0
                || BasePrice == 0
                || CarDrive== CarDrive.None
                || CarEnergy== CarEnergy.None
                || CarGearbox== CarGearbox.None
                || CarSeat== CarSeat.None
                || CarEmissionStandard== CarEmissionStandard.None
                );
        }
        public bool Valid4Enum()
        {
            return (
                Enum.IsDefined(typeof(CarDrive), CarDrive)
                && Enum.IsDefined(typeof(CarEnergy), CarEnergy)
                && Enum.IsDefined(typeof(CarGearbox), CarGearbox)
                && Enum.IsDefined(typeof(CarSeat), CarSeat)
                && Enum.IsDefined(typeof(CarEmissionStandard), CarEmissionStandard)
                && Enum.IsDefined(typeof(CarActivity), CarActivity)
                && Enum.IsDefined(typeof(ValidityState), State)
                );
        }
    }
}
