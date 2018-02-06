using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.IO;

namespace GitHeaderTool.Core.Test
{
    /// <summary>
    /// 工具在项目工程上测试
    /// </summary>
    [TestFixture]
    public class ProjectTest
    {
        private string ProjectPath;
        private CommandEngine commandEngine;
        private string XmlPath;
        [SetUp]
        public void Init()
        {
            ProjectPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "TestFiles");
            XmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "XmlFolder", "web.xml");
            commandEngine = new CommandEngine();
        }
        /// <summary>
        /// 场景一:测试删除 github 某个项目的 .cs文件的头部注释部分
        /// </summary>
        [Test]
        public void ProjectRemoveGitFileHeader()
        {
            string[] commands = new string[]
            {
                "-f",ProjectPath,"*.cs",
                "-r",@"^\s*//[^/]{1}[\s\S]*?$\n",
            };
            bool result = commandEngine.Excute(commands);
            Assert.AreEqual(true, result);
        }
        /// <summary>
        /// 场景二:给自己的项目中 .cs 文件加头部
        /// </summary>
        [Test]
        public void ProjectAppendGitFileHeader()
        {
            string[] commands = new string[]
            {
                "-f",ProjectPath,"*.cs",
                "-a","/*\r\n* @Author bestkf\r\n* @Time 2018-01-30 \r\n*/\r\n",
            };
            bool result = commandEngine.Excute(commands);
            Assert.AreEqual(true, result);
        }
        /// <summary>
        /// 场景三:提取项目文件(*.cs|*.cshtml|*.js)中的匹配内容放到 xml文件中
        /// </summary>
        [Test]
        public void ProjectCatContentToXmlFile()
        {
            string[] commands = new string[]
            {
                "-f",ProjectPath,"*.cs|*.cshtml|*.js",
                "-s","L\\(['\"]{1}([^;\\)]+)['\"]{1}\\)",
                "-x",XmlPath,
            };
            bool result = commandEngine.Excute(commands);
            Assert.AreEqual(true, result);
        }
        /// <summary>
        /// 测试本地一个大的项目工程
        /// </summary>
        [Test]
        public void TestCastleProject()
        {
            string castleProjectPath = @"E:\git-projects\Castle-OlderVersion\Castle.Core-READONLY-Release-Jan-06\InversionOfControl";

            string[] commands = new string[]
            {
                "-f",castleProjectPath,"*.cs",
                "-r",@"^\s*//[^/]{1}[\s\S]*?$\n",
            };
            bool result = commandEngine.Excute(commands);
            Assert.AreEqual(true, result);
        }
    }
}
