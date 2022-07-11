//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CliRows
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential)]
        public struct CustomAttributeRow
        {
            const string TableId = "attributes";

            [Render(12)]
            public CliRowKey Parent;

            [Render(12)]
            public CliRowKey Constructor;

            [Render(12)]
            public CliBlobIndex Value;

            [Render(12)]
            public Address32 ValueOffset;
        }
    }
}