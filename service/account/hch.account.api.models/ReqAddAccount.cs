using hch.definition;
using System;
using System.Collections.Generic;
using System.Text;
using Wx;

namespace hch.account.api.models
{
    public class ReqAddAccount
    {
        /// <summary>
        /// 微信号
        /// </summary>
        public string Wechat { get; set; }

        /// <summary>
        /// 微信昵称
        /// </summary>
        public string WechatName { get; set; }

        /// <summary>
        ///微信用户唯一标识
        /// </summary>
        public string OpenId { get; set; }

        /// <summary>
        /// 公司ID
        /// </summary>
        public string Corporation { get; set; }

        /// <summary>
        /// 性别(可空)
        /// </summary>
        public Gender Sex { get; set; }

        /// <summary>
        /// 邮件(可空)
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 头像(可空)
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// 状态(可空)
        /// </summary>
        public ValidityState State { get; set; }

        public bool Valid4AddAccount()
        {
            return !(string.IsNullOrWhiteSpace(Wechat)
                || string.IsNullOrWhiteSpace(WechatName)
                || string.IsNullOrWhiteSpace(OpenId)
                || string.IsNullOrWhiteSpace(Corporation)
                || string.IsNullOrWhiteSpace(Phone)
                || string.IsNullOrWhiteSpace(Name)

                );
        }

    }
}
