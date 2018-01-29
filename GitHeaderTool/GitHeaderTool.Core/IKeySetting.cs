namespace GitHeaderTool.Core
{
    /// <summary>
    /// 命令关键字
    /// </summary>
    public interface IKeySetting
    {
        /// <summary>
        /// 命令Key
        /// </summary>
        string Key { get;}
        /// <summary>
        /// 参数值
        /// </summary>
        string Value { get; }
        /// <summary>
        /// 权重
        /// </summary>
        int Level { get;}
        T Accept<T>(CommandConverter<T> converter);
        IExcuteTarget CreateTarget();
        IExcuteTarget CreateTarget(IExcuteResult excuteResult);
    }
}
