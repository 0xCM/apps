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

        [Render(8)]
        public uint Index;

        [Render(12)]
        public Address32 Offset;

        [Render(32)]
        public Identifier Source;

        [Render(64)]
        public Identifier Name;

        [Render(16)]
        public SymVal Value;

        [Render(1)]
        public SymExpr Expression;
    }
}