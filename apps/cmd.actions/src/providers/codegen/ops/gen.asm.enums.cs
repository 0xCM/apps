//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;
    using System;

    using static core;
    using static Root;

    partial class CodeGenProvider
    {
        [CmdOp("gen/asm/enums")]
        Outcome GenAsmEnums(CmdArgs args)
        {
            var g = CodeGen.CsEnum();
            var src = Sdm.LoadSigDecomps();
            var count = src.Count + 1;
            var symset = SymSet.create(count);
            symset.Name = "AsmSigId";
            symset.DataType = ClrEnumKind.U16;
            symset.Flags = false;
            symset.SymbolKind = "asm";
            var descriptions = symset.Descriptions;
            var names = symset.Names;
            var symbols = symset.Symbols;
            var values = symset.Values;

            names[0] = "None";
            symbols[0] = EmptyString;
            descriptions[0] = EmptyString;
            values[0] = 0;
            for(var i=1; i<count; i++)
            {
                ref readonly var sig = ref src[i - 1];
                names[i] = sig.Identity;
                descriptions[i] = string.Format("{0} | {1}", sig.Sig, sig.OpCode);
                symbols[i] = sig.Sig.Format();
                values[i] = i;
            }

            var buffer = text.buffer();
            g.Emit(0u, symset, buffer);

            var spec = CgSpecs.define("Z0.Asm").WithContent(buffer.Emit());
            CodeGen.EmitFile(spec, "AsmSigId", CgTarget.Intel);
            return true;
        }
    }
}