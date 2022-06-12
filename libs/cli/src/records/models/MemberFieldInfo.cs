//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct MemberFieldInfo : IRecord<MemberFieldInfo>
    {
        public const byte FieldCount = 6;

        public const string TableId = "cli.metadata.fields";

        public CliToken Token;

        public uint Offset;

        public Address32 Rva;

        public Name FieldName;

        public FieldAttributes Attribs;

        public BinaryCode Sig;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{10,10,10,56,56,64};
    }
}