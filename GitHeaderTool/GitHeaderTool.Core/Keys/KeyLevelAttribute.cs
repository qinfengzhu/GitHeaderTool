using System;
namespace GitHeaderTool.Core.Keys
{
    [AttributeUsage(AttributeTargets.Class,Inherited=false)]
    public class KeyLevelAttribute:Attribute
    {
        public ECommandLevel CommandLevel { get; set; }
    }
}
