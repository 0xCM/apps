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

        [CmdOp("gen/asm")]
        Outcome GenIntel(CmdArgs args)
        {
            AsmCodeGen.Emit();

            return true;
        }

        [CmdOp("gen/asm/data")]
        Outcome GenInstData(CmdArgs args)
        {
            var forms = Sdm.CalcForms();
            var count = forms.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var form = ref forms[i];
                Write(string.Format("{0,-8} | {1,-38} | {2,-48} | {3}", i, form.Name, form.Sig, form.OpCode));
            }

            return true;
        }
   }
}