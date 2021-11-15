//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    partial struct MinidumpRecords
    {
        [StructLayout(LayoutKind.Sequential, Pack = 4)]
        public struct MINIDUMP_EXCEPTION_INFORMATION : IRecord<MINIDUMP_EXCEPTION_INFORMATION>
        {
            public uint ThreadId;

            public IntPtr ExceptionPointers;

            public int ClientPointers;
        }
    }
}