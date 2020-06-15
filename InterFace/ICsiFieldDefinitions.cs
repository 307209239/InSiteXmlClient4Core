using System;

namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// 字段集合
    /// </summary>
    public interface ICsiFieldDefinitions : ICsiXmlElement
    {
        /// <summary>
        /// 获取所有定义的字段
        /// </summary>
        /// <returns></returns>
        Array GetAllFieldDefinitions();
        /// <summary>
        /// 根据ID获取字段
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ICsiFieldDefinition GetFieldDefinitionById(int id);
        /// <summary>
        /// 根据名称获取字段
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        ICsiFieldDefinition GetFieldDefinitionByName(string name);
    }
}