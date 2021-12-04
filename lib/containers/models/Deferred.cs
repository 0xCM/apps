//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Defines a LINQ-monadic cover for a deferred finite or infinite parametric sequence
    /// </summary>
    public readonly struct Deferred<T> : IDeferred<Deferred<T>,T>
    {
        readonly IEnumerable<T> E;

        [MethodImpl(Inline)]
        public Deferred(IEnumerable<T> src)
            => E = src;

        public Index<T> Yield()
            => E.ToArray();

        public readonly IEnumerable<T> Content
        {
            [MethodImpl(Inline)]
            get => E ?? sys.empty<T>();
        }

        [MethodImpl(Inline)]
        public Deferred<T> WithContent(IEnumerable<T> src)
            => new Deferred<T>(src);

        public Deferred<T> Concat(Deferred<T> rhs)
            => new Deferred<T>(Content.Concat(rhs.Content));

        public Deferred<Y> Select<Y>(Func<T,Y> selector)
             => new Deferred<Y>(from x in Content select selector(x));

        public Deferred<Z> SelectMany<Y,Z>(Func<T,Deferred<Y>> lift, Func<T,Y,Z> project)
            => new Deferred<Z>(from x in Content
                          from y in lift(x).Content
                          select project(x, y));

        public Deferred<Y> SelectMany<Y>(Func<T,Deferred<Y>> lift)
            => new Deferred<Y>(from x in Content
                          from y in lift(x).Content
                          select y);

        public Deferred<T> Where(Func<T,bool> predicate)
            => new Deferred<T>(from x in Content where predicate(x) select x);

        public static Deferred<T> operator + (Deferred<T> lhs, Deferred<T> rhs)
            => lhs.Concat(rhs);

        /// <summary>
        /// Implicitly constructs a sequence from an array
        /// </summary>
        /// <param name="src">The source array</param>
        public static implicit operator Deferred<T>(T[] src)
            => new Deferred<T>(src);

        public static Deferred<T> Empty
            => new Deferred<T>(sys.empty<T>());
    }
}