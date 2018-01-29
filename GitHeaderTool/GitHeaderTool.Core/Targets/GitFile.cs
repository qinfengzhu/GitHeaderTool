using System;
namespace GitHeaderTool.Core.Targets
{
    /// <summary>
    /// Git 的文件处理
    /// </summary>
    internal class GitFile : IExcuteTarget
    {
        public string Path { get; private set; }
        public GitFile(string filePath,ICommandExcute commandExcute)
        {
            Path = filePath;
            Header = commandExcute;
        }
        /// <summary>
        /// 命令执行头部
        /// </summary>
        public ICommandExcute Header { get; private set; }
        /// <summary>
        /// 下一个处理目标
        /// </summary>
        public IExcuteTarget NextTarget { get; set; }
    }
}
