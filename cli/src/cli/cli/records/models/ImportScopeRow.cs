//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CliRows
    {
        [CliRecord(CliTableKind.ImportScope), StructLayout(LayoutKind.Sequential)]
        public struct ImportScopeRow : ICliRecord<ImportScopeRow>
        {
            public CliBlobIndex Imports;
        }
    }
}