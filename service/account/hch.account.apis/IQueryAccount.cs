using hch.account.api.models;
using hch.global;
using Microsoft.AspNetCore.Mvc;
using System;
using Wx;

namespace hch.account.apis
{
    public interface IQueryAccount 
    {
        /// <summary>
        /// 根据用户openid获得用户基本信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "QueryAccount", "AccountSimple", "查询用户基本信息", "{OpenId:开放id}")]
        IWsModel<ReqAccount, ResAccount> AccountSimple([FromBody]WsModel<ReqAccount, ResAccount> model);

        /// <summary>
        /// 根据用户openid获得用户信息包含公司信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "QueryAccount", "AccountInfo", "查询用户信息包括公司信息", "{OpenId:开放id}")]
        IWsModel<ReqAccount, ResAccount> AccountInfo([FromBody]WsModel<ReqAccount, ResAccount> model);

        /// <summary>
        /// 根据用户openid获得公司基本信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "QueryAccount", "Corporation", "根据用户openid获得公司基本信息", "{OpenId:开放id}")]
        IWsModel<ReqAccount, ResCorporation> Corporation([FromBody]WsModel<ReqAccount, ResCorporation> model);

        /// <summary>
        /// 根据公司id获得公司信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "QueryAccount", "CorporationInfo", "查询公司信息", "{CorporationId:开放id}")]
        IWsModel<ReqAccount, ResCorporation> CorporationInfo([FromBody]WsModel<ReqAccount, ResCorporation> model);

        /// <summary>
        /// 根据code获得登录状态token
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [QuickWebApi(HchInfo.Code, "QueryAccount", "Login", "根据code获得登录状态token", "{Code:用户登录凭证（有效期五分钟）,WechatName:微信昵称,Sex:性别,Logo:头像}")]
        IWsModel<ReqAccount, ResToken> Login([FromBody]WsModel<ReqAccount, ResToken> model);
    }
}
