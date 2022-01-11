//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    using Flows;

    [Free]
    public interface IChannelMask : ITextual
    {
        MaskKind Kind {get;}

        ulong Value {get;}
    }

    [Free]
    public interface IChannelMask<T> : IChannelMask
        where T : unmanaged, IChannelMask<T>
    {
    }
}