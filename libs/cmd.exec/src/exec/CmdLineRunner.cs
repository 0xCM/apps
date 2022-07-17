//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class CmdLineRunner : WfSvc<CmdLineRunner>
    {
        public void RunScript(FS.FilePath path, string args)
        {
            var cmd = new CmdLine($"cmd /c {path.Format(PathSeparator.BS)} {args}");
            var process = ScriptProcess.create(cmd);
            var output = process.Output;
            Status(output);
        }

        public Task<FS.FilePath> Start(CmdLine cmd)
        {
            FS.FilePath Run()
            {
                var log = AppDb.Logs("procs").Path(timestamp().Format(),FileKind.Log);
                using var writer = log.AsciWriter();
                try
                {
                    var process = ScriptProcess.start(cmd, OnStatusEvent, OnErrorEvent).Wait();
                    var lines =  Lines.read(process.Output);
                    iter(lines, line => writer.WriteLine(line));

                }
                catch(Exception e)
                {
                    Error(e);
                    writer.WriteLine(e.ToString());
                }
                return log;
            }
            return run(Run);
        }

        public Outcome Run(CmdLine cmd, Receiver<string> status, Receiver<string> error, out ReadOnlySpan<TextLine> dst)
            => Run(cmd, DbArchive().Log("cmdline", FileKind.Log), status, error, out dst);

        Outcome Run(CmdLine cmd, FS.FilePath log, Receiver<string> status, Receiver<string> error, out ReadOnlySpan<TextLine> dst)
        {
            using var writer = log.AsciWriter();
            try
            {
                var process = ScriptProcess.start(cmd, status, error).Wait();
                var lines =  Lines.read(process.Output);
                core.iter(lines, line => writer.WriteLine(line));
                dst = lines;
                return true;
            }
            catch(Exception e)
            {
                dst = default;
                return e;
            }
        }

        void OnErrorEvent(in string src)
            => Error(src);

        void OnStatusEvent(in string src)
            => Write(src);
    }
}