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
            AsmCodeGen.GenSigIds();
            AsmCodeGen.GenMnemonicNames();
            var fSrc = AsmCodeGen.DefineSigFormatters();
            var count = fSrc.Count;

            var fDst= text.buffer();
            var margin = 0u;


            var name = "AsmFormatters";
            fDst.IndentLineFormat(margin,"public readonly struct {0}", name);
            fDst.IndentLine(margin, Chars.LBrace);
            margin +=4;
            for(var i=0; i<count; i++)
            {
                ref readonly var f = ref fSrc[i];
                f.Render(margin, fDst);
                fDst.AppendLine();
            }
            margin -=4;
            fDst.IndentLine(margin,Chars.RBrace);

            var spec = CgSpecs.define("Z0.Asm", array("using Operands;"), fDst.Emit());
            CodeGen.EmitFile(spec, name, CgTarget.Intel);


            return true;
        }
   }
}