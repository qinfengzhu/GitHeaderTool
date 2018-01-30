using System;
namespace GitHeaderTool.Core.Commands
{
    /// <summary>
    /// 文件内容抓取命令
    /// </summary>
    public class ContentCatCommand:ICommandExcute
    {
        public IKeySetting CommandKey { get; private set; }
        public ContentCatCommand(IKeySetting keySetting)
        {
            CommandKey = keySetting;
        }

        public void Excute(IContextTarget contextTarget)
        {
            throw new NotImplementedException();
        }

        public IKeySetting NextKeySetting { get; set; }
    }
}
