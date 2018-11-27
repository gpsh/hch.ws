using hch.account.api.models;
using hch.account.apis;
using hch.account.dba;
using hch.account.dbs;
using hch.definition;
using hch.enumextension;
using hch.model;
using hch.wechat.processor;
using Microsoft.AspNetCore.Mvc;
using System;
using Wx;

namespace hch.account.service
{
    public class QueryAccountService : WxWebApiService, IQueryAccount
    {
        public IWsModel<ReqAccount, ResAccount> AccountInfo([FromBody]WsModel<ReqAccount, ResAccount> model)
        {
            if (model == null)
            {
                return new WsModel<ReqAccount, ResAccount>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (string.IsNullOrWhiteSpace(model.Request.OpenId))
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数OpenId为空");
            }
            var result = new DbsAccount().GetAccountInfo(model.Request.OpenId,ValidityState.Enabled);
            if (result==null)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "用户不存在");
            }
            result.DescIdentity = result.Identity.GetIdentityDescription();
            result.DescSex = result.Sex.GetGenderDescription();
            return model.Ok(result);
        }

        public IWsModel<ReqAccount, ResAccount> AccountSimple([FromBody]WsModel<ReqAccount, ResAccount> model)
        {
            if (model == null)
            {
                return new WsModel<ReqAccount, ResAccount>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (string.IsNullOrWhiteSpace(model.Request.OpenId))
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数OpenId为空");
            }
            // var  wxlog=  WxLogFactory.GetWxLogger(typeof(QueryAccountService));
            //Account account = new DbsAccount().ById(model.Request.AccountId);
            Account account = new DbsAccount().ByOpenId(model.Request.OpenId,ValidityState.Enabled);
            if (account == null) return model.Fail(ErrorCode.DB_NOTEXISTED, "用户不存在");
            LogDebug($"找到用户{account.Name}");
            LogInfo($"找到用户{account.Name}");
            LogError($"找到用户{account.Name}");
            var res = new ResAccount(account);
            return model.Ok(res);
        }

        public IWsModel<ReqAccount, ResCorporation> Corporation([FromBody]WsModel<ReqAccount, ResCorporation> model)
        {
            if (model == null)
            {
                return new WsModel<ReqAccount, ResCorporation>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (string.IsNullOrWhiteSpace(model.Request.OpenId))
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数OpenId为空");
            }
            var ret = new DbsAccount().GetCorporation(model.Request.OpenId, ValidityState.Enabled);
            if (ret==null)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "公司不存在");
            }
            return model.Ok(ret);
        }

        public IWsModel<ReqAccount, ResCorporation> CorporationInfo([FromBody]WsModel<ReqAccount, ResCorporation> model)
        {
            if (model == null)
            {
                return new WsModel<ReqAccount, ResCorporation>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (string.IsNullOrWhiteSpace(model.Request.CorporationId))
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数CorporationId为空");
            }
            var cor = new DbsAccount().GetCorporationInfo(model.Request.CorporationId, ValidityState.Enabled);
            if (cor == null)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "公司不存在");
            }
            var ret = new ResCorporation(cor);
            return model.Ok(ret);
        }

        public IWsModel<ReqAccount, ResToken> Login([FromBody] WsModel<ReqAccount, ResToken> model)
        {
            if (model == null)
            {
                return new WsModel<ReqAccount, ResToken>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request.Valid4Login())
            {
                return model.Fail(ErrorCode.PARAM_INVALID, "参数无效");
            }
            var wechat = new WeChatService().GetOpenIdSeeeionKey(model.Request.Code);
            if (wechat == null)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "Code错误");
            }
            var account = new DbsAccount().GetAccount(wechat.openid);
            if (account == null)
            {
                var addaccount = new Account(model.Request.WechatName, wechat.openid, wechat.session_key, model.Request.Sex,ValidityState.Enabled, Identity.Visitor, model.Request.Logo, DateTime.Now);
                var addret = new DbaAccount().AddAccount(addaccount);
                if (addret == 0)
                {
                    return model.Fail(ErrorCode.DB_SAVE_FAILED, "添加失败");
                }
                else
                {
                    var token = new WeChatService().GetToken(wechat);
                    var ret = new ResToken(token, addaccount.OpenId);
                    return model.Ok(ret);
                }
            }
            else
            {
                if (account.State != ValidityState.Enabled)
                {
                    return model.Fail(ErrorCode.USER_DISABLE, "账户不可用");
                }
                var token = new WeChatService().GetToken(wechat);
                var ret = new ResToken(token, account.OpenId, account.Corporation);
                return model.Ok(ret);
            }

        }
    }
}
