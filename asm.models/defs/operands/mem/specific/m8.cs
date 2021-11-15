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
        public readonly struct m8 : IMemOp8<m8>
        {
            public AsmAddress Address {get;}

            [MethodImpl(Inline)]
            public m8(AsmAddress address)
            {
                Address = address;
            }

            [MethodImpl(Inline)]
            public m8(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            {
                Address = new AsmAddress(@base, index, scale, disp);
            }

            public NativeSize Size
            {
                [MethodImpl(Inline)]
                get => Sizes.native(8);
            }

            public string Format()
                => Address.Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator m8(AsmAddress src)
                => new m8(src);

            [MethodImpl(Inline)]
            public static implicit operator m8(mem<m8> src)
                => new m8(src);

            [MethodImpl(Inline)]
            public static implicit operator mem<m8>(m8 src)
                => new mem<m8>(src.Address);
        }
    }
}