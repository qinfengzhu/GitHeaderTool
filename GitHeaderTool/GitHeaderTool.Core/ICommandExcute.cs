namespace GitHeaderTool.Core
{
    /// <summary>
    /// 命令执行者
    /// </summary>
    public interface ICommandExcute
    {
        /// <summary>
        /// 命令关键字
        /// </summary>
        IKeySetting CommandKey { get;}
        /// <summary>
        /// 执行结果
        /// </summary>
        /// <returns>执行结果</returns>
        IExcuteResult Excute();
        /// <summary>
        /// 设置下一个执行命令
        /// </summary>
        /// <param name="nextCommand">下一个执行命令</param>
        /// <returns>结尾执行命令</returns>
        ICommandExcute SetNextCommand(ICommandExcute nextCommand);

    }
}
