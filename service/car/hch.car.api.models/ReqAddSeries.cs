using hch.definition;
using System;
using System.Collections.Generic;
using System.Text;

namespace hch.car.api.models
{
    public class ReqAddSeries
    {
        /// <summary>
        /// 车系Id
        /// </summary>
        public string CarSeriesId { get; set; }
        /// <summary>
        /// 上级ID
        /// </summary>
        public string ParentId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public ValidityState State { get; set; }

        /// <summary>
        /// 车系级别
        /// </summary>
        public CarSeriesGrade SeriesGrade { get; set; }

        public bool Valid4AddSeries()
        {
            return !(string.IsNullOrWhiteSpace(Name)
                || string.IsNullOrWhiteSpace(ParentId)
                || SeriesGrade == CarSeriesGrade.None
                );
        }
        public bool Valid4Enum()
        {

            return (
                Enum.IsDefined(typeof(CarSeriesGrade), SeriesGrade)
                && Enum.IsDefined(typeof(ValidityState), State)
                );
        }

    }
}
