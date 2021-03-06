//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public sealed class ExtractErrorEvent : ApiExtractEvent<ExtractErrorEvent,ApiMemberExtract>
    {
        [MethodImpl(Inline)]
        public ExtractErrorEvent()
        {
            Payload = ApiMemberExtract.Empty;
        }

        [MethodImpl(Inline)]
        public ExtractErrorEvent(in ApiMemberExtract src)
        {
            Payload = src;
        }
    }
}