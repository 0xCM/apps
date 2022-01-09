//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    [Record(TableId)]
    public struct ObjSymRow
    {
        public const string TableId = "objsyms";

        public const byte FieldCount = 6;

        public uint Seq;

        public Hex32 Offset;

        public NmSymCode Code;

        public NmSymKind Kind;

        public string Name;

        public FS.FileUri Source;

        public static ReadOnlySpan<byte> RenderWidths
            => new byte[FieldCount]{12,10,6,24,80,1};
    }
}