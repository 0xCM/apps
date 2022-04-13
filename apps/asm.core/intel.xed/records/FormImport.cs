//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;

    partial struct XedModels
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
        public struct FormImport : IComparable<FormImport>
        {
            public const string TableId = "xed.iform";

            public const byte FieldCount = 7;

            public ushort Index;

            public InstForm InstForm;

            public InstClass InstClass;

            public CategoryKind Category;

            public IsaKind IsaKind;

            public ExtensionKind Extension;

            public InstAttribs Attributes;

            public int CompareTo(FormImport src)
                => Index.CompareTo(src.Index);

            public static ReadOnlySpan<byte> RenderWidths
                => new byte[FieldCount]{8,60,20,16,16,16,1};

            public static FormImport Empty => default;
        }
    }
}