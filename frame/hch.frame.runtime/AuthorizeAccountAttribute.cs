using hch.account.dbs;
using hch.definition;
using hch.wechat.processor;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace hch.frame.runtime
{

    public class AuthorizeAccountAttribute : ActionFilterAttribute
    {
        private Identity _needIdentity { get; set; }

        public AuthorizeAccountAttribute(Identity identity)
        {
            this._needIdentity = identity;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //获取context
            //var result = string.Empty;
            //var bo = context.HttpContext.Request.Body.CanRead;
            //context.HttpContext.Request.Body.Position = 0;
            //result = new StreamReader(context.HttpContext.Request.Body, UTF8Encoding.UTF8).ReadToEnd();
            //获取header
            //var keys = context.HttpContext.Request.Headers.Keys;
            //var values = context.HttpContext.Request.Headers.Values;
            var openid = context.HttpContext.Request.Headers["openid"];
            if (string.IsNullOrWhiteSpace(openid))
            {
                context.HttpContext.Response.StatusCode = 403;
                context.HttpContext.Response.ContentType = "application/json";
                //context.HttpContext.Response.WriteAsync(JsonConvert.SerializeObject(
                //    new { authenticated = false, tokenExpired = true }
                //));
                context.Result = new ContentResult();
                return;
            }
            var account = new DbsAccount().ByOpenId(openid, ValidityState.Enabled);
           //var bo = account.Identity & _needIdentity;
            if (account == null|| account.Identity!=_needIdentity)
            {
                if (account.Identity!=Identity.admin)
                {
                    context.HttpContext.Response.StatusCode = 403;
                    context.HttpContext.Response.ContentType = "application/json";
                    context.Result = new EmptyResult();
                    return;
                }
                
            }
            
        }
    }
}
