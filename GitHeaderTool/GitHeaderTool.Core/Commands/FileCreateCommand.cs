using System;
using System.Collections.Generic;
namespace GitHeaderTool.Core.Commands
{
    /// <summary>
    /// 文件创建命令
    /// </summary>
    public class FileCreateCommand:ICommandExcute
    {
        public IKeySetting CommandKey { get;private set; }
        public FileCreateCommand(IKeySetting keySetting)
        {
            CommandKey = keySetting;
        }

        public void Excute(IContextTarget contextTarget)
        {
            string filePath = CommandKey.Value;
            WebXmlContainer.CreateFile(filePath);
            List<string> dataContext =(List<string>)contextTarget.ContextResult[ECommandLevel.s];
            WebXmlContainer.AppendToFile(filePath, dataContext);
        }

        public IKeySetting NextKeySetting { get; set; }
    }
}
