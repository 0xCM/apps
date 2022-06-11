//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public abstract class AppShell<S> : WfApp<S>
        where S : AppShell<S>, new()
    {
        protected static S shell(params string[] args)
            => create(WfAppLoader.load());

        protected static void run(params string[] args)
        {
            using var app = shell(args);
            app.Run();
        }

        protected static void run(Func<IWfRuntime> f)
        {
            using var app = create(f());
            app.Run();
        }
    }
}