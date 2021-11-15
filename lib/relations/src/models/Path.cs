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
        public struct Path<K,T>
            where K : unmanaged
        {
            Index<Node<K,T>> Data;

            [MethodImpl(Inline)]
            public Path(Node<K,T>[] nodes)
            {
                Data = nodes;
            }

            public Span<Node<K,T>> Segs
            {
                [MethodImpl(Inline)]
                get => Data;
            }

            public uint SegCount
            {
                [MethodImpl(Inline)]
                get => Data.Count;
            }

            public string Format()
            {
                var dst = text.buffer();
                var count = SegCount;
                for(var i=0; i<count; i++)
                {
                    dst.Append(Data[i].Format());
                    if(i != count - 1)
                        dst.Append(" -> ");
                }
                return dst.Emit();
            }

            public override string ToString()
                => Format();
        }
    }
}