using System;
using InSiteXmlClient4Core.InterFace;
using InSiteXmlClient4Core.Util;
using System.Xml;

namespace InSiteXmlClient4Core.Api
{
    public class CsiObject : CsiField, ICsiObject, ICsiField, ICsiXmlElement
    {
        public CsiObject(ICsiDocument doc, ICsiXmlElement parent) : this(doc, "__inputData", parent)
        {
        }

        public CsiObject(ICsiDocument doc, XmlElement domElement) : base(doc, domElement)
        {
        }

        public CsiObject(ICsiDocument doc, string name, ICsiXmlElement parent) : base(doc, name, parent)
        {
        }

        public ICsiContainer ContainerField(string fieldName) =>
            new CsiContainer(this.GetOwnerDocument(), fieldName, this);

        public ICsiContainerList ContainerList(string listName) =>
            new CsiContainerList(this.GetOwnerDocument(), listName, this);

        public void CreateObject(string sCDOType)
        {
            base.SetAttribute("__action", "create");
            if (!StringUtil.IsEmptyString(sCDOType))
            {
                base.SetAttribute("__CDOTypeName", sCDOType);
            }
        }

        public ICsiDataField DataField(string dataFieldName) =>
            new CsiDataField(this.GetOwnerDocument(), dataFieldName, this);

        public ICsiDataList DataList(string listName) =>
            new CsiDataList(this.GetOwnerDocument(), listName, this);

        public ICsiField GetField(string tagName) =>
            (base.FindChildByName(tagName) as CsiField);

        public override Array GetFields() =>
            base.GetAllChildren(true);

        public virtual string GetObjectId()
        {
            CsiDataField impl = base.FindChildByName("__Id") as CsiDataField;
            return impl?.GetValue();
        }

        public virtual string GetObjectType() =>
            base.GetAttribute("__CDOTypeName");

        public virtual Array GetUserDefinedFields()
        {
            CsiXmlElement impl = base.FindChildByName("__userDefinedFields") as CsiXmlElement;
            return impl?.GetAllChildren(false);
        }

        public override bool IsObject() =>
            true;

        public ICsiNamedObject NamedObjectField(string fieldName) =>
            new CsiNamedObject(this.GetOwnerDocument(), fieldName, this);

        public ICsiNamedObjectList NamedObjectList(string listName)
        {
            return (ICsiNamedObjectList)new CsiNamedObjectList(this.GetOwnerDocument(), listName, (ICsiXmlElement)this);
        }

        public ICsiNamedSubentity NamedSubentityField(string objectName) =>
            new CsiNamedSubentity(this.GetOwnerDocument(), objectName, this);

        public ICsiNamedSubentityList NamedSubentityList(string listName) =>
            new CsiNamedSubentityList(this.GetOwnerDocument(), listName, this);

        public ICsiObject ObjectField(string fieldName) =>
            new CsiObject(this.GetOwnerDocument(), fieldName, this);

        public virtual ICsiObjectList ObjectList(string fieldName) =>
            new CsiObjectList(this.GetOwnerDocument(), fieldName, this);

        public ICsiPerform Perform(string eventName)
        {
            CsiPerform csiPerformImpl = new CsiPerform(this.GetOwnerDocument(), (ICsiXmlElement)this);
            new CsiDataField(this.GetOwnerDocument(), "__eventName", (ICsiXmlElement)csiPerformImpl).SetValue(eventName);
            return (ICsiPerform)csiPerformImpl;
        }

        public ICsiRevisionedObject RevisionedObjectField(string fieldName) =>
            new CsiRevisionedObject(this.GetOwnerDocument(), fieldName, this);

        public ICsiRevisionedObjectList RevisionedObjectList(string listName) =>
            new CsiRevisionedObjectList(this.GetOwnerDocument(), listName, this);

        public virtual void SetObjectId(string id)
        {
            if (!(base.FindChildByName("__Id") is CsiDataField impl))
            {
                impl = new CsiDataField(this.GetOwnerDocument(), "__Id", this);
            }
            impl.SetValue(id);
        }

        public virtual void SetObjectType(string type)
        {
            base.SetAttribute("__CDOTypeName", type);
        }

        public ICsiSubentity SubentityField(string fieldName) =>
            new CsiSubentity(this.GetOwnerDocument(), fieldName, this);

        public ICsiSubentityList SubentityList(string listName) =>
            new CsiSubentityList(this.GetOwnerDocument(), listName, this);
    }
}