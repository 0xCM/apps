//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    partial struct CliRows
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential)]
        public struct CustomAttributeRow  : ICliRecord<CustomAttributeRow>
        {
            public const string TableId = "cli.metadata.customattribute";

            public CliRowKey Parent;

            public CliRowKey Constructor;

            public CliBlobIndex Value;

            public Address32 ValueOffset;
        }
    }
}