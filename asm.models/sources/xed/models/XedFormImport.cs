//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    using static XedModels;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct XedFormImport : IRecord<XedFormImport>
    {
        public const string TableId = "xed.iform";

        public const byte FieldCount = 7;

        public ushort Index;

        public IForm Form;

        public IClass Class;

        public Category Category;

        public IsaKind IsaKind;

        public Extension Extension;

        public DelimitedIndex<AttributeKind> Attributes;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{8,60,32,16,16,16,1};
    }
}