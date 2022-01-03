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

    public readonly struct XedInstructions
    {
        Index<InstInfo> _Descriptions {get;}

        Index<InstOperandInfo> _Operands {get;}

        public XedInstructions(InstInfo[] entries, InstOperandInfo[] operands)
        {
            _Descriptions = entries;
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
            get => _Descriptions.Count;
        }

        public ReadOnlySpan<InstInfo> Descriptions
        {
            [MethodImpl(Inline)]
            get => _Descriptions;
        }

        public ReadOnlySpan<InstOperandInfo> Operands
        {
            [MethodImpl(Inline)]
            get => _Operands;
        }

        [MethodImpl(Inline)]
        public ref readonly InstInfo Instruction(ushort index)
            => ref _Descriptions[index];

        [MethodImpl(Inline)]
        public ref readonly InstOperandInfo Operand(uint index)
            => ref _Operands[index];

        public static XedInstructions Empty => new XedInstructions(sys.empty<InstInfo>(), sys.empty<InstOperandInfo>());

        [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
        public struct InstOperandInfo
        {
            public const string TableId = "xed.inst.operand.info";

            public const byte FieldCount = 9;

            public ushort InstIndex;

            public byte OpIndex;

            public OperandKind Kind;

            public VisibilityKind Visibility;

            public OperandAction Action;

            public LookupKind Lookup;

            public BaseType Type;

            public Nonterminal NonTerm;

            public Register Register;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,12,16,16,16,16,16,16,1};
        }

        [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
        public struct InstInfo
        {
            public const string TableId = "xed.instruction";

            public const byte FieldCount = 8;

            public ushort Index;

            public byte OpCount;

            public IClass Class;

            public IFormType Form;

            public CategoryKind Category;

            public ExtensionKind Extension;

            public IsaKind Isa;

            public DelimitedIndex<string> Attributes;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,24,60,16,16,16,1};
        }
    }
}