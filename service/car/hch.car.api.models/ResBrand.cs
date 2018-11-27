using hch.definition;
using System;
using System.Collections.Generic;
using Wx;

namespace hch.car.api.models
{
    public class ResGroupBrand
    {
        public string Capital { get; set; }

        public long Total { get; set; }

        public List<ResBrand> Values { get; set;}

    }

    public class ResBrand : WxSuperModel, ICarsBrandSeries
    {
        public ResBrand() { }

        public ResBrand(ICarsBrandSeries cbs)
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
        public ResBrand(string ParentId, string Name, string BrandLogo, ValidityState State, CarSeriesGrade CarGrade)
        {
            this.ParentId = ParentId;
            this.Name = Name;
            this.State = State;
            this.BrandLogo = BrandLogo;
            this.SeriesGrade = CarGrade;
        }
        public ResBrand(string ParentId, string Name, string Capital, string BrandLogo, ValidityState State, CarSeriesGrade CarGrade, CarBrandType CarBrand, CarBrandCountry BrandCountry)
        {
            this.ParentId = ParentId;
            this.Name = Name;
            this.Capital = Capital;
            this.State = State;
            this.BrandLogo = BrandLogo;
            this.SeriesGrade = CarGrade;
            this.BrandType = CarBrand;
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
        /// 热门
        /// </summary>
        public CarBrandType BrandType { get; set; }

        /// <summary>
        /// 国别
        /// </summary>
        public CarBrandCountry BrandCountry { get; set; }
    }
}
