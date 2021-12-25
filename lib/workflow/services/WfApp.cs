//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class WfApp<A> : AppService<A>
        where A : WfApp<A>, new()
    {
        public static void run(string[] args, params PartId[] parts)
        {
            using var wf = WfAppLoader.load(parts, args);
            using var app = new A();
            app.Init(wf);
            var name = typeof(A).Name;
            var flow = wf.Running(RP.msg("Running application {0}", name));
            app.Run(args);
            wf.Ran(flow, RP.msg("Ran application {0}", name));
        }

        protected abstract void Run();

        protected virtual void Run(string[] args)
            => Run();
    }
}