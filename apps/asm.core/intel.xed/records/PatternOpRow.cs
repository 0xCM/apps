//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    partial class XedRules
    {
        [StructLayout(LayoutKind.Sequential,Pack=1), Record(TableName)]
        public record struct PatternOpRow
        {
            public const byte FieldCount = 22;

            public const string TableName = "xed.inst.patterns.ops";

            public uint PatternId;

            public InstClass InstClass;

            public MachineMode Mode;

            public InstLock Lock;

            public XedOpCode OpCode;

            public byte OpCount;

            public byte Index;

            public OpName Name;

            public OpKind Kind;

            public EnumFormat<OpAction> Action;

            public EnumFormat<OpWidthCode> WidthCode;

            public GprWidth GprWidth;

            public EmptyZero<ushort> BitWidth;

            public ElementType EType;

            public EmptyZero<ushort> EWidth;

            public EmptyZero<byte> ECount;

            public BitSegType SegInfo;

            public EmptyZero<Register> RegLit;

            public OpModifier Modifier;

            public Visibility Visibility;

            public Nonterminal NonTerminal;

            public asci32 SourceExpr;

            public static PatternOpRow Empty => default;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,18,6,6,28,10,10,8,8,8,10,10,10,10,6,6,12,12,8,12,16,1,};
        }
    }
}