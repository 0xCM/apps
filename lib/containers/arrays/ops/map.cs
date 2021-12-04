//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;
    using System.Linq;

    using static Root;

    partial struct Arrays
    {
        /// <summary>
        /// Applies a function to an input sequence to yield a transformed output sequence
        /// </summary>
        /// <param name="src">The source sequence</param>
        /// <param name="f">The projector</param>
        /// <typeparam name="S">The source type</typeparam>
        /// <typeparam name="T">The target type</typeparam>
        [MethodImpl(Inline)]
        public static T[] map<S,T>(IEnumerable<S> src, Func<S,T> f)
        {
            Span<S> source = src.ToArray();
            var count = source.Length;
            var buffer = new T[count];
            Span<T> target = buffer;
            for(var i=0; i<count; i++)
                target[i] = f(source[i]);
            return buffer;
        }
    }
}