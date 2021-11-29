//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public struct Node<T> : INode<T>
    {
        public uint Index;

        public T Payload;

        [MethodImpl(Inline)]
        public Node(uint id, T content)
        {
            Index = id;
            Payload = content;
        }

        T INode<T>.Payload
            => Payload;

        uint INode.Index
            => Index;

        public static Node<T> Empty => default;
    }
}