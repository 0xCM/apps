//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using Operands;

    using static Root;
    using static core;

    using B = ByteBlock10;

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct AsmOperand : IAsmOp
    {
        public readonly AsmOpClass OpClass;

        public readonly NativeSize Size;

        B _Data {get;}

        [MethodImpl(Inline)]
        internal AsmOperand(AsmOpClass opclass, NativeSize size)
        {
            OpClass = opclass;
            Size = size;
            _Data = default;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(MemOp src)
        {
            OpClass = AsmOpClass.M;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,MemOp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(RegOp src)
        {
            OpClass = AsmOpClass.R;
            Size = src.RegWidth;
            _Data = u16(src);
        }

        [MethodImpl(Inline)]
        internal AsmOperand(Imm src)
        {
            OpClass = AsmOpClass.Imm;
            Size = src.Size;
            _Data = src.Value;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(imm8 src)
        {
            OpClass = AsmOpClass.Imm;
            Size = NativeSizeCode.W8;
            _Data = (byte)src;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(imm16 src)
        {
            OpClass = AsmOpClass.Imm;
            Size = NativeSizeCode.W16;
            _Data = (ushort)src;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(imm32 src)
        {
            OpClass = AsmOpClass.Imm;
            Size = NativeSizeCode.W32;
            _Data = (uint)src;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(imm64 src)
        {
            OpClass = AsmOpClass.Imm;
            Size = NativeSizeCode.W64;
            _Data = (ulong)src;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(m8 src)
        {
            OpClass = AsmOpClass.M;
            Size = NativeSizeCode.W8;
            _Data = B.Empty;
            @as<B,m8>(_Data) = src;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(m16 src)
        {
            OpClass = AsmOpClass.M;
            Size = NativeSizeCode.W16;
            _Data = B.Empty;
            @as<B,m16>(_Data) = src;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(m32 src)
        {
            OpClass = AsmOpClass.M;
            Size = NativeSizeCode.W32;
            _Data = B.Empty;
            @as<B,m32>(_Data) = src;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(m64 src)
        {
            OpClass = AsmOpClass.M;
            Size = NativeSizeCode.W64;
            _Data = B.Empty;
            @as<B,m64>(_Data) = src;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(m128 src)
        {
            OpClass = AsmOpClass.M;
            Size = NativeSizeCode.W128;
            _Data = B.Empty;
            @as<B,m128>(_Data) = src;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(m256 src)
        {
            OpClass = AsmOpClass.M;
            Size = NativeSizeCode.W256;
            _Data = B.Empty;
            @as<B,m256>(_Data) = src;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(m512 src)
        {
            OpClass = AsmOpClass.M;
            Size = NativeSizeCode.W512;
            _Data = B.Empty;
            @as<B,m512>(_Data) = src;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(AsmAddress src)
        {
            OpClass = AsmOpClass.M;
            Size = src.AddressSize;
            _Data = B.Empty;
            @as<B,AsmAddress>(_Data) = src;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(AsmOpClass opclass, NativeSize size, B data)
        {
            OpClass = opclass;
            Size = size;
            _Data = data;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(Disp8 src)
        {
            OpClass = AsmOpClass.Disp;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp8>(_Data) = src;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(Disp16 src)
        {
            OpClass = AsmOpClass.Disp;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp16>(_Data) = src;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(Disp32 src)
        {
            OpClass = AsmOpClass.Disp;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp32>(_Data) = src;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(Disp64 src)
        {
            OpClass = AsmOpClass.Disp;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp64>(_Data) = src;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(Disp src)
        {
            OpClass = AsmOpClass.Disp;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(AsmRegMask src)
        {
            OpClass = AsmOpClass.Mask;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,AsmRegMask>(_Data) = src;
        }

        public ReadOnlySpan<byte> Data
        {
            [MethodImpl(Inline)]
            get => _Data.Bytes;
        }

        public bit IsEmpty
        {
            [MethodImpl(Inline)]
            get => OpClass == 0;
        }

        public bit IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => OpClass == 0;
        }

        AsmOpClass IAsmOp.OpClass
            => OpClass;

        NativeSize IAsmOp.Size
            => Size;

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(RegOp src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(AsmAddress src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(imm8 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(imm16 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(imm32 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(imm64 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(AsmRegMask src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(Disp src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(Disp8 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(Disp16 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(Disp32 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(Disp64 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(m8 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(m16 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(m32 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(m64 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(m128 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(m256 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(m512 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand<B>(AsmOperand src)
            =>  new AsmOperand<B>(src.OpClass, src.Size, src._Data);

        public static AsmOperand Empty => default;
    }
}