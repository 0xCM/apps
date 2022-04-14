//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        [Record(TableName)]
        public struct ReflectedField
        {
            public const string TableName = "xed.fields.reflected";

            public const byte FieldCount = 10;

            public ushort Index;

            public FieldKind Field;

            public FieldType FieldType;

            public FieldType FieldTypeE;

            public byte FieldWidth;

            public byte FieldWidthE;

            public ushort TotalSize;

            public ushort TotalWidthE;

            public ushort TotalSizeE;

            public TextBlock Description;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,24,16,16,16,16,12,12,12,1};
        }
    }
}