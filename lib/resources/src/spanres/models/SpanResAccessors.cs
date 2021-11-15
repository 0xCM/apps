//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct SpanResAccessors
    {
        public Type DeclaringType {get;}

        readonly Index<SpanResAccessor> Accessors;

        [MethodImpl(Inline)]
        public SpanResAccessors(Type declaring, SpanResAccessor[] accessors)
        {
            DeclaringType = declaring;
            Accessors = accessors;
        }

        public ReadOnlySpan<SpanResAccessor> View
        {
            [MethodImpl(Inline)]
            get => Accessors;
        }
    }
}