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
            public const string TableName = "xed.fields";

            public const byte FieldCount = 8;

            public byte Pos;

            public byte Index;

            public FieldKind Field;

            public FieldSize FieldSize;

            public FieldSize TotalSize;

            public FieldTypeName DataType;

            public FieldTypeName DomainType;

            public TextBlock Description;

            [MethodImpl(Inline)]
            public int CompareTo(ReflectedField src)
                => Index.CompareTo(src.Index);

            public static ReflectedField Empty => default;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,24,20,20,16,16,1};
        }
    }
}