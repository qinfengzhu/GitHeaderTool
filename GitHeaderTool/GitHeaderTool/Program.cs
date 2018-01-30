using GitHeaderTool.Core;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHeaderTool
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandEngine = new CommandEngine();
            var result = commandEngine.Excute(args);
            if (result == true)
            {
                #if DEBUG
                Trace.Write("执行成功");
                #endif
                #if !DEBUG
                Console.Write("执行成功,按任意键可以退出");
                #endif
            }
            else
            {
                #if DEBUG
                Trace.Write("执行失败");
                #endif
                #if !DEBUG
                Console.Write("执行失败,按任意键可以退出");
                #endif
            }
            #if !DEBUG
            Console.ReadLine();
            #endif
        }
    }
}
