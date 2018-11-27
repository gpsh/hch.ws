using hch.definition;
using hch.frame.runtime;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Wx;

namespace hch.files
{
    [Route("[Controller]/[action]")]
    //[EnableCors("any")]
    [AuthenticationToken]
    [AuthorizeAccount(Identity.Staff)]
    public class FileController : WxApiController
    {
        private IHostingEnvironment hostingEnv;
        public FileController(IHostingEnvironment env)
        {
            this.hostingEnv = env;
        }
        [HttpPost]
        public IResultResponse<file_param> UploadForm(file_param param)
        {
            try
            {
                var user = param.user_id;
                var files = param.formfiles;
                //非空限制
                if (files == null || files.Count <= 0)
                {
                    return SRR.Fail<file_param>(ErrorCode.PARAM_NULL, "请选择上传的文件");
                }
                var conf = ConfigService.AppSettings<FileServerConfig>().Configs.Where(q => q.FType == "IMAGE").FirstOrDefault();
                //张数限制
                if (files.Count > conf.Count)
                {
                    return SRR.Fail<file_param>(ErrorCode.PARAM_INVALID, $"图片只能上传{conf.Count}");
                }
                //格式限制
                var allowTypes = GetAllowType(conf.AllowedExt);
                if (files.Any(b => !allowTypes.Contains(b.ContentType)))
                {
                    return SRR.Fail<file_param>(ErrorCode.PARAM_INVALID, $"只能上传{ conf.AllowedExt.ToString()}格式的文件");
                }
                long imagesize = conf.Size;
                //大小限制
                if (files.Sum(b => b.Length) >= imagesize * files.Count * 1024)
                {
                    return SRR.Fail<file_param>(ErrorCode.PARAM_INVALID, $"每张图片不能超过{imagesize}kb");
                }
                var savepath = hostingEnv.WebRootPath.Replace("\\", "/") + conf.FileServerLocal;
                var exi = Directory.Exists(savepath);
                if (!exi)
                {
                    Directory.CreateDirectory(savepath);
                }
                var ret_urls = new string[files.Count()];
                foreach (var file in files)
                {
                    //原文件名
                    //var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    //filename = hostingEnv.WebRootPath + $@"\{filename}";

                    var savefilename = DateTime.Now.ToString("yyyyMMddHHmmssffff") + new Random().Next(1000, 9999);
                    var fname = file.FileName.Trim('"');
                    var extname = Path.GetExtension(fname).ToLower();
                    //var ft = file.ContentType;
                    //var size = file.Length;
                    var sname = $"{savefilename}{extname}";
                    using (FileStream fs = System.IO.File.Create(savepath + sname))
                    {
                        file.CopyTo(fs);
                        fs.Flush();
                    }
                    ret_urls.Append(sname);
                }
                return SRR.Ok<file_param>(new file_param(ret_urls));
            }
            catch (Exception ex)
            {
                return SRR.Fail<file_param>(ErrorCode.FILE_SAVE_FILED, "上传失败");
            }
        }

        [HttpPost]
        public IResultResponse<file_param> UploadAjax()
        {
            try
            {
                var files = Request.Form.Files;
                var keys = Request.Form.Keys;
                var user = Request.Form["user_id"];
                //非空限制
                if (files == null || files.Count() <= 0)
                {
                    return SRR.Fail<file_param>(ErrorCode.PARAM_NULL, "请选择上传的文件");
                }
                var conf = ConfigService.AppSettings<FileServerConfig>().Configs.Where(q => q.FType == "IMAGE").FirstOrDefault();
                //张数限制
                if (files.Count > conf.Count)
                {
                    return SRR.Fail<file_param>(ErrorCode.PARAM_INVALID, $"图片只能上传{conf.Count}");
                }
                //格式限制
                var allowTypes = GetAllowType(conf.AllowedExt);
                if (files.Any(b => !allowTypes.Contains(b.ContentType)))
                {
                    return SRR.Fail<file_param>(ErrorCode.PARAM_INVALID, $"只能上传{ conf.AllowedExt.ToString()}格式的文件");
                }
                long imagesize = conf.Size;
                //大小限制
                if (files.Sum(b => b.Length) >= imagesize * files.Count() * 1024)
                {
                    return SRR.Fail<file_param>(ErrorCode.PARAM_INVALID, $"每张图片不能超过{imagesize}kb");
                }
                var savepath = hostingEnv.WebRootPath.Replace("\\", "/") + conf.FileServerLocal;
                var exi = Directory.Exists(savepath);
                if (!exi)
                {
                    Directory.CreateDirectory(savepath);
                }
                var ret_urls = new string[files.Count()];

                for (int i = 0; i < files.Count; i++)
                {
                    //原文件名
                    //var filename = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    //filename = hostingEnv.WebRootPath + $@"\{filename}";

                    var savefilename = DateTime.Now.ToString("yyyyMMddHHmmssffff") + new Random().Next(1000, 9999);
                    var fname = files[i].FileName.Trim('"');
                    var extname = Path.GetExtension(fname).ToLower();
                    //var ft = file.ContentType;
                    //var size = file.Length;
                    var sname = $"{savefilename}{extname}";
                    using (FileStream fs = System.IO.File.Create(savepath + sname))
                    {
                        files[i].CopyTo(fs);
                        fs.Flush();
                    }
                    ret_urls[i] = sname;
                }
                return SRR.Ok<file_param>(new file_param(ret_urls));
            }
            catch (Exception ex)
            {
                return SRR.Fail<file_param>(ErrorCode.FILE_SAVE_FILED, "上传失败");
            }
        }
        public class file_param
        {
            public file_param() { }

            public file_param(string[] res_urls)
            {
                this.urls = res_urls;
            }
            public string[] urls { get; set; }

            public string user_id { get; set; }
            public IList<IFormFile> formfiles { get; set; }


            public List<string> img_base64 { get; set; }

        }

        public List<string> GetAllowType(string[] allow)
        {
            if (allow != null || allow.Count(i => i != null) != 0)
            {
                List<string> allowTypes = new List<string>();
                foreach (var extension in allow)
                {
                    if (!string.IsNullOrWhiteSpace(extension))
                    {
                        allowTypes.Add("image/" + extension);
                    }
                }
                return allowTypes;
            }
            return null;
        }
    }
}
