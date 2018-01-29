namespace GitHeaderTool.Core
{
    /// <summary>
    /// 执行命令优先等级
    /// 越小越优先执行
    /// </summary>
    internal enum ECommandLevel
    {
        f=1, //查找文件
        s=2, //查询文件中的内容
        x=3, //导出到指定的xml文件中
        r=4, //删除指定文件中的内容
        a=5  //追加内容到文件头部
    }
}
