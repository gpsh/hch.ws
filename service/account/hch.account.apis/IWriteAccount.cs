using hch.account.api.models;
using hch.global;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Wx;

namespace hch.account.apis
{
    public interface IWriteAccount
    {
        /// <summary>
        /// 添加用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "WriteAccount", "AddAccount", "添加用户", "{Wechat:微信号,WechatName:昵称,OpenId:开放id,Corporation:公司,Phone:手机,Name:名称,Sex:性别(可空),Email:邮箱(可空),Logo:头像(可空)}")]
        IWsModel<ReqAddAccount, ResAccount> AddAccount([FromBody]WsModel<ReqAddAccount, ResAccount> model);

        /// <summary>
        /// 修改用户
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "WriteAccount", "UpdateAccount", "修改用户", "{OpenId:开放id,Wechat:微信号(可空),WechatName:昵称(可空),Corporation:公司(可空),Phone:手机(可空),Name:名称(可空),Sex:性别(可空),Email:邮箱(可空),Logo:头像(可空),State:状态(可空)}")]
        IWsModel<ReqAddAccount, ResAccount> UpdateAccount([FromBody]WsModel<ReqAddAccount, ResAccount> model);

        /// <summary>
        /// 添加公司
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "WriteAccount", "AddCorporation", "添加公司", "{Name:名称,Address:地址,Presentation:简介(可空),FixPhone:固话(可空),Image:店面图片(可空)}")]
        IWsModel<ReqAddCorporation, ResCorporation> AddCorporation([FromBody]WsModel<ReqAddCorporation, ResCorporation> model);

        /// <summary>
        /// 修改公司
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "WriteAccount", "UpdateCorporation", "修改公司", "{CorporationId:公司id,Name:名称(可空),Address:地址(可空),Presentation:简介(可空),FixPhone:固话(可空),Image:店面图片(可空),State:状态(可空)}")]
        IWsModel<ReqAddCorporation, ResCorporation> UpdateCorporation([FromBody]WsModel<ReqAddCorporation, ResCorporation> model);
    }
}
