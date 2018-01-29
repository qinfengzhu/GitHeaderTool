using System;
namespace GitHeaderTool.Core.Targets
{
    /// <summary>
    /// Git 的文件夹处理
    /// </summary>
    internal class GitDirectory : IExcuteTarget
    {
        public string Path { get; private set; }
        public GitDirectory(CommandPair commandPair)
        {
            Path = commandPair.Paramater;
        }
        public ICommandExcute Header { get; private set; }
    }
}
