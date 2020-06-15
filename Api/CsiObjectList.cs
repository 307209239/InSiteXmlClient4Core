using InSiteXmlClient4Core.InterFace;
using System.Collections;
using System.Xml;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiObjectList : CsiList, ICsiObjectList, ICsiList, ICsiField, ICsiXmlElement
    {
        public CsiObjectList(ICsiDocument doc, XmlElement domElement) : base(doc, domElement)
        {
        }

        public CsiObjectList(ICsiDocument doc, string name, ICsiXmlElement parent) : base(doc, name, parent)
        {
        }

        public virtual void AppendItemById(string istanceID)
        {
            ICsiObject obj2 = new CsiObject(this.GetOwnerDocument(), "__listItem", this);
            obj2.SetObjectId(istanceID);
        }

        protected virtual CsiXmlElement GetItem(string name)
        {
            IEnumerator enumerator = this.GetListItems().GetEnumerator();
            while (enumerator.MoveNext())
            {
                CsiXmlElement current = (CsiXmlElement)enumerator.Current;
                CsiXmlElement impl2 = (CsiXmlElement)current.FindChildByName("__name");
                if ((impl2 != null) && name.Equals(impl2.GetElementValue()))
                {
                    return current;
                }
            }
            return null;
        }

        public override bool IsObjectList() =>
            true;
    }
}