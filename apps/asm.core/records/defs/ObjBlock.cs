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

        [Render(ColWidths.Seq)]
        public uint Seq;

        [Render(ColWidths.BlockNumber)]
        public uint BlockNumber;

        [Render(ColWidths.OriginId)]
        public Hex32 OriginId;

        [Render(ColWidths.BlockName)]
        public Identifier BlockName;

        [Render(ColWidths.BlockAddress)]
        public MemoryAddress BlockAddress;

        [Render(ColWidths.BlockSize)]
        public ByteSize BlockSize;

        [Render(1)]
        public FS.FileUri Source;

        public AsmRowKey RowKey
        {
            [MethodImpl(Inline)]
            get => (Seq, BlockNumber,OriginId);
        }
    }
}