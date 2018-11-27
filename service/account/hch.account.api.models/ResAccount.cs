using hch.definition;
using hch.enumextension;
using System;
using System.Collections.Generic;
using System.Text;
using Wx;

namespace hch.account.api.models
{
    public class ResAccount : WxSuperModel
    {
        public ResAccount() { }

        public ResAccount(IAccount ac)
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
            this.UpdateTime = ac.UpdateTime;
            this.State = ac.State;
            this.Sex = ac.Sex;
            this.Phone = ac.Phone;
            this.Name = ac.Name;
            this.Logo = ac.Logo;
            this.Identity = ac.Identity;
            this.Email = ac.Email;
            this.Corporation = ac.Corporation;

            this.DescIdentity = ac.Identity.GetIdentityDescription();
            this.DescSex = ac.Sex.GetGenderDescription();
        }

        public ResAccount(string Id,string Signature,DateTime TimeStamp, string Wechat, string WechatName, string OpenId , string Corporation, string CorporationName, Gender Sex, string Email, string Phone, string Name, ValidityState State, Identity Identity, string Logo, DateTime UpdateTime)
        {
            this.Id = Id;
            this.Signature = Signature;
            this.TimeStamp = TimeStamp;
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
            this.CorporationName = CorporationName;
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
        /// 公司ID
        /// </summary>
        public string Corporation { get; set; }

        /// <summary>
        /// 公司名称
        /// </summary>
        public string CorporationName { get; set; }

        /// <summary>
        /// 性别
        /// </summary>
        public Gender Sex { get; set; }

        /// <summary>
        /// 性别描述
        /// </summary>
        public KeyValuePair<Gender, string> DescSex { get; set; }
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
        /// 身份描述
        /// </summary>
        public List<KeyValuePair<Identity, string>> DescIdentity { get; set; }
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
