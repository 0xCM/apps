// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Z0
{
    using System.Runtime.InteropServices;

    partial struct MinidumpRecords
    {
        [StructLayout(LayoutKind.Explicit)]
        public struct MinidumpMemoryDescriptor : IRecord<MinidumpMemoryDescriptor>
        {
            [FieldOffset(0)]
            public MemoryAddress StartAddress;

            // MINIDUMP_MEMORY_DESCRIPTOR64
            [FieldOffset(8)]
            public MemoryAddress DataSize64;

            // MINIDUMP_MEMORY_DESCRIPTOR
            [FieldOffset(8)]
            public uint DataSize32;

            [FieldOffset(12)]
            public uint Rva;
        }
    }
}