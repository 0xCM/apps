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
        public readonly struct m32 : IMemOp32<m32>
        {
            public AsmAddress Address {get;}

            [MethodImpl(Inline)]
            public m32(AsmAddress address)
            {
                Address = address;
            }

            [MethodImpl(Inline)]
            public m32(RegOp @base, RegOp index, MemoryScale scale, Disp disp)
            {
                Address = new AsmAddress(@base, index, scale, disp);
            }

            public NativeSize Size
            {
                [MethodImpl(Inline)]
                get => Sizes.native(32);
            }

            public string Format()
                => Address.Format();

            public override string ToString()
                => Format();

            [MethodImpl(Inline)]
            public static implicit operator m32(AsmAddress src)
                => new m32(src);

            [MethodImpl(Inline)]
            public static implicit operator m32(mem<m32> src)
                => new m32(src);

            [MethodImpl(Inline)]
            public static implicit operator mem<m32>(m32 src)
                => new mem<m32>(src.Address);
        }
    }
}