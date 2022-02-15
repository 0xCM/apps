//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Operands;

    using static core;

    using B = ByteBlock10;

    [StructLayout(LayoutKind.Sequential,Pack=1), ApiComplete]
    public struct AsmOperand : IAsmOp
    {
        [MethodImpl(Inline), Op]
        public static AsmOpKind kind(AsmOpClass @class, NativeSizeCode size)
            => (AsmOpKind)math.or((ushort)@class, math.sll((ushort)(size), 8));

        public readonly AsmOpClass OpClass;

        public readonly AsmOpKind OpKind;

        public readonly NativeSize Size;

        B _Data;

        [MethodImpl(Inline)]
        public AsmOperand(MemOp src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,MemOp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(RegOp src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = u16(src);
        }

        [MethodImpl(Inline)]
        public AsmOperand(Imm src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Imm>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(imm8 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = NativeSizeCode.W8;
            _Data = B.Empty;
            @as<B,imm8>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(imm16 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = NativeSizeCode.W16;
            _Data = B.Empty;
            @as<B,imm16>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(imm32 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = NativeSizeCode.W32;
            _Data = B.Empty;
            @as<B,imm32>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(imm64 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = NativeSizeCode.W64;
            _Data = B.Empty;
            @as<B,imm64>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(m8 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,m8>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(m16 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,m16>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(m32 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,m32>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(m64 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,m64>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(m128 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,m128>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(m256 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,m256>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(m512 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,m512>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Disp8 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp8>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Rel8 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Rel8>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Rel16 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Rel16>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Rel32 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Rel32>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Rel src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Rel>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Disp16 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp16>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Disp32 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp32>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Disp64 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp64>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Disp src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(RegMask src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,RegMask>(_Data) = src;
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
        public static implicit operator AsmOperand(imm32 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(imm64 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(Disp32 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand(Disp64 src)
            => new AsmOperand(src);

        [MethodImpl(Inline)]
        public static implicit operator AsmOperand<B>(AsmOperand src)
            =>  new AsmOperand<B>(src.OpClass, src.Size, src._Data);

        public static AsmOperand Empty => default;
    }
}