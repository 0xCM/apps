//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.InteropServices;

    [Record(TableId), StructLayout(LayoutKind.Sequential)]
    public struct ApiCatalogEntry : IRecord<ApiCatalogEntry>
    {
        public const string TableId = "api.catalog";

        public const byte FieldCount = 9;

        public uint Sequence;

        public MemoryAddress ProcessBase;

        public MemoryAddress MemberBase;

        public MemoryAddress MemberOffset;

        public Address32 MemberRebase;

        public ByteSize MaxSize;

        public Name PartName;

        public Name HostName;

        public OpUri OpUri;
    }
}