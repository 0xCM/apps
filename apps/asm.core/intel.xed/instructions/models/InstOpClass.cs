//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;

    partial class XedRules
    {
        /// <summary>
        /// Characterizes a disassembled operand class
        /// </summary>
        [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
        public record struct InstOpClass : IComparable<InstOpClass>
        {
            public const string TableId = "xed.inst.ops.classes";

            public const byte FieldCount = 8;

            public uint Seq;

            public OpKind Kind;

            public ushort DataWidth;

            public OpWidthCode WidthCode;

            public ElementType ElementType;

            public byte CellCount;

            public bit IsRegLit;

            public bit IsLookup;

            public int CompareTo(InstOpClass src)
                => XedRules.cmp(this,src);

            public static InstOpClass Empty => default;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,12,12,12,12,12,12,12};

            /*
                ("Seq",8),
                ("Kind",8),
                ("DataWidth", 12),
                ("ElementType", 12),
                ("IsRegLit", 12),
                ("IsLookup", 12),
                ("CellCount", 12),
                ("WidthCode", 16)
                );

            */
        }
    }
}