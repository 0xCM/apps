//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Abstractions;

    public sealed record class Node<V> : Node<Node<V>,V>
    {
        public Node()
        {

        }

        public Node(V value)
            : base(value)
        {

        }
    }

}