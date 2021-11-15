//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;
    using static core;

    public sealed class PointMap<A,B> : Function<A,B>
    {
        readonly Dictionary<A,B> Lookup;

        Index<A> _Domain;

        Index<B> _Range;

        internal PointMap(A[] src, B[] dst)
        {
            Lookup = new();
            _Domain = src;
            _Range = dst;
            var count = Require.equal(src.Length, dst.Length);
            for(var i=0; i<count; i++)
                Lookup.Add(skip(src,i), skip(dst,i));
        }

        [MethodImpl(Inline)]
        public override B Eval(A a)
            => Lookup[a];

        public ReadOnlySpan<A> Domain
        {
            [MethodImpl(Inline)]
            get => _Domain;
        }

        public ReadOnlySpan<B> Range
        {
            [MethodImpl(Inline)]
            get => _Range;
        }
    }
}