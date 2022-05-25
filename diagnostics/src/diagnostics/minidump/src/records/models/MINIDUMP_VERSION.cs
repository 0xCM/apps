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
        /// #define MINIDUMP_VERSION   (42899)
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct MINIDUMP_VERSION : IRecord<MINIDUMP_VERSION>
        {
            public ushort Value;

            public ushort Expected => 42899;
        }
    }
}