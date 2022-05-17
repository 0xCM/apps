//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class AsmCoreCmd
    {
        [CmdOp("asm/codegen")]
        Outcome GenAmsCode(CmdArgs args)
        {
            AsmCodeGen.Emit();
            return true;
        }
    }
}