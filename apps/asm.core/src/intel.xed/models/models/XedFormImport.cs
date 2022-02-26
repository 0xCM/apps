//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct XedFormImport : IComparable<XedFormImport>
    {
        public const string TableId = "xed.iform";

        public const byte FieldCount = 7;

        public ushort Index;

        public IFormType Form;

        public IClass Class;

        public CategoryKind Category;

        public IsaKind IsaKind;

        public ExtensionKind Extension;

        public DelimitedIndex<AttributeKind> Attributes;

        public int CompareTo(XedFormImport src)
            => Index.CompareTo(src.Index);

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{8,60,32,24,24,16,1};
    }
}