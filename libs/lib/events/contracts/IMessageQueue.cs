//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    using Free = System.Security.SuppressUnmanagedCodeSecurityAttribute;

    [Free]
    public interface IMessageQueue : IMessageSink, ICallbackSource<IAppMsg>
    {
        IReadOnlyList<IAppMsg> Dequeue();

        void Emit(FS.FilePath dst);

        IReadOnlyList<IAppMsg> Flush(Exception e);

        void Flush(Exception e, IMessageSink target)
            => target.Deposit(Flush(e));
    }
}