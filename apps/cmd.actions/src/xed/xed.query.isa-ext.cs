//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ProjectCmdProvider
    {
        [CmdOp("xed/query/isa-ext")]
        Outcome XedIsaExt(CmdArgs args)
        {
            var extensions = Xed.IsaExtensions();

            return true;
        }
    }
}