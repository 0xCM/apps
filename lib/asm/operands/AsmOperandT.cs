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

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct AsmOperand<T> : IAsmOperand<T>
        where T : unmanaged
    {
        public AsmOpClass OpClass {get;}

        public NativeSize Size {get;}

        public T Data {get;}

        ReadOnlySpan<byte> IAsmOperand.Data
            => core.bytes(Data);

        [MethodImpl(Inline)]
        public AsmOperand(AsmOpClass opclass, NativeSize size, T data)
        {
            Data = data;
            OpClass =opclass;
            Size = size;
        }
    }
}