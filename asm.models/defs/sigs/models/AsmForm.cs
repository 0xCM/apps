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
        readonly public AsmSig Sig;

        public readonly AsmOpCode OpCode;

        [MethodImpl(Inline)]
        public AsmForm(in AsmSig sig, in AsmOpCode oc)
        {
            Sig = sig;
            OpCode = oc;
        }

        public string Format()
            => string.Format("{0} = {1}", Sig, OpCode);

        public override string ToString()
            => Format();
    }
}