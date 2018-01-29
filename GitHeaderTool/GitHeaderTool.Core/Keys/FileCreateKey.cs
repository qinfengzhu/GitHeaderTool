using System;
namespace GitHeaderTool.Core.Keys
{
    /// <summary>
    /// 文件创建Key
    /// </summary>
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
        public FileCreateKey(string key, string value)
        {
            Key = key;
            Value = value;
            Level = (int)ECommandLevel.x;
        }
        public T Accept<T>(CommandConverter<T> converter)
        {
            return converter.ConvertFileCreateKey(this);
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
