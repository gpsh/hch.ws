using hch.account.api.models;
using hch.account.apis;
using hch.account.dba;
using hch.account.dbs;
using hch.definition;
using hch.enumextension;
using hch.model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Wx;

namespace hch.account.service
{
    public class WriteAccountService : WxWebApiService, IWriteAccount
    {
        public IWsModel<ReqAddAccount, ResAccount> AddAccount([FromBody]WsModel<ReqAddAccount, ResAccount> model)
        {
            if (model == null)
            {
                return new WsModel<ReqAddAccount, ResAccount>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (!model.Request.Valid4AddAccount())
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            var dbs = new DbsAccount();
            if (dbs.GetAccount(model.Request.OpenId) != null)
            {
                return model.Fail(ErrorCode.DB_EXISTED, "数据已存在");
            }
            //验证公司是否存在
            if (dbs.GetCorporationInfo(model.Request.Corporation, ValidityState.Enabled) == null)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "公司不存在");
            }
            var account = new Account(model.Request.Wechat, model.Request.WechatName, model.Request.OpenId, model.Request.Corporation, model.Request.Sex, model.Request.Email, model.Request.Phone, model.Request.Name, ValidityState.Disabled, Identity.Staff, model.Request.Logo, DateTime.Now);
            var result = new DbaAccount().AddAccount(account);
            if (result == 0)
            {
                return model.Fail(ErrorCode.DB_SAVE_FAILED, "添加失败");
            }
            var ret = new ResAccount(account);
            return model.Ok(ret);
        }

        public IWsModel<ReqAddCorporation, ResCorporation> AddCorporation([FromBody]WsModel<ReqAddCorporation, ResCorporation> model)
        {
            if (model == null)
            {
                return new WsModel<ReqAddCorporation, ResCorporation>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (!model.Request.Valid4AddCorporation())
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (new DbsAccount().GetCorporationInfoByName(model.Request.Name) != null)
            {
                return model.Fail(ErrorCode.DB_EXISTED, "数据已存在");
            }
            var corporation = new Corporation(model.Request.Name, model.Request.Address, model.Request.Presentation, model.Request.FixPhone, model.Request.Image, ValidityState.Disabled, DateTime.Now);
            var result = new DbaAccount().AddCorporation(corporation);
            if (result == 0)
            {
                return model.Fail(ErrorCode.DB_SAVE_FAILED, "添加失败");
            }
            var ret = new ResCorporation(corporation);
            return model.Ok(ret);
        }

        public IWsModel<ReqAddAccount, ResAccount> UpdateAccount([FromBody]WsModel<ReqAddAccount, ResAccount> model)
        {
            if (model == null)
            {
                return new WsModel<ReqAddAccount, ResAccount>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (string.IsNullOrWhiteSpace(model.Request.OpenId))
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            var retAccount = new DbsAccount().GetAccount(model.Request.OpenId);
            if (retAccount == null)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "数据不存在");
            }
            if (AlterModel(ref retAccount, model.Request))
            {

                var result = new DbaAccount().UpdateAccount(retAccount);
                if (result == 0)
                {
                    return model.Fail(ErrorCode.DB_SAVE_FAILED, "修改失败");
                }
            }
            var ret = new ResAccount(retAccount);
            return model.Ok(ret);
        }

        public IWsModel<ReqAddCorporation, ResCorporation> UpdateCorporation([FromBody]WsModel<ReqAddCorporation, ResCorporation> model)
        {
            if (model == null)
            {
                return new WsModel<ReqAddCorporation, ResCorporation>().Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (model.Request == null)
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            if (string.IsNullOrWhiteSpace(model.Request.CorporationId))
            {
                return model.Fail(ErrorCode.PARAM_NULL, "参数为空");
            }
            var retCorporation = new DbsAccount().GetCorporationInfo(model.Request.CorporationId);
            if (retCorporation == null)
            {
                return model.Fail(ErrorCode.DB_NOTEXISTED, "数据不存在");
            }
            if (AlterModel(ref retCorporation, model.Request))
            {

                var result = new DbaAccount().UpdateCorporation(retCorporation);
                if (result == 0)
                {
                    return model.Fail(ErrorCode.DB_SAVE_FAILED, "修改失败");
                }
            }

            var ret = new ResCorporation(retCorporation);
            return model.Ok(ret);
        }

        private bool AlterModel(ref Account entity, ReqAddAccount am)
        {
            int sign = 0;
            if (!string.IsNullOrWhiteSpace(am.Corporation))
            {
                entity.Corporation = am.Corporation;
                sign = 1;
            }
            if (!string.IsNullOrWhiteSpace(am.Email))
            {
                entity.Email = am.Email;
                sign = 1;
            }
            if (!string.IsNullOrWhiteSpace(am.Logo))
            {
                entity.Logo = am.Logo;
                sign = 1;
            }
            if (!string.IsNullOrWhiteSpace(am.Name))
            {
                entity.Name = am.Name;
                sign = 1;
            }
            if (!string.IsNullOrWhiteSpace(am.Phone))
            {
                entity.Phone = am.Phone;
                sign = 1;
            }
            if (!string.IsNullOrWhiteSpace(am.Wechat))
            {
                entity.Wechat = am.Wechat;
                sign = 1;
            }
            if (!string.IsNullOrWhiteSpace(am.WechatName))
            {
                entity.WechatName = am.WechatName;
                sign = 1;
            }
            if (Enum.IsDefined(typeof(Gender), am.Sex) && am.Sex != Gender.NONE)
            {
                entity.Sex = am.Sex;
                sign = 1;
            }
            if (Enum.IsDefined(typeof(ValidityState), am.State) && am.State != ValidityState.None)
            {
                entity.State = am.State;
                sign = 1;
            }
            if (sign == 1)
            {
                entity.UpdateTime = DateTime.Now;
            }
            return sign == 1 ? true : false;
        }
        private bool AlterModel(ref Corporation entity, ReqAddCorporation am)
        {
            int sign = 0;
            if (!string.IsNullOrWhiteSpace(am.Address))
            {
                entity.Address = am.Address;
                sign = 1;
            }
            if (!string.IsNullOrWhiteSpace(am.FixPhone))
            {
                entity.FixPhone = am.FixPhone;
                sign = 1;
            }
            if (!string.IsNullOrWhiteSpace(am.Image))
            {
                entity.Image = am.Image;
                sign = 1;
            }
            if (!string.IsNullOrWhiteSpace(am.Name))
            {
                entity.Name = am.Name;
                sign = 1;
            }
            if (!string.IsNullOrWhiteSpace(am.Presentation))
            {
                entity.Presentation = am.Presentation;
                sign = 1;
            }

            if (Enum.IsDefined(typeof(ValidityState), am.State) && am.State != ValidityState.None)
            {
                entity.State = am.State;
                sign = 1;
            }
            if (sign == 1)
            {
                entity.UpdateTime = DateTime.Now;
            }
            return sign == 1 ? true : false;
        }
    }
}
