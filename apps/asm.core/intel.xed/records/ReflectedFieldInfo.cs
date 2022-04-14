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

            public const byte FieldCount = 12;

            public ushort Index;

            public FieldKind Field;

            public FieldTypeName DataKind;

            public FieldTypeName DomainType;

            public byte DataSize;

            public byte DataWidth;

            public byte DomainWidth;

            public ushort DataSizeT;

            public ushort DataWidthT;

            public ushort DomainWidthT;

            public ushort DomainSizeT;

            public TextBlock Description;

            public static ReflectedField Empty => default;

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => Field == 0;
            }

            public bool IsNonEmpyt
            {
                [MethodImpl(Inline)]
                get => Field != 0;
            }

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,24,16,16,16,16,16,16,16,16,16,1};
        }
    }
}