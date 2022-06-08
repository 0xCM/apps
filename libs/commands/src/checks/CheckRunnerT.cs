//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public abstract class CheckRunner<T> : AppCmdService<T,CmdShellState>, ICheckRunner
        where T : CheckRunner<T>, new()
    {
        ConstLookup<Type,IChecker> Services;

        protected CheckRunner()
        {
            Pll = true;
        }

        protected override void Initialized()
        {
            State.Init(Wf, Ws);
            Services = Checkers.discover(Wf, typeof(T));
        }

        protected virtual bool Pll {get;}

        public override sealed void Run()
        {
            iter(Services.Values, svc => svc.Run(Pll), Pll);
        }

        public void Run(bool pll)
        {
            iter(Services.Values, svc => svc.Run(pll), pll);
        }

        public Index<string> ListChecks()
        {
            var dst = list<string>();
            foreach(var svc in Services.Values)
                foreach(var c in svc.Specs)
                    dst.Add(c);
            iter(dst, cmd => Write(cmd));
            return dst.ToArray();
        }

        [CmdOp("checks/list")]
        protected void ChecksList()
            => ListChecks();

        [CmdOp("checks/run")]
        protected void ChecksRun(CmdArgs args)
        {
            if(args.Count == 0)
                Run();
            else
            {
                var count = args.Count;
                for(var i=0; i<count; i++)
                {
                    var match = args[0].Value;
                    var keys = Services.Keys.Where(t => t.Name == match);
                    foreach(var key in keys)
                        Services[key].Run();
                }
            }
        }
    }
}