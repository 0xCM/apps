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
        /// Creates a graph from supplied vertices and edges
        /// </summary>
        /// <param name="nodes">The vertices in the graph</param>
        /// <param name="edges">The edges that connect the vertices</param>
        /// <typeparam name="V">The vertex index type</typeparam>
        [MethodImpl(Inline)]
        public static Graph<V> graph<V>(Node<V>[] nodes, Arrow<Node<V>>[] edges)
            where V : unmanaged
                => new Graph<V>(nodes, edges);
    }
}