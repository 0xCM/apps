// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
namespace Windows
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Sequential)]
    public struct PROCESSOR_INFO
    {
        /// <summary>
        /// PROCESSOR_ARCHITECTURE_AMD64 9 | x64 (AMD or Intel)
        /// PROCESSOR_ARCHITECTURE_ARM 5 | ARM
        /// PROCESSOR_ARCHITECTURE_IA64 6 | Intel Itanium-based
        /// PROCESSOR_ARCHITECTURE_INTEL 0 | x86
        /// PROCESSOR_ARCHITECTURE_UNKNOWN 0xffff | Unknown architecture.
        /// </summary>
        public ushort wProcessorArchitecture;

        public ushort wReserved;
    }

    /// <summary>
    /// https://docs.microsoft.com/en-us/windows/win32/api/sysinfoapi/ns-sysinfoapi-system_info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SYSTEM_INFO
    {
        public PROCESSOR_INFO uProcessorInfo;

        /// <summary>
        /// The page size and the granularity of page protection and commitment
        /// </summary>
        public uint dwPageSize;

        /// <summary>
        /// A pointer to the lowest memory address accessible to applications and dynamic-link libraries
        /// </summary>
        public IntPtr lpMinimumApplicationAddress;

        /// <summary>
        /// A pointer to the highest memory address accessible to applications and DLLs
        /// </summary>
        public IntPtr lpMaximumApplicationAddress;

        /// <summary>
        /// A mask representing the set of processors configured into the system. Bit 0 is processor 0; bit 31 is processor 31
        /// </summary>
        public IntPtr dwActiveProcessorMask;

        /// <summary>
        /// The number of logical processors in the current group
        /// </summary>
        public uint dwNumberOfProcessors;

        /// <summary>
        /// Obsolete
        /// </summary>
        public uint dwProcessorType;

        /// <summary>
        /// The granularity for the starting address at which virtual memory can be allocated
        /// </summary>
        public uint dwAllocationGranularity;

        /// <summary>
        /// The architecture-dependent processor level. It should be used only for display purposes.
        /// </summary>
        public short wProcessorLevel;

        /// <summary>
        /// The architecture-dependent processor revision
        /// </summary>
        public short wProcessorRevision;
    }
}