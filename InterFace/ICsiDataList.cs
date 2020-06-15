using System;
using System.Collections.Generic;
using System.Text;

namespace InSiteXmlClient4Core.InterFace
{
    public  interface ICsiDataList : ICsiList, ICsiField, ICsiXmlElement
    {
        /// <summary>
        /// 添加项
        /// </summary>
        /// <param name="valueRenamed"></param>
        /// <returns></returns>
        ICsiDataField AppendItem(string valueRenamed);
        /// <summary>
        /// 更改指定索引项
        /// </summary>
        /// <param name="index"></param>
        /// <param name="valueRenamed"></param>
        /// <returns></returns>
        ICsiDataField ChangeItemByIndex(int index, string valueRenamed);
        /// <summary>
        /// 更新值
        /// </summary>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        ICsiDataField ChangeItemByValue(string oldValue, string newValue);
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="valueRenamed"></param>
        /// <returns></returns>
        ICsiDataField DeleteItemByValue(string valueRenamed);
        /// <summary>
        /// 获取指定索引的项
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        ICsiDataField GetItemByIndex(int index);
    }

  
}
