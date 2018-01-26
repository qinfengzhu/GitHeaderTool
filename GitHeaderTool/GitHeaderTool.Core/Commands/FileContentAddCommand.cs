using System;
namespace GitHeaderTool.Core.Commands
{
    /// <summary>
    /// 文件内容追加命令
    /// </summary>
    public class FileContentAddCommand:ICommandExcute
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
