//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCode
    {
        public EncodedMembers LoadEncoded()
            => LoadEncoded(Dispense.dispenser(Dispense.symbols));

        public EncodedMembers LoadEncoded(string spec)
            => LoadEncoded(Dispense.dispenser(Dispense.symbols), spec);

        public EncodedMembers LoadEncoded(PartId src)
        {
            Load(src, out var index, out var code);
            return members(Dispense.dispenser(Dispense.symbols), index, code);
        }

        EncodedMembers LoadEncoded(SymbolDispenser symbols)
        {
            Load(out var index, out var code);
            return members(symbols, index, code);
        }

        EncodedMembers LoadEncoded(SymbolDispenser symbols, string spec)
        {
            if(text.nonempty(spec))
            {
                var i = text.index(spec, Chars.FSlash);
                if(i>0)
                    return LoadEncoded(symbols, ApiHostUri.define(ApiParsers.part(text.left(spec,i)), text.right(spec,i)));
                else
                    return LoadEncoded(symbols, ApiParsers.part(spec));
            }
            else
                return LoadEncoded(symbols);
        }

        EncodedMembers LoadEncoded(SymbolDispenser symbols, ApiHostUri src)
        {
            Load(src, out var index, out var code);
            return members(symbols, index, code);
        }

        EncodedMembers LoadEncoded(SymbolDispenser symbols, PartId src)
        {
            Load(src, out var index, out var code);
            return members(symbols, index, code);
        }
    }
}