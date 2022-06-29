//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static ApiGranules;

    [ApiHost]
    public class ToolsetCmd : CmdService<ToolsetCmd>
    {
        Toolsets Toolsets => Wf.Toolsets();

        Settings Config;

        [CmdOp("toolset")]
        void LlvmConfig(CmdArgs args)
        {
            // d:/views/llvm/llvm.config
            var path = FS.path(arg(args,0));
            Config = Toolsets.Config(path);
            Config.Iter(setting => Write(setting.Format(Chars.Colon)));

        }
    }

    public struct ToolsetConfig
    {
        public asci16 WsId;

        public FS.FolderPath Root;

        public FS.FolderPath Docs;

        public FS.FolderPath Help;

        public FS.FolderPath Lists;

        public FS.FilePath ToolList;

        public FS.FilePath LibList;

        public FS.FilePath IncludeList;

        public FS.FilePath HelpList;
    }
}
