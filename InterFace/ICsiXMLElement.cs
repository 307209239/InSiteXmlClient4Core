﻿using System;

namespace InSiteXmlClient4Core.InterFace
{
    public interface ICsiXmlElement
    {
        /// <summary>
        /// 添加子元素
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        ICsiXmlElement AppendChild(ICsiXmlElement child);
        ICsiContainer AsContainer();
        /// <summary>
        /// 转换为批次集合
        /// </summary>
        /// <returns></returns>
        ICsiContainerList AsContainerList();
        /// <summary>
        /// 转换为数据字段
        /// </summary>
        /// <returns></returns>
        ICsiDataField AsDataField();
        /// <summary>
        ///  转换为数据字段集合
        /// </summary>
        /// <returns></returns>
        ICsiDataList AsDataList();
        /// <summary>
        /// 转换为字段
        /// </summary>
        /// <returns></returns>
        ICsiField AsField();
        /// <summary>
        /// 转换为集合
        /// </summary>
        /// <returns></returns>
        ICsiList AsList();
        /// <summary>
        /// 转换为NDO
        /// </summary>
        /// <returns></returns>
        ICsiNamedObject AsNamedObject();
        /// <summary>
        /// 转换为NDO集合
        /// </summary>
        /// <returns></returns>
        ICsiNamedObjectList AsNamedObjectList();
        /// <summary>
        /// 转换为NamedSubentity
        /// </summary>
        /// <returns></returns>
        ICsiNamedSubentity AsNamedSubentity();
        /// <summary>
        /// 转换为NamedSubentity集合
        /// </summary>
        /// <returns></returns>
        ICsiNamedSubentityList AsNamedSubentityList();
        /// <summary>
        /// 转换为object
        /// </summary>
        /// <returns></returns>
        ICsiObject AsObject();
        /// <summary>
        /// 转换为object集合
        /// </summary>
        /// <returns></returns>
        ICsiObjectList AsObjectList();
        /// <summary>
        /// 转换为请求数据
        /// </summary>
        /// <returns></returns>
        ICsiRequestData AsRequestData();
        /// <summary>
        /// 转换为RO
        /// </summary>
        /// <returns></returns>
        ICsiRevisionedObject AsRevisionedObject();
        /// <summary>
        /// 转换为RO  集合
        /// </summary>
        /// <returns></returns>
        ICsiRevisionedObjectList AsRevisionedObjectList();
        ICsiService AsService();
        /// <summary>
        /// 转换为Subentity
        /// </summary>
        /// <returns></returns>
        ICsiSubentity AsSubentity();
        /// <summary>
        /// 转换为Subentity集合
        /// </summary>
        /// <returns></returns>
        ICsiSubentityList AsSubentityList();
        /// <summary>
        /// 查找子元素
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ICsiXmlElement FindChildByName(string name);
        /// <summary>
        /// 获取所有子元素
        /// </summary>
        /// <returns></returns>
        Array GetAllChildren();
        /// <summary>
        /// 获取特性
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        string GetAttribute(string name);
        /// <summary>
        /// 根据名称获取子元素
        /// </summary>
        /// <param name="name">名称</param>
        /// <returns></returns>
        Array GetChildrenByName(string name);
        /// <summary>
        /// 获取元素名称
        /// </summary>
        /// <returns></returns>
        string GetElementName();
        /// <summary>
        /// 文档
        /// </summary>
        /// <returns></returns>
        ICsiDocument GetOwnerDocument();
        /// <summary>
        /// 获取父元素
        /// </summary>
        /// <returns></returns>
        ICsiXmlElement GetParentElement();
        /// <summary>
        /// 枚举子元素
        /// </summary>
        /// <returns></returns>
        bool HasChildren();
        /// <summary>
        /// 是否Container类型
        /// </summary>
        /// <returns></returns>
        bool IsContainer();
        /// <summary>
        /// 是否Container集合
        /// </summary>
        /// <returns></returns>
        bool IsContainerList();
        /// <summary>
        /// 是否数据字段
        /// </summary>
        /// <returns></returns>
        bool IsDataField();
        /// <summary>
        /// 是否数据字段集合
        /// </summary>
        /// <returns></returns>
        bool IsDataList();
        /// <summary>
        /// 是否字段
        /// </summary>
        /// <returns></returns>
        bool IsField();
        /// <summary>
        /// 是否集合
        /// </summary>
        /// <returns></returns>
        bool IsList();
        /// <summary>
        /// 是否NamedObject类型
        /// </summary>
        /// <returns></returns>
        bool IsNamedObject();
        /// <summary>
        /// 是否NamedObject集合
        /// </summary>
        /// <returns></returns>
        bool IsNamedObjectList();
        /// <summary>
        /// 是否 有名称的子项
        /// </summary>
        /// <returns></returns>
        bool IsNamedSubentity();
        /// <summary>
        /// 是否 有名称子项集合
        /// </summary>
        /// <returns></returns>
        bool IsNamedSubentityList();
        /// <summary>
        /// 是否为对象
        /// </summary>
        /// <returns></returns>
        bool IsObject();
        /// <summary>
        /// 是否为对象集合
        /// </summary>
        /// <returns></returns>
        bool IsObjectList();
        /// <summary>
        /// 是否为返回数据
        /// </summary>
        /// <returns></returns>
        bool IsRequestData();
        /// <summary>
        /// 是否为RevisionedObject类型
        /// </summary>
        /// <returns></returns>
        bool IsRevisionedObject();
        /// <summary>
        /// 是否为RevisionedObject集合
        /// </summary>
        /// <returns></returns>
        bool IsRevisionedObjectList();
        /// <summary>
        /// 是否为服务
        /// </summary>
        /// <returns></returns>
        bool IsService();
        /// <summary>
        /// 是否为子项
        /// </summary>
        /// <returns></returns>
        bool IsSubentity();
        /// <summary>
        /// 是否子项集合
        /// </summary>
        /// <returns></returns>
        bool IsSubentityList();
        /// <summary>
        /// 删除所有子元素
        /// </summary>
        void RemoveAllChildren();
        /// <summary>
        /// 删除子元素
        /// </summary>
        /// <param name="child"></param>
        /// <returns></returns>
        ICsiXmlElement RemoveChild(ICsiXmlElement child);
        /// <summary>
        /// 设置特性
        /// </summary>
        /// <param name="name">名称</param>
        /// <param name="value">值</param>
        void SetAttribute(string name, string value);
    }
}
