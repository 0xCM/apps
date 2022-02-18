//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct CoffSymRecord
    {
        public const string TableId = "coff.symbols";

        public const byte FieldCount = 8;

        public uint Seq;

        public uint DocId;

        public ushort Section;

        public Address32 Address;

        public uint SymSize;

        public Hex32 Value;

        public ushort AuxCount;

        public @string Name;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,8,8,10,8,10,8,48};
    }
}