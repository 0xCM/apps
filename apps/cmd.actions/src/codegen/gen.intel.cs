//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;
    using Asm;

    partial class CodeGenProvider
    {
        LlvmDataProvider LlvmData => Service(Wf.LlvmDataProvider);

        AsmCodeGen AsmCodeGen => Service(Wf.AsmCodeGen);

        [CmdOp("gen/asm")]
        Outcome GenIntel(CmdArgs args)
        {
            AsmCodeGen.GenSigIds();
            AsmCodeGen.GenMnemonicNames();
            var funcs = AsmCodeGen.DefineSigFormatters();
            var count = funcs.Count;

            var dst= text.buffer();
            var margin = 8u;
            for(var i=0; i<count; i++)
            {
                ref readonly var f = ref funcs[i];
                f.Render(margin, dst);
                dst.AppendLine();
            }
            Write(dst.Emit());

            return true;
        }
   }
}