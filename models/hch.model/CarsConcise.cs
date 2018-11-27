using hch.definition;
using System;
using System.Collections.Generic;
using System.Text;
using Wx;

namespace hch.model
{
    /// <summary>
    /// 车辆简明信息
    /// </summary>
    public class CarsConcise : WxSuperModel, ICarsConcise
    {
        public CarsConcise() { }
        public CarsConcise(string AccountId = null, string CarsDetailsId = null, string CorporationId = null, string Name = null,  string BrandId = null, string SeriesId = null,
            Decimal GuidePrice = 0, Decimal SellingPrice = 0, Decimal BasePrice = 0,
            ValidityState State = ValidityState.Disabled, string SurfaceImage = null, CarSell CarSell = CarSell.Sale, CarActivity CarActivity = CarActivity.None )
        {
            this.AccountId = AccountId;
            this.CarsDetailsId = CarsDetailsId;
            this.CorporationId = CorporationId;
            this.CarSell = CarSell;
            this.BrandId = BrandId;
            this.SeriesId = SeriesId;
            this.CarActivity = CarActivity;
            this.Name = Name;
            this.GuidePrice = GuidePrice;
            this.SellingPrice = SellingPrice;
            this.BasePrice = BasePrice;
            this.State = State;
            this.SurfaceImage = SurfaceImage;
            this.UpdateTime = DateTime.Now;
        }
        /// <summary>
        /// 品牌ID
        /// </summary>
        public string BrandId { get; set; }

        /// <summary>
        /// 车系ID
        /// </summary>
        public string SeriesId { get; set; }
        /// <summary>
        /// 车辆详情
        /// </summary>
        public string CarsDetailsId { get; set; }

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
        /// 状态（可空）
        /// </summary>
        public ValidityState State { get; set; }

        /// <summary>
        /// 封面图（可空）
        /// </summary>
        public string SurfaceImage { get; set; }

        /// <summary>
        /// 活动类型（可空）
        /// </summary>
        public CarActivity CarActivity { get; set; }

        /// <summary>
        /// 销售情况（可空）
        /// </summary>
        public CarSell CarSell { get; set; }

        /// <summary>
        /// 更新时间（可空）
        /// </summary>
        public DateTime UpdateTime { get; set; }

    }
}
