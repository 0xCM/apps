//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRecords;

    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct XedInstOperand
    {
        public const string TableId = "xed.inst.operand.info";

        public const byte FieldCount = 9;

        public ushort InstIndex;

        public byte OpIndex;

        public XedOpKind Kind;

        public VisibilityKind Visibility;

        public OperandAction Action;

        public LookupKind Lookup;

        public BaseTypeKind Type;

        public NonterminalKind NonTerm;

        public XedRegId Register;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,12,16,16,16,16,16,16,1};
    }
}