//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public sealed class ScriptRunner
    {
        [MethodImpl(Inline)]
        public static ScriptRunner create(IEnvPaths paths)
            => new ScriptRunner(paths);

        readonly IEnvPaths Paths;

        [MethodImpl(Inline)]
        ScriptRunner(IEnvPaths paths)
            => Paths = paths;

        public ReadOnlySpan<TextLine> RunControlScript(FS.FileName name, CmdVars? vars = null)
            => RunScript(Paths.ControlScript(name), new ScriptId(name.Name), vars);

        public ReadOnlySpan<TextLine> RunToolCmd(ToolScript src)
            => RunToolScript(src.Tool, src.Script, ToolScriptKind.Cmd, src.Vars);

        public ReadOnlySpan<TextLine> RunToolCmd(ToolId tool, ScriptId script, CmdVars? vars = null)
            => RunToolScript(tool, script, ToolScriptKind.Cmd, vars);

        public ReadOnlySpan<TextLine> RunToolPs(ToolId tool, ScriptId script, CmdVars? vars = null)
            => RunToolScript(tool, script, ToolScriptKind.Ps, vars);

        ReadOnlySpan<TextLine> RunToolScript(ToolId tool, ScriptId script, ToolScriptKind kind, CmdVars? vars)
            => Run(CmdLine(ScriptFile(tool, script, kind), kind), script, vars);

        ReadOnlySpan<TextLine> RunScript(FS.FilePath src, ScriptId script, CmdVars? vars)
            => Run(new CmdLine(src.Format(PathSeparator.BS)), script, vars);

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
                var kind = ToolScriptKind.Cmd;
                var path = ScriptFile(script, kind);
                if(!path.Exists)
                    return (false,FS.missing(path));
                var process = ScriptProcess.create(CmdLine(path, kind), script.Vars, status, error);
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
                var process = vars != null ? ScriptProcess.create(cmd, vars.Value) : ScriptProcess.create(cmd);
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

        FS.FilePath ScriptFile(ToolId tool, ScriptId script, ToolScriptKind kind)
        {
            var x = kind switch{
                ToolScriptKind.Cmd => FS.Cmd,
                ToolScriptKind.Ps => FS.Ps1,
                _ => FS.FileExt.Empty
            };
            return Paths.ToolScript(tool, script, x);
        }

        FS.FilePath ScriptFile(ToolScript spec, ToolScriptKind kind)
        {
            var x = kind switch{
                ToolScriptKind.Cmd => FS.Cmd,
                ToolScriptKind.Ps => FS.Ps1,
                _ => FS.FileExt.Empty
            };
            return Paths.ToolScript(spec.Tool, spec.Script, x);
        }

        CmdLine CmdLine(FS.FilePath path, ToolScriptKind kind)
        {
            return kind switch{
                ToolScriptKind.Cmd => WinCmd.script(path),
                ToolScriptKind.Ps => PwshCmd.script(path),
                _ => Z0.CmdLine.Empty
            };
        }
    }
}