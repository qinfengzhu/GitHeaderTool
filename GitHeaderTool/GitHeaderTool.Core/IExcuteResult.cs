namespace GitHeaderTool.Core
{
    /// <summary>
    /// 执行结果
    /// </summary>
    public interface IExcuteResult
    {
        string CurrentValue { get; set; }
        IExcuteTarget CurrentTarget { get; }
        IExcuteTarget GetNextTarget(IKeySetting keySetting);
    }
}
