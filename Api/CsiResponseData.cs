using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using InSiteXmlClient4Core.InterFace;

namespace InSiteXmlClient4Core.Api
{
   

   internal  class CsiResponseData : CsiXmlElement, ICsiResponseData, ICsiXmlElement
   {
       public CsiResponseData(ICsiDocument doc, XmlElement domElement)
           : base(doc, domElement)
       {
       }

       public CsiResponseData(ICsiDocument doc, ICsiXmlElement oParent)
           : base(doc, "__responseData", oParent)
       {
       }

       public virtual Array GetResponseFields()
       {
           return this.GetAllChildren(true);
       }

       public virtual ICsiSubentity GetSessionValues()
       {
           return this.FindChildByName("__sessionValues") as ICsiSubentity;
       }

       public ICsiField GetResponseFieldByName(string fieldName)
       {
           return this.FindChildByName(fieldName) as ICsiField;
       }
   }
}
