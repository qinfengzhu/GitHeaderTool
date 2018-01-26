# GitHeaderTool

删除git项目中，文件头部注释部分，方便我们后期查看源码方便

# 使用方法

目前解析的命令,命令之间用空格隔开,参数与命令之间也用空格隔开
1. -f: 查找文件
2. -s: 查找文件中的内容
3. -r: 删除查找到的文件内容
4. -a: 追加内容到文件头部
5. -d: 把查找到的内容以xml的文件放到指定文件中,格式如下
```xml
<?xml version="1.0" encoding="utf-8" ?>
  <localizationDictionary culture="">
    <texts>
      <text name="SmtpHost">SmtpHost</text>
    </texts>
  </localizationDictionary>
</xml>
```
