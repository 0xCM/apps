//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct PrimitiveParser
    {
        public static Outcome parse(string src, out PrimalKind dst)
        {
            var symbols = Symbols.index<PrimalKind>();
            var i = text.index(src, Chars.Colon);
            dst = default;
            if(i > 0)
            {
                var input = text.left(src,i);
                if(symbols.Lookup(input, out var s))
                    dst = s.Kind;
            }
            else
            {
                i = text.index(src,Chars.Space);
                if(i>0)
                {
                    var input = text.left(src,i);
                    if(symbols.Lookup(input, out var s))
                        dst = s.Kind;
                }
            }

            return dst != 0;
        }
    }
}