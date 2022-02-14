//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;
    using Asm;

    using static core;


    partial class CodeGenProvider
    {
        LlvmDataProvider LlvmData => Service(Wf.LlvmDataProvider);

        AsmCodeGen AsmCodeGen => Service(Wf.AsmCodeGen);

        AsmSigSvc Sigs => Service(Wf.AsmSigs);

        [CmdOp("gen/asm")]
        Outcome GenIntel(CmdArgs args)
        {
            AsmCodeGen.GenMnemonicNames();
            AsmCodeGen.GenFormKinds();

            return true;
        }


        [CmdOp("gen/asm/data")]
        Outcome GenInstData(CmdArgs args)
        {
            return true;
        }

   }
}