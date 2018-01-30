using System;
using System.IO;

namespace GitHeaderTool.Core.Keys
{
    /// <summary>
    /// 文件内容删除Key
    /// </summary>
    [KeyLevel(CommandLevel = ECommandLevel.r)]
    public class FileContentRemoveKey:IKeySetting
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
        /// <summary>
        /// 对应的命令
        /// </summary>
        public ICommandExcute CommandExcute { get; private set; }
        public FileContentRemoveKey(string key,string value)
        {
            Key = key;
            Value = value;
            Level = (int)ECommandLevel.r;
        }
        public T Accept<T>(CommandConverter<T> converter) where T : ICommandExcute
        {
            var commandExcute= converter.ConvertContentRemoveKey(this);
            CommandExcute = commandExcute;
            return commandExcute;
        }
    }
}
