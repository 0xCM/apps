//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;

    internal class ApiExtractChannel
    {
        event EventHandler<HostResolvedEvent> HostResolved;

        event EventHandler<PartResolvedEvent> PartResolved;

        event EventHandler<MemberParsedEvent> MemberParsed;

        event EventHandler<MemberDecodedEvent> MemberDecoded;

        event EventHandler<ExtractErrorEvent> ExtractError;

        public void Raise(HostResolvedEvent e)
            => run(() => HostResolved.Invoke(this, e));

        public void Raise(PartResolvedEvent e)
            => run(() => PartResolved.Invoke(this, e));

        public void Raise(MemberParsedEvent e)
            => run(() => MemberParsed.Invoke(this, e));

        public void Raise(MemberDecodedEvent e)
            => run(() => MemberDecoded.Invoke(this, e));

        public void Raise(ExtractErrorEvent e)
            => run(() => ExtractError.Invoke(this, e));

        public void Enlist(ApiExtractWorkflow receiver)
        {
            PartResolved += (source, e) => receiver.Deposit(e);
            HostResolved += (source, e) => receiver.Deposit(e);
            MemberParsed += (source, e) => receiver.Deposit(e);
            MemberDecoded += (source, e) => receiver.Deposit(e);
            ExtractError += (source, e) => receiver.Deposit(e);
        }
    }
}