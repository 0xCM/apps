//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial class AsmSigs
    {
        // [MethodImpl(Inline), Op, Closures(Closure)]
        // public static AsmSigOp<K> sigop<K>(AsmSigOpKind kind, K value)
        //     where K : unmanaged
        //         => new AsmSigOp<K>(kind,value);
    }
}