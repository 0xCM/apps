//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsmForm
    {
        public readonly Identifier Name;

        public readonly AsmSig Sig;

        public readonly AsmOpCode OpCode;

        [MethodImpl(Inline)]
        public AsmForm(Identifier name, AsmSig sig, AsmOpCode oc)
        {
            Name = name;
            Sig = sig;
            OpCode = oc;
        }

        public static AsmForm Empty => default;

    }
}