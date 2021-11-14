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
        public static AsmCallInfo call(AsmCallSite callsite, AsmCallee target)
            => new AsmCallInfo(callsite, target);

        [MethodImpl(Inline), Op]
        public static AsmCallSite callsite(AsmCaller caller, Address16 offset, uint4 size)
            => new AsmCallSite(caller, offset, size);

        [MethodImpl(Inline), Op]
        public static AsmCaller caller(MemoryAddress @base, string symbol)
            => new AsmCaller(@base, symbol);

        [MethodImpl(Inline), Op]
        public static AsmCallee callee(MemoryAddress @base, string symbol)
            => new AsmCallee(@base, symbol);
    }
}
