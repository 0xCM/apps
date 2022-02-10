//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelSdm
    {
        public SymSet LoadSigSymbols()
        {
            var src = LoadSymbolicSigs();
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
                names[i] = sig.Name;
                descriptions[i] = sig.Source.Format();
                symbols[i] = sig.Target.Format();
                values[i] = i;
            }
            return symset;
        }
    }
}