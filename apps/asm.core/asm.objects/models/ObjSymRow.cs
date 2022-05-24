//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId)]
    public struct ObjSymRow
    {
        public const string TableId = "objsyms";

        public const byte FieldCount = 8;

        [Render(ColWidths.Seq)]
        public uint Seq;

        [Render(ColWidths.DocSeq)]
        public uint DocSeq;

        [Render(ColWidths.OriginId)]
        public Hex32 OriginId;

        [Render(10)]
        public Hex32 Offset;

        [Render(6)]
        public ObjSymCode Code;

        [Render(ColWidths.SymbolName)]
        public ObjSymKind Kind;

        [Render(80)]
        public string Name;

        [Render(1)]
        public FS.FileUri Source;

        public AsmRowKey RowKey
        {
            [MethodImpl(Inline)]
            get => (Seq,DocSeq,OriginId);
        }
    }
}