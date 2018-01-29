using System;
using System.Collections.Generic;
using System.Linq;

namespace GitHeaderTool.Core.Keys
{
    /// <summary>
    /// Key 创建的工厂类
    /// </summary>
    public class KeyFactory
    {
        private static Dictionary<ECommandLevel, Type> Keys;
        private static CmdCommandConverter CommandConverter;
        private KeyFactory() { }
        private static KeyFactory _instance;
        public static KeyFactory Instance
        {
            get { return _instance; }
        }
        static KeyFactory()
        {
            if (Keys == null)
            {
                Keys = new Dictionary<ECommandLevel, Type>();
            }
            CommandConverter = new CmdCommandConverter();
            var keyTypes= AppDomain.CurrentDomain.GetAssemblies().SelectMany(p => p.GetTypes()).Where(
                t => t.GetInterfaces().Contains(typeof(IKeySetting)) 
                && t.GetCustomAttributes(typeof(KeyLevelAttribute),false).Count() > 0
            );
            foreach(var keyType in keyTypes)
            {
                var commandLevel =(KeyLevelAttribute) keyType.GetCustomAttributes(typeof(KeyLevelAttribute), false).FirstOrDefault();
                Keys.Add(commandLevel.CommandLevel, keyType);
            }
            _instance = new KeyFactory();
        }
        internal IKeySetting CreateBy(CommandPair commandPair)
        {
            var keySettingType = Keys[commandPair.CommandLevel];
            var keySetting=(IKeySetting)Activator.CreateInstance(keySettingType, new object[] { commandPair.Key,commandPair.Paramater });
            keySetting.Accept<ICommandExcute>(CommandConverter);
            return keySetting;
        }
    }
}
