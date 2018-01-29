namespace GitHeaderTool.Core
{
    /// <summary>
    /// 执行目标
    /// </summary>
    public interface IExcuteTarget
    {
        string Path { get; }
        /// <summary>
        /// 命令头部
        /// </summary>
        ICommandExcute Header { get; }
    }
}
