//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial struct CliRows
    {
        [CliRecord(CliTableKind.EncMap), StructLayout(LayoutKind.Sequential)]
        public struct EncMapRow : ICliRecord<EncMapRow>
        {

        }
    }
}