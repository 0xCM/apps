//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost]
    public readonly struct Tokens
    {
        public static Index<Token> tokenize(Type symtype)
        {
            var symbols = Symbols.untyped(symtype).View;
            var count = symbols.Length;
            var dst = alloc<Token>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var symbol = ref skip(symbols,i);
                seek(dst,i) = new Token(symbol.Key, symbol.Type.Name.Content, symbol.Name.Content, symbol.Expr.Text, symbol.Value);
            }
            return dst;
        }

        public static Index<Token> tokenize<K>(Symbols<K> src)
            where K : unmanaged
        {
            var count = src.Length;
            var dst = alloc<Token>(count);
            for(var i=0u; i<count; i++)
            {
                ref readonly var symbol = ref src[i];
                seek(dst,i) = new Token(symbol.Key, symbol.Type.Name.Content, symbol.Name.Content, symbol.Expr.Text, symbol.Value);
            }
            return dst;
        }

        public static TokenSet set(Type[] src)
        {
            var dst = new TokenSet();
            dst.WithTypes(src);
            return dst;
        }

        public static TokenSet set(string name, Type[] src)
        {
            var dst = new TokenSet(name);
            dst.WithTypes(src);
            return dst;
        }
    }
}