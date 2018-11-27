using hch.definition;
using System;
using System.Collections.Generic;
using System.Text;

namespace hch.car.api.models
{
    public class ResCarDetail:ResCarConciseInfo
    {
        /// <summary>
        /// 创建者
        /// </summary>
        public string AccountId { get; set; }


        /// <summary>
        /// 公司ID
        /// </summary>
        public string CorporationId { get; set; }

        /// <summary>
        /// 外观
        /// </summary>
        public string Appearance { get; set; }

        /// <summary>
        /// 内饰
        /// </summary>
        public string Interior { get; set; }

        /// <summary>
        /// 输入配置
        /// </summary>
        public string CarConfig { get; set; }

        /// <summary>
        /// 排量,新能源的是0,筛选从1.0及以下开始
        /// </summary>
        public float Emission { get; set; }

        /// <summary>
        /// 车辆图片
        /// </summary>
        public string[] Images { get; set; }

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
    }
}
