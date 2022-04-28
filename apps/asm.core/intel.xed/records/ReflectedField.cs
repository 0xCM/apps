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
        public struct ReflectedField : IComparable<ReflectedField>
        {
            public const string TableName = "xed.fields.positioned";

            public const byte FieldCount = 9;

            public byte Pos;

            public byte Index;

            public FieldKind Field;

            public asci16 DataType;

            public Aligned NativeWidth;

            public ushort NativeOffset;

            public DataSize PackedWidth;

            public ushort PackedOffset;

            public TextBlock Description;

            [MethodImpl(Inline)]
            public int CompareTo(ReflectedField src)
                => Index.CompareTo(src.Index);

            public static ReflectedField Empty => default;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,24,16,12,12,12,12,1};
        }
    }
}