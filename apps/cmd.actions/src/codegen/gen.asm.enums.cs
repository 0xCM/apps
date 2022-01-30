//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class CodeGenProvider
    {
        [CmdOp("gen/asm/enums")]
        Outcome GenAsmEnums(CmdArgs args)
        {
            var symbols = Sdm.AsmSigSymbols();
            var g = CodeGen.EnumGen();
            var buffer = text.buffer();
            g.Emit(0u, symbols, buffer);
            var spec = CgSpecs.define("Z0.Asm").WithContent(buffer.Emit());
            CodeGen.EmitFile(spec, "AsmSigId", CgTarget.Intel);
            return true;
        }
    }
}