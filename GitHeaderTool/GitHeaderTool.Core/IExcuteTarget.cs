namespace GitHeaderTool.Core
{
    /// <summary>
    /// 执行目标
    /// </summary>
    public interface IExcuteTarget
    {
        ICommandExcute Header { get; }
    }
}
