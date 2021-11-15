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
        [CliRecord(CliTableKind.EncMap), StructLayout(LayoutKind.Sequential)]
        public struct EncMapRow : ICliRecord<EncMapRow>
        {

        }
    }
}