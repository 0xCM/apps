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
        [Op]
        public static string format(in AsmOperand src)
        {
            switch(src.OpClass)
            {
                case AsmOpClass.Mem:
                    return src.Mem.Format();
                case AsmOpClass.Reg:
                    return src.Reg.Format();
                case AsmOpClass.Imm:
                    return src.Imm.Format();
                case AsmOpClass.Disp:
                    return src.Disp.Format();
                case AsmOpClass.RegMask:
                    return src.RegMask.Format();
                default:
                    return EmptyString;
            }
        }

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
        public AsmOperand(Imm8 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Imm>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Imm16u src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Imm>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Imm16i src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Imm>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Imm32 src)
        {
            OpClass = src.OpClass;
            OpKind = src.OpKind;
            Size = src.Size;
            _Data = B.Empty;
            @as<B,Imm>(_Data) = src;
        }

        [MethodImpl(Inline)]
        public AsmOperand(Imm64 src)
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

       public string Format()
            => format(this);

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