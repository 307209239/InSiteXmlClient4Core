using System;
using System.Collections.Generic;
using System.Text;

namespace InSiteXmlClient4Core.InterFace
{
    public interface ICsiObject: ICsiField,ICsiXmlElement
    {
        /// <summary>
        /// Container字段
        /// </summary>
        /// <param name="fieldName">字段名称</param>
        /// <returns></returns>
        ICsiContainer ContainerField(string fieldName);
        /// <summary>
        /// 获取批次集合
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        ICsiContainerList ContainerList(string fieldName);
        /// <summary>
        /// 创建对象
        /// </summary>
        /// <param name="cdoType">cdo类型</param>
        void CreateObject(string cdoType);
        /// <summary>
        /// 数据字段
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        ICsiDataField DataField(string fieldName);
        /// <summary>
        /// 数据字段集合
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        ICsiDataList DataList(string fieldName);
        /// <summary>
        /// 获取字段
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        ICsiField GetField(string fieldName);
        /// <summary>
        /// 获取对象ID
        /// </summary>
        /// <returns></returns>
        string GetObjectId();
        /// <summary>
        /// 获取对象类型
        /// </summary>
        /// <returns></returns>
        string GetObjectType();
        /// <summary>
        /// 获取用户定义的字段
        /// </summary>
        /// <returns></returns>
        Array GetUserDefinedFields();
        /// <summary>
        /// NDO字段
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        ICsiNamedObject NamedObjectField(string fieldName);
        /// <summary>
        /// NDO集合
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
         ICsiNamedObjectList NamedObjectList(string fieldName);
        /// <summary>
        /// NamedSubentity字段
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        ICsiNamedSubentity NamedSubentityField(string fieldName);
        /// <summary>
        /// NamedSubentity字段集合
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        ICsiNamedSubentityList NamedSubentityList(string fieldName);
        /// <summary>
        /// 对象字段
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        ICsiObject ObjectField(string fieldName);
        /// <summary>
        /// 对象集合
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        ICsiObjectList ObjectList(string fieldName);
        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="eventName">事件名称</param>
        /// <returns></returns>
        ICsiPerform Perform(string eventName);
        /// <summary>
        /// RO字段
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        ICsiRevisionedObject RevisionedObjectField(string fieldName);
        /// <summary>
        /// RO 集合字段
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        ICsiRevisionedObjectList RevisionedObjectList(string fieldName);
        /// <summary>
        /// 设定ID
        /// </summary>
        /// <param name="id"></param>
        void SetObjectId(string id);
        /// <summary>
        /// 设定类型
        /// </summary>
        /// <param name="cdoType"></param>
        void SetObjectType(string cdoType);
        /// <summary>
        /// 子字段
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        ICsiSubentity SubentityField(string fieldName);
        /// <summary>
        /// 子集合字段
        /// </summary>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        ICsiSubentityList SubentityList(string fieldName);
    }
}
