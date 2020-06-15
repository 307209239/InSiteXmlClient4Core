using System;
using System.Collections;
using System.Xml;
using InSiteXmlClient4Core.Enum;
using InSiteXmlClient4Core.Exceptions;
using InSiteXmlClient4Core.InterFace;
using InSiteXmlClient4Core.Util;

namespace InSiteXmlClient4Core.Api
{
    public class CsiRequestField : CsiField, ICsiRequestField, ICsiField, ICsiXmlElement
    {
        public CsiRequestField(ICsiDocument doc, XmlElement requestField) : base(doc, requestField)
        {
        }

        public CsiRequestField(ICsiDocument doc, string name, ICsiXmlElement parent) : base(doc, name, parent)
        {
        }

        private ICsiXmlElement GetAllFieldElement()
        {
            ICsiXmlElement element = base.FindChildByName("__allFields");
            if (element == null)
            {
                element = new CsiXmlElement(this.GetOwnerDocument(), "__allFields", this);
            }
            return element;
        }

        public void RequestAllFields()
        {
            this.GetAllFieldElement();
        }

        public void RequestAllFieldsRecursive()
        {
            this.GetAllFieldElement().SetAttribute("__recursive", "true");
        }

        public void RequestCaption()
        {
            ICsiMetaData data = base.FindChildByName("__metadata") as ICsiMetaData;
            if (data == null)
            {
                data = new CsiMetaData(this.GetOwnerDocument(), this);
            }
            data.RequestFieldLabel();
        }

        public void RequestCdoDefinition()
        {
            ICsiMetaData data = base.FindChildByName("__metadata") as ICsiMetaData;
            if (data == null)
            {
                data = new CsiMetaData(this.GetOwnerDocument(), this);
            }
            data.RequestCdoDefinition();
        }

        public void RequestDefaultValue()
        {
            CsiXmlHelper.FindCreateSetValue(this, "__defaultValue", null);
        }

        public ICsiRequestField RequestField(string fieldName)
        {
            ICsiRequestField impl = base.FindChildByName(fieldName) as CsiRequestField;
            if (impl == null)
            {
                impl = new CsiRequestField(this.GetOwnerDocument(), fieldName, this);
            }
            return impl;
        }

        public void RequestFieldDefinition()
        {
            CsiMetaData sourceElement = base.FindChildByName("__metadata") as CsiMetaData;
            if (sourceElement == null)
            {
                sourceElement = new CsiMetaData(this.GetOwnerDocument(), this);
            }
            CsiXmlHelper.FindCreateSetValue(sourceElement, "__fieldDef", null);
        }

        public ICsiRequestField RequestListItemByIndex(int index, string fieldName, string cdoTypeName)
        {
            if (index < 0)
            {
                string src = base.GetType().FullName + ".requestListItemByIndex()";
                throw new CsiClientException(0x2e001aL, src);
            }
            CsiXmlElement parent = null;
            IEnumerator enumerator = base.GetChildrenByName("__listItem").GetEnumerator();
            while (enumerator.MoveNext())
            {
                parent = enumerator.Current as CsiXmlElement;
                if (int.Parse(parent.GetAttribute("__index")) == index)
                {
                    break;
                }
                parent = null;
            }
            if (parent == null)
            {
                parent = new CsiXmlElement(this.GetOwnerDocument(), "__listItem", this);
                parent.SetAttribute("__index", Convert.ToString(index));
            }
            CsiXmlElement child = parent;
            if (!StringUtil.IsEmptyString(fieldName) && (fieldName != null))
            {
                child = base.FindChildByName(fieldName) as CsiXmlElement;
                if (child != null)
                {
                    base.RemoveChild(child);
                }
                child = new CsiRequestField(this.GetOwnerDocument(), fieldName, parent);
                parent.AppendChild(child);
            }
            return (child as ICsiRequestField);
        }

        public ICsiRequestField RequestListItemByName(string name, string fieldName, string cdoTypeName)
        {
            if (name == null)
            {
                string src = base.GetType().FullName + ".requestListItemByName()";
                throw new CsiClientException(0x2e001aL, src);
            }
            CsiXmlElement parent = null;
            IEnumerator enumerator = base.GetChildrenByName("__listItem").GetEnumerator();
            while (enumerator.MoveNext())
            {
                parent = enumerator.Current as CsiXmlElement;
                if (name.Equals(parent.GetAttribute("__name")))
                {
                    break;
                }
                parent = null;
            }
            if (parent == null)
            {
                parent = new CsiXmlElement(this.GetOwnerDocument(), "__listItem", this);
                parent.SetAttribute("__name", name);
            }
            CsiXmlElement child = parent;
            if (!StringUtil.IsEmptyString(fieldName))
            {
                child = base.FindChildByName(fieldName) as CsiXmlElement;
                if (child != null)
                {
                    base.RemoveChild(child);
                }
                child = new CsiRequestField(this.GetOwnerDocument(), fieldName, parent);
                parent.AppendChild(child);
            }
            return (child as CsiRequestField);
        }

        public void RequestSelectionValues()
        {
            if (this.GetSelectionValues() == null)
            {
                new CsiSelectionValues(this.GetOwnerDocument(), this);
            }
        }

        public ICsiRequestSelectionValuesEx RequestSelectionValuesEx()
        {
            ICsiRequestSelectionValuesEx impl = base.FindChildByName("__requestSelectionValuesEx") as ICsiRequestSelectionValuesEx;
            if (impl == null)
            {
                impl = new CsiRequestSelectionValuesEx(this.GetOwnerDocument(), this);
            }
            return impl;
        }

        public void RequestUserDefinedFieldDefinitions()
        {
            ICsiMetaData data = base.FindChildByName("__metadata") as ICsiMetaData;
            if (data == null)
            {
                data = new CsiMetaData(this.GetOwnerDocument(), this);
            }
            data.RequestUserDefinedFields();
        }

        public void RequestUserDefinedFields()
        {
            CsiXmlHelper.FindCreateSetValue(this, "__userDefinedFields", null);
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