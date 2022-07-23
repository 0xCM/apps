//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
     using Asm;

    partial class AsmCoreCmd
    {
       [CmdOp("gen/sdm/code")]
        void GenAmsCode()
            => SdmCodeGen.Emit();
    }
}