//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct AsmOperands
    {
        public readonly struct m128 : IMemOp128<m128>
        {
            public AsmAddress Address {get;}

            [MethodImpl(Inline)]
            public m128(AsmAddress address)
            {
                Address = address;
            }

            [MethodImpl(Inline)]
            public m128(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            {
                Address = new AsmAddress(@base, index, scale, disp);
            }

            public NativeSize Size
            {
                [MethodImpl(Inline)]
                get => Sizes.native(128);
            }

            public string Format()
                => Address.Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator m128(AsmAddress src)
                => new m128(src);

            [MethodImpl(Inline)]
            public static implicit operator m128(mem<m128> src)
                => new m128(src);

            [MethodImpl(Inline)]
            public static implicit operator mem<m128>(m128 src)
                => new mem<m128>(src.Address);
        }
    }
}