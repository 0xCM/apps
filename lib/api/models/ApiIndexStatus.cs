//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [Record(TableId)]
    public struct ApiIndexStatus : IRecord<ApiIndexStatus>, ITextual
    {
        public const string TableId = "api-index.status";

        public PartId[] Parts;

        public ApiHostUri[] Hosts;

        public MemoryAddress[] Addresses;

        public Count MemberCount;

        public PartCodeAddresses Encoded;

        [MethodImpl(Inline)]
        public string Format()
            => text.format(RP.PSx5, Parts.Length, Hosts.Length, MemberCount, Addresses.Length, Encoded.Count);

        public override string ToString()
            => Format();
    }
}