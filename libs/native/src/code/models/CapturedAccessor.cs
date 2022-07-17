//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct CapturedAccessor
    {
        public readonly CollectedEncoding Member;

        public readonly MemorySeg DataSegment;

        public readonly SpanResKind ResKind;

        [MethodImpl(Inline)]
        public CapturedAccessor(CollectedEncoding member, MemorySeg data, SpanResKind kind)
        {
            Member = member;
            DataSegment = data;
            ResKind = kind;
        }

        public BinaryCode MemberCode
        {
            [MethodImpl(Inline)]
            get => Member.Code;
        }
    }
}