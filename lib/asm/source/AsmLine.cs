//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    using C = AsmLineClass;
    using SQ = SymbolicQuery;

    public readonly struct AsmLine
    {
        public static AsmLineClass classify(string src)
        {
            var content = text.trim(src);

            if(text.empty(content))
                return C.Empty;

            if(IsLabel(content))
                return C.Label;

            if(IsDirective(content))
                return C.Directive;

            return C.AsmSource;
        }

        [MethodImpl(Inline)]
        static bool IsLabel(string src)
            => SQ.xedni(src, Chars.Colon) == src.Length - 1;

        [MethodImpl(Inline)]
        static bool IsDirective(string src)
            => SQ.index(src, Chars.Dot) == 0;

        public Index<object> Tokens {get;}

        [MethodImpl(Inline), Op]
        public AsmLine(Index<object> src)
        {
            Tokens = src;
        }

        public string Format()
            => string.Concat(Tokens.Select(x => x.ToString()));
    }
}