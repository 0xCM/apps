//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System.Runtime.CompilerServices;

    using static Root;

    partial class AsmSigs
    {
        public readonly struct mem : IMemOpClass<mem>
        {
            public NativeSize Size {get;}

            [MethodImpl(Inline)]
            public mem(NativeSize size)
            {
                Size = size;
            }

            public AsmOpClass OpClass
                => AsmOpClass.M;

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(mem src)
                => new AsmOperand(src.OpClass, src.Size);
        }

        public readonly struct m8 : IMemOpClass<m8>
        {
            public AsmOpClass OpClass
                => AsmOpClass.M;

            public NativeSize Size
                => NativeSizeCode.W8;

            [MethodImpl(Inline)]
            public static implicit operator mem(m8 src)
                => new mem(src.Size);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(m8 src)
                => new AsmOperand(src.OpClass, src.Size);
        }

        public readonly struct m16 : IMemOpClass<m16>
        {
            public AsmOpClass OpClass
                => AsmOpClass.M;

            public NativeSize Size
                => NativeSizeCode.W16;

            [MethodImpl(Inline)]
            public static implicit operator mem(m16 src)
                => new mem(src.Size);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(m16 src)
                => new AsmOperand(src.OpClass, src.Size);
        }

        public readonly struct m32 : IMemOpClass<m32>
        {
            public AsmOpClass OpClass
                => AsmOpClass.M;

            public NativeSize Size
                => NativeSizeCode.W32;

            [MethodImpl(Inline)]
            public static implicit operator mem(m32 src)
                => new mem(src.Size);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(m32 src)
                => new AsmOperand(src.OpClass, src.Size);
        }

        public readonly struct m64 : IMemOpClass<m64>
        {
            public AsmOpClass OpClass
                => AsmOpClass.M;

            public NativeSize Size
                => NativeSizeCode.W64;

            [MethodImpl(Inline)]
            public static implicit operator mem(m64 src)
                => new mem(src.Size);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(m64 src)
                => new AsmOperand(src.OpClass, src.Size);
        }

        public readonly struct m128 : IMemOpClass<m128>
        {
            public AsmOpClass OpClass
                => AsmOpClass.M;

            public NativeSize Size
                => NativeSizeCode.W128;

            [MethodImpl(Inline)]
            public static implicit operator mem(m128 src)
                => new mem(src.Size);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(m128 src)
                => new AsmOperand(src.OpClass, src.Size);
        }

        public readonly struct m256 : IMemOpClass<m256>
        {
            public AsmOpClass OpClass
                => AsmOpClass.M;

            public NativeSize Size
                => NativeSizeCode.W256;

            [MethodImpl(Inline)]
            public static implicit operator mem(m256 src)
                => new mem(src.Size);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(m256 src)
                => new AsmOperand(src.OpClass, src.Size);
        }

        public readonly struct m512 : IMemOpClass<m512>
        {
            public AsmOpClass OpClass
                => AsmOpClass.M;

            public NativeSize Size
                => NativeSizeCode.W512;

            [MethodImpl(Inline)]
            public static implicit operator mem(m512 src)
                => new mem(src.Size);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(m512 src)
                => new AsmOperand(src.OpClass, src.Size);
        }
    }
}