//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Spans;
    using static Arrays;
    using static Algs;

    partial class Cmd
    {
        public static CmdDispatcher dispatcher<T>(T svc, IWfEventTarget log, ICmdActions actions)
            where T : ICmdService
                => Cmd.dispatcher(svc.GetType().DisplayName(), actions, log);

        public static CmdDispatcher dispatcher(asci32 provider, ICmdActions actions, IWfEventTarget log)
            => new CmdDispatcher(provider, actions, log);

        public static CmdDispatcher dispatcher<T>(T svc, IWfEventTarget log,  Index<ICmdProvider> providers)
        {
            var dst = dict<string,ActionRunner>();
            var _dst = bag<ICmdActions>();
            _dst.Add(actions(svc));
            iter(providers, x => _dst.Add(x.Actions));
            return dispatcher(svc.GetType().DisplayName(), Cmd.join(_dst.ToArray()), log);
        }
    }
}