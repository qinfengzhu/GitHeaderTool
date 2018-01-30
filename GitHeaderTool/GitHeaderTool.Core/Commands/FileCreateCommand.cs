using System;
namespace GitHeaderTool.Core.Commands
{
    /// <summary>
    /// 文件创建命令
    /// </summary>
    public class FileCreateCommand:ICommandExcute
    {
        public IKeySetting CommandKey { get;private set; }
        public FileCreateCommand(IKeySetting keySetting)
        {
            CommandKey = keySetting;
        }

        public void Excute(IContextTarget contextTarget)
        {
            throw new NotImplementedException();
        }

        public IKeySetting NextKeySetting { get; set; }
    }
}
