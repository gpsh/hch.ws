using System;
using Wx;

namespace hch.account.api.models
{
    public class ReqAccount
    {

        public string AccountId { get; set; }

        public string OpenId { get; set; }

        public string CorporationId { get; set; }


        /// <summary>
        /// 用户登录凭证（有效期五分钟）
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 微信昵称
        /// </summary>
        public string WechatName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Gender Sex { get; set; }

        /// <summary>
        /// 头像
        /// </summary>
        public string Logo { get; set; }

        public bool Valid4Login()
        {
            return !(string.IsNullOrWhiteSpace(Code)
                || string.IsNullOrWhiteSpace(WechatName)
                || string.IsNullOrWhiteSpace(Logo)
                || Enum.IsDefined(typeof(Gender), Sex)
                );
        }
    }
}
