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
        public struct PointerWidthInfo
        {
            public const string TableId = "xed.widths.pointers";

            public const byte FieldCount = 4;

            [Render(6)]
            public byte Seq;

            [Render(12)]
            public text15 Name;

            [Render(6)]
            public char Symbol;

            [Render(1)]
            public NativeSize Size;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{6,12,6,1};
        }
    }
}