//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a random variable
    /// </summary>
    public readonly struct RVar<T>
        where T : unmanaged
    {
        readonly IEnumerable<T> stream;

        public readonly Interval<T> Domain;

        public RVar(Interval<T> domain, IBoundSource source)
        {
            Domain = domain;
            stream = source.Stream<T>(domain);
        }

        /// <summary>
        /// Samples a specified number of values
        /// </summary>
        /// <param name="count">The sample count</param>
        public T[] Sample(int count)
            => stream.TakeArray(count);

        /// <summary>
        /// Samples an arbitrary number of values
        /// </summary>
        /// <param name="count">The sample count</param>
        public IEnumerable<T> Sample()
            => stream;

        /// <summary>
        /// Samples exactly one value
        /// </summary>
        [MethodImpl(Inline)]
        public T Next()
            => stream.First();
    }
}