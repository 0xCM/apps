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

    [StructLayout(LayoutKind.Sequential,Pack=1), ApiComplete]
    public struct AsmOperand : IAsmOp
    {
        [MethodImpl(Inline), Op]
        public static AsmOpKind kind(AsmOpClass @class, NativeSizeCode size)
            => (AsmOpKind)math.or((ushort)@class, math.sll((ushort)(size), 8));

        [MethodImpl(Inline), Op]
        public static AsmOperand op(r8 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(r16 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(r32 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(r64 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(xmm src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(ymm src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(zmm src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(imm8 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(imm16 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(imm32 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(imm64 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(m8 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(m16 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(m32 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(m64 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(m128 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(m256 src)
            => new AsmOperand(src);

        [MethodImpl(Inline), Op]
        public static AsmOperand op(m512 src)
            => new AsmOperand(src);

        public readonly AsmOpClass OpClass;

        public readonly AsmOpKind OpKind;

        public readonly NativeSize Size;

        B _Data;

        [MethodImpl(Inline)]
        internal AsmOperand(MemOp src)
        {
            OpClass = AsmOpClass.Mem;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,MemOp>(_Data) = src;
            OpKind = (AsmOpKind)((ushort)AsmOpKind.Mem | ((ushort)src.Size.Code << 8));
        }

        [MethodImpl(Inline)]
        internal AsmOperand(RegOp src)
        {
            OpClass = AsmOpClass.Reg;
            Size = src.RegWidth;
            _Data = u16(src);
            OpKind = (AsmOpKind)((ushort)AsmOpKind.Reg | ((ushort)src.Size << 8));
        }

        [MethodImpl(Inline)]
        internal AsmOperand(Imm src)
        {
            OpClass = AsmOpClass.Imm;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Imm>(_Data) = src;
            OpKind = (AsmOpKind)((ushort)AsmOpKind.Imm | ((ushort)src.Size << 8));
        }

        [MethodImpl(Inline)]
        internal AsmOperand(imm8 src)
        {
            OpClass = AsmOpClass.Imm;
            Size = NativeSizeCode.W8;
            _Data = B.Empty;
            @as<B,imm8>(_Data) = src;
            OpKind = AsmOpKind.Imm8;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(imm16 src)
        {
            OpClass = AsmOpClass.Imm;
            Size = NativeSizeCode.W16;
            _Data = B.Empty;
            @as<B,imm16>(_Data) = src;
            OpKind = AsmOpKind.Imm16;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(imm32 src)
        {
            OpClass = AsmOpClass.Imm;
            Size = NativeSizeCode.W32;
            _Data = B.Empty;
            @as<B,imm32>(_Data) = src;
            OpKind = AsmOpKind.Imm32;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(imm64 src)
        {
            OpClass = AsmOpClass.Imm;
            Size = NativeSizeCode.W64;
            _Data = B.Empty;
            @as<B,imm64>(_Data) = src;
            OpKind = AsmOpKind.Imm64;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(m8 src)
        {
            OpClass = AsmOpClass.Mem;
            Size = NativeSizeCode.W8;
            _Data = B.Empty;
            @as<B,m8>(_Data) = src;
            OpKind = AsmOpKind.Mem8;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(m16 src)
        {
            OpClass = AsmOpClass.Mem;
            Size = NativeSizeCode.W16;
            _Data = B.Empty;
            @as<B,m16>(_Data) = src;
            OpKind = AsmOpKind.Mem16;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(m32 src)
        {
            OpClass = AsmOpClass.Mem;
            Size = NativeSizeCode.W32;
            _Data = B.Empty;
            @as<B,m32>(_Data) = src;
            OpKind = AsmOpKind.Mem32;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(m64 src)
        {
            OpClass = AsmOpClass.Mem;
            Size = NativeSizeCode.W64;
            _Data = B.Empty;
            @as<B,m64>(_Data) = src;
            OpKind = AsmOpKind.Mem64;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(m128 src)
        {
            OpClass = AsmOpClass.Mem;
            Size = NativeSizeCode.W128;
            _Data = B.Empty;
            @as<B,m128>(_Data) = src;
            OpKind = AsmOpKind.Mem128;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(m256 src)
        {
            OpClass = AsmOpClass.Mem;
            Size = NativeSizeCode.W256;
            _Data = B.Empty;
            @as<B,m256>(_Data) = src;
            OpKind = AsmOpKind.Mem256;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(m512 src)
        {
            OpClass = AsmOpClass.Mem;
            Size = NativeSizeCode.W512;
            _Data = B.Empty;
            @as<B,m512>(_Data) = src;
            OpKind = AsmOpKind.Mem512;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(Disp8 src)
        {
            OpClass = AsmOpClass.Disp;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp8>(_Data) = src;
            OpKind = AsmOpKind.Disp8;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(Disp16 src)
        {
            OpClass = AsmOpClass.Disp;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp16>(_Data) = src;
            OpKind = AsmOpKind.Disp16;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(Disp32 src)
        {
            OpClass = AsmOpClass.Disp;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp32>(_Data) = src;
            OpKind = AsmOpKind.Disp32;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(Disp64 src)
        {
            OpClass = AsmOpClass.Disp;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp64>(_Data) = src;
            OpKind = AsmOpKind.Disp64;
        }

        [MethodImpl(Inline)]
        internal AsmOperand(Disp src)
        {
            OpClass = AsmOpClass.Disp;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp>(_Data) = src;
            OpKind = (AsmOpKind)((ushort)AsmOpKind.Disp | ((ushort)src.Size.Code << 8));
        }

        [MethodImpl(Inline)]
        internal AsmOperand(RegMask src)
        {
            OpClass = AsmOpClass.RegMask;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,RegMask>(_Data) = src;
            OpKind = (AsmOpKind)((ushort)AsmOpKind.RegMask | ((ushort)src.Size.Code << 8));
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => OpClass == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => OpClass == 0;
        }

        public bool IsReg
        {
            [MethodImpl(Inline)]
            get => AsmOpTests.IsReg(OpKind);
        }

        public bool IsMem
        {
            [MethodImpl(Inline)]
            get => AsmOpTests.IsMem(OpKind);
        }

        public bool IsImm
        {
            [MethodImpl(Inline)]
            get => AsmOpTests.IsImm(OpKind);
        }

        public bool IsDisp
        {
            [MethodImpl(Inline)]
            get => AsmOpTests.IsDisp(OpKind);
        }

        public bool IsRegMask
        {
            [MethodImpl(Inline)]
            get => AsmOpTests.IsRegMask(OpKind);
        }

        public ReadOnlySpan<byte> Data
        {
            [MethodImpl(Inline)]
            get => _Data.Bytes;
        }

        public ref readonly RegOp Reg
        {
            [MethodImpl(Inline)]
            get => ref @as<RegOp>(Data);
        }

        public ref readonly MemOp Mem
        {
            [MethodImpl(Inline)]
            get => ref @as<MemOp>(Data);
        }

        public ref readonly Imm Imm
        {
            [MethodImpl(Inline)]
            get  => ref first(recover<Imm>(Data));
        }

        public ref readonly RegMask RegMask
        {
            [MethodImpl(Inline)]
            get => ref @as<RegMask>(Data);
        }

        public ref readonly Disp Disp
        {
            [MethodImpl(Inline)]
            get => ref first(recover<Disp>(Data));
        }

        public ref readonly r8 Reg8
        {
            [MethodImpl(Inline)]
            get => ref @as<r8>(Data);
        }

        public ref readonly r16 Reg16
        {
            [MethodImpl(Inline)]
            get => ref @as<r16>(Data);
        }

        public ref readonly r32 Reg32
        {
            [MethodImpl(Inline)]
            get => ref @as<r32>(Data);
        }

        public ref readonly r64 Reg64
        {
            [MethodImpl(Inline)]
            get => ref @as<r64>(Data);
        }

        public ref readonly m8 Mem8
        {
            [MethodImpl(Inline)]
            get => ref @as<m8>(Data);
        }

        public ref readonly m16 Mem16
        {
            [MethodImpl(Inline)]
            get => ref @as<m16>(Data);
        }

        public ref readonly m32 Mem32
        {
            [MethodImpl(Inline)]
            get => ref @as<m32>(Data);
        }

        public ref readonly m64 Mem64
        {
            [MethodImpl(Inline)]
            get  => ref first(recover<m64>(Data));
        }

        public ref readonly m128 Mem128
        {
            [MethodImpl(Inline)]
            get  => ref first(recover<m128>(Data));
        }

        public ref readonly m256 Mem256
        {
            [MethodImpl(Inline)]
            get  => ref first(recover<m256>(Data));
        }

        public ref readonly m512 Mem512
        {
            [MethodImpl(Inline)]
            get  => ref first(recover<m512>(Data));
        }

        public ref readonly imm8 Imm8
        {
            [MethodImpl(Inline)]
            get => ref @as<imm8>(Data);
        }

        public ref readonly imm16 Imm16
        {
            [MethodImpl(Inline)]
            get => ref @as<imm16>(Data);
        }

        public ref readonly imm32 Imm32
        {
            [MethodImpl(Inline)]
            get  => ref first(recover<imm32>(Data));
        }

        public ref readonly imm64 Imm64
        {
            [MethodImpl(Inline)]
            get  => ref first(recover<imm64>(Data));
        }

        public string Format()
        {
            if(IsReg)
                return Reg.Format();
            else if(IsMem)
                return Mem.Format();
            else if(IsImm)
            {
                return Size.Code switch
                {
                    NativeSizeCode.W8 => Imm8.Format(),
                    NativeSizeCode.W16 => Imm16.Format(),
                    NativeSizeCode.W32 => Imm32.Format(),
                    NativeSizeCode.W64 => Imm64.Format(),
                    _ => "<unsized>",

                };
            }
            else if(IsRegMask)
                return RegMask.Format();
            else if(IsDisp)
                return Disp.Format();
            else
                return EmptyString;
        }

        public override string ToString()
            => Format();

        AsmOpClass IAsmOp.OpClass
            => OpClass;

        NativeSize IAsmOp.Size
            => Size;

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(RegOp src)
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
        public static implicit operator AsmOperand(RegMask src)
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