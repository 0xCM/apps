//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using Operands;

    using static Root;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static ymm v256(RegIndexCode r)
            => r;
    }
}