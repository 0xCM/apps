//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CliRows
    {
        [Record(TableId),  StructLayout(LayoutKind.Sequential)]
        public struct AssemblyRefRow : ICliRecord<AssemblyRefRow>
        {
            public const string TableId = "cli.metadata.assemblyref";

            public AssemblyVersion Version;

            public AssemblyFlags Flags;

            public CliBlobIndex Token;

            public CliStringIndex Name;

            public CliStringIndex Culture;

            public CliBlobIndex Hash;
        }
    }
}