//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Record(TableId), StructLayout(StructLayout,Pack=1)]
    public struct SymHeapEntry
    {
        public const string TableId = "api.symbols.heap";

        [Render(8)]
        public uint Key;

        [Render(12)]
        public Address32 Offset;

        [Render(6)]
        public uint Size;

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