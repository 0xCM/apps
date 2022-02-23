//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class AsmCmdProvider
    {
        [CmdOp("asm/docs/emit")]
        Outcome EmitAsmDocs(CmdArgs args)
        {
            AsmDocs.Emit();
            return true;
        }
    }
}