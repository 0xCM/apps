//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Reflection;

    using static Root;

    public readonly struct SpanResAccessor
    {
        public MethodInfo Member {get;}

        public SpanResKind Kind {get;}

        [MethodImpl(Inline)]
        public SpanResAccessor(MethodInfo member, SpanResKind format)
        {
            Member = member;
            Kind = format;;
        }

        public Type DeclaringType
        {
            [MethodImpl(Inline)]
            get => Member?.DeclaringType ?? EmptyVessels.EmptyType;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Member == null || EmptyVessels.IsEmpty(Member);
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }
    }
}