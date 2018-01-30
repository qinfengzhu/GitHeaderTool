using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Collections.Concurrent;

namespace GitHeaderTool.Core
{
    /// <summary>
    /// XML 文件容器池 
    /// </summary>
    public static class WebXmlContainer
    {
        private static ConcurrentDictionary<string, FilePool> Files = new ConcurrentDictionary<string, FilePool>();

        public static void CreateFile(string filePath)
        {
            if (!Files.ContainsKey(filePath))
            {
                Files.AddOrUpdate(filePath, new FilePool(filePath), (fileName, filePool) =>
                {
                    return filePool;
                });
            }
        } 
        public static void AppendToFile(string filePath,List<string>content)
        {
            var filePool = Files.GetOrAdd(filePath,(filename) =>
            {
                return new FilePool(filename);
            });
            filePool.AppendData(content);
        }
        public static void BuildFile(string filePath)
        {
            var filePool = Files.GetOrAdd(filePath, (filename) =>
            {
                return new FilePool(filename);
            });
            filePool.BuildFile();
            FilePool removeFilePool;
            Files.TryRemove(filePath, out removeFilePool);
            removeFilePool.Dispose();
        }
        public static void BuildFile()
        {
            foreach(var file in Files)
            {
                file.Value.BuildFile();
                file.Value.Dispose();
            }
            Files.Clear();
        }
        /// <summary>
        /// 文件单体池
        /// </summary>
        class FilePool:IDisposable
        {
            private List<string> m_data;
            private string m_filePath;
            public FilePool(string filePath)
            {
                m_filePath = filePath;
                m_data = new List<string>();
            }
            public void AppendData(string textData)
            {
                m_data.Add(string.Format("          <text name=\"{0}\">{0}</text>\n", textData));
            }
            public void AppendData(List<string> textData)
            {
                foreach (var text in textData)
                {
                    m_data.Add(string.Format("          <text name=\"{0}\">{0}</text>\n", text));
                }
            }
            public void BuildFile()
            {
                StringBuilder fileContent = new StringBuilder();
                fileContent.Append("<?xml version=\"1.0\" encoding=\"utf-8\" ?>\n");
                fileContent.Append("<localizationDictionary culture=\"\">\n");
                fileContent.Append("    <texts>\n");
                var distinctData= m_data.Distinct();
                foreach (var data in distinctData)
                {
                    fileContent.Append(data);
                }
                fileContent.Append("    </texts>\n");
                fileContent.Append("</localizationDictionary>\n");
                if(!File.Exists(m_filePath))
                {
                    string dir = Path.GetDirectoryName(m_filePath);
                    if (!Directory.Exists(dir))
                        Directory.CreateDirectory(dir);
                    File.Create(m_filePath);
                }
                File.WriteAllText(m_filePath, fileContent.ToString());
            }
            public void Dispose()
            {
                m_filePath = null;
                m_data.Clear();
            }
        }
    }
}
