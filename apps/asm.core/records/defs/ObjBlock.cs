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

        public const byte FieldCount = 6;

        public Hex32 OriginId;

        public Identifier BlockName;

        public uint BlockNumber;

        public MemoryAddress BlockAddress;

        public ByteSize BlockSize;

        public FS.FileUri Source;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{
            ColWidths.OriginId,
            ColWidths.BlockName,
            ColWidths.BlockNumber,
            ColWidths.BlockAddress,
            12,
            1};
    }
}