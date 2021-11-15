//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    partial struct MinidumpRecords
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/windows/win32/api/minidumpapiset/ns-minidumpapiset-minidump_memory_descriptor
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MINIDUMP_MEMORY_DESCRIPTOR : IRecord<MINIDUMP_MEMORY_DESCRIPTOR>
        {
            public ulong StartOfMemoryRange;

            public MINIDUMP_LOCATION_DESCRIPTOR Memory;
        }
    }
}