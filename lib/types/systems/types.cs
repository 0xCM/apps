//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    [ApiHost]
    public readonly struct types
    {
        const NumericKind Closure = UnsignedInts;

        internal static string format(PrimalKind src)
            => src.ToString().ToLower();

        internal static Outcome parse(string src, out PrimalKind dst)
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