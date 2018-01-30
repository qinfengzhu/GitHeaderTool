using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GitHeaderTool.Core
{
    /// <summary>
    /// 处理上下文目标
    /// </summary>
    public interface IContextTarget
    {
        string FilePath { get; set; }
        Encoding FileEncodingType { get; }
        Dictionary<ECommandLevel, object> ContextResult { get; set; }
    }
    /// <summary>
    /// 默认的处理上下文
    /// </summary>
    public class DefaultContextTarget : IContextTarget, IDisposable
    {
        private string m_filePath;
        private Encoding m_fileEncoding;
        public string FilePath
        {
            get { return m_filePath; }
            set
            {
                m_filePath = value;
                m_fileEncoding = EncodingType.GetType(m_filePath);
            }
        }
        public Encoding FileEncodingType
        {
            get { return m_fileEncoding; }
        }
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
            Rewrite();
            FilePath = string.Empty;
            ContextResult.Clear();
        }
        /// <summary>
        /// 调整后的内容写入到文件
        /// </summary>
        private void Rewrite()
        {
            File.WriteAllText(FilePath, (string)ContextResult[ECommandLevel.f], FileEncodingType);
        }
    }
}
