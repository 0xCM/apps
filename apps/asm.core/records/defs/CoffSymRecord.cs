//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [Record(TableId), StructLayout(LayoutKind.Sequential,Pack=1)]
    public struct CoffSymRecord : IComparable<CoffSymRecord>
    {
        public const string TableId = "coff.symbols";

        public const byte FieldCount = 10;

        public uint Seq;

        public uint Section;

        public Hex32 OriginId;

        public Address32 Address;

        public uint SymSize;

        public Hex32 Value;

        public SymStorageClass SymClass;

        public ushort AuxCount;

        public @string Name;

        public FS.FileUri Source;

        public AsmRowKey RowKey
        {
            [MethodImpl(Inline)]
            get => (Seq,Section,OriginId);
        }
        public int CompareTo(CoffSymRecord src)
        {
            var result = Source.Format().CompareTo(src.Source.Format());
            if(result  == 0)
            {
                if(result == 0)
                {
                    result = Section.CompareTo(src.Section);
                    if(result == 0)
                        result = Address.CompareTo(src.Address);
                }

            }
            return result;
        }

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{
            ColWidths.Seq,
            ColWidths.DocSeq,
            ColWidths.OriginId,
            ColWidths.IP,
            8,
            10,
            16,
            8,
            48,
            1};

    }
}