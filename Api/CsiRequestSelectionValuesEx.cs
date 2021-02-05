using InSiteXmlClient4Core.InterFace;
using System;
using System.Xml;
using InSiteXmlClient4Core.Util;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiRequestSelectionValuesEx : CsiXmlElement, ICsiRequestSelectionValuesEx, ICsiXmlElement
    {
        public CsiRequestSelectionValuesEx(ICsiDocument doc, ICsiXmlElement parent)
          : base(doc, "__requestSelectionValuesEx", parent)
        {
        }

        public CsiRequestSelectionValuesEx(ICsiDocument doc, XmlElement element)
          : base(doc, element)
        {
        }

        public virtual long GetResultsetSize()
        {
            if (this.FindChildByName("__rowSetSize") is ICsiDataField childByName)
                return long.Parse(childByName.GetValue());
            return -1;
        }

        public virtual void SetResultsetSize(long size)
        {
            try
            {
                ICsiXmlElement childByName = this.FindChildByName("__rowSetSize");
                if (null != childByName)
                    this.RemoveChild(childByName);
                CsiDataField csiDataFieldImpl = new CsiDataField(this.GetOwnerDocument(), "__rowSetSize", (ICsiXmlElement)this, XmlConvert.ToString(size));
            }
            catch (Exception ex)
            {
                LogHelper.Error<CsiRequestSelectionValuesEx>(ex.Message);
            }
        }

        public virtual long GetStartRow()
        {
            if (this.FindChildByName("__startRow") is ICsiDataField childByName)
                return long.Parse(childByName.GetValue());
            return -1;
        }

        public virtual void SetStartRow(long val)
        {
            try
            {
                ICsiXmlElement childByName = this.FindChildByName("__startRow");
                if (null != childByName)
                    this.RemoveChild(childByName);
                ICsiDataField csiDataFieldImpl = new CsiDataField(this.GetOwnerDocument(), "__startRow", (ICsiXmlElement)this, Convert.ToString(val));
            }
            catch (Exception ex)
            {
                LogHelper.Error<CsiRequestSelectionValuesEx>(ex.Message);
            }
        }

        public virtual ICsiQueryParameters CreateQueryParameters()
        {
            return this.FindChildByName("__queryParameters") as ICsiQueryParameters ?? (ICsiQueryParameters)new CsiQueryParameters(this.GetOwnerDocument(), (ICsiXmlElement)this);
        }

        public virtual bool GetRequestRecordCount()
        {
            ICsiDataField childByName = this.FindChildByName("__requestRecordCount") as ICsiDataField;
            try
            {
                return bool.Parse(childByName.GetValue());
            }
            catch (Exception ex)
            {
                LogHelper.Error<CsiRequestSelectionValuesEx>(ex.Message);
                return false;
            }
        }

        public virtual void SetRequestRecordCount(bool val)
        {
            try
            {
                this.removeChildByName((ICsiXmlElement)this, "__requestRecordCount");
                if (!val)
                    return;
                ICsiDataField csiDataFieldImpl = new CsiDataField(this.GetOwnerDocument(), "__requestRecordCount", (ICsiXmlElement)this, "true");
            }
            catch (Exception ex)
            {
                LogHelper.Error<CsiRequestSelectionValuesEx>(ex.Message);
            }
        }

        public void ClearParameters()
        {
            ICsiXmlElement childByName = this.FindChildByName("__queryParameters");
            childByName?.RemoveAllChildren();
        }

        public virtual void SetParameter(string param, string val)
        {
            this.CreateQueryParameters().SetParameter(param, val);
        }
    }
}