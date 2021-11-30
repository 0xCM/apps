//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    using static minicore;

    [Free]
    public interface IValue
    {
        BitWidth ContentWidth {get;}

        BitWidth StorageWidth {get;}
    }

    [Free]
    public interface IValue<S> : IValue
        where S : unmanaged
    {
        BitWidth IValue.StorageWidth
            => width<S>();
    }
}