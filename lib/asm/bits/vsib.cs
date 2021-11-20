//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    partial class AsmBits
    {
        [MethodImpl(Inline), Op]
        public static uint vsib(Vsib src, Span<char> dst)
        {
            var i=0u;
            seek(dst,i++) = Open;
            BitNumbers.render(src.SS(), ref i, dst);
            seek(dst,i++) = Chars.Space;
            BitNumbers.render(src.Index(), ref i, dst);
            seek(dst,i++) = Chars.Space;
            BitNumbers.render(src.Base(), ref i, dst);
            seek(dst,i++) = Close;
            return i;
        }
    }
}