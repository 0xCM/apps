//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    using static core;

    [WfCmdHost]
    public abstract class AppCmdHost<H,K> : AppService<H>
        where H : AppCmdHost<H,K>, new()
        where K : unmanaged
    {
        static bool CommandsRegistered;

        public CmdResult Run(K kind)
        {
            if(Cmd.find(kind, out var cmd))
                return Wf.Router.Dispatch(cmd.Enclosed);
            else
                return Cmd.fail(cmd.Enclosed);
        }

        public static Type CommandType => typeof(K);

        protected CmdIndex Index;

        public IEnumerable<CmdExec> Hosted
            => Index.Values;

        protected override void Initialized()
        {
            Index = CmdIndex.create();
            if(!CommandsRegistered)
            {
                RegisterCommands(Index);
                CommandsRegistered = true;
                Wf.Babble(string.Format("Registered <{0}> commands from <{1}>", Index.Count, typeof(H).Name));
            }
        }

        protected virtual void RegisterCommands(CmdIndex index)
        {
            var count = GetType().DeclaredInstanceMethods().Tagged<ActionAttribute>(out var methods);
            if(count != 0)
            {
                var view = @readonly(methods);
                for(var i=0; i<count; i++)
                {
                    ref readonly var method = ref skip(view,i);
                    index.Include(Cmd.assign((K)method.Tag.Key, (Action)method.Method.CreateDelegate(typeof(Action),this)));
                }
            }
        }
    }
}