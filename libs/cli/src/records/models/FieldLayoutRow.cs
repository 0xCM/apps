//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CliRows
    {
        [CliRecord(CliTableKind.FieldLayout), StructLayout(LayoutKind.Sequential)]
        public struct FieldLayoutRow : ICliRecord<FieldLayoutRow>
        {
            public uint Offset;

            public CliRowKey Field;
        }
    }
}