namespace GitHeaderTool.Core
{
    /// <summary>
    /// 命令关键字
    /// </summary>
    public interface IKeySetting
    {
        string Key { get; set; }
        IExcuteTarget CreateTarget();
        IExcuteTarget CreateTarget(IExcuteResult excuteResult);
    }
}
