//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static ApiGranules;

    [ApiHost]
    public class ToolsetCmd : AppCmdService<ToolsetCmd>
    {
        Toolsets Toolsets => Wf.Toolsets();

        [CmdOp("tools/llvm")]
        void LlvmConfig()
        {
            var config = Toolsets.LlvmDistConfig();
            config.Iter(setting => Write(setting.Format(Chars.Colon)));
        }
    }
}
