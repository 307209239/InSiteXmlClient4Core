using System.Xml;
using InSiteXmlClient4Core.InterFace;
using InSiteXmlClient4Core.Util;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiContainer : CsiObject, ICsiContainer, ICsiObject, ICsiField, ICsiXmlElement
    {
        public CsiContainer(ICsiDocument doc, XmlElement element) : base(doc, element)
        {
        }

        public CsiContainer(ICsiDocument doc, string name, ICsiXmlElement parent) : base(doc, name, parent)
        {
        }

        protected internal bool Equals(string name, string level)
        {
            bool flag = name.Equals(this.GetName());
            if ((level != null) && !level.Equals(this.GetLevel()))
            {
                flag = false;
            }
            return flag;
        }

        public virtual string GetLevel()
        {
            CsiXmlElement impl = base.FindChildByName("__level") as CsiXmlElement;
            string str = string.Empty;
            if (impl != null)
            {
                CsiXmlElement csiElement = (CsiXmlElement)impl.FindChildByName("__name");
                if (csiElement != null)
                {
                    str = CsiXmlHelper.GetFirstTextNodeValue(csiElement);
                }
            }
            return str;
        }

        public virtual string GetName()
        {
            CsiXmlElement csiElement = (CsiXmlElement)base.FindChildByName("__name");
            string str = string.Empty;
            if (csiElement != null)
            {
                str = CsiXmlHelper.GetFirstTextNodeValue(csiElement);
            }
            return str;
        }

       
        public virtual void GetRef(out string name, out string level)
        {
            name = this.GetName();
            level = this.GetLevel();
        }

        public override bool IsContainer() =>
            true;

        public void SetRef(string name, string level)
        {
            CsiXmlHelper.FindCreateSetValue(this, "__name", name, true);
            if (!StringUtil.IsEmptyString(level))
            {
                CsiXmlHelper.FindCreateSetValue2(this, "__level", "__name", level, true);
            }
        }
    }
}