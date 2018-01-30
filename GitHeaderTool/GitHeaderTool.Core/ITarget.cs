using System;
namespace GitHeaderTool.Core
{
    /// <summary>
    /// 创建目标-这里指创建文件
    /// </summary>
    public interface ITarget
    {
        /// <summary>
        /// 创建目标
        /// </summary>
        /// <returns>创建目标</returns>
        IExcuteTarget CreateTarget();
    }
}
