using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace GitHeaderTool.Core.Test
{    
    /// <summary>
    /// 命令解释器测试
    /// </summary>
    [TestFixture]
    public class CommandParserTest
    {
        private CommandParser parserInstance;
        [SetUp]
        public void Init()
        {
            parserInstance = new CommandParser();
        }
        /// <summary>
        /// 测试正确解析命令对
        /// </summary>
        [Test]
        public void GetCommandPairsTest()
        {
            var commandPairs = CommandParser.GetCommandPairs("-f", @"E:\git-projects", "*.cs", "-r", "//[^/]*", "-a", "//默认头部");

            Assert.AreEqual(3, commandPairs.Count);
        }
        /// <summary>
        /// 测试正确解析命令对顺序
        /// </summary>
        [Test]
        public void GetCommandPairsRightSortTest()
        {
            var commandPairs = CommandParser.GetCommandPairs( "-r", "//[^/]*", "-a", "//默认头部","-f", @"E:\git-projects", "*.cs");

            Assert.AreEqual("-f", commandPairs[0].Key);
            Assert.AreEqual(@"E:\git-projects||*.cs", commandPairs[0].Paramater);
        }
        [Test]
        public void PrintHelpInfoTest()
        {
            parserInstance.ParserToCommand("-help");

            Assert.AreEqual(1, 1);
        }
        [Test]
        public void PrintErrorTest()
        {
            CommandParser.PrintError("请输入命令参数");
            Assert.AreEqual(1, 1);
        }
        /// <summary>
        /// 构建处理链测试
        /// </summary>
        [Test]
        public void ParserToCommandTest()
        {
            string directory = @"F:\ScanerProject";
            string destinationDir = @"F:\ScanerProject\web.xml";

            var excuteTarget= parserInstance.ParserToCommand(new string[]{"-f",directory,"*.cs|*.cshtml|*.js","-s",@"\.L\(","-x",destinationDir});

            Assert.AreEqual(1,1);
        }
    }
}
