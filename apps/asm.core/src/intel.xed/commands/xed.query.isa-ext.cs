//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedCmdProvider
    {
        [CmdOp("xed/query/isa-ext")]
        Outcome XedIsaExt(CmdArgs args)
        {
            var extensions = Xed.IsaExtensions();

            return true;
        }
    }
}