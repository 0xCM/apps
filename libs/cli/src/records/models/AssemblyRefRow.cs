//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CliRows
    {
        [Record(TableId),  StructLayout(LayoutKind.Sequential)]
        public struct AssemblyRefRow
        {
            const string TableId = "refs.assemblies";

            [Render(12)]
            public CliBlobIndex Token;

            [Render(12)]
            public CliStringIndex Name;

            [Render(12)]
            public AssemblyVersion Version;

            [Render(12)]
            public CliStringIndex Culture;

            [Render(12)]
            public CliBlobIndex Hash;

            [Render(1)]
            public AssemblyFlags Flags;
        }
    }
}