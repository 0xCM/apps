//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;


    using static Root;

    /// <summary>
    /// A default projection effector
    /// </summary>
    public readonly struct SeqProjector<S,T> : ISeqProjector<S,T>
    {
        internal readonly Func<S,T> F;

        [MethodImpl(Inline)]
        internal SeqProjector(Func<S,T> f)
            => F = f;

        public Outcome<uint> Project(ReadOnlySpan<S> src, Span<T> dst)
            => TS.apply(this,src,dst);
    }
}