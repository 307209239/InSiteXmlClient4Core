using System;

namespace InSiteXmlClient4Core.InterFace
{
    public interface ICsiSelectionValues : ICsiXmlElement
    {
        Array GetAllSelectionValues();
        ICsiSelectionValue GetSelectionValueByName(string name);
    }
}