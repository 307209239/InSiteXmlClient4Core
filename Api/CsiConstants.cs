using System.Collections;

namespace InSiteXmlClient4Core.Api
{
    public class CsiConstants

    {
        public const string mkAssemblyPrefix = "InSiteXmlClient4Core.Api.";
        public const string mkDefaultClass =  "InSiteXmlClient4Core.Api.CsiXmlElement";
        public static readonly Hashtable NodeToClassMapping = new Hashtable();

        static CsiConstants()
        {
            NodeToClassMapping["__query"] = "InSiteXmlClient4Core.Api.CsiQuery";
            NodeToClassMapping["__recordSet"] = "InSiteXmlClient4Core.Api.CsiRecordset";
            NodeToClassMapping["__responseData"] = "InSiteXmlClient4Core.Api.CsiResponseData";
            NodeToClassMapping["__parameters"] = "InSiteXmlClient4Core.Api.CsiParameters";
            NodeToClassMapping["__queryParameters"] = "InSiteXmlClient4Core.Api.CsiQueryParameters";
            NodeToClassMapping["__parameter"] = "InSiteXmlClient4Core.Api.CsiParameter";
            NodeToClassMapping["__service"] = "InSiteXmlClient4Core.Api.CsiService";
            NodeToClassMapping["__exceptionData"] = "InSiteXmlClient4Core.Api.CsiExceptionData";
            NodeToClassMapping["__selectionValue"] = "InSiteXmlClient4Core.Api.CsiSelectionValue";
            NodeToClassMapping["__selectionValues"] = "InSiteXmlClient4Core.Api.CsiSelectionValues";
            NodeToClassMapping["__requestData"] = "InSiteXmlClient4Core.Api.CsiRequestData";
            NodeToClassMapping["__metadata"] = "InSiteXmlClient4Core.Api.CsiMetaData";
            NodeToClassMapping["__CDOType"] = "InSiteXmlClient4Core.Api.CsiMetaData";
            NodeToClassMapping["__CDOSubType"] = "InSiteXmlClient4Core.Api.CsiMetaData";
            NodeToClassMapping["__CDOSubTypes"] = "InSiteXmlClient4Core.Api.CsiMetaData";
            NodeToClassMapping["__CDODefinition"] = "InSiteXmlClient4Core.Api.CsiMetaData";
            NodeToClassMapping["__label"] = "InSiteXmlClient4Core.Api.CsiMetaData";
            NodeToClassMapping["__field"] = "InSiteXmlClient4Core.Api.CsiMetaData";
            NodeToClassMapping["__listItem"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["__parent"] = "InSiteXmlClient4Core.Api.CsiParentInfo";
            NodeToClassMapping["__fieldDefs"] = "InSiteXmlClient4Core.Api.CsiMetaData";
            NodeToClassMapping["__fieldDef"] = "InSiteXmlClient4Core.Api.CsiMetaData";
            NodeToClassMapping["__defaultValue"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["__requestSelectionValuesEx"] = "InSiteXmlClient4Core.Api.CsiRequestSelectionValuesEx";
            NodeToClassMapping["__selectionValuesEx"] = "InSiteXmlClient4Core.Api.CsiSelectionValuesEx";
            NodeToClassMapping["__recordSetHeader"] = "InSiteXmlClient4Core.Api.CsiRecordsetHeader";
            NodeToClassMapping["__column"] = "InSiteXmlClient4Core.Api.CsiRecordsetHeaderColumn";
            NodeToClassMapping["__fieldType"] = "InSiteXmlClient4Core.Api.CsiFieldType";
            NodeToClassMapping["__row"] = "InSiteXmlClient4Core.Api.CsiRecordsetField";
            NodeToClassMapping["Object"] = "InSiteXmlClient4Core.Api.CsiObject";
            NodeToClassMapping["ObjRef"] = "InSiteXmlClient4Core.Api.CsiObject";
            NodeToClassMapping["ObjRefList"] = "InSiteXmlClient4Core.Api.CsiObjectList";
            NodeToClassMapping["ObjectList"] = "InSiteXmlClient4Core.Api.CsiObjectList";
            NodeToClassMapping["NamedObject"] = "InSiteXmlClient4Core.Api.CsiNamedObject";
            NodeToClassMapping["NamedObjRef"] = "InSiteXmlClient4Core.Api.CsiNamedObject";
            NodeToClassMapping["NamedObjRefList"] = "InSiteXmlClient4Core.Api.CsiNamedObjectList";
            NodeToClassMapping["NamedList"] = "InSiteXmlClient4Core.Api.CsiNamedObjectList";
            NodeToClassMapping["RevisionObject"] = "InSiteXmlClient4Core.Api.CsiRevisionedObject";
            NodeToClassMapping["RevObjRef"] = "InSiteXmlClient4Core.Api.CsiRevisionedObject";
            NodeToClassMapping["RevObjRefList"] = "InSiteXmlClient4Core.Api.CsiRevisionedObjectList";
            NodeToClassMapping["RevisionList"] = "InSiteXmlClient4Core.Api.CsiRevisionedObjectList";
            NodeToClassMapping["ContainerObject"] = "InSiteXmlClient4Core.Api.CsiContainer";
            NodeToClassMapping["ContainerObjRef"] = "InSiteXmlClient4Core.Api.CsiContainer";
            NodeToClassMapping["ContainerObjRefList"] = "InSiteXmlClient4Core.Api.CsiContainerList";
            NodeToClassMapping["ContainerList"] = "InSiteXmlClient4Core.Api.CsiContainerList";
            NodeToClassMapping["Subentity"] = "InSiteXmlClient4Core.Api.CsiSubentity";
            NodeToClassMapping["SubentityObjRef"] = "InSiteXmlClient4Core.Api.CsiSubentity";
            NodeToClassMapping["SubentityObjRefList"] = "InSiteXmlClient4Core.Api.CsiSubentityList";
            NodeToClassMapping["SubentityList"] = "InSiteXmlClient4Core.Api.CsiSubentityList";
            NodeToClassMapping["NamedSubentity"] = "InSiteXmlClient4Core.Api.CsiNamedSubentity";
            NodeToClassMapping["NamedSubentityObjRef"] = "InSiteXmlClient4Core.Api.CsiNamedSubentity";
            NodeToClassMapping["NamedSubentityObjRefList"] = "InSiteXmlClient4Core.Api.CsiNamedSubentityList";
            NodeToClassMapping["NamedSubentityList"] = "InSiteXmlClient4Core.Api.CsiNamedSubentityList";
            NodeToClassMapping["DataField"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["Integer"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["String"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["Float"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["TimeStamp"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["Currency"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["Boolean"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["Data"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["DataList"] = "InSiteXmlClient4Core.Api.CsiDataList";
            NodeToClassMapping["IntegerList"] = "InSiteXmlClient4Core.Api.CsiDataList";
            NodeToClassMapping["StringList"] = "InSiteXmlClient4Core.Api.CsiDataList";
            NodeToClassMapping["FloatList"] = "InSiteXmlClient4Core.Api.CsiDataList";
            NodeToClassMapping["TimeStampList"] = "InSiteXmlClient4Core.Api.CsiDataList";
            NodeToClassMapping["CurrencyList"] = "InSiteXmlClient4Core.Api.CsiDataList";
            NodeToClassMapping["BooleanList"] = "InSiteXmlClient4Core.Api.CsiDataList";
            NodeToClassMapping["__rowSetSize"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["__startRow"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["__requestRecordCount"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["__recordCount"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["__changeCount"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["__sessionValues"] = "InSiteXmlClient4Core.Api.CsiSubentity";
            NodeToClassMapping["__queryName"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["__queryText"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["__name"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["__rev"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["__Id"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["__level"] = "InSiteXmlClient4Core.Api.CsiNamedObject";
            NodeToClassMapping["__CDOTypeName"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["__CDOTypeId"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["__value"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["__default"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["__dataType"] = "InSiteXmlClient4Core.Api.CsiDataField";
            NodeToClassMapping["__dataSourceName"] = "InSiteXmlClient4Core.Api.CsiDataField";
        }
    }
}