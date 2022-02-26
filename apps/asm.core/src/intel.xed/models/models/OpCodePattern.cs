//-----------------------------------------------------------------------------
// Copyright   : Intel Corporation, 2020
// License     : Apache
// Sources     : all-map-descriptions.txt
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct XedModels
    {
        [Record(TableId)]
        public struct OpCodePattern
        {
            public const string TableId = "xed.rules.ocpattern";

            public const byte FieldCount = 6;

            public byte Index;

            public OpCodeClass Class;

            public text15 Name;

            public byte Number;

            public OpCodeKind Identity;

            public text15 Pattern;

            public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{6,12,16,12,16,1};
        }
    }
}