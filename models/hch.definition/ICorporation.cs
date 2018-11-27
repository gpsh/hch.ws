using System;
using System.Collections.Generic;
using System.Text;
using Wx;

namespace hch.definition
{
    /// <summary>
    /// 公司
    /// </summary>
    public interface ICorporation:IWxSuperModel
    {
        string Name { get; set; }

        string Address { get; set; }

        string Presentation { get; set; }

        string FixPhone { get; set; }

        string Image { get; set; }

        ValidityState State { get; set; }

        DateTime UpdateTime { get; set; }
    }
}
