//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CliRows
    {
        [CliRecord(CliTableKind.Field), StructLayout(LayoutKind.Sequential)]
        public struct FieldDefRow : ICliRecord<FieldDefRow>
        {
            public FieldAttributes Attributes;

            public CliStringIndex Name;

            public CliBlobIndex Signature;

            public uint Offset;

            public CliBlobIndex Marshal;
        }
    }
}