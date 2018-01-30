using System;
using System.Text.RegularExpressions;

namespace GitHeaderTool.Core.Commands
{
    /// <summary>
    /// 文件内容删除命令
    /// </summary>
    public class FileContentRemoveCommand : ICommandExcute
    {
        public IKeySetting CommandKey { get; private set; }
        public FileContentRemoveCommand(IKeySetting keySetting)
        {
            CommandKey = keySetting;
        }
        public void Excute(IContextTarget contextTarget)
        {
            string fileContext = (string)contextTarget.ContextResult[ECommandLevel.f];
            Regex rgx = new Regex(CommandKey.Value);
            rgx.Replace(fileContext, string.Empty);
            contextTarget.ContextResult[ECommandLevel.f] = fileContext;
        }
        public IKeySetting NextKeySetting { get; set; }
    }
}
