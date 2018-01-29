using System;
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

        public object Excute()
        {
            throw new NotImplementedException();
        }
        public IKeySetting NextKeySetting { get; set; }
    }
}
