//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Flows
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IPacket
    {
        dynamic Content {get;}

        ulong Kind {get;}
    }

    [Free]
    public interface IPacket<T> : IPacket
        where T : unmanaged
    {
        new T Content {get;}

        dynamic IPacket.Content
            => Content;
    }

    [Free]
    public interface IPacket<K,T> : IPacket<T>
        where K : unmanaged
        where T : unmanaged
    {
        new K Kind {get;}

        ulong IPacket.Kind
            => core.bw64(Kind);
    }
}