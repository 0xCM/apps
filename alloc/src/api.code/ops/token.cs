//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCode
    {
        public static ApiToken token(SymbolDispenser symbols, in MethodEntryPoint entry, MemoryAddress target)
            => new ApiToken(
                symbols.DispenseSymbol(entry.Location, entry.Uri?.Format() ?? EmptyString),
                symbols.DispenseSymbol(target, entry.Sig.Format()));

        public static ApiToken token(SymbolDispenser symbols, in MethodEntryPoint entry)
            => new ApiToken(
                symbols.DispenseSymbol(entry.Location, text.ifempty(entry.Uri.Format(),EmptyString)),
                symbols.DispenseSymbol(entry.Location, entry.Sig.Format())
                );
    }
}