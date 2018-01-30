using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace GitHeaderTool.Core
{
    /// <summary>
    /// 命令关键字
    /// </summary>
    public interface IKeySetting
    {
        /// <summary>
        /// 命令Key
        /// </summary>
        string Key { get;}
        /// <summary>
        /// 参数值
        /// </summary>
        string Value { get; }
        /// <summary>
        /// 权重
        /// </summary>
        int Level { get;}
        /// <summary>
        /// 对应的命令
        /// </summary>
        ICommandExcute CommandExcute { get; }
        T Accept<T>(CommandConverter<T> converter) where T : ICommandExcute;        
    }
}
