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

            public const byte FieldCount = 10;

            public byte Pos;

            public byte Index;

            public FieldKind Field;

            public asci16 DataType;

            public asci16 NativeType;

            public byte NativeWidth;

            public ushort NativeOffset;

            public byte PackedWidth;

            public ushort PackedOffset;

            public TextBlock Description;

            public DataSize Size
            {
                [MethodImpl(Inline)]
                get => new DataSize(NativeWidth, PackedWidth);
            }

            [MethodImpl(Inline)]
            public int CompareTo(ReflectedField src)
                => Index.CompareTo(src.Index);

            public static ReflectedField Empty => default;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,24,16,16,12,12,12,12,1};
        }
    }
}