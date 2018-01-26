using System;
using System.Collections.Generic;

namespace GitHeaderTool.Core
{
    /// <summary>
    /// 命令解析器
    /// 目前解析的命令,命令之间用空格隔开,参数与命令之间也用空格隔开
    /// -f: 查找文件
    /// -s: 查找文件中的内容
    /// -r: 删除查找到的文件内容
    /// -a: 追加内容到文件头部
    /// -d: 把查找到的内容以xml的文件放到指定文件中,格式如下
    /// <?xml version="1.0" encoding="utf-8" ?>
    /// <localizationDictionary culture="">
    ///  <texts>
    ///    <text name="SmtpHost">SmtpHost</text>
    ///  </texts>
    /// </localizationDictionary>
    /// </summary>
    public class CommandParser
    {
    }
}
