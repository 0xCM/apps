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

            public ushort BitWidth;

            public OpWidth OpWidth;

            public ElementType ElementType;

            public byte ElementCount;

            public bit IsRegLit;

            public bit IsRule;

            public int CompareTo(InstOpClass src)
                => XedRules.cmp(this,src);

            public static InstOpClass Empty => default;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,12,12,12,12,12,12,12};
        }
    }
}