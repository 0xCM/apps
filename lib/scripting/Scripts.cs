//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;
    using static core;

    [ApiHost]
    public readonly struct Scripting
    {
        [MethodImpl(Inline), Op]
        public static TextExpr expression(string body)
            => new TextExpr(body);

        public static Dictionary<string,TextVar> vars(ReadOnlySpan<char> src)
        {
            var count = src.Length;
            var dst = dict<string,TextVar>();
            var name = EmptyString;
            var parsing = false;
            for(var i=0; i<count-1; i++)
            {
                ref readonly var c0 = ref skip(src,i);
                ref readonly var c1 = ref skip(src,i+1);

                if(!parsing)
                {
                    if(c0 == Chars.Dollar && c1 == Chars.LParen)
                    {
                        name = EmptyString;
                        parsing = true;
                        i++;
                        continue;
                    }
                }
                else
                {
                    if(nonempty(name) && c0 == Chars.RParen)
                    {
                        dst.TryAdd(name,new TextVar(name));
                        name = EmptyString;
                        parsing = false;
                    }
                    else
                    {
                        name += c0;
                    }
                }
            }

            if(nonempty(name))
                dst.TryAdd(name,new TextVar(name));
            return dst;
        }

        /// <summary>
        /// Creates a non-valued <see cref='ScriptVar'/>
        /// </summary>
        /// <param name="symbol">The variable symbol</param>
        [MethodImpl(Inline), Op]
        public static ScriptVar var(VarSymbol symbol)
            => new ScriptVar(symbol);

        /// <summary>
        /// Creates a valued <see cref='ScriptVar'/>
        /// </summary>
        /// <param name="symbol">The variable symbol</param>
        /// <param name="value">The variable value</param>
        [MethodImpl(Inline), Op]
        public static ScriptVar var(VarSymbol symbol, string value)
            => new ScriptVar(symbol, value);
    }
}
