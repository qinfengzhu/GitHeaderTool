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
