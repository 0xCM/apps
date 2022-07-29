//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Z0.Asm;

    public sealed class MemberDecodedEvent : ApiExtractEvent<MemberDecodedEvent,Arrow<MemberCodeBlock,AsmRoutine>>
    {
        [MethodImpl(Inline)]
        public MemberDecodedEvent()
        {
            Payload = (MemberCodeBlock.Empty, AsmRoutine.Empty);
        }

        [MethodImpl(Inline)]
        public MemberDecodedEvent(in MemberCodeBlock src, in AsmRoutine dst)
        {
            Payload = (src,dst);
        }
    }
}