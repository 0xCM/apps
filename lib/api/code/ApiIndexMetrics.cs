//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Collects statistics of encoded data known to a <see cref='ApiBlockIndex'/>
    /// </summary>
    [Record(TableId)]
    public struct ApiIndexMetrics : ITextual, IRecord<ApiIndexMetrics>
    {
        public const string TableId = "api.index.metrics";

        public uint PartCount;

        public uint HostCount;

        public uint AddressCount;

        public uint BlockCount;

        public uint IdentityCount;

        public ByteSize ByteCount;
        public string Format()
            => string.Format("{0}", new {PartCount, HostCount, AddressCount, BlockCount, IdentityCount, ByteCount});

        public override string ToString()
            => Format();
    }
}