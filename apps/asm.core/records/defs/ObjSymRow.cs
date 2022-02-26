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

        public DocRowKey Key
        {
            [MethodImpl(Inline)]
            get => (Seq,DocSeq);
        }

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{8,8,12,10,6,24,80,1};
    }
}