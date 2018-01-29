using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.IO;

namespace GitHeaderTool.Core.Test
{
    [TestFixture]
    /// <summary>
    /// 文件夹查询测试
    /// </summary>
    public class DirectorySearchTest
    {
        private string directoryPath;
        [SetUp]
        public void Init()
        {
            directoryPath = Path.Combine(@"E:\git-projects\Castle-OlderVersion\Castle.Core-READONLY-Release-Jan-06\InversionOfControl\Castle.MicroKernel.Tests");
        }
        /// <summary>
        /// 根据文件扩展名查询文件
        /// </summary>
        [Test]
        public void SearchFilesByExtension()
        {
            var csharpFiles=Directory.GetFiles(directoryPath, "*.cs", SearchOption.AllDirectories);

            Assert.Greater(csharpFiles.Count(),0);
        }
        /// <summary>
        /// 根据文件指定名称查询文件
        /// </summary>
        [Test]
        public void SearchFilesByDefineName()
        {
            var oneFile = Directory.GetFiles(directoryPath, "GraphTestCase.cs", SearchOption.AllDirectories);

            Assert.AreEqual(1, oneFile.Count());
        }
        /// <summary>
        /// 根据文件模糊名称查询文件
        /// </summary>
        [Test]
        public void SearchFilesByLikeName()
        {

        }
        /// <summary>
        /// 正则表达式方式查询文件
        /// </summary>
        [Test]
        public void SearchFilesByRegular()
        {

        }
    }
}
