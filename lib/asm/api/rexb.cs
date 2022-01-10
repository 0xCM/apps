//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmOpCodeTokens;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static RexB rexb(RexBToken token, RegIndexCode r)
            => new RexB(token,r);
    }
}