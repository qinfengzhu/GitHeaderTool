using System;
namespace GitHeaderTool.Core.Commands
{
    /// <summary>
    /// 文件内容删除命令
    /// </summary>
    public class FileContentRemoveCommand:ICommandExcute
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
