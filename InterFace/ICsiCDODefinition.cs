using System;
using System.Collections.Generic;
using System.Text;

namespace InSiteXmlClient4Core.InterFace
{
    /// <summary>
    /// CDO声明接口
    /// </summary>
    public interface ICsiCdoDefinition
    {
        /// <summary>
        /// 获取CDO类型ID
        /// </summary>
        /// <returns></returns>
        int GetCdoTypeId();
        /// <summary>
        /// 获取CDO类型名称
        /// </summary>
        /// <returns></returns>
        string GetCdoTypeName();
        /// <summary>
        /// 获取定义的字段
        /// </summary>
        /// <returns></returns>
        ICsiFieldDefinitions GetFieldDefinitions();
    }
}
