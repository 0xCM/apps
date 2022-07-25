//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [ApiHost]
    public class ToolsetCmd : AppCmdService<ToolsetCmd>
    {
        Toolsets Toolsets => Wf.Toolsets();

        SettingLookup Config;

        [CmdOp("toolset")]
        void LlvmConfig(CmdArgs args)
        {
            // d:/views/llvm/llvm.config
            var path = FS.path(arg(args,0));
            Config = Toolsets.Config(path);
            Config.Iter(setting => Write(setting.Format(Chars.Colon)));

        }
    }
}
