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
            public const string TableId = "xed.rules.widths.pointers";

            public const byte FieldCount = 4;

            public byte Seq;

            public text15 Name;

            public text7 Spec;

            public NativeSize Size;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{6,12,6,1};
        }
    }
}