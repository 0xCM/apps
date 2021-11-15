//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;

    partial struct PeRecords
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential)]
        public struct FieldOffset : IRecord<FieldOffset>
        {
            public const string TableId = "image.offsets";

            public string Name;

            public ulong Value;
        }
    }
}