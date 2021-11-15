//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    partial struct MinidumpRecords
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MINIDUMP_LOCATION_DESCRIPTOR : IRecord<MINIDUMP_LOCATION_DESCRIPTOR>
        {
            public uint DataSize;

            public uint Rva;
        }
    }
}