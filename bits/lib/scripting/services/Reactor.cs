//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;

    public sealed class Reactor : GlobalService<Reactor,int>
    {
        public static void dispatch(string[] args)
        {
            try
            {
                var parts = ApiRuntimeLoader.parts(array<PartId>());
                term.inform(AppMsg.status(TextProp.define("PartCount", parts.Components.Length)));
                var rng = Rng.@default();
                using var wf = WfAppLoader.load(parts, args).WithSource(rng);
                if(args.Length == 0)
                {
                    wf.Status("usage: run <command> [options]");
                    var settings = wf.Settings;
                    wf.Row(settings.Format());
                }
                else
                {
                    wf.Status("Dispatching");
                    Reactor.create(wf).Dispatch(args);
                }

            }
            catch(Exception e)
            {
                term.error(e);
            }
        }


        protected override Reactor Init(out int state)
        {
            state = 0;
            return this;
        }

        public void Dispatch(CmdLine src)
        {
            var args = src.Parts;
            if(args.IsEmpty)
                return;

            var cmd = new RunScriptCmd();
            var name =  first(args).Content;
            var path = args.Length >= 2 ? args[1].Content : EmptyString;
            cmd.ScriptPath = FS.path(path);
            Wf.Execute(cmd);
        }
    }
}