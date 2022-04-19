//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Windows
{
    using System;
    using System.Runtime.InteropServices;

    [StructLayout(LayoutKind.Explicit, Size = 24)]
    public struct PROCESS_BASIC_INFORMATION
    {
        [FieldOffset(4)]
        public IntPtr PebBaseAddress;

        [FieldOffset(16)]
        public UIntPtr UniqueProcessId;
    }
}