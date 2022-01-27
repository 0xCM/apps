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
    public readonly struct AsmSigOp
    {
        public byte Value {get;}

        public AsmSigOpKind OpKind {get;}

        public NativeSize Size {get;}

        [MethodImpl(Inline)]
        public AsmSigOp(AsmSigOpKind kind, byte value, NativeSizeCode size = NativeSizeCode.Unknown)
        {
            Value = value;
            OpKind = kind;
            Size = size;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => OpKind == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => OpKind != 0;
        }

        public static AsmSigOp Empty =>default;
    }
}