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

    using static core;

    partial struct AsmParser
    {
        public static AsmLineClass lineclass(string src)
        {
            var content = text.trim(src);

            [MethodImpl(Inline)]
            static bool IsLabel(string src)
                => SQ.xedni(src, Chars.Colon) == src.Length - 1;

            [MethodImpl(Inline)]
            static bool IsDirective(string src)
                => SQ.index(src, Chars.Dot) == 0;

            if(text.empty(content))
                return C.Empty;

            if(IsLabel(content))
                return C.Label;

            if(IsDirective(content))
                return C.Directive;

            return C.AsmSource;
        }
    }
}