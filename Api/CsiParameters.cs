using InSiteXmlClient4Core.InterFace;
using System.Collections;
using System.Xml;
using InSiteXmlClient4Core.Exceptions;

namespace InSiteXmlClient4Core.Api
{
    public class CsiParameters: CsiXmlElement, ICsiParameters, ICsiXmlElement
    {
        public CsiParameters(ICsiDocument doc, XmlElement element) : base(doc, element)
        {
        }

        public CsiParameters(ICsiDocument doc, string tagName, ICsiXmlElement parent) : base(doc, tagName, parent)
        {
            if (!(tagName.Equals("__parameters") || tagName.Equals("__queryParameters")))
            {
                string src = base.GetType().FullName + ".Constructor()";
                string desc = CsiXmlHelper.GetInvalidElement(tagName) + "(valid elements are: __parameters and " + "__queryParameters)";
                throw new CsiClientException(-1L, desc, src);
            }
        }

        public virtual void ClearAll()
        {
            base.RemoveAllChildren();
        }

        public virtual long GetCount()
        {
            long num = 0L;
            IEnumerator enumerator = this.GetAllChildren().GetEnumerator();
            while (enumerator.MoveNext())
            {
                CsiXmlElement current = enumerator.Current as CsiXmlElement;
                if (current.GetDomElement().NodeType == XmlNodeType.Element)
                {
                    num += 1L;
                }
            }
            return num;
        }

        public virtual ICsiParameter GetParameterByName(string paramName) => 
            (this.FindChildByName("__parameter", "__name", paramName) as ICsiParameter);

        public virtual void RemoveParameterByName(string parameterName)
        {
            if (!(this.GetParameterByName(parameterName) is CsiParameter impl))
            {
                throw new CsiClientException(-1L, $"参数 '{parameterName}' 不存在.");
            }
            base.GetDomElement().RemoveChild(impl.GetDomElement());
        }

        public virtual void SetParameter(string name, string val)
        {
            ICsiParameter parameter = this.GetParameterByName(name);
            if (parameter == null)
            {
                parameter = new CsiParameter(this.GetOwnerDocument(), name, this);
            }
            parameter.SetValue(val);
        }
    }
}