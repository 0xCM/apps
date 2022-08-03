//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    partial class Cmd
    {
        public static AppCmdDispatcher dispatcher<T>(T svc, IWfEventTarget log, IAppCommands actions)
            where T : ICmdService
                => dispatcher(svc.GetType().DisplayName(), actions, log);

        public static AppCmdDispatcher dispatcher(asci32 provider, IAppCommands actions, IWfEventTarget log)
            => new AppCmdDispatcher(provider, actions, log);

        public static AppCmdDispatcher dispatcher<T>(T svc, IWfEventTarget log, Index<ICmdProvider> providers)
        {
            var dst = dict<string,AppCmdRunner>();
            var _dst = bag<IAppCommands>();
            _dst.Add(AppCommands.discover(svc));
            iter(providers, x => _dst.Add(x.Actions));
            return dispatcher(svc.GetType().DisplayName(), Cmd.join(_dst.ToArray()), log);
        }
    }
}