//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using Z0.Asm;

    using static Root;

    public sealed class MemberDecodedEvent : ApiExtractEvent<MemberDecodedEvent,DataFlow<ApiMemberCode,AsmRoutine>>
    {
        [MethodImpl(Inline)]
        public MemberDecodedEvent()
        {
            Payload = relations.flow(ApiMemberCode.Empty, AsmRoutine.Empty);
        }

        [MethodImpl(Inline)]
        public MemberDecodedEvent(in ApiMemberCode src, in AsmRoutine dst)
        {
            Payload = relations.flow(src,dst);
        }
    }
}