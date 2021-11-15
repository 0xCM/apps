//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    partial struct Symbols
    {
        public static ReadOnlySpan<Token> tokenize(Type symtype, out ReadOnlySpan<char> data)
        {
            var symbols = Symbols.untyped(symtype).View;
            var symcount = symbols.Length;
            var content = text.buffer();
            for(var i=0; i< symcount; i++)
            {
                ref readonly var symbol = ref skip(symbols,i);
                content.Append(symbol.Expr.Format());
                content.Append('\0');
            }

            var src = span(content.Emit());
            data = src;
            var count = src.Length;
            var counter = 0u;
            var tokens = span<Token>(count);
            var chars = span<char>(count);
            var k = 0u;
            var t = 0u;
            for(var i=0; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                if(c == '\0')
                {
                    if(t !=0 )
                    {
                        ref readonly var symbol = ref skip(symbols,k);
                        var type = symbol.Type.Name.Content;
                        var name = symbol.Name.Content;
                        var expr = text.format(slice(chars, 0, t));
                        var value = symbol.Value;
                        seek(tokens, counter++) = new Token(k++, type, name, expr,value);
                        t = 0;
                        chars.Clear();
                    }
                }
                else
                    seek(chars, t++) = c;
            }

            if(t != 0)
            {
                ref readonly var symbol = ref skip(symbols,k);
                var type = symbol.Type.Name.Content;
                var name = symbol.Name.Content;
                var expr = text.format(slice(chars, 0, t));
                var value = symbol.Value;
                seek(tokens, counter++) = new Token(k++, type, name, expr,value);
                chars.Clear();
            }
            return slice(tokens,0,counter);
        }
    }
}