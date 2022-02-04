//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct SpanResAccessor
    {
        public MethodEntryPoint Member {get;}

        public SpanResKind Kind {get;}

        [MethodImpl(Inline)]
        public SpanResAccessor(MethodInfo member, SpanResKind format)
        {
            Member = MethodEntryPoints.entry(member);
            Kind = format;
        }

        public PartId Part
        {
            [MethodImpl(Inline)]
            get => Member.Uri.Part;
        }

        public ApiHostUri Host
        {
            [MethodImpl(Inline)]
            get => Member.Uri.Host;
        }

        public OpIdentity OpId
        {
            [MethodImpl(Inline)]
            get => Member.Uri.OpId;
        }

        public string OpName
        {
            [MethodImpl(Inline)]
            get => OpId.Name;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Member.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }
    }
}