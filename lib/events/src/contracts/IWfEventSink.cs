//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IWfEventSink : ISink
    {
       void Deposit(IWfEvent e);

       void Deposit<S>(in S e)
            where S : struct, IWfEvent
                => Deposit((IWfEvent)e);
    }
}