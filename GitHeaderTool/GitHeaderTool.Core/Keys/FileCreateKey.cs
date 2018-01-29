using System;
namespace GitHeaderTool.Core.Keys
{
    /// <summary>
    /// 文件创建Key
    /// </summary>
    [KeyLevel(CommandLevel = ECommandLevel.x)]
    public class FileCreateKey:IKeySetting
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
        /// <summary>
        /// 上下文
        /// </summary>
        public IExcuteTarget ContextTarget { get; set; }
        public FileCreateKey(string key, string value)
        {
            Key = key;
            Value = value;
            Level = (int)ECommandLevel.x;
        }
        public T Accept<T>(CommandConverter<T> converter) where T : ICommandExcute
        {
            var commandExcute= converter.ConvertFileCreateKey(this);
            CommandExcute = commandExcute;
            return commandExcute;
        }
    }
}
