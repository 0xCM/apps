//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using static core;

    partial class LlvmCmd
    {
        [CmdOp("tool-env")]
        Outcome LoadToolEnv(CmdArgs args)
        {
            var result = Outcome.Success;
            LoadToolEnv(out var settings);
            var env = new ToolEnv(settings);
            Write("Header Includes");
            iter(env.HeaderIncludes(), h => Write(h, h.Exists ? FlairKind.Status : FlairKind.Error));
            Write("Library Includes");
            iter(env.LibIncludes(), h => Write(h, h.Exists ? FlairKind.Status : FlairKind.Error));
            return result;
        }
    }
}