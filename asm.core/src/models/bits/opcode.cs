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
        public static uint opcode(Hex8 src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            BitRender.render8(src, ref  i, dst);
            return i-i0;
        }
    }
}