using GitHeaderTool.Core.Targets;
using System;
using System.Collections.Generic;
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
        public static ICommandExcute ParserToCommand(params object[] commands)
        {
            //检查命令格式
            if (commands == null)
            {
                PrintError("GitHeaderTool 需要参数处理");
                return null;
            }
            if (commands.Length == 1 && commands[0].ToString() == "-help" || commands[0].ToString() == "help")
            {
                PrintHelpInfo();
                return null;
            }
            //处理命令对
            foreach (var command in commands)
            {

            }
            //分配命令
            
            return null;
        }
        internal static void PrintHelpInfo()
        {
            StringBuilder helpInfo = new StringBuilder();
            helpInfo.AppendLine("GitHeaderTool 工具帮助文档");
            helpInfo.AppendLine("-f: 查找配对文件(参数1:目录;参数2:查询条件,当没有目录的时候为当前目录) ");
            helpInfo.AppendLine("-s: 查找文件中的内容(参数1:正则表达式)");
            helpInfo.AppendLine("-r: 删除文件中的内容(参数1:正则表达式)");
            helpInfo.AppendLine("-a: 追加内容到文件头部(参数1:文本内容)");
            helpInfo.AppendLine("-x: 配合-s命令,把查询到的内容导入到指定xml文件中(参数1:xml文件的路径)");
            Console.Write(helpInfo.ToString());
        }
        internal static void PrintError(string errorInfo)
        {
            StringBuilder helpInfo = new StringBuilder();
            helpInfo.AppendLine(errorInfo);
            Console.Write(helpInfo.ToString());
        }
    }
}
