//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static Calcs;

    partial struct CalcClients
    {
        [MethodImpl(Inline), Srl, Closures(Closure)]
        public static ref readonly SpanBlock128<T> srl<T>(in SpanBlock128<T> a, [Imm] byte count, in SpanBlock128<T> dst)
            where T : unmanaged
                => ref Calcs.srl<T>(w128).Invoke(a, count, dst);

        [MethodImpl(Inline), Srl, Closures(Closure)]
        public static ref readonly SpanBlock256<T> srl<T>(in SpanBlock256<T> a, [Imm] byte count, in SpanBlock256<T> dst)
            where T : unmanaged
                => ref Calcs.srl<T>(w256).Invoke(a, count, dst);
    }
}