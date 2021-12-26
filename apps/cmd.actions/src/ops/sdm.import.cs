//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class GlobalCommands
    {
        [CmdOp("sdm/import")]
        Outcome runsdmetl(CmdArgs args)
            => Sdm.Import();
    }
}