using System;
using System.Collections.Generic;
using System.Text;

namespace InSiteXmlClient4Core.Enum
{
    /// <summary>
    /// 类型枚举
    /// </summary>
    public enum CsiReferenceTypes
    {
        /// <summary>
        /// 无类型
        /// </summary>
        ReferenceTypeNone,
        /// <summary>
        /// container类型
        /// </summary>
        ReferenceTypeContainer,
        /// <summary>
        /// NDO类型
        /// </summary>
        ReferenceTypeNamedDataObject,
        /// <summary>
        /// RO类型
        /// </summary>
        ReferenceTypeRevisionedObject,
        /// <summary>
        /// SubEntity 类型
        /// </summary>
        ReferenceTypeSubEntity,
        /// <summary>
        /// NamedSubEntity类型
        /// </summary>
        ReferenceTypeNamedSubEntity,
        /// <summary>
        /// Object类型
        /// </summary>
        ReferenceTypeObject
    }
}
