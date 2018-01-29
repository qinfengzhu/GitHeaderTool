using System;
namespace GitHeaderTool.Core.Results
{
    /// <summary>
    /// 正则的结果
    /// </summary>
    public class RegularResult:IExcuteResult
    {
        public string CurrentValue { get; set; }
        public IExcuteTarget CurrentTarget
        {
            get { throw new NotImplementedException(); }
        }

        public IExcuteTarget GetNextTarget(IKeySetting keySetting)
        {
            throw new NotImplementedException();
        }
    }
}
