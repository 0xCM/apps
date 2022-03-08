//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [Record(TableId)]
        public struct OpWidth : IComparable<OpWidth>
        {
            public const string TableId = "xed.rules.widths";

            public const byte FieldCount = 8;

            public OperandWidthKind Code;

            public text15 Name;

            public ElementType EType;

            public ushort EWidth;

            public ushort Width16;

            public ushort Width32;

            public ushort Width64;

            public SegType Seg;

            public string Format()
                => string.Format("{0}:{1}w", XedFormatters.format(Code), Width64);

            public override string ToString()
                => Format();

            public int CompareTo(OpWidth src)
                => Name.CompareTo(src.Name);

            public static OpWidth Empty => default;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,12,8,8,8,8,8,8};
        }
    }
}