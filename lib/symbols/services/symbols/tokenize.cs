//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial struct Symbols
    {
        public static Index<Token> tokenize(Type symtype)
        {
            var symbols = untyped(symtype).View;
            var count = symbols.Length;
            var dst = alloc<Token>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var symbol = ref skip(symbols,i);
                seek(dst,i) = new Token(symbol.Key, symbol.Class, symbol.Type.Name.Content, symbol.Name, symbol.Expr.Text, symbol.Value);
            }
            return dst;
        }

        public static Index<Token<K>> tokenize<K>(Type symtype)
            where K : unmanaged
        {
            var tag = symtype.Tag<SymSourceAttribute>().Require();
            var kind = (K)tag.SymKind;
            var src = tokenize(symtype);
            return map(src, t => t.WithKind(kind));
        }
    }
}