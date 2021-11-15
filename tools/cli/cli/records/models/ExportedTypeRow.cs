//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;
    using System.Reflection;

    partial struct CliRows
    {
        [CliRecord(CliTableKind.ExportedType), StructLayout(LayoutKind.Sequential)]
        public struct ExportedTypeRow  : ICliRecord<ExportedTypeRow>
        {
            public TypeAttributes Flags;

            public CliRowKey TypeDefId;

            public CliStringIndex TypeName;

            public CliStringIndex TypeNamespace;

            public CliRowKey Implementation;
        }
    }
}