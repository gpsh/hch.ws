using hch.definition;
using System;
using System.Collections.Generic;
using System.Text;
using Wx;

namespace hch.model
{
    /// <summary>
    /// 品牌车系
    /// </summary>
    public class CarsBrandSeries : WxSuperModel, ICarsBrandSeries
    {
        public CarsBrandSeries() { }

        public CarsBrandSeries(ICarsBrandSeries cbs)
        {
            if (cbs == null)
            {
                return;
            }
            this.Id = cbs.Id;
            this.Signature = cbs.Signature;
            this.TimeStamp = cbs.TimeStamp;
            this.ParentId = cbs.ParentId;
            this.Name = cbs.Name;
            this.Capital = cbs.Capital;
            this.State = cbs.State;
            this.BrandLogo = cbs.BrandLogo;
            this.SeriesGrade = cbs.SeriesGrade;
            this.BrandType = cbs.BrandType;
            this.BrandCountry = cbs.BrandCountry;
        }
        public CarsBrandSeries(string ParentId, string Name, ValidityState State, CarSeriesGrade SeriesGrade)
        {
            this.ParentId = ParentId;
            this.Name = Name;
            this.State = State;
            this.SeriesGrade = SeriesGrade;
        }
        public CarsBrandSeries( string Name, string Capital, string BrandLogo, ValidityState State, CarBrandType BrandType, CarBrandCountry BrandCountry)
        {
            this.Name = Name;
            this.Capital = Capital;
            this.State = State;
            this.BrandLogo = BrandLogo;
            this.BrandType = BrandType;
            this.BrandCountry = BrandCountry;
        }
        /// <summary>
        /// 上级ID
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 品牌首字母
        /// </summary>
        public string Capital { get; set; }

        /// <summary>
        /// 品牌图片
        /// </summary>
        public string BrandLogo { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public ValidityState State { get; set; }

        /// <summary>
        /// 车系级别
        /// </summary>
        public CarSeriesGrade SeriesGrade { get; set; }

        /// <summary>
        /// 热门品牌
        /// </summary>
        public CarBrandType BrandType { get; set; }

        /// <summary>
        /// 国别
        /// </summary>
        public CarBrandCountry BrandCountry { get; set; }
    }
}
