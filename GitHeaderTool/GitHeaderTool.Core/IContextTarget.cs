using System;
using System.Collections.Generic;
using System.Linq;

namespace GitHeaderTool.Core
{
    /// <summary>
    /// 处理上下文目标
    /// </summary>
    public interface IContextTarget
    {
        string FilePath { get; set; }
        Dictionary<ECommandLevel, object> ContextResult { get; set; }
    }
    /// <summary>
    /// 默认的处理上下文
    /// </summary>
    public class DefaultContextTarget : IContextTarget, IDisposable
    {
        public string FilePath { get; set; }
        public Dictionary<ECommandLevel, object> ContextResult { get; set; }
        public DefaultContextTarget()
        {
            FilePath = string.Empty;
            ContextResult = new Dictionary<ECommandLevel, object>();
        }
        /// <summary>
        /// 释放资源
        /// </summary>
        public void Dispose()
        {
            FilePath = string.Empty;
            ContextResult.Clear();
        }
    }
}
