using System;

namespace GitHeaderTool.Core
{
    /// <summary>
    /// 参数命令对
    /// </summary>
    internal class CommandPair : IComparable<CommandPair>, IEquatable<CommandPair>
    {
        public string Key { get; private set; }
        public string Paramater { get; private set; }
        public CommandPair(string key, string paramater)
        {
            Key = key;
            Paramater = paramater;
        }

        public int CompareTo(CommandPair other)
        {
            return string.Compare(Key, other.Key, true);
        }

        public bool Equals(CommandPair other)
        {
            return string.Equals(Key, other.Key, StringComparison.CurrentCultureIgnoreCase);
        }
    }
}
