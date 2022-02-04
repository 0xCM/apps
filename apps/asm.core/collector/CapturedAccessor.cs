//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct CapturedAccessor
    {
        public EncodedMember Member {get;}

        public SpanResKind ResKind {get;}

        [MethodImpl(Inline)]
        public CapturedAccessor(EncodedMember member, SpanResKind kind)
        {
            Member = member;
            ResKind = kind;
        }

        public MemoryAddress TargetAddress
        {
            [MethodImpl(Inline)]
            get => Member.TargetAddress;
        }

        public ReadOnlySpan<byte> Code
        {
            [MethodImpl(Inline)]
            get => Member.Code;
        }
    }
}