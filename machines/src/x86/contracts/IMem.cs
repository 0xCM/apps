//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Machines.X86
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IMem
    {
        DataWidth Width {get;}
    }

    public interface IMem<T> : IMem, IContented<T>
        where T : unmanaged
    {
        DataWidth IMem.Width
            => core.width<T>();
    }

    public interface IMem8<T> : IMem<T>
        where T : unmanaged
    {

    }

    public interface IMem8<H,T> : IMem8<T>
        where H : unmanaged, IMem8<H,T>
        where T : unmanaged
    {

    }

    public interface IMem16<T> : IMem<T>
        where T : unmanaged
    {

    }

    public interface IMem16<H,T> : IMem16<T>, IContented<T>
        where H : unmanaged, IMem16<H,T>
        where T : unmanaged
    {

    }

    public interface IMem32<T> : IMem<T>
        where T : unmanaged
    {

    }

    public interface IMem32<H,T> : IMem32<T>, IContented<T>
        where H : unmanaged, IMem32<H,T>
        where T : unmanaged
    {

    }

    public interface IMem64<T> : IMem<T>
        where T : unmanaged
    {

    }

    public interface IMem64<H,T> : IMem64<T>, IContented<T>
        where H : unmanaged, IMem64<H,T>
        where T : unmanaged
    {

    }

    public interface IMem128<T> : IMem<T>
        where T : unmanaged
    {

    }

    public interface IMem128<H,T> : IMem128<T>, IContented<T>
        where H : unmanaged, IMem128<H,T>
        where T : unmanaged
    {

    }

    public interface IMem256<T> : IMem<T>
        where T : unmanaged
    {

    }

    public interface IMem256<H,T> : IMem256<T>, IContented<T>
        where H : unmanaged, IMem256<H,T>
        where T : unmanaged
    {

    }

    public interface IMem512<T> : IMem<T>
        where T : unmanaged
    {

    }

    public interface IMem512<H,T> : IMem512<T>, IContented<T>
        where H : unmanaged, IMem512<H,T>
        where T : unmanaged
    {

    }

}