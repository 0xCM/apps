//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public abstract class CheckRunner<T> : AppCmdService<T,CmdShellState>
        where T : CheckRunner<T>, new()
    {
        ConstLookup<Identifier,ICheckService> CheckServices;

        protected override void Initialized()
        {
            State.Init(Wf, Ws);
            CheckServices = Checkers.discover(Wf, ApiRuntimeCatalog.Components);
        }

        public override void Run()
        {
            iter(CheckServices.Values, svc => svc.Run());
        }

        public Index<string> ListChecks()
        {
            var dst = list<string>();
            foreach(var svc in CheckServices.Values)
                foreach(var c in svc.Checks)
                    dst.Add(string.Format("{0}/{1}", svc.Name, c));
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
                    var name = args[0].Value;
                    if(CheckServices.Find(name, out var checker))
                        checker.Run();
                    else
                        Warn(string.Format("{0} checker not found", name));
                }
            }
        }
    }
}