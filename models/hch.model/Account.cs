using hch.definition;
using System;
using Wx;

namespace hch.model
{
    /// <summary>
    /// 账户
    /// </summary>
    public class Account : WxSuperModel, IAccount
    {
        public Account() { }

        public Account(IAccount ac)
        {
            if (ac == null)
            {
                return;
            }
            this.Id = ac.Id;
            this.Signature = ac.Signature;
            this.TimeStamp = ac.TimeStamp;
            this.WechatName = ac.WechatName;
            this.Wechat = ac.Wechat;
            this.OpenId = ac.OpenId;
            this.Session_Key = ac.Session_Key;
            this.UnionId = ac.UnionId;
            this.UpdateTime = ac.UpdateTime;
            this.State = ac.State;
            this.Sex = ac.Sex;
            this.Phone = ac.Phone;
            this.Name = ac.Name;
            this.Logo = ac.Logo;
            this.Identity = ac.Identity;
            this.Email = ac.Email;
            this.Corporation = ac.Corporation;
        }
        public Account(string Wechat, string WechatName, string OpenId, string Corporation, Gender Sex, string Email, string Phone, string Name, ValidityState State, Identity Identity, string Logo, DateTime UpdateTime)
        {
            this.WechatName = WechatName;
            this.Wechat = Wechat;
            this.OpenId = OpenId;
            this.UpdateTime = UpdateTime;
            this.State = State;
            this.Sex = Sex;
            this.Phone = Phone;
            this.Name = Name;
            this.Logo = Logo;
            this.Identity = Identity;
            this.Email = Email;
            this.Corporation = Corporation;
        }
        public Account(string WechatName, string OpenId, string Session_Key, Gender Sex, ValidityState State, Identity Identity, string Logo, DateTime UpdateTime)
        {
            this.WechatName = WechatName;
            this.OpenId = OpenId;
            this.UpdateTime = UpdateTime;
            this.State = State;
            this.Sex = Sex;
            this.Logo = Logo;
            this.Identity = Identity;
            this.Session_Key = Session_Key;
        }
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
        /// 会话密匙
        /// </summary>
        public string Session_Key { get; set; }

        /// <summary>
        /// 用户在开放平台的唯一标识符
        /// </summary>
        public string UnionId { get; set; }
        /// <summary>
        /// 公司ID
        /// </summary>
        public string Corporation { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Gender Sex { get; set; }

        /// <summary>
        /// 邮件
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
        /// 状态
        /// </summary>
        public ValidityState State { get; set; }

        /// <summary>
        /// 身份
        /// </summary>
        public Identity Identity { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }

    }
}
