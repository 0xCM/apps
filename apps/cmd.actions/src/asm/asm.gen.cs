//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static core;

    partial class AsmCmdProvider
    {
        // [CmdOp("asm/gen")]
        // Outcome GenAsm(CmdArgs args)
        // {
        //     var details = Sdm.LoadFormDetails();
        //     var count = details.Count;
        //     for(var i=0; i<count; i++)
        //     {
        //         ref readonly var detail = ref details[i];
        //         ref readonly var mnemonic = ref detail.Sig.Mnemonic;
        //         if(mnemonic == "and")
        //             Gen(detail.Name, new AsmForm(detail.Sig, detail.OpCode));
        //     }
        //     return true;
        // }

        // void Gen(in text47 name, in AsmForm form)
        // {
        //     var g = AsmGen;
        //     ref readonly var sig = ref form.Sig;
        //     ref readonly var ops = ref sig.Operands;

        //     Write(string.Format("{0,-32} | {1}", name, form.Format()));
        //     var count = ops.OpCount;
        //     for(byte i=0; i<count; i++)
        //     {
        //         var op = ops[i];
        //     }

        // }

    }
}