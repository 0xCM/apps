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
        public readonly struct mem : IMemOpClass<mem>, IAsmSigOp<mem, MemToken>
        {
            public MemToken Token => MemToken.mem;

            public NativeSize Size {get;}

            [MethodImpl(Inline)]
            public mem(NativeSize size)
            {
                Size = size;
            }

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(mem src)
                => new AsmOperand(src.OpClass, src.Size);
        }

        public readonly struct m8 : IMemOpClass<m8>, IAsmSigOp<m8, MemToken>
        {
            public MemToken Token => MemToken.m8;

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

            public NativeSize Size
                => NativeSizeCode.W8;

            [MethodImpl(Inline)]
            public static implicit operator mem(m8 src)
                => new mem(src.Size);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(m8 src)
                => new AsmOperand(src.OpClass, src.Size);
        }

        public readonly struct m16 : IMemOpClass<m16>, IAsmSigOp<m16, MemToken>
        {
            public MemToken Token => MemToken.m16;

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

            public NativeSize Size
                => NativeSizeCode.W16;

            [MethodImpl(Inline)]
            public static implicit operator mem(m16 src)
                => new mem(src.Size);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(m16 src)
                => new AsmOperand(src.OpClass, src.Size);
        }

        public readonly struct m32 : IMemOpClass<m32>, IAsmSigOp<m32, MemToken>
        {
            public MemToken Token => MemToken.m32;

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

            public NativeSize Size
                => NativeSizeCode.W32;

            [MethodImpl(Inline)]
            public static implicit operator mem(m32 src)
                => new mem(src.Size);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(m32 src)
                => new AsmOperand(src.OpClass, src.Size);
        }

        public readonly struct m64 : IMemOpClass<m64>, IAsmSigOp<m64, MemToken>
        {
            public MemToken Token => MemToken.m64;

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

            public NativeSize Size
                => NativeSizeCode.W64;

            [MethodImpl(Inline)]
            public static implicit operator mem(m64 src)
                => new mem(src.Size);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(m64 src)
                => new AsmOperand(src.OpClass, src.Size);
        }

        public readonly struct m128 : IMemOpClass<m128>, IAsmSigOp<m128, MemToken>
        {
            public MemToken Token => MemToken.m128;

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

            public NativeSize Size
                => NativeSizeCode.W128;

            [MethodImpl(Inline)]
            public static implicit operator mem(m128 src)
                => new mem(src.Size);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(m128 src)
                => new AsmOperand(src.OpClass, src.Size);
        }

        public readonly struct m256 : IMemOpClass<m256>, IAsmSigOp<m256, MemToken>
        {
            public MemToken Token => MemToken.m256;

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

            public NativeSize Size
                => NativeSizeCode.W256;

            [MethodImpl(Inline)]
            public static implicit operator mem(m256 src)
                => new mem(src.Size);

            [MethodImpl(Inline)]
            public static implicit operator AsmOperand(m256 src)
                => new AsmOperand(src.OpClass, src.Size);
        }

        public readonly struct m512 : IMemOpClass<m512>, IAsmSigOp<m512, MemToken>
        {
            public MemToken Token => MemToken.m512;

            public AsmOpClass OpClass
                => AsmOpClass.Mem;

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