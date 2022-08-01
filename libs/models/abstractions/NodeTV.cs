//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Abstractions
{
    public abstract record class Node<T,V> : Model<T>, INode<V>
        where T : Node<T,V>, new()
    {
        public V Value;

        protected Node()
        {

        }

        protected Node(V value)
        {
            Value = value;
        }

        V INode<V>.Value
            => Value;
    }
}