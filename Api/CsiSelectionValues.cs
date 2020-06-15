using InSiteXmlClient4Core.InterFace;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiSelectionValues
    {
        private ICsiDocument csiDocument;
        private CsiRequestField csiRequestField;

        public CsiSelectionValues(ICsiDocument csiDocument, CsiRequestField csiRequestField)
        {
            this.csiDocument = csiDocument;
            this.csiRequestField = csiRequestField;
        }
    }
}