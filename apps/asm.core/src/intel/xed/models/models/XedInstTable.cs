//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;

    using static XedModels;

    public readonly struct XedInstTable
    {
        Index<InstInfo> _Instructions {get;}

        Index<InstOperand> _Operands {get;}

        public XedInstTable(InstInfo[] entries, InstOperand[] operands)
        {
            _Instructions = entries;
            _Operands = operands;
        }

        public uint OperandCount
        {
            [MethodImpl(Inline)]
            get => _Operands.Count;
        }

        public uint InstCount
        {
            [MethodImpl(Inline)]
            get => _Instructions.Count;
        }

        public ReadOnlySpan<InstInfo> Instructions
        {
            get => _Instructions;
        }
        public ReadOnlySpan<InstOperand> Operands
        {
            [MethodImpl(Inline)]
            get => _Operands;
        }

        [MethodImpl(Inline)]
        public ref readonly InstInfo Instruction(ushort index)
            => ref _Instructions[index];

        [MethodImpl(Inline)]
        public ref readonly InstOperand Operand(uint index)
            => ref _Operands[index];

        public static XedInstTable Empty => new XedInstTable(sys.empty<InstInfo>(), sys.empty<InstOperand>());

        [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
        public struct InstOperand
        {
            public const string TableId = "xed.table.operand";

            public ushort InstIndex;

            public byte OperandIndex;

            public OperandKind Kind;

            public OperandVisibility Visibility;

            public OperandAction Action;

            public LookupKind Lookup;

            public OperandElementType Type;

            public Nonterminal NonTerm;

            public RegId Register;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
        public struct InstInfo
        {
            public const string TableId = "xed.table.instruction";

            public const byte FieldCount = 8;

            public ushort Index;

            public byte OpCount;

            public IClass Class;

            public IFormType Form;

            public Category Category;

            public Extension Extension;

            public IsaKind Isa;

            public AttributeVector Attributes;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,24,48,16,16,16,1};
        }
    }
}