using GitHeaderTool.Core.Commands;
using GitHeaderTool.Core.Keys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GitHeaderTool.Core
{
    /// <summary>
    /// 键与命令转换器
    /// </summary>
    /// <typeparam name="T">转换的类型</typeparam>
    public abstract class CommandConverter<T>
    {
        protected CommandConverter() { }
        public T Convert(IKeySetting keySetting)
        {
            if (keySetting == null)
            {
                return default(T);
            }
            return keySetting.Accept(this);
        }
        public abstract T ConvertFileSearchKey(FileSearchKey fileSearchKey);
        public abstract T ConvertContentSearchKey(ContentSearchKey contentSearchKey);
        public abstract T ConvertContentAddKey(FileContentAddKey fileContentAddKey);
        public abstract T ConvertContentRemoveKey(FileContentRemoveKey fileContentRemoveKey);
        public abstract T ConvertFileCreateKey(FileCreateKey fileCreateKey);
    }
    /// <summary>
    /// 命令行转换
    /// </summary>
    public class CmdCommandConverter : CommandConverter<ICommandExcute>
    {
        public override ICommandExcute ConvertFileSearchKey(FileSearchKey fileSearchKey)
        {
            return new FileSearchCommand(fileSearchKey);
        }
        public override ICommandExcute ConvertContentSearchKey(ContentSearchKey contentSearchKey)
        {
            return new ContentCatCommand(contentSearchKey);
        }
        public override ICommandExcute ConvertContentAddKey(FileContentAddKey fileContentAddKey)
        {
            return new FileContentAddCommand(fileContentAddKey);
        }
        public override ICommandExcute ConvertContentRemoveKey(FileContentRemoveKey fileContentRemoveKey)
        {
            return new FileContentRemoveCommand(fileContentRemoveKey);
        }
        public override ICommandExcute ConvertFileCreateKey(FileCreateKey fileCreateKey)
        {
            return new FileCreateCommand(fileCreateKey);
        }
    }
}
