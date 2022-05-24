// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Z0
{
    using System.Runtime.InteropServices;

    partial struct MinidumpRecords
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct MinidumpThreadInfo : IRecord<MinidumpThreadInfo>
        {
            public uint ThreadId;

            public uint DumpFlags;

            public uint DumpError;

            public uint ExitStatus;

            public ulong CreateTime;

            public ulong ExitTime;

            public ulong KernelTime;

            public ulong UserTime;

            public ulong StartAddress;

            public ulong Affinity;
        }
    }
}