using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace hch.definition
{
    public class PageParam
    {
        DateTime valid_min_time = new DateTime(2010, 1, 1);
        public PageParam()
            : this(0, 0,0, null, null)
        { }
        public PageParam(int page_index, int page_size,int totalrows, DateTime? begin_time = null, DateTime? end_time = null, SortType SortType=SortType.Time, bool ascending = false)
        {
            this.TotalRows = totalrows;
            this.SortType = SortType;
            this.PageIndex = page_index <= 0 ? 0 : page_index;
            this.PageSize = page_size <= 0 ? 10 : page_size;
            if (begin_time.HasValue && begin_time.Value > valid_min_time)
                this.BeginTime = begin_time;
            if (end_time.HasValue && end_time.Value > valid_min_time)
                this.Endtime = end_time;
            this.Ascending = ascending;
        }

        public PageParam(int page_size, SortType SortType = SortType.Time, bool ascending = false)
        {
            this.SortType = SortType;
            this.PageSize = page_size <= 0 ? 10 : page_size;
            this.Ascending = ascending;
        }
        public PageParam(int page_size, DateTime? begin_time , DateTime? end_time)
        {
            this.PageSize = page_size <= 0 ? 10 : page_size;
            if (begin_time.HasValue && begin_time.Value > valid_min_time)
                this.BeginTime = begin_time;
            if (end_time.HasValue && end_time.Value > valid_min_time)
                this.Endtime = end_time;
        }
        /// <summary>
        /// 当前页码
        /// </summary>
        public int PageIndex { get; set; }
        /// <summary>
        /// 每页最大行数
        /// </summary>
        public int PageSize { get; set; }
        /// <summary>
        /// 总行数
        /// </summary>
        public int TotalRows { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        public DateTime? BeginTime { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        public DateTime? Endtime { get; set; }

        /// <summary>
        /// 排序类型
        /// </summary>
        public SortType SortType { get; set; }
        /// <summary>
        /// 是否升序
        /// </summary>
        public bool Ascending { get; set; }


    }

    /// <summary>
    /// 排序类型
    /// </summary>
    public enum SortType
    {
        /// <summary>
        /// 时间
        /// </summary>
        [Display(Description = "时间")]
        Time = 0,
        /// <summary>
        /// 价格
        /// </summary>
        [Display(Description = "价格")]
        Price = 1,

    }
}
