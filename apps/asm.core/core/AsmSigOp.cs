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
        [MethodImpl(Inline)]
        public static AsmSigOp define<T>(AsmSigOpKind kind, T value, NativeSizeCode size = NativeSizeCode.Unknown)
            where T : unmanaged
                => new AsmSigOp(kind, core.bw8(value), size);

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