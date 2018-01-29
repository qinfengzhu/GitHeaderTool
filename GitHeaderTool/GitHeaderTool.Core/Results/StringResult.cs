using System;
namespace GitHeaderTool.Core.Results
{
    /// <summary>
    /// 字符关键字的结果
    /// </summary>
    public class StringResult:IExcuteResult
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
