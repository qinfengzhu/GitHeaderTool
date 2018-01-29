using GitHeaderTool.Core.Keys;
using GitHeaderTool.Core.Targets;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace GitHeaderTool.Core
{
    /// <summary>
    /// 命令解析器
    /// 目前解析的命令,命令之间用空格隔开,参数与命令之间也用空格隔开
    /// -f: 查找文件
    /// -s: 查找文件中的内容
    /// -r: 删除查找到的文件内容
    /// -a: 追加内容到文件头部
    /// -x: 把查找到的内容以xml的文件放到指定文件中,格式如下
    /// <?xml version="1.0" encoding="utf-8" ?>
    /// <localizationDictionary culture="">
    ///  <texts>
    ///    <text name="Login">Login</text>
    ///  </texts>
    /// </localizationDictionary>
    /// </summary>
    public class CommandParser
    {
        public CommandParser() { }
        public IExcuteTarget ParserToCommand(params string[] commands)
        {
            //检查命令格式
            if (commands == null)
            {
                PrintError("GitHeaderTool 需要参数处理");
                return default(IExcuteTarget);
            }
            if (commands.Length == 1 && commands[0].ToString() == "-help" || commands[0].ToString() == "help")
            {
                PrintHelpInfo();
                return default(IExcuteTarget); ;
            }
            //分配命令
            var commandPairs = GetCommandPairs(commands);
            //检查分配的命令
            if(commandPairs.Count<2)
            {
                PrintError("命令缺失");
                return default(IExcuteTarget); 
            }
            if(commandPairs.First().CommandLevel!=ECommandLevel.f)
            {
                PrintError("命令最少要包含 -f 操作");
                return default(IExcuteTarget); 
            }
            //分配KeySetting
            IExcuteTarget excuteTarget = null;
            IKeySetting fileSearchKey = KeyFactory.Instance.CreateBy(commandPairs.First());
            excuteTarget = ((ITarget)fileSearchKey).CreateTarget();
            //配置处理链
            var currentExcuteTarget = excuteTarget;
            while (currentExcuteTarget!= null)
            {
                //配置后续的key处理
                var nexkeyTail = currentExcuteTarget.Header.NextKeySetting;
                for (int index = 1, length = commandPairs.Count; index < length;index++ )
                {
                    IKeySetting keySetting = KeyFactory.Instance.CreateBy(commandPairs[index]);
                    if (index == 1)
                    {
                        currentExcuteTarget.Header.NextKeySetting = keySetting;                        
                    }
                    else
                    {
                        nexkeyTail.CommandExcute.NextKeySetting = keySetting;
                    }
                    nexkeyTail = keySetting;
                }
                //跳转到下一个target处理
                currentExcuteTarget = currentExcuteTarget.NextTarget;
            }
            return excuteTarget;
        }
        /// <summary>
        /// 获取排序好的命令
        /// </summary>
        /// <param name="commands">命令集合</param>
        /// <returns>返回排序好的命令</returns>
        internal static List<CommandPair> GetCommandPairs(params string[] commands)
        {
            List<CommandPair> commandPairs = new List<CommandPair>(); 
            //处理命令对
            string key = string.Empty;
            string paramter = string.Empty;
            string paramterSplit = "|";

            for (int index=0, length = commands.Length; index < length;index++ )
            {
                string command = commands[index];
                if(command.StartsWith("-"))
                {
                    key = command;
                    paramter = string.Empty;
                }
                else
                {
                    paramter = string.IsNullOrEmpty(paramter) ? command : string.Format("{0}{1}{2}", paramter, paramterSplit, command);
                    if ((index+1<length&& commands[index + 1].StartsWith("-"))||index==length-1)
                    {
                        commandPairs.Add(new CommandPair(key, paramter));
                    }
                }
            }
            commandPairs.Sort();
            return commandPairs;
        }
        /// <summary>
        /// 打印帮助信息
        /// </summary>
        internal static void PrintHelpInfo()
        {
            StringBuilder helpInfo = new StringBuilder();
            helpInfo.AppendLine("GitHeaderTool 工具帮助文档");
            helpInfo.AppendLine("-f: 查找配对文件(参数1:目录;参数2:查询条件,当没有目录的时候为当前目录) ");
            helpInfo.AppendLine("-s: 查找文件中的内容(参数1:正则表达式)");
            helpInfo.AppendLine("-r: 删除文件中的内容(参数1:正则表达式)");
            helpInfo.AppendLine("-a: 追加内容到文件头部(参数1:文本内容)");
            helpInfo.AppendLine("-x: 配合-s命令,把查询到的内容导入到指定xml文件中(参数1:xml文件的路径)");
            #if DEBUG
            Trace.Write(helpInfo.ToString());
            #endif
            #if RELEASE
            Console.Write(helpInfo.ToString());
            #endif
        }
        /// <summary>
        /// 打印错误信息
        /// </summary>
        /// <param name="errorInfo">错误信息</param>
        internal static void PrintError(string errorInfo)
        {
            StringBuilder helpInfo = new StringBuilder();
            helpInfo.AppendLine(errorInfo);
            #if DEBUG
            Trace.Write(errorInfo);
            #endif
            #if RELEASE
            Console.Write(helpInfo.ToString());
            #endif
        }
    }
}
