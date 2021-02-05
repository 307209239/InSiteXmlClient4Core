using System;
using System.Xml;
using InSiteXmlClient4Core.Enum;
using InSiteXmlClient4Core.Exceptions;
using InSiteXmlClient4Core.InterFace;
using InSiteXmlClient4Core.Util;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiDataField :CsiField, ICsiDataField, ICsiField, ICsiXmlElement
    {
        private XmlNode mData;
        private const string mkUID = "{8700F239-6C00-43e9-BA57-F2393B34D1DA}";

        public CsiDataField(ICsiDocument doc, XmlElement domElement) : base(doc, domElement)
        {
            try
            {
                this.mData = base.GetDomElement().FirstChild;
                if (this.mData == null)
                {
                    this.mData = base.GetDomElement();
                }
            }
            catch (Exception)
            {
                this.mData = null;
            }
        }

        public CsiDataField(ICsiDocument doc, string name, ICsiXmlElement parent) : base(doc, name, parent)
        {
            this.mData = base.GetDomElement().OwnerDocument.CreateCDataSection("");
            base.GetDomElement().AppendChild(this.mData);
        }

        public CsiDataField(ICsiDocument doc, string name, ICsiXmlElement parent, string val) : this(doc, name, parent)
        {
            this.SetValue(val);
        }

        private CsiDataField(ICsiDocument doc, string name, ICsiXmlElement parent, string val, bool ignoreContraint) : base(doc, name, parent)
        {
            this.mData = base.GetDomElement().OwnerDocument.CreateCDataSection(val);
            base.GetDomElement().AppendChild(this.mData);
        }

        public string GetFormattedValue(DataFormats format)
        {
            string str3;
            string val = this.GetValue();
            if ((val == null) || (val.Length == 0))
            {
                return val;
            }
            try
            {
                switch (format)
                {
                    case DataFormats.FormatDateAndTime:
                        return CsiXmlDataFormat.Lexical2LocaleDateTime(val);

                    case DataFormats.FormatDate:
                        return CsiXmlDataFormat.Lexical2LocaleDate(val);

                    case DataFormats.FormatTime:
                        return CsiXmlDataFormat.Lexical2LocaleTime(val);

                    case DataFormats.FormatDecimal:
                        return CsiXmlDataFormat.Lexical2LocaleDecimal(val);

                    case DataFormats.FormatFloat:
                        return CsiXmlDataFormat.Lexical2LocaleFloat(val);
                }
                str3 = base.GetType().FullName + ".getFormattedValue()";
                throw new CsiClientException(-1L, "格式化错误", str3);
            }
            catch (Exception exception)
            {
                str3 = base.GetType().FullName + ".getFormattedValue()";
                string desc = "不能转换 '" + val + "' 为 '" + format.GetType().Name + "'. " + exception.Message;
                throw new CsiClientException(-1L, desc, str3);
            }
        }

        public virtual string GetValue()
        {
            if (StringUtil.IsEmptyString(this.mData.Value))
            {
                return string.Empty;
            }
            string strMessage = this.mData.Value;
            if (base.GetAttribute("__encrypted") == "yes")
            {
                strMessage = new RC2StringProvider().Decrypt("{8700F239-6C00-43e9-BA57-F2393B34D1DA}", strMessage);
            }
            return strMessage;
        }

        public override bool IsDataField() =>
            true;

        public virtual bool IsEmptyValue() =>
            "yes".Equals(base.GetAttribute("__empty"));

        public void SetEmptyValue()
        {
            base.SetAttribute("__empty", "yes");
        }

        public void SetEncryptedValue(string val)
        {
            base.SetAttribute("__encrypted", "no");
            this.SetValue(val);
            //RC2StringProvider provider = new RC2StringProvider();
            //this.SetValue(provider.Encrypt("{8700F239-6C00-43e9-BA57-F2393B34D1DA}", val));
        }

        public void SetFormattedValue(string val, DataFormats format)
        {
            string str = null;
            string str2;
            try
            {
                switch (format)
                {
                    case DataFormats.FormatDateAndTime:
                        str = CsiXmlDataFormat.Locale2LexicalDateTime(val);
                        goto Label_00DE;

                    case DataFormats.FormatDate:
                        str = CsiXmlDataFormat.Locale2LexicalDate(val);
                        goto Label_00DE;

                    case DataFormats.FormatTime:
                        str = CsiXmlDataFormat.Locale2LexicalTime(val);
                        goto Label_00DE;

                    case DataFormats.FormatDecimal:
                        str = CsiXmlDataFormat.Locale2LexicalDecimal(val);
                        goto Label_00DE;

                    case DataFormats.FormatFloat:
                        str = CsiXmlDataFormat.Locale2LexicalFloat(val);
                        goto Label_00DE;
                }
                str2 = base.GetType().FullName + ".setFormattedValue()";
                throw new CsiClientException(-1L, "格式化错误", str2);
            }
            catch (Exception exception)
            {
                str2 = base.GetType().FullName + "#setFormattedValue()";
                string desc = string.Concat(new object[] { "不能转换'", val, "' 为 '", format, "'. ", exception.Message });
                throw new CsiClientException(-1L, desc, str2);
            }
            Label_00DE:
            if (str != null)
            {
                this.SetValue(str);
            }
        }

        public virtual void SetValue(string val)
        {
            this.mData.Value = val;
        }
    }
}