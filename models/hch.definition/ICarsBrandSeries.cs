using System;
using System.Collections.Generic;
using System.Text;
using Wx;

namespace hch.definition
{
    /// <summary>
    /// 汽车品牌车系
    /// </summary>
    public interface ICarsBrandSeries :IWxSuperModel
    {
        string ParentId { get; set; }
        string Name { get; set; }

        string Capital { get; set; }

        string BrandLogo { get; set; }

        ValidityState State { get; set; }

        CarSeriesGrade SeriesGrade { get;set; }

        CarBrandType BrandType { get; set; }

        CarBrandCountry BrandCountry { get; set; }
    }
}
