//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    [StructLayout(LayoutKind.Sequential, Size=2)]
    public readonly struct AsmSigOp : IAsmSigOp
    {
        public byte Value {get;}

        public AsmSigOpKind OpKind {get;}

        [MethodImpl(Inline)]
        public AsmSigOp(AsmSigOpKind kind, byte value)
        {
            Value = value;
            OpKind = kind;
        }

        public bit IsEmpty
        {
            [MethodImpl(Inline)]
            get => OpKind == 0;
        }

        public bit IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => OpKind != 0;
        }


        public static AsmSigOp Empty =>default;
    }
}