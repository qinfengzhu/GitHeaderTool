using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace GitHeaderTool.Core.Test
{
    [TestFixture]
    /// <summary>
    /// 内容换行测试类
    /// </summary>
    public class LineTest
    {
        [Test]
        public void StringBuilderAppendContentTest()
        {
            string appendContent = "/*\r\n* @Author bestkf\r\n* @Time 2018-01-30 \r\n*/\r\n";
            StringBuilder builder = new StringBuilder();
            builder.Append(appendContent);
            builder.AppendLine();
            builder.Append("Test");
            string result = builder.ToString();
            Assert.AreNotEqual(string.Empty, result);
        }
    }
}
