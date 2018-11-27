using hch.account.api.models;
using hch.account.apis;
using Microsoft.AspNetCore.Mvc;
using System;
using Wx;

namespace hch.account.ctrl
{
    [Route("[controller]/[action]")]
    public class QueryAccountController : WxApiController, IQueryAccount
    {
        IQueryAccount _srv_queryaccount;

        public QueryAccountController(IQueryAccount srv_queryaccount)
        {
            _srv_queryaccount = srv_queryaccount;
        }
        [HttpPost]
        public IWsModel<ReqAccount, ResAccount> AccountInfo([FromBody]WsModel<ReqAccount, ResAccount> model)
        {
            return _srv_queryaccount.AccountInfo(model);
        }

        [HttpPost]
        public IWsModel<ReqAccount, ResAccount> AccountSimple([FromBody]WsModel<ReqAccount, ResAccount> model)
        {
            return _srv_queryaccount.AccountSimple(model);
        }
        [HttpPost]
        public IWsModel<ReqAccount, ResCorporation> Corporation([FromBody]WsModel<ReqAccount, ResCorporation> model)
        {
            return _srv_queryaccount.Corporation(model);
        }
        [HttpPost]
        public IWsModel<ReqAccount, ResCorporation> CorporationInfo([FromBody]WsModel<ReqAccount, ResCorporation> model)
        {
            return _srv_queryaccount.CorporationInfo(model);
        }

        [HttpPost]
        public IWsModel<ReqAccount, ResToken> Login([FromBody] WsModel<ReqAccount, ResToken> model)
        {
            return _srv_queryaccount.Login(model);
        }
    }
}
