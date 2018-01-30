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
        public const string ParamterSplit = "&";
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
            IKeySetting fileSearchKey = KeyFactory.Instance.CreateBy(commandPairs.First());
            IExcuteTarget excuteTarget = ((ITarget)fileSearchKey).CreateTarget();
            IExcuteTarget contextTarget = excuteTarget;
            #region 配置处理链
            IKeySetting templateKeySetting = null;
            IKeySetting templateKeyTail = null;
            for (int index = 1, length = commandPairs.Count; index < length; index++)
            {
                if (index == 1)
                {
                    templateKeySetting = KeyFactory.Instance.CreateBy(commandPairs[index]);
                    templateKeyTail = templateKeySetting;
                }
                else
                {
                    templateKeyTail.CommandExcute.NextKeySetting = KeyFactory.Instance.CreateBy(commandPairs[index]);
                    templateKeyTail = templateKeyTail.CommandExcute.NextKeySetting;
                }
            }
            #endregion
            #region 配置处理链的上下文
            while (contextTarget != null)
            {
                contextTarget.Header.NextKeySetting = templateKeySetting;
                contextTarget = contextTarget.NextTarget;
            }
            #endregion
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
                    paramter = string.IsNullOrEmpty(paramter) ? command : string.Format("{0}{1}{2}", paramter, ParamterSplit, command);
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
    /// <summary>
    /// 命令执行器
    /// </summary>
    public class CommandEngine
    {
        public void Excute(IExcuteTarget excuteTarget)
        {
            var contextTarget = excuteTarget;
            var defaultContextTarget = new DefaultContextTarget();
            while (contextTarget != null)
            {
                //执行处理链
                contextTarget.Header.Excute(defaultContextTarget);
                var excuteContext = contextTarget.Header.NextKeySetting;
                while (excuteContext != null)
                {
                    excuteContext.CommandExcute.Excute(defaultContextTarget);
                    excuteContext = excuteContext.CommandExcute.NextKeySetting;
                }
                //再来一次处理下一个文件目标
                contextTarget = contextTarget.NextTarget;
                defaultContextTarget.Dispose();
            }
            //构建文件
            WebXmlContainer.BuildFile();
        }
    }
}
