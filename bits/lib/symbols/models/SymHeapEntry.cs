//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    [Record(TableId)]
    public struct SymHeapEntry
    {
        public const string TableId = "api.symbols.heap";

        public const byte FieldCount = 6;

        public uint Index;

        public Address32 Offset;

        public Identifier Source;

        public Identifier Name;

        public SymVal Value;

        public SymExpr Expression;

        public static ReadOnlySpan<byte> RenderWidths => new byte[FieldCount]{8,12,32,64,16,1};
    }
}