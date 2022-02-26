//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [StructLayout(LayoutKind.Sequential, Pack=1), Record(TableId)]
    public struct ObjBlock
    {
        public const string TableId = "obj.blocks";

        public const byte FieldCount = 7;

        public uint Seq;

        public uint BlockNumber;

        public Hex32 OriginId;

        public Identifier BlockName;

        public MemoryAddress BlockAddress;

        public ByteSize BlockSize;

        public FS.FileUri Source;

        public AsmRowKey RowKey
        {
            [MethodImpl(Inline)]
            get => (Seq, BlockNumber,OriginId);
        }

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{
            ColWidths.Seq,
            ColWidths.BlockNumber,
            ColWidths.OriginId,
            ColWidths.BlockName,
            ColWidths.BlockAddress,
            ColWidths.BlockSize,
            1};
    }
}