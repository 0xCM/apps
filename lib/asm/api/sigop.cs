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
        public static AsmSigOp sigop(AsmSigOpKind kind, byte value)
            => new AsmSigOp(kind,value);


        [MethodImpl(Inline), Op, Closures(Closure)]
        public static AsmSigOp sigop<T>(AsmSigOpKind kind, T value)
            where T : unmanaged
                => new AsmSigOp(kind, core.bw8(value));
    }
}