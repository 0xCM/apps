//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct CoffSymRecord : IOriginated
    {
        public const string TableId = "coff.symbols";

        public const byte FieldCount = 10;

        public uint Seq;

        public Hex32 OriginId;

        public ushort SectionNumber;

        public Address32 Address;

        public uint SymSize;

        public Hex32 Value;

        public SymStorageClass SymClass;

        public ushort AuxCount;

        public @string Name;

        public FS.FileUri Source;

        Hex32 IOriginated.OriginId
            => OriginId;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,12,16,10,8,10,16,8,48,1};

    }
}