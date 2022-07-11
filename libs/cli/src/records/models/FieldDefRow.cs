//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CliRows
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential)]
        public struct FieldDefRow
        {
            const string TableId = "field.defs";

            [Render(12)]
            public CliStringIndex Name;

            [Render(12)]
            public CliBlobIndex Sig;

            [Render(12)]
            public Address32 Offset;

            [Render(12)]
            public CliBlobIndex Marshal;

            [Render(1)]
            public FieldAttributes Attributes;
        }
    }
}