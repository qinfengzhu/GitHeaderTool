namespace GitHeaderTool.Core
{
    /// <summary>
    /// 执行目标
    /// </summary>
    public interface IExcuteTarget
    {
        /// <summary>
        /// 命令头部
        /// </summary>
        ICommandExcute Header { get; }
    }
}
