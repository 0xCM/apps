//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    using static minicore;

    [Free]
    public interface IBlittable
    {
        BitWidth ContentWidth {get;}

        BitWidth StorageWidth {get;}
    }

    [Free]
    public interface IBlittable<S> : IBlittable
        where S : unmanaged
    {
        BitWidth IBlittable.StorageWidth
            => width<S>();
    }
}