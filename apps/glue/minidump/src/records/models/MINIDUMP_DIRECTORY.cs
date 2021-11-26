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
        public struct MINIDUMP_DIRECTORY : IRecord<MINIDUMP_DIRECTORY>
        {
            public MinidumpStreamType StreamType;

            public MINIDUMP_LOCATION_DESCRIPTOR Location;
        }
    }
}