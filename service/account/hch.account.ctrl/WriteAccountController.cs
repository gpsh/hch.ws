using hch.account.api.models;
using hch.account.apis;
using hch.frame.runtime;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Wx;

namespace hch.account.ctrl
{
    [Route("[controller]/[action]")]

    [AuthenticationToken]
    [AuthorizeAccount(definition.Identity.admin)]
    public class WriteAccountController : WxApiController, IWriteAccount
    {
        IWriteAccount _srv_writeaccount;

        public WriteAccountController(IWriteAccount srv_writeaccount)
        {
            _srv_writeaccount = srv_writeaccount;
        }
        [HttpPost]
        public IWsModel<ReqAddAccount, ResAccount> AddAccount([FromBody]WsModel<ReqAddAccount, ResAccount> model)
        {
            return _srv_writeaccount.AddAccount(model);
        }
        [HttpPost]
        public IWsModel<ReqAddCorporation, ResCorporation> AddCorporation([FromBody]WsModel<ReqAddCorporation, ResCorporation> model)
        {
            return _srv_writeaccount.AddCorporation(model);
        }
        [HttpPost]
        public IWsModel<ReqAddAccount, ResAccount> UpdateAccount([FromBody]WsModel<ReqAddAccount, ResAccount> model)
        {
            return _srv_writeaccount.UpdateAccount(model);
        }
        [HttpPost]
        public IWsModel<ReqAddCorporation, ResCorporation> UpdateCorporation([FromBody]WsModel<ReqAddCorporation, ResCorporation> model)
        {
            return _srv_writeaccount.UpdateCorporation(model);
        }
    }
}
