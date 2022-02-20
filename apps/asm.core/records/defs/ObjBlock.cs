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

        public Hex32 DocId;

        public TextBlock BlockName;

        public uint BlockNumber;

        public MemoryAddress BlockBase;

        public ByteSize BlockSize;

        public FS.FileUri Source;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{12,42,12,12,12,1};
    }
}