//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    public sealed class MemberDecodedEvent : ApiExtractEvent<MemberDecodedEvent,Arrow<ApiMemberCode,AsmRoutine>>
    {
        [MethodImpl(Inline)]
        public MemberDecodedEvent()
        {
            Payload = (ApiMemberCode.Empty, AsmRoutine.Empty);
        }

        [MethodImpl(Inline)]
        public MemberDecodedEvent(in ApiMemberCode src, in AsmRoutine dst)
        {
            Payload = (src,dst);
        }
    }
}