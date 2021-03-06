//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public sealed class ScriptRunner : WfSvc<ScriptRunner>
    {
        FS.FilePath ErrorLog(Timestamp ts, string name)
            => AppDb.Logs("process").Path($"{name}.errors.{ts}", FileKind.Log);

        FS.FilePath StatusLog(Timestamp ts, string name)
            => AppDb.Logs("process").Path($"{name}.{ts}", FileKind.Log);

        public void Run(bool pll, params CmdScript[] src)
            => iter(src, Run, pll);

        void Run(CmdScript src)
        {
            var ts = core.timestamp();
            using var status = StatusLog(ts,src.Id.Format()).AsciWriter();

            void OnStatus(in string msg)
                => status.AppendLine(msg);

            void OnError(in string msg)
                => ErrorLog(ts,src.Id).Append(msg);

            try
            {
                var flow = Running($"Executing process '{src.ToCmdLine()}'");
                var process = ScriptProcess.start(src.ToCmdLine(), OnStatus, OnError).Wait();
                Ran(flow);
            }
            catch(Exception e)
            {
                ErrorLog(ts,src.Id).Append(e.ToString());
                Error(e);
            }
        }

        public ReadOnlySpan<TextLine> RunControlScript(FS.FileName name, CmdVars? vars = null)
            => RunScript(Paths.ControlScript(name), new ScriptId(name.Name), vars);

        public ReadOnlySpan<TextLine> RunToolCmd(ToolScript src)
            => RunToolScript(src.Ws, src.Tool, src.Script, ScriptKind.Cmd, src.Vars);

        public ReadOnlySpan<TextLine> RunToolCmd(IToolWs ws, Actor tool, ScriptId script, CmdVars? vars = null)
            => RunToolScript(ws, tool, script, ScriptKind.Cmd, vars);

        ReadOnlySpan<TextLine> RunToolScript(IToolWs ws, Actor tool, ScriptId script, ScriptKind kind, CmdVars? vars)
            => Run(Scripts.script(Scripts.path(ws, tool, script, kind), kind), script, vars);

        ReadOnlySpan<TextLine> RunScript(FS.FilePath src, ScriptId script, CmdVars? vars)
            => Run(new CmdLine(src.Format(PathSeparator.BS)), script, vars);

        public void Dispatch(Index<IToolResultHandler> handlers, Index<string> args, ILineProcessor processor)
        {
            try
            {
                var count = args.Length;
                for(var i=0; i<count; i++)
                {
                    var name = FS.file(args[i]);
                    term.inform(name);

                    if(!name.HasExtension)
                        name = name.WithExtension(FS.Cmd);

                    var script = AppDb.Control().Path(name);
                    if(script.Exists)
                    {
                        var output = RunControlScript(name);
                        iter(output, x => processor.Process(x));
                    }
                    else
                    {
                        term.error($"The script {script.ToUri()} does not exist");
                    }
                }
            }
            catch(Exception e)
            {
                term.error(e);
            }
        }

        public ReadOnlySpan<TextLine> RunCmd(CmdLine cmd, CmdVars vars)
        {
            try
            {
                var process = ScriptProcess.create(cmd, vars);
                process.Wait();
                return Lines.read(process.Output);
            }
            catch(Exception e)
            {
                term.error(e);
                return default;
            }
        }

        public Outcome RunCmd(ToolScript script, Receiver<string> status, Receiver<string> error, out ReadOnlySpan<TextLine> dst)
        {
            dst = default;
            try
            {
                var kind = ScriptKind.Cmd;
                var path = script.Path();
                if(!path.Exists)
                    return (false,FS.missing(path));
                var process = ScriptProcess.create(Scripts.script(path, kind), script.Vars, status, error);
                process.Wait();
                dst = Lines.read(process.Output);
                return true;
            }
            catch(Exception e)
            {
                return e;
            }
        }

        public Outcome RunCmd(CmdLine cmd, CmdVars vars, Receiver<string> status, Receiver<string> error, out ReadOnlySpan<TextLine> dst)
        {
            dst = default;
            try
            {
                var process = ScriptProcess.create(cmd, vars, status, error);
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
                var process = ScriptProcess.create(cmd, vars);
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
                var process = ScriptProcess.create(cmd);
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
            using var writer = Paths.CmdLog(script).Writer();
            try
            {
                var process = vars != null ? ScriptProcess.create(cmd, vars) : ScriptProcess.create(cmd);
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