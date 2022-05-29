//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct FieldDefInfo
    {
        public const string TableId = "image.field-defs";

        public const byte FieldCount = 5;

        public string Component;

        public CliToken Token;

        public string Name;

        public CliSig CliSig;

        public FieldAttributes Attributes;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{24,16,48,48,12};
    }
}