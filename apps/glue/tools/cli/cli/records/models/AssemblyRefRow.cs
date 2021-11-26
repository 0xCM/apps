//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;
    using System.Reflection;

    partial struct CliRows
    {
        [CliRecord(CliTableKind.AssemblyRef),  StructLayout(LayoutKind.Sequential)]
        public struct AssemblyRefRow : ICliRecord<AssemblyRefRow>
        {
            public AssemblyVersion Version;

            public AssemblyFlags Flags;

            public CliBlobIndex Token;

            public CliStringIndex Name;

            public CliStringIndex Culture;

            public CliBlobIndex Hash;
        }
    }
}