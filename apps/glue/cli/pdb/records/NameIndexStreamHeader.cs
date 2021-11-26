//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    partial struct PdbRecords
    {
        [Record(TableId), StructLayout(LayoutKind.Sequential)]
        public struct NameIndexStreamHeader : IRecord<NameIndexStreamHeader>
        {
            public const string TableId = "name-idx.header";

            public Cell32 Version;

            public Cell32 Signature;

            public Cell32 Age;

            public Cell128 Guid;

            public Cell32 CountStringBytes;
        }
    }
}