//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct XedFieldDef : IComparable<XedFieldDef>
        {
            public const string TableId = "xed.fields";

            public const byte FieldCount = 4;

            public text31 Name;

            public FieldType FieldType;

            public byte Width;

            public VisibilityKind Visibility;

            public int CompareTo(XedFieldDef src)
                => Name.CompareTo(src.Name);

            public static XedFieldDef Empty => default;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{32,32,8,1};
        }
    }
}