//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public sealed class MemberParsedEvent : ApiExtractEvent<MemberParsedEvent,DataFlow<ApiMemberExtract,ApiMemberCode>>
    {
        [MethodImpl(Inline)]
        public MemberParsedEvent()
        {
            Payload = flows.dataflow(ApiMemberExtract.Empty, ApiMemberCode.Empty);

        }

        [MethodImpl(Inline)]
        public MemberParsedEvent(in ApiMemberExtract src, in ApiMemberCode dst)
        {
            Payload = flows.dataflow(src,dst);
        }
    }
}