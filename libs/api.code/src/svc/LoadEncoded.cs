//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class ApiCode
    {
        public EncodedMembers LoadEncoded()
            => LoadEncoded(Dispense.composite());

        public EncodedMembers LoadEncoded(string spec)
            => LoadEncoded(Dispense.composite(), spec);

        public EncodedMembers LoadEncoded(PartId src)
        {
            Load(src, out var index, out var code);
            return members(Dispense.composite(), index, code);
        }

        EncodedMembers LoadEncoded(ICompositeDispenser symbols)
        {
            Load(out var index, out var code);
            return members(symbols, index, code);
        }

        EncodedMembers LoadEncoded(ICompositeDispenser symbols, string spec)
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

        EncodedMembers LoadEncoded(ICompositeDispenser symbols, ApiHostUri src)
        {
            Load(src, out var index, out var code);
            return members(symbols, index, code);
        }

        EncodedMembers LoadEncoded(ICompositeDispenser symbols, PartId src)
        {
            Load(src, out var index, out var code);
            return members(symbols, index, code);
        }
    }
}