//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Flows
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct Packet<K,T> : IPacket<K,T>
        where K : unmanaged
        where T : unmanaged
    {
        public K Kind {get;}     

        public T Content {get;}   

        [MethodImpl(Inline)]
        public Packet(K kind, T content)
        {
            Kind = kind;
            Content = content;            
        }
    }
}