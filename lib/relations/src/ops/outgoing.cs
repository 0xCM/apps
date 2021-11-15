//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static core;

    partial struct relations
    {
        /// <summary>
        /// Finds the edges in a graph that emit from an identified vertex
        /// </summary>
        /// <param name="graph">The declaring graph</param>
        /// <param name="target">The index of the target vertex</param>
        /// <typeparam name="V">The vertex index type</typeparam>
        public static ReadOnlySpan<Arrow<Node<V>>> outgoing<V>(Graph<V> graph, V source)
            where V : unmanaged
        {
            var count = graph.EdgeCount;
            var buffer = alloc<Arrow<Node<V>>>(count);
            Span<Arrow<Node<V>>> edges = buffer;
            var j = 0;
            for(var i = 0; i<count; i++)
            {
                ref readonly var edge = ref graph.Edge(i);
                if(edge.Source.Equals(source))
                    seek(edges,j++) = edge;
            }
            return slice(edges,0, j);
        }
    }
}