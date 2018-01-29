namespace GitHeaderTool.Core
{
    /// <summary>
    /// 命令关键字
    /// </summary>
    public interface IKeySetting:IContextTarget
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
        /// <summary>
        /// 对应的命令
        /// </summary>
        ICommandExcute CommandExcute { get; }
        T Accept<T>(CommandConverter<T> converter) where T : ICommandExcute;        
    }
    /// <summary>
    /// 创建目标-这里指创建文件
    /// </summary>
    public interface ITarget
    {
        /// <summary>
        /// 创建目标
        /// </summary>
        /// <returns>创建目标</returns>
        IExcuteTarget CreateTarget();
    }
    /// <summary>
    /// 处理上下文目标-这里指文件
    /// </summary>
    public interface IContextTarget
    {
        IExcuteTarget ContextTarget { get; set; }
    }
}
