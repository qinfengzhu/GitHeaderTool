using System;
namespace GitHeaderTool.Core.Commands
{
    /// <summary>
    /// 文件创建命令
    /// </summary>
    public class FileCreateCommand:ICommandExcute
    {
        public IKeySetting CommandKey
        {
            get { throw new NotImplementedException(); }
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
