//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Algs;

    public sealed class ScriptRunner : WfSvc<ScriptRunner>
    {
        public static Task start(ReadOnlySeq<CmdScript> src, bool pll)
            => core.start(() => iter(src, run, pll));

        static FS.FilePath ErrorLog(Timestamp ts, string name)
            => AppDb.Logs("process").Path($"{name}.errors.{ts}", FileKind.Log);

        static FS.FilePath StatusLog(Timestamp ts, string name)
            => AppDb.Logs("process").Path($"{name}.{ts}", FileKind.Log);

        static void run(CmdScript src)
        {
            var ts = timestamp();
            using var status = StatusLog(ts,src.Id.Format()).AsciWriter();

            void OnStatus(in string msg)
                => status.AppendLine(msg);

            void OnError(in string msg)
                => ErrorLog(ts,src.Id).Append(msg);

            try
            {
                var process = CmdScripts.process(src.ToCmdLine(), OnStatus, OnError).Wait();
            }
            catch(Exception e)
            {
                ErrorLog(ts,src.Id).Append(e.ToString());
            }
        }

        public ReadOnlySpan<TextLine> RunCmd(CmdLine cmd, CmdVars vars)
        {
            try
            {
                var process = CmdScripts.process(cmd, vars);
                process.Wait();
                return Lines.read(process.Output);
            }
            catch(Exception e)
            {
                term.error(e);
                return default;
            }
        }

        public Outcome RunCmd(CmdLine cmd, CmdVars vars, Receiver<string> status, Receiver<string> error, out ReadOnlySpan<TextLine> dst)
        {
            dst = default;
            try
            {
                var process = CmdScripts.process(cmd, vars, status, error);
                process.Wait();
                dst = Lines.read(process.Output);
                return true;
            }
            catch(Exception e)
            {
                return e;
            }
        }

        public Outcome RunCmd(CmdLine cmd, CmdVars vars, out ReadOnlySpan<TextLine> dst)
        {
            dst = default;
            try
            {
                var process = CmdScripts.process(cmd, vars);
                process.Wait();
                dst = Lines.read(process.Output);
                return true;
            }
            catch(Exception e)
            {
                return e;
            }
        }

        public ReadOnlySpan<TextLine> RunCmd(CmdLine cmd, Action<Exception> errhandle = null)
        {
            try
            {
                var process = CmdScripts.process(cmd);
                process.Wait();
                return Lines.read(process.Output);
            }
            catch(Exception e)
            {
                if(errhandle != null)
                    errhandle(e);
                else
                    term.error(e);
                return default;
            }
        }

        ReadOnlySpan<TextLine> Run(CmdLine cmd, ScriptId script, CmdVars? vars)
        {
            using var writer = AppDb.Logs("scripts").Path(script,FileKind.Log).Writer();
            try
            {
                var process = vars != null ? CmdScripts.process(cmd, vars) : CmdScripts.process(cmd);
                process.Wait();
                var lines =  Lines.read(process.Output);
                iter(lines, line => writer.WriteLine(line));
                return lines;
            }
            catch(Exception e)
            {
                term.error(e);
                writer.WriteLine(e.ToString());
                return default;
            }
        }
    }
}