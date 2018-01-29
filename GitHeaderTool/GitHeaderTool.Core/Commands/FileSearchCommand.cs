using System;
namespace GitHeaderTool.Core.Commands
{
    /// <summary>
    /// 文件搜索命令
    /// </summary>
    public class FileSearchCommand:ICommandExcute
    {
        public IKeySetting CommandKey { get; private set; }
        public FileSearchCommand(IKeySetting keySetting)
        {
            CommandKey = keySetting;
        }
        /// <summary>
        /// 返回文件路径
        /// </summary>
        /// <returns></returns>
        public object Excute()
        {
            return CommandKey.Value;
        }
        /// <summary>
        /// 设置下一个执行Key
        /// </summary>
        public IKeySetting NextKeySetting { get; set; }
    }
}
