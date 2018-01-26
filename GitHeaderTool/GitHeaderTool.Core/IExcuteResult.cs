namespace GitHeaderTool.Core
{
    /// <summary>
    /// 执行结果
    /// </summary>
    public interface IExcuteResult
    {
        IExcuteTarget CurrentTarget { get; }
        IExcuteTarget GetNextTarget(IKeySetting keySetting);
    }
}
