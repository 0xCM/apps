//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CliRows
    {
        [CliRecord(CliTableKind.ExportedType), StructLayout(LayoutKind.Sequential)]
        public struct ExportedTypeRow
        {
            [Render(12)]
            public CliRowKey TypeDefId;

            [Render(16)]
            public CliStringIndex TypeName;

            [Render(16)]
            public CliStringIndex TypeNamespace;

            [Render(16)]
            public CliRowKey Implementation;

            [Render(1)]
            public TypeAttributes Flags;
        }
    }
}