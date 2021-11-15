//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct AsmOperands
    {
        public readonly struct ptr<T>
            where T : unmanaged, IMemOp<T>
        {
            public readonly T Source;

            [MethodImpl(Inline)]
            public ptr(T src)
            {
                Source = src;
            }

            public AsmAddress Target
            {
                [MethodImpl(Inline)]
                get => Source.Address;
            }

            public NativeSize Size
            {
                [MethodImpl(Inline)]
                get => Source.Size;
            }

            [MethodImpl(Inline)]
            public static implicit operator ptr<T>(T src)
                => new ptr<T>(src);
        }
    }
}