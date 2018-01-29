using System;

namespace GitHeaderTool.Core.Keys
{
    /// <summary>
    /// 内容查询Key
    /// </summary>
    [KeyLevel(CommandLevel = ECommandLevel.s)]
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
        /// <summary>
        /// 对应的命令
        /// </summary>
        public ICommandExcute CommandExcute { get; private set; }
        /// <summary>
        /// 上下文
        /// </summary>
        public IExcuteTarget ContextTarget { get; set; }
        public ContentSearchKey(string key, string value)
        {
            Key = key;
            Value = value;
            Level = (int)ECommandLevel.s;
        }
        /// <summary>
        /// 接受Key来关联CommandExcute
        /// </summary>
        /// <typeparam name="T">ICommandExcute</typeparam>
        /// <param name="converter">访问转换器</param>
        public T Accept<T>(CommandConverter<T> converter) where T : ICommandExcute
        {
            var commandExcute=converter.ConvertContentSearchKey(this);
            CommandExcute = commandExcute;
            return commandExcute;
        }
    }
}
