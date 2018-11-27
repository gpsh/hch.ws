using System;
using System.Collections.Generic;
using System.Text;
using Wx;

namespace hch.definition
{
    /// <summary>
    /// 车辆
    /// </summary>
    public interface ICarsConcise:IWxSuperModel
    {
        string BrandId { get; set; }

        string SeriesId { get; set; }

        string CarsDetailsId { get; set; }

        string AccountId { get; set; }

        string CorporationId { get; set; }

        string Name { get; set; }

        Decimal GuidePrice { get; set; }

        Decimal SellingPrice { get; set; }

        Decimal BasePrice { get; set; }

        ValidityState State { get; set; }

        string SurfaceImage { get; set; }

        CarActivity CarActivity { get; set; }


        CarSell CarSell { get; set; }

        DateTime UpdateTime { get; set; }

        

    }
}
