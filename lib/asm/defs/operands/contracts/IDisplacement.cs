//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IDisplacement
    {
        int Value {get;}

        byte StorageWidth {get;}
    }

    [Free]
    public interface IDisplacement<T> : IDisplacement
        where T : unmanaged
    {
        new T Value {get;}

        byte IDisplacement.StorageWidth
            => (byte)core.width<T>();
    }

    [Free]
    public interface IDisplacement<H,T> : IDisplacement<T>
        where T : unmanaged
        where H : unmanaged, IDisplacement<H,T>
    {

    }
}