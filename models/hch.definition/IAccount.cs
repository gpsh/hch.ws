using System;
using Wx;

namespace hch.definition
{
    /// <summary>
    /// 账户
    /// </summary>
    public interface IAccount : IWxSuperModel
    {
        string Wechat { get; set; }
        string WechatName { get; set; }
        string OpenId { get; set; }

        string Session_Key { get; set;}

        string UnionId { get; set; }

        string Corporation { get; set; }
        Gender Sex { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        string Name { get; set; }
        ValidityState State { get; set; }
        Identity Identity { get; set; }
        string Logo { get; set; }
        DateTime UpdateTime { get; set; }
    }
}
