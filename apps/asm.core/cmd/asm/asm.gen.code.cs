//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    partial class AsmCoreCmd
    {
        [CmdOp("gen/asm/code")]
        Outcome GenIntel(CmdArgs args)
        {
            AsmCodeGen.Emit();
            return true;
        }
    }
}