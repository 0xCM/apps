//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public struct ApiDecoderStats : ITextual
    {
        public static ApiDecoderStats init()
            => new ApiDecoderStats();

        public uint MemberCount;

        public uint HostCount;

        public uint PartCount;

        public uint InstructionCount;

        public string Format()
            => text.format(RP.PSx4, PartCount, HostCount, MemberCount, InstructionCount);

        public override string ToString()
            => Format();
    }
}