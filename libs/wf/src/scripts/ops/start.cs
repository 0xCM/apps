//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    partial class CmdScripts
    {
        public static Task<FS.FilePath> start(CmdArgs args)
        {
            var count = Demand.gt(args.Count,0u);
            var spec = text.emitter();
            for(var i=0; i<args.Count; i++)
            {
                if(i != 0)
                    spec.Append(Chars.Space);
                spec.Append(args[i].Value);
            }

            return start(Cmd.cmd(spec.Emit()));
        }

        public static Task start(ReadOnlySeq<CmdScript> src, bool pll)
            => Algs.start(() => iter(src, run, pll));

        public static Task start(CmdLine cmd, CmdVars vars, Action<TextLine> receiver)
        {
            void run()
            {
                var result = Outcome.Success;
                try
                {
                    var process = Cmd.process(cmd, vars);
                    process.Wait();
                    iter(Lines.read(process.Output), receiver);
                }
                catch(Exception e)
                {
                    result = e;
                }

            }
            return Algs.start(run);
        }

        public static Task<FS.FilePath> start(CmdLine cmd)
        {
            static void OnError(in string src)
                => term.emit(Events.error(typeof(CmdScripts), src, Events.originate(typeof(CmdScript))));

            static void OnStatus(in string src)
                => term.emit(Events.data(src,FlairKind.Babble));

            FS.FilePath run()
            {
                var log = AppDb.Logs("procs").Path(timestamp().Format(),FileKind.Log);
                using var writer = log.AsciWriter();
                try
                {
                    term.print();
                    term.emit(Events.running(typeof(Cmd), $"'{cmd}"));
                    var process = Cmd.process(cmd, OnStatus, OnError).Wait();
                    var lines =  Lines.read(process.Output);
                    iter(lines, line => writer.WriteLine(line));
                    term.emit(Events.ran(typeof(Cmd), $"Executed '{cmd}'"));
                }
                catch(Exception e)
                {
                    writer.WriteLine(e.ToString());
                }
                return log;
            }
            return Algs.start(run);
        }
    }
}