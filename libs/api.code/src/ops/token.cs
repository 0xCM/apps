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
                symbols.Symbol(entry.Location, entry.Uri?.Format() ?? EmptyString),
                symbols.Symbol(target, entry.Sig.Format()));

        public static ApiToken token(SymbolDispenser symbols, in MethodEntryPoint entry)
            => new ApiToken(
                symbols.Symbol(entry.Location, text.ifempty(entry.Uri.Format(), EmptyString)),
                symbols.Symbol(entry.Location, entry.Sig.Format())
                );
    }
}