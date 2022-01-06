//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class bits
    {
        [MethodImpl(Inline), Op]
        public static byte segwidth(byte i0, byte i1)
            => (byte)(i1 - i0 + 1);
    }
}