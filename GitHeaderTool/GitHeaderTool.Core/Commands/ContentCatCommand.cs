using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
        /// <summary>
        /// 查找文件中的内容
        /// </summary>
        /// <param name="contextTarget">执行上下文</param>
        public void Excute(IContextTarget contextTarget)
        {
            string fileContext =(string)contextTarget.ContextResult[ECommandLevel.f];
            MatchCollection matches = Regex.Matches(fileContext, CommandKey.Value,RegexOptions.Multiline);
            List<string> matchContent = new List<string>();
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    if (match.Groups.Count > 1)
                    {
                        string lastValue = match.Groups[1].Value;
                        matchContent.Add(lastValue);
                    }
                    else
                    {
                        matchContent.Add(match.Value);
                    }
                }
            }
            contextTarget.ContextResult.Add(ECommandLevel.s, matchContent);
        }

        public IKeySetting NextKeySetting { get; set; }
    }
}
