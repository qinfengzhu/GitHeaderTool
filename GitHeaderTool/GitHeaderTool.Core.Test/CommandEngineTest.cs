using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace GitHeaderTool.Core.Test
{
    /// <summary>
    /// 测试命令引擎类
    /// </summary>
    [TestFixture]
    public class CommandEngineTest
    {
        private CommandEngine commandEngine;
        [SetUp]
        public void Init()
        {
            commandEngine = new CommandEngine();
        }
        /// <summary>
        /// 场景一:测试删除 github 某个项目的 .cs文件的头部注释部分
        /// </summary>
        [Test]
        public void ExcuteRemoveGitFileHeader()
        {
            string[] commands = new string[]
            {
                "-f",@"D:\git-project\Castle.Core","*.cs",
                "-r",@"^\s*//[\s\S]*?$\n",
            };
            bool result=commandEngine.Excute(commands);
            Assert.AreEqual(true, result);
        }
        /// <summary>
        /// 场景二:给自己的项目中 .cs 文件加头部
        /// </summary>
        [Test]
        public void ExcuteAppendGitFileHeader()
        {
            string[] commands = new string[]
            {
                "-f",@"D:\git-project\MyProject","*.cs",
                "-a",@"/*\r\n* @Author bestkf\r\n* @Time 2018-01-30 \r\n*/\r\n",
            };
            bool result = commandEngine.Excute(commands);
            Assert.AreEqual(true, result);
        }
        /// <summary>
        /// 场景三:提取项目文件(*.cs|*.cshtml|*.js)中的匹配内容放到 xml文件中
        /// </summary>
        [Test]
        public void ExcuteCatContentToXmlFile()
        {
            string[] commands = new string[]
            {
                "-f",@"D:\git-project\MyProject","*.cs|*.cshtml|*.js",
                "-s","L\\(['\"]{1}([^;\\)]+)['\"]{1}\\)",
                "-x",@"D:\git-project\myweb.xml",
            };
            bool result = commandEngine.Excute(commands);
            Assert.AreEqual(true, result);
        }
    }
}
