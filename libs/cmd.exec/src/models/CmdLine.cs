//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class CmdLineRunner : AppService<CmdLineRunner>
    {
        public void RunScript(FS.FilePath path, string args)
        {
            var cmd = new CmdLine($"cmd /c {path.Format(PathSeparator.BS)} {args}");
            var process = ScriptProcess.create(cmd);
            var output = process.Output;
            Wf.Status(output);
        }

        public void RunScripts(ScriptArchive archive, ReadOnlySpan<ScriptId> scripts, FS.FilePath log)
        {
            try
            {
                var count = scripts.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var id = ref skip(scripts,i);
                    var path = archive.Script(id);
                    if(path.Exists)
                    {
                        var output = RunScript(path, log);
                        var processor = CmdResultProcessor.create(path, sys.empty<IToolResultHandler>());
                        Write("Response");
                        iter(output, x => processor.Process(x));
                    }
                    else
                    {
                        Error($"The script {path.ToUri()} does not exist");
                    }
                }
            }
            catch(Exception e)
            {
                Error(e);
            }
        }

        public void RunScripts(ScriptArchive archive, ReadOnlySpan<ScriptId> scripts)
            => RunScripts(archive, scripts, Db.AppLog("cmdline"));

        public ReadOnlySpan<TextLine> Run(CmdLine cmd, FS.FilePath log)
        {
            using var writer = log.AsciWriter();
            try
            {
                var process = ScriptProcess.create(cmd, OnStatusEvent, OnErrorEvent).Wait();
                var lines =  Lines.read(process.Output);
                iter(lines, line => writer.WriteLine(line));
                return lines;
            }
            catch(Exception e)
            {
                Error(e);
                writer.WriteLine(e.ToString());
                return default;
            }
        }

        public Outcome Run(CmdLine cmd, out ReadOnlySpan<TextLine> dst)
            => Run(cmd, OnStatusEvent, OnErrorEvent, out dst);

        public Outcome Run(CmdLine cmd, Receiver<string> status, Receiver<string> error, out ReadOnlySpan<TextLine> dst)
            => Run(cmd,Db.AppLog("cmdline"), status, error, out dst);

        public Outcome Run(CmdLine cmd, FS.FilePath log, Receiver<string> status, Receiver<string> error, out ReadOnlySpan<TextLine> dst)
        {
            using var writer = log.AsciWriter();
            try
            {
                var process = ScriptProcess.create(cmd, status, error).Wait();
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

        public ReadOnlySpan<TextLine> RunScript(FS.FilePath src, FS.FilePath log)
            => Run(WinCmd.script(src), log);

        void OnErrorEvent(in string src)
            => Error(src);

        void OnStatusEvent(in string src)
            => Write(src);
    }
    /// <summary>
    /// Captures the content of a command-line
    /// </summary>
    public readonly struct CmdLine
    {
        readonly Index<string> Data;

        [MethodImpl(Inline)]
        public CmdLine(params string[] content)
            => Data = content;

        public ReadOnlySpan<CmdLinePart> Parts
        {
            [MethodImpl(Inline)]
            get => recover<string,CmdLinePart>(Data.Edit);
        }

        [MethodImpl(Inline)]
        public string Format()
            => text.delimit(Data.View, Chars.Space, 0);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator CmdLine(string src)
            => new CmdLine(src);

        [MethodImpl(Inline)]
        public static implicit operator CmdLine(string[] src)
            => new CmdLine(src);

        [MethodImpl(Inline)]
        public static implicit operator string(CmdLine src)
            => src.Format();

        public static CmdLine Empty
        {
            [MethodImpl(Inline)]
            get => new CmdLine(sys.empty<string>());
        }
    }
}