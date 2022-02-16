//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Operands;

    using static core;

    using B = ByteBlock16;

    [StructLayout(LayoutKind.Sequential,Pack=1), ApiComplete]
    public struct AsmOperand : IAsmOp
    {
        public readonly AsmOpClass OpClass;

        public readonly AsmOpKind OpKind;

        public readonly NativeSize Size;

        B _Data;

        [MethodImpl(Inline)]
        public AsmOperand(RegOp src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,RegOp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(imm8 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Imm>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(imm16 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Imm>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(imm32 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Imm>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(imm64 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Imm>(_Data) = src;
        }

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
        public AsmOperand(m8 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,MemOp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(m16 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,MemOp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(m32 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,MemOp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(m64 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,MemOp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(m128 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,MemOp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(m256 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,MemOp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(m512 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,MemOp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Disp8 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Disp16 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Disp32 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Disp64 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Disp>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Rel8 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Rel>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Rel16 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Rel>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Rel32 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Rel>(_Data) = src;
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
            get  => ref @as<Imm>(Data);
        }

        public ref readonly RegMask RegMask
        {
            [MethodImpl(Inline)]
            get => ref @as<RegMask>(Data);
        }

        public ref readonly Rel Rel
        {
            [MethodImpl(Inline)]
            get => ref @as<Rel>(Data);
        }

        public ref readonly Disp Disp
        {
            [MethodImpl(Inline)]
            get => ref @as<Disp>(Data);
        }


        // public ref readonly r8 Reg8
        // {
        //     [MethodImpl(Inline)]
        //     get => ref @as<r8>(Data);
        // }

        // public ref readonly r16 Reg16
        // {
        //     [MethodImpl(Inline)]
        //     get => ref @as<r16>(Data);
        // }

        // public ref readonly r32 Reg32
        // {
        //     [MethodImpl(Inline)]
        //     get => ref @as<r32>(Data);
        // }

        // public ref readonly r64 Reg64
        // {
        //     [MethodImpl(Inline)]
        //     get => ref @as<r64>(Data);
        // }

        // public ref readonly m8 Mem8
        // {
        //     [MethodImpl(Inline)]
        //     get => ref @as<m8>(Data);
        // }

        // public ref readonly m16 Mem16
        // {
        //     [MethodImpl(Inline)]
        //     get => ref @as<m16>(Data);
        // }

        // public ref readonly m32 Mem32
        // {
        //     [MethodImpl(Inline)]
        //     get => ref @as<m32>(Data);
        // }

        // public ref readonly m64 Mem64
        // {
        //     [MethodImpl(Inline)]
        //     get  => ref first(recover<m64>(Data));
        // }

        // public ref readonly m128 Mem128
        // {
        //     [MethodImpl(Inline)]
        //     get  => ref first(recover<m128>(Data));
        // }

        // public ref readonly m256 Mem256
        // {
        //     [MethodImpl(Inline)]
        //     get  => ref first(recover<m256>(Data));
        // }

        // public ref readonly m512 Mem512
        // {
        //     [MethodImpl(Inline)]
        //     get  => ref first(recover<m512>(Data));
        // }

        // public ref readonly imm8 Imm8
        // {
        //     [MethodImpl(Inline)]
        //     get => ref @as<imm8>(Data);
        // }

        // public ref readonly imm16 Imm16
        // {
        //     [MethodImpl(Inline)]
        //     get => ref @as<imm16>(Data);
        // }

        // public ref readonly imm32 Imm32
        // {
        //     [MethodImpl(Inline)]
        //     get  => ref first(recover<imm32>(Data));
        // }

        // public ref readonly imm64 Imm64
        // {
        //     [MethodImpl(Inline)]
        //     get  => ref first(recover<imm64>(Data));
        // }

        public string Format()
            => AsmRender.format(this);

        public override string ToString()
            => Format();

        AsmOpClass IAsmOp.OpClass
            => OpClass;

        NativeSize IAsmOp.Size
            => Size;

        AsmOpKind IAsmOp.OpKind
            => OpKind;

        public static AsmOperand Empty => default;
    }
}