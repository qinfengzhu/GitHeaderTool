using System;
namespace GitHeaderTool.Core.Targets
{
    /// <summary>
    /// Git 的文件处理
    /// </summary>
    public class GitFile:IExcuteTarget
    {
        public ICommandExcute Header
        {
            get { throw new NotImplementedException(); }
        }
    }
}
