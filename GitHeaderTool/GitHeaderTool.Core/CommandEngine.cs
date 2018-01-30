using System;
using System.Collections.Generic;
using System.Linq;

namespace GitHeaderTool.Core
{
    /// <summary>
    /// 命令执行器
    /// </summary>
    public class CommandEngine
    {
        private CommandParser m_commandParser;
        public CommandEngine()
        {
            m_commandParser = new CommandParser();
        }
        public bool Excute(string[] commands)
        {
            bool sucess = true;
            try
            {
                var excuteTarget = m_commandParser.ParserToCommand(commands);
                Excute(excuteTarget);                
            }
            catch
            {
                sucess= false;
            }
            return sucess;
        }
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
                defaultContextTarget.Dispose();
                contextTarget = contextTarget.NextTarget;                
            }
            //构建文件
            WebXmlContainer.BuildFile();
        }
    }
}
