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
        /// 执行命令
        /// </summary>
        void Excute(IContextTarget contextTarget);
        /// <summary>
        /// 下一个关键字命令
        /// </summary>
        IKeySetting NextKeySetting { get; set; }
    }
}
