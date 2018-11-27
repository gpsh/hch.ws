using hch.account.dbs;
using hch.definition;
using hch.wechat.processor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;

namespace hch.frame.runtime
{
    public class AuthenticationTokenAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var token = context.HttpContext.Request.Headers["token"];
            var openid = context.HttpContext.Request.Headers["openid"];
            if (string.IsNullOrWhiteSpace(token) || string.IsNullOrWhiteSpace(openid))
            {
                context.HttpContext.Response.StatusCode = 401;
                context.HttpContext.Response.ContentType = "application/json";
                //context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(
                //    new { authenticated = false, tokenExpired = true }
                //));
                context.Result = new ContentResult();
                return;
            }
            var account = new DbsAccount().ByOpenId(openid, ValidityState.Enabled);

            if (account == null || string.IsNullOrWhiteSpace(account.Session_Key))
            {
                context.HttpContext.Response.StatusCode = 401;
                context.HttpContext.Response.ContentType = "application/json";
                context.Result = new EmptyResult();
                return;
            }
            var basetoken = new WeChatService().GetToken(new WeChatRes(openid, account.Session_Key));
            if (basetoken != token)
            {
                context.HttpContext.Response.StatusCode = 401;
                context.HttpContext.Response.ContentType = "application/json";
                context.Result = new ContentResult();
                return;
            }
        }
    }
}
