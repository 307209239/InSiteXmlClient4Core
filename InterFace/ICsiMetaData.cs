using System;
using System.Collections.Generic;
using System.Text;

namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 元数据
    /// </summary>
      public interface ICsiMetaData


    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ICsiCdoDefinition GetCdoDefinition();
        ICsiFieldDefinition GetCdoField();
        ICsiLabel GetCdoLabel();
        ICsiCdoType GetCdoType();
        ICsiLabel GetFieldLabel();
        ICsiLabel GetLabel();
        ICsiQueryParameters GetQueryParameters();
        Array GetUserDefinedFields();
        void RequestCdoDefinition();
        void RequestCdoDefinitionById(int id);
        void RequestCdoDefinitionByName(string name);
        void RequestCdoDefinitionFieldByName(string name, string fieldName);
        void RequestCdoLabel();
        void RequestCdoSubTypesById(int Id, bool recurse);
        void RequestCdoSubTypesByName(string name, bool recurse);
        void RequestFieldItem(string itemName);
        void RequestFieldLabel();
        void RequestLabelById(int labelId);
        void RequestLabelByName(string labelName);
        void RequestQueryParameters(string queryName);
        void RequestUserDefinedFields();
    }
}
