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
        public struct MINIDUMP_HANDLE_DATA_STREAM : IRecord<MINIDUMP_HANDLE_DATA_STREAM>
        {
            public uint SizeOfHeader;

            public uint SizeOfDescriptor;

            public uint NumberOfDescriptors;

            public uint Reserved;
        }
    }
}