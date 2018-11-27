using hch.definition;
using System;
using System.Collections.Generic;
using System.Text;

namespace hch.car.api.models
{
    public class ReqAddBrand
    {
        /// <summary>
        /// 品牌Id
        /// </summary>
        public string CarBrandId { get; set; }
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
        /// 热门品牌
        /// </summary>
        public CarBrandType BrandType { get; set; }

        /// <summary>
        /// 国别
        /// </summary>
        public CarBrandCountry BrandCountry { get; set; }

        public bool Valid4AddBrand()
        {
            return !(string.IsNullOrWhiteSpace(Name)
                || string.IsNullOrWhiteSpace(Capital)
                || string.IsNullOrWhiteSpace(BrandLogo)
                || BrandType == CarBrandType.None
                || BrandCountry == CarBrandCountry.None
                );
        }
        public bool Valid4Enum()
        {

            return (
                Enum.IsDefined(typeof(CarBrandType), BrandType)
                && Enum.IsDefined(typeof(CarBrandCountry), BrandCountry)
                && Enum.IsDefined(typeof(ValidityState), State)
                );
        }
    }
}
