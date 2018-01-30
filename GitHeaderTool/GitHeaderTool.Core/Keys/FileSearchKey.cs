using GitHeaderTool.Core.Targets;
using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;
namespace GitHeaderTool.Core.Keys
{
    /// <summary>
    /// 文件查询Key
    /// </summary>
    [KeyLevel(CommandLevel = ECommandLevel.f)]
    public class FileSearchKey : IKeySetting, ITarget
    {
        /// <summary>
        /// 命令关键字
        /// </summary>
        public string Key { get; private set; }
        /// <summary>
        /// 命令参数值
        /// </summary>
        public string Value { get; private set; }
        /// <summary>
        /// 执行优先等级
        /// </summary>
        public int Level { get; private set; }
        /// <summary>
        /// 对应的命令
        /// </summary>
        public ICommandExcute CommandExcute { get; private set; }
        public FileSearchKey(string key,string value)
        {
            Key = key;
            Value = value;
            Level = (int)ECommandLevel.f;
        }
        public T Accept<T>(CommandConverter<T> converter) where T:ICommandExcute
        {
            var commandExcute= converter.ConvertFileSearchKey(this);
            CommandExcute = commandExcute;
            return commandExcute;
        }
        /// <summary>
        /// 创建处理目标
        /// </summary>
        /// <returns></returns>
        public IExcuteTarget CreateTarget()
        {
            if (Value.Contains(CommandParser.ParamterSplit))
            {
                var p = Value.Split(CommandParser.ParamterSplit[0]);
                string dir = p[0];
                string searchConditon = p[1];
                var files = searchConditon.GetFiles(dir);
                IExcuteTarget targetHeader = null;
                IExcuteTarget targetTail = null;
                for (int index=0,length=files.Count;index<length;index++)
                {
                    if (index == 0)
                    {
                        var commandPair = new CommandPair("-f", files[index]);
                        IKeySetting fileSearchKey = KeyFactory.Instance.CreateBy(commandPair);
                        targetHeader = ((ITarget)fileSearchKey).CreateTarget();
                        targetTail = targetHeader;
                    }
                    else
                    {
                        var commandPair = new CommandPair("-f", files[index]);
                        IKeySetting fileSearchKey = KeyFactory.Instance.CreateBy(commandPair);
                        targetTail.NextTarget = ((ITarget)fileSearchKey).CreateTarget();
                        targetTail = targetTail.NextTarget;
                    }
                }
                return targetHeader;
            }
            //当时文件的情况
            if (File.Exists(Value))
            {
                var target = new GitFile(Value, CommandExcute);
                return target;
            }
            return default(IExcuteTarget);
        }
    }
    internal static class DirectoryExtension
    {
        public static List<string> GetFiles(this string pattern,string dir)
        {
            var childrenDirectories = Directory.GetDirectories(dir);
            var files = new List<string>() ;
            foreach (var childrenDir in childrenDirectories)
            {
                //当前文件夹文件
                var currentDirFiles = pattern.Split('|').SelectMany(p => Directory.GetFiles(childrenDir, p)).ToList();
                //递归获取文件
                var moreFiles = pattern.GetFiles(childrenDir).ToList();
                files.AddRange(currentDirFiles);
                files.AddRange(moreFiles);
            }
            return files;
        }
    }
}
