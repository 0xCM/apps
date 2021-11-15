//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    partial struct relations
    {
        /// <summary>
        /// Connects a source vertex to a target vertex
        /// </summary>
        /// <param name="src">The source vertex</param>
        /// <param name="dst">The target vertex</param>
        /// <typeparam name="V">The vertex index type</typeparam>
        /// <typeparam name="T">The vertex payload type</typeparam>
        [MethodImpl(Inline), Op, Closures(Closure)]
        public static Arrow<Node<T>> connect<T>(Node<T> src, Node<T> dst)
            where T : unmanaged
                => new Arrow<Node<T>>(src, dst);

        /// <summary>
        /// Connects a source vertex to a target vertex
        /// </summary>
        /// <param name="src">The source vertex</param>
        /// <param name="dst">The target vertex</param>
        /// <typeparam name="V">The vertex index type</typeparam>
        /// <typeparam name="T">The vertex payload type</typeparam>
        [MethodImpl(Inline)]
        public static Arrow<V> connect<V,T>(in Node<V,T> src, in Node<V,T> dst)
            where V : unmanaged
            where T : unmanaged
                => new Arrow<V>(src.Index, dst.Index);
    }
}