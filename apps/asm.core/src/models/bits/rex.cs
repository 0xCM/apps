//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class AsmBits
    {
        [MethodImpl(Inline), Op]
        public static uint rex(RexPrefix src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            BitRender.render8x4(src.Encoded, ref  i, dst);
            return i-i0;
        }

        [Op]
        public static string bitstring(RexPrefix src)
            => string.Format("0100 {0} {1} {2} {3}", src.W(), src.R(), src.X(), src.B());
    }
}