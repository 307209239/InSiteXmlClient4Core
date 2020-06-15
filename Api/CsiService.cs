using System;
using System.Xml;
using InSiteXmlClient4Core.Exceptions;
using InSiteXmlClient4Core.InterFace;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiService : CsiObject, ICsiService, ICsiObject, ICsiField, ICsiXmlElement
    {
        public CsiService(ICsiDocument doc, string serviceName, ICsiXmlElement parent)
          : base(doc, "__service", parent)
        {
            this.SetAttribute("__serviceType", serviceName);
            CsiXmlHelper.FindCreateSetValue((ICsiXmlElement)this, "__txnGUID", CsiXmlHelper.GenerateGuid());
            CsiXmlHelper.FindCreateSetValue((ICsiXmlElement)this, "__utcOffset", CsiXmlDataFormat.GetUTCOffset());
        }

        public CsiService(ICsiDocument doc, XmlElement domElement)
          : base(doc, domElement)
        {
        }

        public override bool IsService()
        {
            return true;
        }

        public string ServiceTypeName()
        {
            return this.GetDomElement().GetAttribute("__serviceType");
        }

        public ICsiObject InputData()
        {
            return (ICsiObject)new CsiObject(this.GetOwnerDocument(), (ICsiXmlElement)this);
        }

        public ICsiRequestData RequestData()
        {
            return (ICsiRequestData)(this.FindChildByName("__requestData") as CsiRequestData ?? new CsiRequestData(this.GetOwnerDocument(), (ICsiXmlElement)this));
        }

        public ICsiResponseData ResponseData()
        {
            return this.FindChildByName("__responseData") as ICsiResponseData;
        }

        public ICsiExceptionData ExceptionData()
        {
            return this.GetChildExceptionData();
        }

        public void SetExecute()
        {
            if (this.FindChildByName("__execute") != null)
                return;
            CsiXmlElement csiXmlElementImpl = new CsiXmlElement(this.GetOwnerDocument(), "__execute", (ICsiXmlElement)this);
        }

        public virtual bool UseTxnGuid
        {
            set
            {
                if (value)
                    CsiXmlHelper.FindCreateSetValue((ICsiXmlElement)this, "__txnGUID", CsiXmlHelper.GenerateGuid());
                else
                    this.removeChildByName((ICsiXmlElement)this, "__txnGUID");
            }
        }

        public virtual string GetUtcOffset()
        {
            if (this.FindChildByName("__utcOffset") is CsiXmlElement childByName)
                return (childByName.GetDomElement().FirstChild as XmlText).Data;
            return (string)null;
        }

        public virtual void SetUtcOffset(string offset)
        {
            try
            {
                bool flag = offset.StartsWith("-");
                if (offset.StartsWith("-") || offset.StartsWith("+"))
                    offset = offset.Remove(0, 1);
                DateTime dateTime = DateTime.Parse(offset);
                if (dateTime.Hour > 12)
                    throw new FormatException();
                string str = dateTime.ToString("HH:mm");
                CsiXmlHelper.FindCreateSetValue((ICsiXmlElement)this, "__utcOffset", (flag ? "-" : "+") + str);
            }
            catch (Exception ex)
            {
                throw new CsiClientException(-2147467259L, ex, this.GetType().FullName + ".setUTCOffset()");
            }
        }
    }
}