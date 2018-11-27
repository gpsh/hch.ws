using System;
using System.Collections.Generic;
using System.Text;

namespace hch.account.api.models
{
    public class ResToken
    {
        public ResToken() { }

        public ResToken(string token,string openid=null,string corporationid=null) {
            this.Token = token;
            this.OpenId = openid;
            this.CorporationId = corporationid;
        }
        public string Token { get; set; }

        public string OpenId { get; set; }

        public string CorporationId { get; set; }
    }
}
