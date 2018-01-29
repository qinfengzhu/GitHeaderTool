using System;
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

        public IExcuteResult Excute()
        {
            throw new NotImplementedException();
        }

        public ICommandExcute SetNextCommand(ICommandExcute nextCommand)
        {
            throw new NotImplementedException();
        }
    }
}
