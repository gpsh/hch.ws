using hch.definition;
using System;
using System.Collections.Generic;
using System.Text;
using Wx;

namespace hch.model
{
    /// <summary>
    /// 公司
    /// </summary>
    public class Corporation : WxSuperModel, ICorporation
    {
        public Corporation() { }

        public Corporation(ICorporation corp)
        {
            if (corp == null)
            {
                return;
            }
            this.Id = corp.Id;
            this.Signature = corp.Signature;
            this.TimeStamp = corp.TimeStamp;
            this.Name = corp.Name;
            this.Address = corp.Address;
            this.FixPhone = corp.FixPhone;
            this.Image = corp.Image;
            this.Presentation = corp.Presentation;
            this.State = corp.State;
            this.UpdateTime = corp.UpdateTime;
        }

        public Corporation(string Name, string Address, string Presentation, string FixPhone, string Image, ValidityState State, DateTime UpdateTime)
        {
            this.Name = Name;
            this.Address = Address;
            this.FixPhone = FixPhone;
            this.Image = Image;
            this.Presentation = Presentation;
            this.State = State;
            this.UpdateTime = UpdateTime;
        }
        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

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
        public string Image { get; set; }


        /// <summary>
        /// 状态
        /// </summary>
        public ValidityState State { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
