//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Concurrent;

    using static core;

    public sealed class WfCmdRouter : AppService<WfCmdRouter>, ICmdRouter<WfCmdRouter>
    {
        ConcurrentDictionary<CmdId,ICmdReactor> Nodes;

        public WfCmdRouter()
        {
            Nodes = new ConcurrentDictionary<CmdId,ICmdReactor>();
        }

        public WfCmdRouter(IWfRuntime wf)
            : base(wf)
        {
            Nodes = new ConcurrentDictionary<CmdId,ICmdReactor>();
        }

        protected override void OnInit()
        {

        }

        public ReadOnlySpan<CmdId> SupportedCommands
            => Nodes.Keys.Array();

        public void Enlist(Index<ICmdReactor> src)
        {
            var count = 0;
            foreach(var reactor in src)
            {
                if(Nodes.TryAdd(reactor.CmdId, reactor))
                    count++;
            }
            iter(src, cmd => Nodes.TryAdd(cmd.CmdId, cmd));
        }

        public CmdResult Dispatch(ICmd cmd, string msg)
        {
            using var dispatch = Wf.Running(msg);
            try
            {
                if(Nodes.TryGetValue(cmd.CmdId, out var node))
                {

                    Wf.Status(DispatchingCmd.Format(cmd.CmdId, node.GetType().Name));
                    var result = node.Invoke(cmd);
                    if(result.Succeeded)
                        Wf.Status(result);
                    else
                        Wf.Error(result);
                    return result;
                }
                else
                {
                    Wf.Error(EventFactory.missing(cmd.CmdId, EventFactory.originate(nameof(WfCmdRouter))));
                    return Cmd.fail(cmd);
                }
            }
            catch(Exception e)
            {
                Wf.Error(e);
                return Cmd.fail(cmd, e);
            }
        }

        public CmdResult Dispatch(ICmd cmd)
        {
            return Dispatch(cmd, string.Format("Dispatching <{0}>", cmd.CmdId));
        }

        public static MsgPattern<CmdId,string> DispatchingCmd => "Dispatching {0} command to {1}";
    }
}