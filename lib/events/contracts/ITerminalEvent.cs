//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface ITerminalEvent<T> : IWfEvent<T>
        where T : ITerminalEvent<T>, IWfEvent<T>, new()
    {

    }
}