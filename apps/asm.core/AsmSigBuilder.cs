//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static AsmSigs;

    public readonly struct AsmSigBuilder
    {
        const NumericKind Closure = UnsignedInts;

        // [Op, MethodImpl(Inline)]
        // public static AsmSig and_al_imm8()
        //     =>  sig("and", al(), imm8());
    }
}