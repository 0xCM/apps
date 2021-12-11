//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        [CmdOp("xed/query/opkinds")]
        Outcome XedOpKinds(CmdArgs args)
            => ShowSyms(Xed.OperandKinds());
    }
}