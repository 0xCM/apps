//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct Checkers
    {
        public static void run(string name, Action<ITextEmitter> f, bool show = true)
        {
            var log = text.emitter();
            run(name, f, log, show);
        }

        public static void run(bool pll, params (string name, Action<ITextEmitter> f)[] checks)
        {
            iter(checks, x => run(x.name, x.f), pll);
        }

        static void run(string name, Action<ITextEmitter> f, ITextEmitter log, bool show)
        {
            Run();

            void Run()
            {
                try
                {
                    f(log);
                    if(show)
                        ShowCheckResult(name, log.Emit(false));
                }
                catch(Exception e)
                {
                    if(show)
                        ShowCheckResult(name, log.Emit(false), e);
                }
            }
        }

        static void ShowCheckResult(string name, string data, Exception e = null)
        {
            term.print(
                (Eol, FlairKind.Data),
                (name, FlairKind.StatusData),
                (RP.PageBreak120, FlairKind.StatusData),
                (Eol, FlairKind.Data),
                (data + (e == null ? EmptyString :  Eol + e.ToString()), e == null ? FlairKind.Data : FlairKind.Error)
                );
        }

        public static Type[] types(params Assembly[] src)
            => src.Types().Tagged<CheckerAttribute>().Concrete();

        public static ConstLookup<Type,ICheckService> discover(IWfRuntime wf, params Assembly[] src)
        {
            var dst = dict<Type,ICheckService>();
            foreach(var type in types(src))
            {
                var factories = type.StaticMethods().Where(x => x.Name == "create");
                if(factories.Length == 1)
                {
                    ref readonly var factory = ref first(factories);
                    var service = (ICheckService)factory.Invoke(null, new object[]{wf});
                    var name = service.GetType().FullName;
                    dst.Add(service.GetType(),service);
                }
            }
            return dst;
        }
    }
}