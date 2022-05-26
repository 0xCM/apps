//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public sealed class CheckRunner : CheckRunner<CheckRunner>
    {
        public static void run(string name, Action<ITextEmitter> f, bool show = true)
        {
            var log = text.emitter();
            run(name, f, log, show);
        }

        public static void run(bool pll, params (string name, Action<ITextEmitter> f)[] checks)
        {
            core.iter(checks, x => run(x.name, x.f), pll);
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


   }
}