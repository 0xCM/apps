//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class ProjectCmdProvider
    {
        [CmdOp("env/includes")]
        Outcome LoadToolEnv(CmdArgs args)
        {
            var result = Outcome.Success;
            LoadToolEnv(out var settings);
            var env = ToolEnv.load(settings);
            iter(env.HeaderIncludes(), h => Write(string.Format("{0}:{1}", "Header",h), h.Exists ? FlairKind.Status : FlairKind.Error));
            iter(env.LibIncludes(), h => Write(string.Format("{0}:{1}", "Lib",h), h.Exists ? FlairKind.Status : FlairKind.Error));
            return result;
        }
    }
}