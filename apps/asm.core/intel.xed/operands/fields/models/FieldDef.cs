//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [Record(TableName), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct FieldDef : IComparable<FieldDef>
        {
            public const string TableName = "xed.fields.defs";

            public const byte FieldCount = 10;

            public byte Pos;

            public byte Index;

            public FieldKind Field;

            public asci16 DataType;

            public asci16 NativeType;

            public uint PackedWidth;

            public uint AlignedWidth;

            public uint PackedOffset;

            public uint AlignedOffset;

            public TextBlock Description;

            public DataSize Size
            {
                [MethodImpl(Inline)]
                get => new DataSize(PackedWidth, AlignedWidth);
            }

            [MethodImpl(Inline)]
            public int CompareTo(FieldDef src)
                => Index.CompareTo(src.Index);

            public static FieldDef Empty => default;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,24,16,16,16,16,16,16,1};
        }
    }
}