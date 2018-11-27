using hch.definition;
using System;
using System.Collections.Generic;
using System.Text;
using Wx;

namespace hch.account.api.models
{
    public class ResCorporation: WxSuperModel
    {
        public ResCorporation() { }

        public ResCorporation(ICorporation corp)
        {
            if (corp == null)
            {
                return;
            }
            this.Id = corp.Id;
            this.Signature = corp.Signature;
            this.TimeStamp = corp.TimeStamp;
            this.CorporationName = corp.Name;
            this.Address = corp.Address;
            this.FixPhone = corp.FixPhone;
            this.CorporationImage = corp.Image;
            this.Presentation = corp.Presentation;
            this.CorporationState = corp.State;

        }
        /// <summary>
        /// 名称
        /// </summary>
        public string CorporationName { get; set; }

        /// <summary>
        /// 地址
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// 简介
        /// </summary>
        public string Presentation { get; set; }

        /// <summary>
        /// 固话
        /// </summary>
        public string FixPhone { get; set; }

        /// <summary>
        /// 店面图片
        /// </summary>
        public string CorporationImage { get; set; }

        /// <summary>
        /// 公司状态
        /// </summary>
        public ValidityState CorporationState { get; set; }

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
        /// 手机号
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string AccountName { get; set; }

        /// <summary>
        /// 用户状态
        /// </summary>
        public ValidityState AccountState { get; set; }
    }
}
