using hch.definition;
using System;
using System.Collections.Generic;
using System.Text;
using Wx;

namespace hch.car.api.models
{
    public class ResCarConciseInfo : WxSuperModel
    {
        public ResCarConciseInfo() { }
        public ResCarConciseInfo(ICarsConcise cc, DateTime? CarLicenseTime=null, float Mileage =0)
        {
            this.CarInfoId = cc.Id;
            this.UpdateTime = cc.UpdateTime;
            this.CarsDetailsId = cc.CarsDetailsId;
            this.CarActivity = cc.CarActivity;
            this.Name = cc.Name;
            this.GuidePrice = cc.GuidePrice;
            this.SellingPrice = cc.SellingPrice;
            this.BasePrice = cc.BasePrice;
            this.SurfaceImage = cc.SurfaceImage;
            this.CarLicenseTime = CarLicenseTime;
            this.Mileage = Mileage;
        }
        /// <summary>
        /// 车辆信息Id
        /// </summary>
        public string CarInfoId { get; set; }
        /// <summary>
        /// 车辆详情
        /// </summary>
        public string CarsDetailsId { get; set; }

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
        /// 封面图
        /// </summary>
        public string SurfaceImage { get; set; }

        /// <summary>
        /// 活动类型
        /// </summary>
        public CarActivity CarActivity { get; set; }

        /// <summary>
        /// 上牌时间
        /// </summary>
        public DateTime? CarLicenseTime { get; set; }

        /// <summary>
        /// 表显里程
        /// </summary>
        public float Mileage { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
