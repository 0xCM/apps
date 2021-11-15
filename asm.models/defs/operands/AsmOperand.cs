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
    using static core;
    using static AsmOperands;

    [StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct AsmOperand : IAsmOperand
    {
        public readonly AsmOpClass OpClass;

        public readonly NativeSize Size;

        ByteBlock10 _Data {get;}

        [MethodImpl(Inline)]
        internal AsmOperand(AsmOpClass opclass, NativeSize size)
        {
            OpClass = opclass;
            Size = size;
            _Data = default;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(RegOp src)
        {
            OpClass = AsmOpClass.R;
            Size = src.RegWidth;
            _Data = u16(src);
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
            _Data = @as<AsmAddress,ByteBlock10>(src.Address);
        }

        [MethodImpl(Inline)]
        internal AsmOperand(m16 src)
        {
            OpClass = AsmOpClass.M;
            Size = NativeSizeCode.W16;
            _Data = @as<AsmAddress,ByteBlock10>(src.Address);
        }

        [MethodImpl(Inline)]
        internal AsmOperand(m32 src)
        {
            OpClass = AsmOpClass.M;
            Size = NativeSizeCode.W32;
            _Data = @as<AsmAddress,ByteBlock10>(src.Address);
        }

        [MethodImpl(Inline)]
        internal AsmOperand(m64 src)
        {
            OpClass = AsmOpClass.M;
            Size = NativeSizeCode.W64;
            _Data = @as<AsmAddress,ByteBlock10>(src.Address);
        }

        [MethodImpl(Inline)]
        internal AsmOperand(m128 src)
        {
            OpClass = AsmOpClass.M;
            Size = NativeSizeCode.W128;
            _Data = @as<AsmAddress,ByteBlock10>(src.Address);
        }

        [MethodImpl(Inline)]
        internal AsmOperand(m256 src)
        {
            OpClass = AsmOpClass.M;
            Size = NativeSizeCode.W256;
            _Data = @as<AsmAddress,ByteBlock10>(src.Address);
        }

        [MethodImpl(Inline)]
        internal AsmOperand(m512 src)
        {
            OpClass = AsmOpClass.M;
            Size = NativeSizeCode.W512;
            _Data = @as<AsmAddress,ByteBlock10>(src.Address);
        }

        [MethodImpl(Inline)]
        internal AsmOperand(AsmAddress src)
        {
            OpClass = AsmOpClass.M;
            Size = src.AddressSize;
            _Data = @as<AsmAddress,ByteBlock10>(src);
        }

        [MethodImpl(Inline)]
        internal AsmOperand(AsmOpClass opclass, NativeSize size, ByteBlock10 data)
        {
            OpClass = opclass;
            Size = size;
            _Data = data;
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

        AsmOpClass IAsmOperand.OpClass
            => OpClass;

        NativeSize IAsmOperand.Size
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
        public static implicit operator AsmOperand<ByteBlock10>(AsmOperand src)
            =>  new AsmOperand<ByteBlock10>(src.OpClass, src.Size, src._Data);

        public static AsmOperand Empty => default;
    }
}