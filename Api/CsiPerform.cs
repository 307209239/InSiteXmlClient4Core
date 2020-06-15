using InSiteXmlClient4Core.InterFace;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiPerform : CsiXmlElement, ICsiPerform, ICsiXmlElement
    {
        public CsiPerform(ICsiDocument document, ICsiXmlElement parent) : base(document, "__perform", parent)
        {
        }

        public ICsiParameters AddParameters()
        {
            if (!(base.FindChildByName("__parameters") is ICsiParameters parameters))
            {
                parameters = new CsiParameters(this.GetOwnerDocument(), "__parameters", this);
            }
            return parameters;
        }
    }
}