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
        public readonly struct m16 : IMemOp16<m16>
        {
            public AsmAddress Address {get;}


            [MethodImpl(Inline)]
            public m16(AsmAddress address)
            {
                Address = address;
            }

            [MethodImpl(Inline)]
            public m16(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            {
                Address = new AsmAddress(@base, index, scale, disp);
            }

            public NativeSize Size
            {
                [MethodImpl(Inline)]
                get => Sizes.native(16);
            }

            public string Format()
                => Address.Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator m16(AsmAddress src)
                => new m16(src);

            [MethodImpl(Inline)]
            public static implicit operator m16(mem<m16> src)
                => new m16(src);

            [MethodImpl(Inline)]
            public static implicit operator mem<m16>(m16 src)
                => new mem<m16>(src.Address);
        }
    }
}