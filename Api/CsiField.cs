using System;
using System.Xml;
using InSiteXmlClient4Core.Enum;
using InSiteXmlClient4Core.InterFace;
using InSiteXmlClient4Core.Util;

namespace InSiteXmlClient4Core.Api
{
    public class CsiField : CsiXmlElement, ICsiField, ICsiXmlElement
    {
        public CsiField(ICsiDocument doc, XmlElement domElement) : base(doc, domElement)
        {
        }

        public CsiField(ICsiDocument doc, string name, ICsiXmlElement parent) : base(doc, name, parent)
        {
        }

        public virtual ICsiLabel GetCaption()
        {
            ICsiMetaData data = base.FindChildByName("__metadata") as ICsiMetaData;
            if (data != null)
            {
                return data.GetFieldLabel();
            }
            return null;
        }

        public virtual ICsiCdoDefinition GetCdoDefinition()
        {
            ICsiMetaData data = base.FindChildByName("__metadata") as ICsiMetaData;
            if (data != null)
            {
                return data.GetCdoDefinition();
            }
            return null;
        }

        public virtual ICsiField GetDefaultValue() =>
            (base.FindChildByName("__defaultValue") as ICsiField);

        public virtual ICsiFieldDefinition GetFieldDefinition()
        {
            ICsiMetaData data = base.FindChildByName("__metadata") as ICsiMetaData;
            if (data != null)
            {
                return data.GetCdoField();
            }
            return null;
        }

        public virtual Array GetFields()
        {
            ICsiObject obj2 = (ICsiObject)this;
            return obj2.GetFields();
        }

        public virtual CsiGenericTypes GetGenericType()
        {
            string data = base.GetAttribute("__genericType");
            if (StringUtil.IsEmptyString(data) && (this.GetElementName().Equals("__listItem") && (this.GetParentElement() != null)))
            {
                data = this.GetParentElement().GetAttribute("__genericType");
            }
            if (!StringUtil.IsEmptyString(data))
            {
                if (data.Equals("Boolean"))
                {
                    return CsiGenericTypes.GenericTypeBoolean;
                }
                if (data.Equals("Decimal"))
                {
                    return CsiGenericTypes.GenericTypeDecimal;
                }
                if (data.Equals("Fixed"))
                {
                    return CsiGenericTypes.GenericTypeFixed;
                }
                if (data.Equals("Float"))
                {
                    return CsiGenericTypes.GenericTypeFloat;
                }
                if (data.Equals("Integer"))
                {
                    return CsiGenericTypes.GenericTypeInteger;
                }
                if (data.Equals("Object"))
                {
                    return CsiGenericTypes.GenericTypeObject;
                }
                if (data.Equals("String"))
                {
                    return CsiGenericTypes.GenericTypeString;
                }
                if (data.Equals("TimeStamp"))
                {
                    return CsiGenericTypes.GenericTypeTimestamp;
                }
            }
            return CsiGenericTypes.GenericTypeNone;
        }

        protected virtual ICsiMetaData GetMetaData() =>
            (base.FindChildByName("__metadata") as ICsiMetaData);

        public virtual CsiReferenceTypes GetReferenceType()
        {
            string data = base.GetAttribute("__referenceType");
            if (StringUtil.IsEmptyString(data) && (this.GetElementName().Equals("__listItem") && (this.GetParentElement() != null)))
            {
                data = this.GetParentElement().GetAttribute("__referenceType");
            }
            if (!StringUtil.IsEmptyString(data))
            {
                if (data.Equals("Container"))
                {
                    return CsiReferenceTypes.ReferenceTypeContainer;
                }
                if (data.Equals("NamedDataObject"))
                {
                    return CsiReferenceTypes.ReferenceTypeNamedDataObject;
                }
                if (data.Equals("RevisionedObject"))
                {
                    return CsiReferenceTypes.ReferenceTypeRevisionedObject;
                }
                if (data.Equals("Subentity"))
                {
                    return CsiReferenceTypes.ReferenceTypeSubEntity;
                }
                if (data.Equals("NamedSubentity"))
                {
                    return CsiReferenceTypes.ReferenceTypeNamedSubEntity;
                }
                if (data.Equals("Object"))
                {
                    return CsiReferenceTypes.ReferenceTypeObject;
                }
                if (data.Equals(""))
                {
                    return CsiReferenceTypes.ReferenceTypeNone;
                }
            }
            return CsiReferenceTypes.ReferenceTypeNone;
        }

        public virtual ICsiSelectionValues GetSelectionValues() =>
            (base.FindChildByName("__selectionValues") as ICsiSelectionValues);

        public virtual ICsiSelectionValuesEx GetSelectionValuesEx() =>
            (base.FindChildByName("__selectionValuesEx") as ICsiSelectionValuesEx);

        public virtual string GetSpecificType()
        {
            string data = base.GetAttribute("__specificType");
            if (StringUtil.IsEmptyString(data) && (this.GetElementName().Equals("__listItem") && (this.GetParentElement() != null)))
            {
                data = this.GetParentElement().GetAttribute("__specificType");
            }
            return data;
        }

        public override bool IsField() =>
            true;
    }
}