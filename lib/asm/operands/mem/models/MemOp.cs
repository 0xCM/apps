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

    [StructLayout(LayoutKind.Sequential, Pack=1)]
    public readonly struct MemOp : IMemOp
    {
        public NativeSize Size {get;}

        public AsmAddress Address {get;}

        [MethodImpl(Inline)]
        public MemOp(NativeSize size, AsmAddress address)
        {
            Size = size;
            Address = address;
        }

        [MethodImpl(Inline)]
        public AsmOperand Untyped()
            => new AsmOperand(this);

        public string Format()
            => Address.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(MemOp src)
            => src.Untyped();

        public static MemOp Empty => default;
    }
}