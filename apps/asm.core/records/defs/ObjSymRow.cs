//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [Record(TableId)]
    public struct ObjSymRow
    {
        public const string TableId = "objsyms";

        public const byte FieldCount = 8;

        public uint Seq;

        public uint DocSeq;

        public Hex32 OriginId;

        public Hex32 Offset;

        public ObjSymCode Code;

        public ObjSymKind Kind;

        public string Name;

        public FS.FileUri Source;

        public AsmRowKey RowKey
        {
            [MethodImpl(Inline)]
            get => (Seq,DocSeq,OriginId);
        }

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{
                ColWidths.Seq,
                ColWidths.DocSeq,
                ColWidths.OriginId,
                10,
                6,
                ColWidths.SymbolName,
                80,
                1};
    }
}