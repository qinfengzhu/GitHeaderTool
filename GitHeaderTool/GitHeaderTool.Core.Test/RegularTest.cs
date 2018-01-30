using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using System.Text.RegularExpressions;
using System.IO;

namespace GitHeaderTool.Core.Test
{
    /// <summary>
    /// 正则表达式功能测试
    /// </summary>
    [TestFixture]
    public class RegularTest
    {
        private string gitFileTemplate;
        private string testFolder;
        [SetUp]
        public void Init()
        {
            StringBuilder gitFile = new StringBuilder();
            gitFile.AppendLine("// Copyright 2004-2006 Castle Project - http://www.castleproject.org/");
            gitFile.AppendLine("//");
            gitFile.AppendLine("// Licensed under the Apache License, Version 2.0 (the \"License\");");
            gitFile.AppendLine("// you may not use this file except in compliance with the License.");
            gitFile.AppendLine("// You may obtain a copy of the License at");
            gitFile.AppendLine("//");
            gitFile.AppendLine("//     http://www.apache.org/licenses/LICENSE-2.0");
            gitFile.AppendLine("//");
            gitFile.AppendLine("// Unless required by applicable law or agreed to in writing, software");
            gitFile.AppendLine("// distributed under the License is distributed on an \"AS IS\" BASIS,");
            gitFile.AppendLine("// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.");
            gitFile.AppendLine("// See the License for the specific language governing permissions and");
            gitFile.AppendLine("// limitations under the License.");
            gitFile.AppendLine("");
            gitFile.AppendLine("namespace Castle.MicroKernel.Tests");
            gitFile.AppendLine("{");
            gitFile.AppendLine("        /// <summary>");
            gitFile.AppendLine("        /// 图角点测试");
            gitFile.AppendLine("        /// </summary>");
            gitFile.AppendLine("	public class GraphTestCase");
            gitFile.AppendLine("	{");
            gitFile.AppendLine("		private IKernel kernel;");
            gitFile.AppendLine("		public void Init()");
            gitFile.AppendLine("		{");
            gitFile.AppendLine("			kernel = new DefaultKernel();");
            gitFile.AppendLine("		}");
            gitFile.AppendLine("	}");
            gitFile.AppendLine("}");

            gitFileTemplate = gitFile.ToString();
            testFolder =Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"TestFiles");
        }
        /// <summary>
        /// 获取 .cs 文件的头部内容, //**** 非 ///****
        /// /\*[\s\S]*?\*/    注释 /*  */
        /// ^\s*//[\s\S]*?$   单行注释 //    ^\s*//[\s\S]*?$\n  单行注释包括换行符
        /// ^\s*$\n           空行
        /// ^\s*//[\s\S]*     
        /// </summary>
        [Test]
        public void SearchHeaderContent()
        {
            //字符串测试
            string replaceString = Regex.Replace(gitFileTemplate, @"^\s*//[^/]{1}[\s\S]*?$\n", "", RegexOptions.Multiline); 
            Assert.AreNotEqual(gitFileTemplate, replaceString);
        }
        /// <summary>
        /// 测试 .cs文件的头部内容,这里主要是移除双斜杠的注释内容
        /// /\*[\s\S]*?\*/    注释 /*  */
        /// ^\s*//[\s\S]*?$   单行注释 //    ^\s*//[\s\S]*?$\n  单行注释包括换行符
        /// ^\s*$\n           空行
        /// ^\s*//[\s\S]* 
        /// </summary>
        [Test]
        public void TestCSharpFileContent()
        {
            //文件测试
            string filePath = Path.Combine(testFolder, "GraphTestCase.cs"); 
            var encoding = EncodingType.GetType(filePath);
            string fileContent = File.ReadAllText(filePath,encoding);
            string replaceString = Regex.Replace(fileContent, @"^\s*//[^/]{1}[\s\S]*?$\n", "", RegexOptions.Multiline);
            Assert.AreNotEqual(replaceString, fileContent);
        }
        /// <summary>
        /// cshtml 获取语言定位函数 L("")| L('')
        /// L\\(['\"]{1}([^;\\)]+)['\"]{1}\\)
        /// </summary>
        [Test]
        public void GetHtmlContent()
        {
            string filePath = Path.Combine(testFolder, "Index.cshtml");
            var encoding = EncodingType.GetType(filePath);
            string fileContent = File.ReadAllText(filePath, encoding);
            var matches = Regex.Matches(fileContent, "L\\(['\"]{1}([^;\\)]+)['\"]{1}\\)", RegexOptions.Multiline);
            List<string> matchValues = new List<string>();
            if (matches.Count > 0)
            {
                foreach(Match match in matches)
                {
                    if (match.Groups.Count > 0)
                    {
                        string lastValue = match.Groups[1].Value;
                        matchValues.Add(lastValue);
                    }
                    else
                    {
                        matchValues.Add(match.Value);
                    }
                }
            }
            Assert.AreEqual(matches.Count, 2);
        }
        /// <summary>
        /// Javascript 获取语言定位函数 L("")| L('')
        /// L\\(['\"]{1}([^;\\)]+)['\"]{1}\\)
        /// </summary>
        [Test]
        public void GetJavascriptContent()
        {
            string filePath = Path.Combine(testFolder, "test.js");
            var encoding = EncodingType.GetType(filePath);
            string fileContent = File.ReadAllText(filePath, encoding);
            var matches = Regex.Matches(fileContent, "L\\(['\"]{1}([^;\\)]+)['\"]{1}\\)", RegexOptions.Multiline);
            List<string> matchValues = new List<string>();
            if (matches.Count > 0)
            {
                foreach (Match match in matches)
                {
                    if (match.Groups.Count > 0)
                    {
                        string lastValue = match.Groups[1].Value;
                        matchValues.Add(lastValue);
                    }
                    else
                    {
                        matchValues.Add(match.Value);
                    }
                }
            }
            Assert.AreEqual(matches.Count, 3);
        }
    }
}
