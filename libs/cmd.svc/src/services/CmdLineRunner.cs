//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class CmdLineRunner : WfSvc<CmdLineRunner>
    {
        // public Task<FS.FilePath> Start(CmdLine cmd)
        // {
        //     FS.FilePath Run()
        //     {
        //         var log = AppDb.Logs("procs").Path(timestamp().Format(),FileKind.Log);
        //         using var writer = log.AsciWriter();
        //         try
        //         {
        //             var process = CmdScripts.process(cmd, OnStatusEvent, OnErrorEvent).Wait();
        //             var lines =  Lines.read(process.Output);
        //             iter(lines, line => writer.WriteLine(line));

        //         }
        //         catch(Exception e)
        //         {
        //             writer.WriteLine(e.ToString());
        //         }
        //         return log;
        //     }
        //     return start(Run);
        // }

        public Outcome Run(CmdLine cmd, Receiver<string> status, Receiver<string> error, out ReadOnlySpan<TextLine> dst)
            => Run(cmd, Archives.Service().Log("cmdline", FileKind.Log), status, error, out dst);

        Outcome Run(CmdLine cmd, FS.FilePath log, Receiver<string> status, Receiver<string> error, out ReadOnlySpan<TextLine> dst)
        {
            using var writer = log.AsciWriter();
            dst = sys.empty<TextLine>();
            var result = Outcome.Success;
            try
            {
                var process = CmdScripts.process(cmd, status, error).Wait();
                var lines =  Lines.read(process.Output);
                core.iter(lines, line => writer.WriteLine(line));
                dst = lines;
            }
            catch(Exception e)
            {
                result = e;
            }
            return result;
        }

        void OnErrorEvent(in string src)
            => Error(src);

        void OnStatusEvent(in string src)
            => Write(src);
    }
}