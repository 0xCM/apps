//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class AsmCoreCmd
    {
        public void EmitAsmDocs()
            => AsmDocs.Emit();

        [CmdOp("asm/docs/emit")]
        Outcome EmitAsmDocs(CmdArgs args)
        {
            EmitAsmDocs();
            return true;
        }
    }
}