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
        /// <summary>
        /// 下一个处理目标
        /// </summary>
        IExcuteTarget NextTarget { get; set; }
    }
}
