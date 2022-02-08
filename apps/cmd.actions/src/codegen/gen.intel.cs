//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;
    using static core;

    partial class CodeGenProvider
    {

        LlvmDataProvider LlvmData => Service(Wf.LlvmDataProvider);

        [CmdOp("gen/intel")]
        Outcome GenIntel(CmdArgs args)
        {
            GenAsmSigIds();
            GenMnemonicNames();
            return true;
        }


        void GenAsmSigIds()
        {
            var symbols = Sdm.LoadSigSymbols();
            var g = CodeGen.EnumGen();
            var buffer = text.buffer();
            g.Emit(0u, symbols, buffer);
            var spec = CgSpecs.define("Z0.Asm").WithContent(buffer.Emit());
            CodeGen.EmitFile(spec, "AsmSigId", CgTarget.Intel);

        }

        void GenMnemonicNames()
        {
            var g = CodeGen.LiteralProvider();
            var name = "AsmMnemonicNames";
            var src = Sdm.LoadSigs().Select(x => x.Mnemonic.Format(Asm.MnemonicCase.Lowercase)).Distinct();
            var dst = CodeGen.SourceFile(name, CgTarget.Intel);
            var names = src.View;
            var values = src.View;
            var literals = Literals.seq(name, names, values);
            g.Emit("Z0", literals, dst);
        }
   }
}