//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct asm
    {
        [MethodImpl(Inline), Op]
        public static AsmCallSite callsite(AsmCaller caller, Address16 offset, uint4 size)
            => new AsmCallSite(caller, offset, size);


        public static Conditions conditions()
            => Conditions.create();
    }
}