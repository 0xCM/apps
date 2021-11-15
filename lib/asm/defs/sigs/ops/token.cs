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
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static AsmSigToken<K> token<K>(AsmSigTokenKind kind, K value)
            where K : unmanaged
                => new AsmSigToken<K>(kind,value);
    }
}