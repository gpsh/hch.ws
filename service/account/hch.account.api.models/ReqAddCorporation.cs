using hch.definition;
using System;
using System.Collections.Generic;
using System.Text;

namespace hch.account.api.models
{
    public class ReqAddCorporation
    {
        /// <summary>
        /// 公司Id
        /// </summary>
        public string CorporationId { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 简介(可空)
        /// </summary>
        public string Presentation { get; set; }

        /// <summary>
        /// 固话(可空)
        /// </summary>
        public string FixPhone { get; set; }

        /// <summary>
        /// 店面图片(可空)
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// 状态(可空)
        /// </summary>
        public ValidityState State { get; set; }

        public bool Valid4AddCorporation()
        {
            return !(string.IsNullOrWhiteSpace(Name)
                || string.IsNullOrWhiteSpace(Address)
                );
        }
    }
}
