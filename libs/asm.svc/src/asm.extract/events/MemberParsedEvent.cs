//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class MemberParsedEvent : ApiExtractEvent<MemberParsedEvent,Arrow<ApiMemberExtract,MemberCodeBlock>>
    {
        [MethodImpl(Inline)]
        public MemberParsedEvent()
        {
            Payload = (ApiMemberExtract.Empty, MemberCodeBlock.Empty);

        }

        [MethodImpl(Inline)]
        public MemberParsedEvent(in ApiMemberExtract src, in MemberCodeBlock dst)
        {
            Payload = (src,dst);
        }
    }
}