﻿using System;

namespace GitHeaderTool.Core.Keys
{
    /// <summary>
    /// 内容查询Key
    /// </summary>
    public  class ContentSearchKey:IKeySetting
    {
        /// <summary>
        /// 命令关键字
        /// </summary>
        public string Key { get; private set; }
        /// <summary>
        /// 命令参数值
        /// </summary>
        public string Value { get; private set; }
        /// <summary>
        /// 执行优先等级
        /// </summary>
        public int Level { get; private set; }
        public ContentSearchKey(string key, string value)
        {
            Key = key;
            Value = value;
            Level = (int)ECommandLevel.s;
        }
        public T Accept<T>(CommandConverter<T> converter)
        {
            return converter.ConvertContentSearchKey(this);
        }

        public IExcuteTarget CreateTarget()
        {
            throw new NotImplementedException();
        }

        public IExcuteTarget CreateTarget(IExcuteResult excuteResult)
        {
            throw new NotImplementedException();
        }
    }
}
