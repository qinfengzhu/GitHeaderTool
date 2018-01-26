namespace GitHeaderTool.Core
{
    /// <summary>
    /// 命令执行者
    /// </summary>
    public interface ICommandExcute
    {
        IKeySetting CommandKey { get; }
        IExcuteResult Excute();
        ICommandExcute SetNextCommand(ICommandExcute nextCommand);
    }
}
