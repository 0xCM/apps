//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;

    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct XedInstInfo
    {
        public const string TableId = "xed.instruction";

        public const byte FieldCount = 8;

        public ushort Index;

        public byte OpCount;

        public IClass Class;

        public IFormType Form;

        public CategoryKind Category;

        public ExtensionKind Extension;

        public IsaKind Isa;

        public DelimitedIndex<string> Attributes;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,24,60,16,16,16,1};
    }
}