using System;
using System.Text;
namespace GitHeaderTool.Core.Commands
{
    /// <summary>
    /// 文件内容追加命令
    /// </summary>
    public class FileContentAddCommand:ICommandExcute
    {
        public IKeySetting CommandKey { get; private set; }
        public FileContentAddCommand(IKeySetting keySetting)
        {
            CommandKey = keySetting;
        }

        public void Excute(IContextTarget contextTarget)
        {
            StringBuilder content = new StringBuilder(CommandKey.Value);
            string fileContent = (string)contextTarget.ContextResult[ECommandLevel.f];
            contextTarget.ContextResult[ECommandLevel.f] = content.AppendLine().Append(fileContent).ToString();
        }

        public IKeySetting NextKeySetting { get; set; }
    }
}
