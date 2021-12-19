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

            //1
            public byte OperandIndex;

            //1
            public OperandKind Kind;

            //1
            public OperandVisibility Visibility;

            //1
            public OperandAction Action;

            //1
            public LookupKind Lookup;

            //1
            public OperandElementType Type;

            //2
            public Nonterminal NonTerm;

            //2
            public RegId Register;
        }

        [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
        public struct InstInfo
        {
            public const string TableId = "xed.table.instruction";

            public ushort Index;

            public IClass Class;

            public IFormType Form;

            public Category Category;

            public Extension Extension;

            public IsaKind Isa;

            public AttributeVector Attributes;

            public byte OperandCount;
        }
    }
}