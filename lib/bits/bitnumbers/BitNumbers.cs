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
    public readonly partial struct BitNumbers
    {
        public const NumericKind Closure = NumericKind.UnsignedInts;

        [MethodImpl(Inline)]
        internal static void render(uint src, byte count, uint offset, Span<char> dst)
        {
            byte i=0;
            for(var j=offset; j<count; j++)
                seek(dst, j) = @char(@bool(bit.test(src, i++)));
        }
    }
}