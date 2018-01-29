using System;
namespace GitHeaderTool.Core.Targets
{
    /// <summary>
    /// Git 的文件处理
    /// </summary>
    internal class GitFile : IExcuteTarget
    {
        public string Path { get; private set; }
        public GitFile(CommandPair commandPair)
        {
            Path = commandPair.Paramater;
        }
        public ICommandExcute Header { get; private set; }
    }
}
