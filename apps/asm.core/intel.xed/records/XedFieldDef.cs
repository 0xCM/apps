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
        [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct XedFieldDef : IComparable<XedFieldDef>
        {
            public const string TableId = "xed.fields.imported";

            [Render(32)]
            public text31 Name;

            [Render(32)]
            public EnumFormat<XedFieldType> FieldType;

            [Render(8)]
            public byte Width;

            [Render(1)]
            public VisibilityKind Visibility;

            public int CompareTo(XedFieldDef src)
                => Name.CompareTo(src.Name);

            public static XedFieldDef Empty => default;
        }
    }
}