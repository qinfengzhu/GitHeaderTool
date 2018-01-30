## 工具的场景使用方式

1. 比如我从github 上clone下来项目 [Castle Core](https://github.com/castleproject-deprecated/Castle.Core-READONLY),
您会发现,有个很不好的东东,就是`.cs文件`的头部有Apache协议的注释块,很妨碍我们Look代码。假设您Clone下来的目录为: `D:\git-project\Castle.Core`

我们使用命令  `GitHeaderTool.exe -f D:\git-project\Castle.Core` *.cs -r ^\s*//[^/]{1}[\s\S]*?$\n


2. 然后我们又想在我们自己的项目文件的头部加上自己的书写标识,假设我们的项目目录为: `D:\git-project\MyProject` 如

```xml
/*
* @Author bestkf
* @Time 2018-01-30
*/
```

我们使用命令 `GitHeaderTool.exe -f D:\git-project\MyProject *.cs -a "/*\r\n* @Author bestkf\r\n* @Time 2018-01-30 \r\n*/\r\n"`

3. 我们想提取某些匹配的文本值,然后放到 `xml` 字典中,假设我们的项目目录为: `D:\git-project\MyProject`,xml文件存储在 `D:\git-project\myweb.xml`

我们使用命令 `GitHeaderTool.exe -f D:\git-project\MyProject *.cs|*.cshtml|*.js -s "L\\(['\"]{1}([^;\\)]+)['\"]{1}\\)" -x  D:\git-project\myweb.xml`

这样我们就可以匹配 `L("")`方式或者 `L('')`方式中的文本内容了,并且生成格式如下的xml

```xml
 <?xml version="1.0" encoding="utf-8" ?>
 <localizationDictionary culture="">
  <texts>
    <text name="Login">Login</text>
  </texts>
 </localizationDictionary>
 </summary>
```

## 直接使用类库的方法

1. 对应上面的场景一

```csharp
public void ExcuteRemoveGitFileHeader()
{
	var commandEngine = new CommandEngine();
    string[] commands = new string[]
    {
        "-f",@"D:\git-project\Castle.Core","*.cs",
        "-r",@"^\s*//[\s\S]*?$\n",
    };
    bool result=commandEngine.Excute(commands);
    Assert.AreEqual(true, result);
}
```

2. 对应上面的场景二

```csharp
public void ExcuteAppendGitFileHeader()
{
	var commandEngine = new CommandEngine();
    string[] commands = new string[]
    {
        "-f",@"D:\git-project\MyProject","*.cs",
        "-a","/*\r\n* @Author bestkf\r\n* @Time 2018-01-30 \r\n*/\r\n",
    };
    bool result = commandEngine.Excute(commands);
    Assert.AreEqual(true, result);
}
```

3.对应上面的场景三

```csharp
public void ExcuteCatContentToXmlFile()
{
	var commandEngine = new CommandEngine();
    string[] commands = new string[]
    {
        "-f",@"D:\git-project\MyProject","*.cs|*.cshtml|*.js",
        "-s","L\\(['\"]{1}([^;\\)]+)['\"]{1}\\)",
        "-x",@"D:\git-project\myweb.xml",
    };
    bool result = commandEngine.Excute(commands);
    Assert.AreEqual(true, result);
}
```

