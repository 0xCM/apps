//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    partial class AsmCmdService
    {
        [CmdOp(".xed-etl", "Executes the XED etl workflow")]
        Outcome EmitXedTables(CmdArgs args)
        {
            var dst = Ws.Tables().Subdir(AsmTableScopes.IntelXed);
            dst.Clear();
            Wf.IntelXed().EmitTables(dst);
            return true;
        }

        [CmdOp(".xed-isa")]
        Outcome XedIsa(CmdArgs args)
            => Xed.EmitIsa(arg(args,0).Value);
    }
}