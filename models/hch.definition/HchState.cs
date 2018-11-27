using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace hch.definition
{
    [Flags]
    public enum ValidityState
    {
        /// <summary>
        /// 无
        /// </summary>
        [Display(Description = "无")]
        None = 0,
        /// <summary>
        /// 可用
        /// </summary>
        [Display(Description = "可用")]
        Enabled = 1,
        /// <summary>
        /// 禁用
        /// </summary>
        [Display(Description = "禁用")]
        Disabled = 2,
        /// <summary>
        /// 删除
        /// </summary>
        [Display(Description = "删除")]
        Deleted = 4,

    }

    [Flags]
    public enum Identity
    {
        /// <summary>
        /// 无
        /// </summary>
        [Display(Description = "无")]
        None = 0,
        /// <summary>
        /// 游客
        /// </summary>
        [Display(Description = "游客")]
        Visitor = 1,
        /// <summary>
        /// 职员
        /// </summary>
        [Display(Description = "职员")]
        Staff = 2,
        /// <summary>
        /// 管理员
        /// </summary>
        [Display(Description = "管理员")]
        admin = 4,
    }
}
