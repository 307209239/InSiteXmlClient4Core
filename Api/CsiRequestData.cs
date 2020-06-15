using System;
using System.Xml;
using InSiteXmlClient4Core.Enum;
using InSiteXmlClient4Core.InterFace;
using InSiteXmlClient4Core.Util;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiRequestData : CsiXmlElement, ICsiRequestData, ICsiXmlElement
    {
        public CsiRequestData(ICsiDocument doc, ICsiXmlElement parent) : base(doc, "__requestData", parent)
        {
        }

        public CsiRequestData(ICsiDocument doc, XmlElement domElement) : base(doc, domElement)
        {
        }

        public override bool IsRequestData() =>
            true;

        public virtual void RequestAllFields()
        {
            new CsiXmlElement(this.GetOwnerDocument(), "__allFields", this);
        }

        public virtual void RequestAllFieldsRecursive()
        {
            ICsiXmlElement element = new CsiXmlElement(this.GetOwnerDocument(), "__allFields", this);
            element.SetAttribute("__recursive", "true");
        }

        public virtual ICsiRequestField RequestField(string fieldName) =>
            base.RequestForField(fieldName);

        public virtual void RequestFields(Array fields)
        {
            foreach (string str in fields)
            {
                this.RequestField(str);
            }
        }

        public virtual void RequestSessionValues()
        {
            new CsiXmlElement(this.GetOwnerDocument(), "__sessionValues", this);
        }

        public virtual void SetSerializationMode(SerializationModes mode)
        {
            string data = "";
            switch (mode)
            {
                case SerializationModes.SerializationModeDeep:
                    data = "deep";
                    break;

                case SerializationModes.SerializationModeShallow:
                    data = "shallow";
                    break;

                case SerializationModes.SerializationModeDefault:
                    data = "default";
                    break;
            }
            if (!StringUtil.IsEmptyString(data))
            {
                base.SetAttribute("__serialization", data);
            }
        }
    }
}