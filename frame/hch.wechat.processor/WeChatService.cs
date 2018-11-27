using hch.model;
using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using Wx;

namespace hch.wechat.processor
{
    public class WeChatService
    {

        public WeChatRes GetOpenIdSeeeionKey(string code)
        {
            string domain = "https://api.weixin.qq.com/sns/jscode2session?grant_type=authorization_code";
            string appid = ConfigService.GetValue<string>("AppId");
            string secret = ConfigService.GetValue<string>("AppSecret");
            string geturl = domain + "&appid=" + appid + "&secret=" + secret + "&js_code=" + code;

            HttpClient httpClient = new HttpClient();
            //httpClient.MaxResponseContentBufferSize = 256000;
            //httpClient.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (Windows NT 6.1; WOW64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/36.0.1985.143 Safari/537.36");
            HttpResponseMessage response = httpClient.GetAsync(new Uri(geturl)).Result;
            String result = response.Content.ReadAsStringAsync().Result;
            var retres = JsonSerializationConverter.FromJsonStr<WeChatRes>(result);
            if (retres.errcode!=0|| string.IsNullOrWhiteSpace(retres.openid) || string.IsNullOrWhiteSpace(retres.session_key))
            {
                //记录日志，返回错误的信息
                return null;
            }
            return retres;
        }

        public string GetToken(WeChatRes param)
        {
            string EncryptStr = param.openid + param.session_key;
            //string ret = EncryptToMD5(EncryptStr);
           
            string ret = EncryptToSHA1(EncryptStr);
            return ret;

        }

        #region 获取由SHA1加密的字符串
        public string EncryptToSHA1(string str)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] str1 = Encoding.UTF8.GetBytes(str);
            byte[] str2 = sha1.ComputeHash(str1);
            sha1.Clear();
            (sha1 as IDisposable).Dispose();

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < str2.Length; i++)
            {
              sb.Append(str2[i].ToString("x2"));
            }
            return sb.ToString() ;
        }
        #endregion
        #region 获取由MD5加密的字符串
        public string EncryptToMD5(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] str1 = Encoding.UTF8.GetBytes(str);
            byte[] str2 = md5.ComputeHash(str1, 0, str1.Length);
            md5.Clear();
            (md5 as IDisposable).Dispose();

            StringBuilder sb = new StringBuilder();
            foreach (var item in str2)
            {
                sb.AppendFormat("{0:x2}",item);
            }
            return sb.ToString();
        }
        #endregion

    }

    public class WeChatRes
    {
        public WeChatRes() { }

        public WeChatRes(string openid, string sessionkey)
        {
            this.openid = openid;
            this.session_key = sessionkey;
        }
        public string openid { get; set; }

        public string session_key { get; set; }

        public string unionid { get; set; }

        public long errcode { get; set; }
        public string errmsg { get; set; }

    }
}
