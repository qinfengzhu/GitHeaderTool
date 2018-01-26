using System;

namespace GitHeaderTool.Core.Keys
{
    /// <summary>
    /// 文件内容添加Key
    /// </summary>
    public class FileContentAddKey:IKeySetting
    {
        public string Key
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string Value
        {
            get { throw new NotImplementedException(); }
        }

        public int Level
        {
            get { throw new NotImplementedException(); }
        }

        public IExcuteTarget CreateTarget()
        {
            throw new NotImplementedException();
        }

        public IExcuteTarget CreateTarget(IExcuteResult excuteResult)
        {
            throw new NotImplementedException();
        }
    }
}
