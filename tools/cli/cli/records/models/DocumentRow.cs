//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    partial struct CliRows
    {
        [CliRecord(CliTableKind.Document), StructLayout(LayoutKind.Sequential)]
        public struct DocumentRow : ICliRecord<DocumentRow>
        {
            public CliBlobIndex Name;

            public GuidIndex HashAlgorithm;

            public CliBlobIndex Hash;

            public GuidIndex Language;
        }
    }
}