//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Source      : xed-reg-class.h
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential, Pack=1)]
        public struct PointerWidthRecord
        {
            public const string TableId = "xed.rules.widths.pointers";

            public const byte FieldCount = 4;

            public byte Seq;

            public text15 Name;

            public char Spec;

            public NativeSize Size;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{6,12,6,1};
        }
    }
}