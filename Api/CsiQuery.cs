using System;
using InSiteXmlClient4Core.InterFace;
using System.Xml;
using InSiteXmlClient4Core.Exceptions;

namespace InSiteXmlClient4Core.Api
{
    internal class CsiQuery : CsiXmlElement, ICsiQuery, ICsiXmlElement
    {
        public CsiQuery(ICsiDocument doc, ICsiXmlElement parent) : base(doc, "__query", parent)
        {
        }

        public CsiQuery(ICsiDocument doc, XmlElement element) : base(doc, element)
        {
        }

        public void ClearParameters()
        {
            ICsiXmlElement element = base.FindChildByName("__queryParameters");
            element?.RemoveAllChildren();
        }

        public ICsiExceptionData ExceptionData() =>
            this.GetChildExceptionData();

        public string GetParameter(string param)
        {
            string str;
            string str2;
            ICsiQueryParameters parameters = this.GetQueryParameters();
            if (parameters == null)
            {
                str = base.GetType().FullName + ".getParameter()";
                str2 = CsiXmlHelper.GetNotExists("__parameters");
                throw new CsiClientException(-1L, str2, str);
            }
            ICsiParameter parameter = parameters.GetParameterByName(param);
            if (parameter != null)
            {
                return parameter.GetValue();
            }
            str = base.GetType().FullName + ".getParameter()";
            str2 = CsiXmlHelper.GetNotExists(param);
            throw new CsiClientException(-1L, str2, str);
        }

        public virtual string GetQueryName()
        {
            try
            {
                return (base.FindChildByName("__queryName") as CsiDataField).GetValue();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual ICsiQueryParameters GetQueryParameters()
        {
            if (!(base.FindChildByName("__queryParameters") is ICsiQueryParameters parameters))
            {
                parameters = new CsiQueryParameters(this.GetOwnerDocument(), this);
            }
            return parameters;
        }

        public virtual long GetRecordCount()
        {
            try
            {
                return long.Parse(((CsiDataField)base.FindChildByName("__responseData").FindChildByName("__recordCount")).GetValue());
            }
            catch (Exception)
            {
                return 0L;
            }
        }

        public virtual ICsiRecordset GetRecordset()
        {
            try
            {
                return (base.FindChildByName("__responseData").FindChildByName("__recordSet") as ICsiRecordset);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual ICsiRecordsetHeader GetRecordsetHeader()
        {
            try
            {
                return (base.FindChildByName("__responseData").FindChildByName("__recordSetHeader") as ICsiRecordsetHeader);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual bool GetRequestRecordCount()
        {
            try
            {
                return bool.Parse(((CsiDataField)base.FindChildByName("__requestRecordCount")).GetValue());
            }
            catch (Exception)
            {
                return false;
            }
        }

        public virtual long GetRowsetSize()
        {
            try
            {
                return long.Parse(((CsiDataField)base.FindChildByName("__rowSetSize")).GetValue());
            }
            catch (Exception)
            {
                return -1L;
            }
        }

        public virtual string GetSqlText()
        {
            try
            {
                return (base.FindChildByName("__queryText") as CsiDataField).GetValue();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public virtual long GetStartRow()
        {
            try
            {
                return long.Parse((base.FindChildByName("__startRow") as CsiDataField).GetValue());
            }
            catch (Exception)
            {
                return -1L;
            }
        }

        public virtual long GetUserQueryChangeCount()
        {
            try
            {
                return long.Parse(((CsiDataField)base.FindChildByName("__responseData").FindChildByName("__changeCount")).GetValue());
            }
            catch (Exception)
            {
                return 0L;
            }
        }

        public virtual void SetCdoTypeId(int Id)
        {
            try
            {
                this.removeChildByName(this, "__CDOTypeId");
                new CsiDataField(this.GetOwnerDocument(), "__CDOTypeId", this, Convert.ToString(Id));
            }
            catch (Exception)
            {
            }
        }

        public void SetParameter(string param, string val)
        {
            try
            {
                ICsiQueryParameters parameters = this.GetQueryParameters();
                if (parameters == null)
                {
                    parameters = new CsiQueryParameters(this.GetOwnerDocument(), this);
                }
                parameters.SetParameter(param, val);
            }
            catch (Exception)
            {
            }
        }

        public virtual void SetQueryName(string query)
        {
            try
            {
                this.removeChildByName(this, "__queryName");
                new CsiDataField(this.GetOwnerDocument(), "__queryName", this, query);
            }
            catch (Exception)
            {
            }
        }

        public virtual void SetRequestRecordCount(bool val)
        {
            try
            {
                this.removeChildByName(this, "__requestRecordCount");
                if (val)
                {
                    new CsiDataField(this.GetOwnerDocument(), "__requestRecordCount", this, "true");
                }
            }
            catch (Exception)
            {
            }
        }

        public virtual void SetRowsetSize(long size)
        {
            try
            {
                this.removeChildByName(this, "__rowSetSize");
                new CsiDataField(this.GetOwnerDocument(), "__rowSetSize", this, Convert.ToString(size));
            }
            catch (Exception)
            {
            }
        }

        public virtual void SetSqlText(string sql)
        {
            try
            {
                this.removeChildByName(this, "__queryText");
                new CsiDataField(this.GetOwnerDocument(), "__queryText", this, sql);
            }
            catch (Exception)
            {
            }
        }

        public virtual void SetStartRow(long row)
        {
            try
            {
                this.removeChildByName(this, "__startRow");
                new CsiDataField(this.GetOwnerDocument(), "__startRow", this, Convert.ToString(row));
            }
            catch (Exception)
            {
            }
        }

        public void SetUserQueryName(string queryName, long changeCount)
        {
            try
            {
                this.removeChildByName(this, "__queryName");
                ICsiXmlElement element = new CsiDataField(this.GetOwnerDocument(), "__queryName", this, queryName);
                element.SetAttribute("__type", "user");
                element.SetAttribute("__changeCount", Convert.ToString(changeCount));
            }
            catch (Exception)
            {
            }
        }
    }
}