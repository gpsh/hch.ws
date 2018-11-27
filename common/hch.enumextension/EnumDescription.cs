using hch.definition;
using System;
using System.Collections.Generic;
using Wx;

namespace hch.enumextension
{
    public static class EnumDescription
    {
        public static KeyValuePair<Gender, string> GetGenderDescription(this Gender vstate)
        {
            if (vstate == Gender.NONE)
                return new KeyValuePair<Gender, string>(Gender.NONE, "无");
            if ((vstate & Gender.MALE) > 0)
                return new KeyValuePair<Gender, string>(Gender.MALE, "男");
            if ((vstate & Gender.FEMALE) > 0)
                return new KeyValuePair<Gender, string>(Gender.FEMALE, "女");
            return new KeyValuePair<Gender, string>();
        }

        /// <summary>
        /// 获取操作员类型的值的所有描述
        /// </summary>
        /// <param name="otype"></param>
        /// <returns></returns>
        public static List<KeyValuePair<Identity, string>> GetIdentityDescription(this Identity otype)
        {
            var desclist = new List<KeyValuePair<Identity, string>>();

            if (otype == Identity.Visitor)
                desclist.Add(new KeyValuePair<Identity, string>(Identity.Visitor, Identity.Visitor.GetDisplayDescription()));
            if ((otype & Identity.Staff) > 0)
                desclist.Add(new KeyValuePair<Identity, string>(Identity.Staff, Identity.Staff.GetDisplayDescription()));
            if ((otype & Identity.admin) > 0)
                desclist.Add(new KeyValuePair<Identity, string>(Identity.admin, Identity.admin.GetDisplayDescription()));
           
            //attribute自带的获取name和description
            //var str = identity_type.admin.GetAttribute<identity_type, DisplayAttribute>();
            //var sname = str.GetName();
            //var description = str.GetDescription();
            return desclist;
        }
    }
}
