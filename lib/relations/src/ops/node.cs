//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;
    using static Root;

    partial struct relations
    {
        /// <summary>
        /// Creates a vertex with payload
        /// </summary>
        /// <param name="index">The index of the vertex that servies as a
        /// unique identifier within the context of a graph</param>
        /// <typeparam name="V">The index type</typeparam>
        /// <typeparam name="V">The payload type</typeparam>
        [MethodImpl(Inline)]
        public static Node<V,T> node<V,T>(V index, T data)
            where V : unmanaged
            where T : unmanaged
                => new Node<V,T>(index,data);

        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Node<T> node<T>(uint index, T src)
            => new Node<T>(index,src);

        [MethodImpl(Inline)]
        public static LabeledVertex<V> vertex<V>(Label name, V value)
            where V : unmanaged, IEquatable<V>
                => new LabeledVertex<V>(name,value);
    }
}