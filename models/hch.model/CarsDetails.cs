using hch.definition;
using System;
using System.Collections.Generic;
using System.Text;
using Wx;

namespace hch.model
{
    /// <summary>
    /// 车辆详情
    /// </summary>
    public class CarsDetails : WxSuperModel, ICarsDetails
    {
        public CarsDetails() { }
        public CarsDetails(CarDrive CarDrive = CarDrive.None, CarEnergy CarEnergy = CarEnergy.None, CarGearbox CarGearbox = CarGearbox.None,
            CarSeat CarSeat = CarSeat.None, CarEmissionStandard CarEmissionStandard = CarEmissionStandard.None,
            string Appearance=null, string Interior=null, string CarConfig = null, DateTime? CarLicenseTime=null, DateTime? CarAge=null, float Mileage =0,
            float Emission=0, string[] Images=null)
        {
            this.Appearance = Appearance;
            this.Interior = Interior;
            this.CarConfig = CarConfig;
            this.CarLicenseTime = CarLicenseTime;
            this.CarAge = CarAge;
            this.Emission = Emission;
            this.Images = Images;
            this.CarDrive = CarDrive;
            this.CarEnergy = CarEnergy;
            this.CarGearbox = CarGearbox;
            this.CarSeat = CarSeat;
            this.CarEmissionStandard = CarEmissionStandard;
            this.Mileage = Mileage;
        }
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

        
    }
}
