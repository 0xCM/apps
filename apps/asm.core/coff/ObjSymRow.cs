//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [Record(TableId)]
    public struct ObjSymRow : IOriginated
    {
        public const string TableId = "objsyms";

        public const byte FieldCount = 8;

        public uint Seq;

        public Hex32 OriginId;

        public uint DocSeq;

        public Hex32 Offset;

        public ObjSymCode Code;

        public ObjSymKind Kind;

        public string Name;

        public FS.FileUri Source;

        Hex32 IOriginated.OriginId
            => OriginId;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{8,12,8,10,6,24,80,1};
    }
}