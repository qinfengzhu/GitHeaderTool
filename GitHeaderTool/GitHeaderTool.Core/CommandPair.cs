using System;
using System.Collections.Generic;

namespace GitHeaderTool.Core
{
    /// <summary>
    /// 参数命令对
    /// </summary>
    public class CommandPair : IComparable<CommandPair>, IEquatable<CommandPair>,IComparer<CommandPair>
    {
        public string Key { get; private set; }
        public string Paramater { get; private set; }
        public ECommandLevel CommandLevel { get; private set; }
        public CommandPair(string key, string paramater)
        {
            Key = key;
            Paramater = paramater;
            CommandLevel = CreateLevel(key);
        }
        public int Compare(CommandPair x, CommandPair y)
        {
            return (int)x.CommandLevel - (int)y.CommandLevel;
        }
        public int CompareTo(CommandPair other)
        {
            return Compare(this, other);
        }

        public bool Equals(CommandPair other)
        {
            return string.Equals(Key, other.Key, StringComparison.CurrentCultureIgnoreCase);
        }
        public const string f = "-f";
        public const string s = "-s";
        public const string x = "-x";
        public const string r = "-r";
        public const string a = "-a";
        static ECommandLevel CreateLevel(string key)
        {
            switch (key)
            {
                case f:
                    return ECommandLevel.f;
                case s:
                    return ECommandLevel.s;
                case x:
                    return ECommandLevel.x;
                case r:
                    return ECommandLevel.r;
                case a:
                    return ECommandLevel.a;
                default:
                    return ECommandLevel.n;
            }
        }
    }
}
