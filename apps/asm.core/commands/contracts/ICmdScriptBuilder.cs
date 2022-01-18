//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface ICmdScriptBuilder
    {
        CmdScript BuildCmdScript(IFileFlowCmd src);

        Index<CmdLine> BuildCmdLines(IProjectWs project, string cmdsrc, IFileFlowType flowtype);
    }
}