using System;
using System.IO;
using GitHeaderTool.Core;

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
        public void Excute(IContextTarget contextTarget)
        {
            contextTarget.FilePath = CommandKey.Value;
            string fileContext= File.ReadAllText(contextTarget.FilePath);
            contextTarget.ContextResult.Add(ECommandLevel.f, fileContext);
        }
        /// <summary>
        /// 设置下一个执行Key
        /// </summary>
        public IKeySetting NextKeySetting { get; set; }
    }
}
