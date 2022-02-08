//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-Extension-enum.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedRecords
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct XedFieldDef
        {
            public const string TableId = "xed.fields";

            public const byte FieldCount = 4;

            public text31 Name;

            public TypeSpec Type;

            public byte Width;

            public VisibilityKind Visibility;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{32,32,8,1};

            public static XedFieldDef Empty => default;
        }
    }
}