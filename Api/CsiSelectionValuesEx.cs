using InSiteXmlClient4Core.InterFace;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiSelectionValuesEx : CsiXmlElement, ICsiSelectionValuesEx, ICsiXmlElement
    {
        public CsiSelectionValuesEx(CsiDocument doc, ICsiXmlElement parent)
          : base(doc, "__selectionValuesEx", parent)
        {
        }

        public CsiSelectionValuesEx(CsiDocument doc, XmlElement element)
          : base(doc, element)
        {
        }

        public virtual ICsiRecordset GetRecordset()
        {
            try
            {
                return this.FindChildByName("__recordSet") as ICsiRecordset;
            }
            catch (Exception ex)
            {
                return (ICsiRecordset)null;
            }
        }

        public virtual ICsiRecordsetHeader GetRecordsetHeader()
        {
            try
            {
                return this.FindChildByName("__recordSetHeader") as ICsiRecordsetHeader;
            }
            catch (Exception ex)
            {
                return (ICsiRecordsetHeader)null;
            }
        }

        public virtual long GetRecordCount()
        {
            long num = 0;
            var childByName = this.FindChildByName("__responseData") as CsiDataField;
            if ( childByName!=null)
            {
                ICsiDataField childByNam= childByName .FindChildByName("__recordCount") as ICsiDataField;
                try
                {
                    num = long.Parse(childByNam.GetValue());
                }
                catch (Exception ex)
                {
                }
            }
            return num;
        }
    }
}
