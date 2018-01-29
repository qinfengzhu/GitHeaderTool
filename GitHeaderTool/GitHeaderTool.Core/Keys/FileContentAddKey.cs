using System;

namespace GitHeaderTool.Core.Keys
{
    /// <summary>
    /// 文件内容添加Key
    /// </summary>
    public class FileContentAddKey:IKeySetting
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
        public FileContentAddKey(string key,string value)
        {
            Key = key;
            Value = value;
            Level = (int)(ECommandLevel.a);
        }
        public T Accept<T>(CommandConverter<T> converter)
        {
            return converter.ConvertContentAddKey(this);
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
