//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static XedPatterns;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct XedFormImport : IComparable<XedFormImport>
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

        public int CompareTo(XedFormImport src)
            => Index.CompareTo(src.Index);

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{8,60,20,16,16,16,1};

        public static XedFormImport Empty => default;
    }
}