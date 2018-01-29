using GitHeaderTool.Core.Targets;
using System;
using System.IO;
namespace GitHeaderTool.Core.Keys
{
    /// <summary>
    /// 文件查询Key
    /// </summary>
    [KeyLevel(CommandLevel = ECommandLevel.f)]
    public class FileSearchKey : IKeySetting, ITarget
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
        public FileSearchKey(string key,string value)
        {
            Key = key;
            Value = value;
            Level = (int)ECommandLevel.f;
        }
        public T Accept<T>(CommandConverter<T> converter) where T:ICommandExcute
        {
            var commandExcute= converter.ConvertFileSearchKey(this);
            CommandExcute = commandExcute;
            return commandExcute;
        }
        /// <summary>
        /// 创建处理目标
        /// </summary>
        /// <returns></returns>
        public IExcuteTarget CreateTarget()
        {
            if (Value.Contains("|"))
            {
                var p = Value.Split('|');
                string dir = p[0];
                string searchConditon = p[1];
                var files = Directory.GetFiles(dir, searchConditon);
                IExcuteTarget targetHeader = null;
                IExcuteTarget targetTail = null;
                for (int index=0,length=files.Length;index<length;index++)
                {
                    if (index == 0)
                    {
                        var commandPair = new CommandPair("-f", files[index]);
                        IKeySetting fileSearchKey = KeyFactory.Instance.CreateBy(commandPair);
                        targetHeader = ((ITarget)fileSearchKey).CreateTarget();
                        targetTail = targetHeader;
                    }
                    else
                    {
                        var commandPair = new CommandPair("-f", files[index]);
                        IKeySetting fileSearchKey = KeyFactory.Instance.CreateBy(commandPair);
                        targetTail.NextTarget = ((ITarget)fileSearchKey).CreateTarget();
                    }
                }
                return targetHeader;
            }
            //当时文件的情况
            if (File.Exists(Value))
            {
                var target = new GitFile(Value, CommandExcute);
                return target;
            }
            return default(IExcuteTarget);
        }
    }
}
