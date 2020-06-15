using System;
using System.Collections;
using System.Xml;
using InSiteXmlClient4Core.InterFace;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiMetaData : CsiXmlElement, ICsiMetaData, ICsiCdoType, ICsiCdoDefinition, ICsiFieldDefinition, ICsiFieldDefinitions, ICsiLabel, ICsiXmlElement
    {
        public CsiMetaData(ICsiDocument doc, ICsiXmlElement parent) : base(doc, "__metadata", parent)
        {
        }

        public CsiMetaData(ICsiDocument doc, XmlElement element) : base(doc, element)
        {
        }

        public virtual Array GetAllFieldDefinitions() =>
            base.GetChildrenByName("__field");

        public virtual ICsiCdoDefinition GetCdoDefinition() =>
            (base.FindChildByName("__CDODefinition") as ICsiCdoDefinition);

        public virtual ICsiFieldDefinition GetCdoField()
        {
            string tagName = "__fieldDef" + '.' + "__field";
            return (base.FindChildByName(tagName) as ICsiFieldDefinition);
        }

        public virtual ICsiLabel GetCdoLabel()
        {
            string tagName = "__CDODefinition" + '.' + "__label";
            return (base.FindChildByName(tagName) as ICsiLabel);
        }

        public ICsiCdoType GetCdoType()
        {
            if (!(base.FindChildByName("__CDOSubTypes") is ICsiCdoType type))
            {
                type = base.FindChildByName("__CDOType") as ICsiCdoType;
            }
            if (type == null)
            {
                type = base.FindChildByName("__field" + '.' + "__CDOType") as ICsiCdoType;
            }
            return type;
        }

        public virtual int GetCdoTypeId()
        {
            if ("__CDODefinition".Equals(this.GetElementName()))
            {
                return int.Parse((base.FindChildByName("__CDOTypeId") as CsiXmlElement).GetElementName().Trim());
            }
            return int.Parse((base.FindChildByName("__Id") as CsiXmlElement).GetElementName().Trim());
        }

        public virtual string GetCdoTypeName()
        {
            ICsiXmlElement element;
            if ("__CDODefinition".Equals(this.GetElementName()))
            {
                element = base.FindChildByName("__CDOTypeName");
                if (element != null)
                {
                    return (element as CsiXmlElement).GetElementName();
                }
            }
            else
            {
                element = base.FindChildByName("__name");
                if (element != null)
                {
                    return (element as CsiXmlElement).GetElementName();
                }
            }
            return null;
        }

        public virtual string GetDataType()
        {
            string tagName = "__dataType";
            if (base.FindChildByName(tagName) is CsiXmlElement impl)
            {
                return impl.GetElementName();
            }
            return string.Empty;
        }

        public virtual string GetDefaultValue()
        {
            try
            {
                return ((CsiXmlElement)base.FindChildByName("__defaultValue")).GetElementName();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual ICsiCdoType GetFieldCdoType()
        {
            string tagName = "__CDOType";
            return (base.FindChildByName(tagName) as ICsiCdoType);
        }

        public virtual ICsiFieldDefinition GetFieldDefinitionById(int id)
        {
            Array array = this.GetAllFieldDefinitions();
            for (int i = 0; i < array.Length; i++)
            {
                if ((array.GetValue(i) is ICsiFieldDefinition definition) && (id == definition.GetFieldId()))
                {
                    return definition;
                }
            }
            return null;
        }

        public virtual ICsiFieldDefinition GetFieldDefinitionByName(string name)
        {
            Array array = this.GetAllFieldDefinitions();
            for (int i = 0; i < array.Length; i++)
            {
                if ((array.GetValue(i) is ICsiFieldDefinition definition) && name.Equals(definition.GetFieldName()))
                {
                    return definition;
                }
            }
            return null;
        }

        public virtual ICsiFieldDefinitions GetFieldDefinitions()
        {
            try
            {
                return (base.FindChildByName("__fieldDefs") as ICsiFieldDefinitions);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual int GetFieldId()
        {
            try
            {
                string tagName = "__Id";
                if (base.FindChildByName(tagName) is CsiXmlElement impl)
                {
                    return int.Parse(impl.GetElementName());
                }
            }
            catch (Exception)
            {
            }
            return -1;
        }

        public virtual ICsiLabel GetFieldLabel()
        {
            string tagName = "__label";
            return (base.FindChildByName(tagName) as ICsiLabel);
        }

        public virtual string GetFieldName()
        {
            string tagName = "__name";
            if (base.FindChildByName(tagName) is CsiXmlElement impl)
            {
                return impl.GetElementName();
            }
            return string.Empty;
        }

        public virtual ICsiLabel GetLabel()
        {
            ICsiXmlElement element = base.FindChildByName("__label");
            if (element == null)
            {
                string tagName = "__field" + '.' + "__label";
                element = base.FindChildByName(tagName);
            }
            return (element as ICsiLabel);
        }

        public virtual int GetLabelId()
        {
            try
            {
                return int.Parse(((CsiXmlElement)base.FindChildByName("__Id")).GetElementName().Trim());
            }
            catch (Exception)
            {
                return -1;
            }
        }

        public virtual string GetLabelName()
        {
            try
            {
                return ((CsiXmlElement)base.FindChildByName("__name")).GetElementName();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual ICsiQueryParameters GetQueryParameters() =>
            (base.FindChildByName("__queryParameters") as ICsiQueryParameters);

        public virtual Array GetUserDefinedFields()
        {
            string tagName = string.Concat(new object[] { "__CDODefinition", '.', "__fieldDefs", '.', "__userDefinedFields" });
            CsiMetaData impl = base.FindChildByName(tagName) as CsiMetaData;
            ArrayList list = new ArrayList();
            if (impl != null)
            {
                IEnumerator enumerator = impl.GetChildrenByName("__userDefinedField").GetEnumerator();
                while (enumerator.MoveNext())
                {
                    list.Add(enumerator.Current);
                }
            }
            return list.ToArray();
        }

        public virtual string GetValue()
        {
            try
            {
                return ((CsiXmlElement)base.FindChildByName("__value")).GetElementName();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual bool HasSelectionValues()
        {
            try
            {
                string tagName = "__hasSelectionValues";
                return "true".Equals(((CsiXmlElement)base.FindChildByName(tagName)).GetElementName());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual bool IsHidden()
        {
            try
            {
                string tagName = "__isHidden";
                return "true".Equals(((CsiXmlElement)base.FindChildByName(tagName)).GetElementName());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual bool IsListField()
        {
            try
            {
                string tagName = "__isList";
                return "true".Equals(((CsiXmlElement)base.FindChildByName(tagName)).GetElementName());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual bool IsObjectField()
        {
            try
            {
                string tagName = "__isObject";
                return "true".Equals(((CsiXmlElement)base.FindChildByName(tagName)).GetElementName());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual bool IsReadOnly()
        {
            try
            {
                string tagName = "__isReadOnly";
                return "true".Equals(((CsiXmlElement)base.FindChildByName(tagName)).GetElementName());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual bool IsRequired()
        {
            try
            {
                string tagName = "__isRequired";
                return "true".Equals(((CsiXmlElement)base.FindChildByName(tagName)).GetElementName());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual bool IsTypeUnique()
        {
            try
            {
                string tagName = "__isTypeUnique";
                return "true".Equals(((CsiXmlElement)base.FindChildByName(tagName)).GetElementName());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual bool IsUserDefinedField()
        {
            try
            {
                string tagName = "__isUserDefinedField";
                return "true".Equals(((CsiXmlElement)base.FindChildByName(tagName)).GetElementName());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual bool IsValueRequired()
        {
            try
            {
                string tagName = "__isValueRequired";
                return "true".Equals(((CsiXmlElement)base.FindChildByName(tagName)).GetElementName());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual bool OwnsObject()
        {
            try
            {
                string tagName = "__ownsSubentity";
                return "true".Equals(((CsiXmlElement)base.FindChildByName(tagName)).GetElementName());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual void RequestCdoDefinition()
        {
            base.ClearXmlElementChildByName("__CDODefinition");
        }

        public virtual void RequestCdoDefinitionById(int id)
        {
            CsiXmlHelper.FindCreateSetValue(base.ClearXmlElementChildByName("__CDODefinition"), "__CDOTypeId", Convert.ToString(id));
        }

        public virtual void RequestCdoDefinitionByName(string typeName)
        {
            CsiXmlHelper.FindCreateSetValue(base.ClearXmlElementChildByName("__CDODefinition"), "__CDOTypeName", typeName);
        }

        public virtual void RequestCdoDefinitionFieldByName(string typeName, string fieldName)
        {
            ICsiXmlElement sourceElement = base.ClearXmlElementChildByName("__CDODefinition");
            CsiXmlHelper.FindCreateSetValue(sourceElement, "__CDOTypeName", typeName);
            new CsiXmlElement(this.GetOwnerDocument(), "__field", sourceElement).SetAttribute("__name", fieldName);
        }

        public virtual void RequestCdoLabel()
        {
            ICsiXmlElement parentElement = base.ClearXmlElementChildByName("__CDODefinition");
            new CsiXmlElement(this.GetOwnerDocument(), "__label", parentElement);
        }

        private void requestCDOSubTypes(string childTag, string nameOrId, bool recurse)
        {
            ICsiXmlElement parentElement = base.ClearXmlElementChildByName("__CDOSubType");
            if (recurse)
            {
                new CsiXmlElement(this.GetOwnerDocument(), "__recurse", parentElement);
            }
            if ((nameOrId != null) && (childTag != null))
            {
                CsiXmlHelper.FindCreateSetValue(parentElement, childTag, nameOrId);
            }
        }

        public virtual void RequestCdoSubTypesById(int id, bool recurse)
        {
            this.requestCDOSubTypes("__CDOTypeId", Convert.ToString(id), recurse);
        }

        public virtual void RequestCdoSubTypesByName(string baseName, bool recursive)
        {
            this.requestCDOSubTypes("__CDOTypeName", baseName, recursive);
        }

        public virtual void RequestFieldItem(string itemName)
        {
            new CsiXmlElement(this.GetOwnerDocument(), "__field", this).SetAttribute("__name", itemName);
        }

        public virtual void RequestFieldLabel()
        {
            base.ClearXmlElementChildByName("__label");
        }

        public virtual void RequestLabelById(int labelId)
        {
            CsiXmlHelper.FindCreateSetValue(base.ClearXmlElementChildByName("__label"), "__Id", Convert.ToString(labelId));
        }

        public virtual void RequestLabelByName(string name)
        {
            CsiXmlHelper.FindCreateSetValue(base.ClearXmlElementChildByName("__label"), "__name", name);
        }

        public virtual void RequestQueryParameters(string queryName)
        {
            new CsiQueryParameters(this.GetOwnerDocument(), queryName, this);
        }

        public virtual void RequestUserDefinedFields()
        {
            ICsiXmlElement parentElement = base.ClearXmlElementChildByName("__CDODefinition");
            new CsiXmlElement(this.GetOwnerDocument(), "__userDefinedFields", parentElement);
        }
    }
}