//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Collections.Generic;

    using static core;

    public class OmniScript : AppService<OmniScript>
    {
        public Outcome Run(CmdLine cmd, List<string> status = null, List<string> errors = null)
        {
            status = status ?? list<string>();
            errors = errors ?? list<string>();

            void OnStatus(in string data)
            {
                if(nonempty(data))
                    status.Add(data.Trim());
            }

            void OnError(in string data)
            {
                if(nonempty(data))
                    errors.Add(data.Trim());
            }

            var running = Running(cmd);
            ScriptProcess.create(cmd, OnStatus, OnError).Wait();
            Ran(running);

            if(errors.Count == 0)
                return true;
            else
                return (false, errors.Delimit(Chars.NL).Format());
        }

        public Outcome Run(CmdLine cmdline, FS.FilePath dst, List<string> status = null, List<string> errors = null)
        {
            status = status ?? list<string>();
            errors = errors ?? list<string>();
            void OnStatus(in string data)
            {
                if(nonempty(data))
                    status.Add(data);
            }

            void OnError(in string data)
            {
                if(nonempty(data))
                    errors.Add(data);
            }

            try
            {
                var running = Running(cmdline);
                using var writer = dst.AsciWriter();
                ScriptProcess.create(cmdline, writer, OnStatus, OnError).Wait();
                status.Sort();
                Ran(running);
            }
            catch(Exception e)
            {
                Error(e.Message);
            }

            if(status.Count != 0)
            {
                var path = dst.ChangeExtension(FS.Log);
                using var logger = path.Utf8Writer();
                iter(status, entry => logger.WriteLine(entry));
            }

            if(errors.Count != 0)
            {
                var path = dst.ChangeExtension(FS.ext("errors.log"));
                using var logger = path.Utf8Writer();
                iter(errors, entry => logger.WriteLine(entry));
            }

             if(errors.Count == 0)
                return true;
            else
                return (false, errors.Delimit(Chars.NL).Format());
       }

        public Outcome RunToolScript(FS.FilePath src, CmdVars vars, bool quiet, out ReadOnlySpan<ToolCmdFlow> flows)
        {
            flows = default;

            var result = Outcome.Success;
            if(!src.Exists)
                return (false, FS.missing(src));

            result = ScriptRunner.RunCmd(
                Cmd.cmdline(src.Format(PathSeparator.BS)),
                vars,
                quiet ? ReceiveCmdStatusQuiet : ReceiveCmdStatus, ReceiveCmdError,
                out var response
                );

            if(result.Fail)
                return result;

            flows = ScriptProcess.flow(response);

            return result;
        }

        public Outcome RunProjectScript(ProjectId project, string srcid, Subject scope, ScriptId script, bool quiet, out ReadOnlySpan<ToolCmdFlow> flows)
        {
            var path = Ws.Projects().Script(project, scope, script, FS.Cmd);
            var result = Outcome.Success;
            var vars = WsVars.create();
            vars.SrcId = srcid;
            return RunToolScript(path, vars.ToCmdVars(), quiet, out flows);
        }

        public Outcome RunProjectScript(ProjectId project, string srcid, ScriptId script, bool quiet, out ReadOnlySpan<ToolCmdFlow> flows)
        {
            var path = Ws.Projects().Script(project, script, FS.Cmd);
            var result = Outcome.Success;
            var vars = WsVars.create();
            vars.SrcId = srcid;
            return RunToolScript(path, vars.ToCmdVars(), quiet, out flows);
        }

        public Outcome RunProjectScript(ProjectId project, ScriptId script, bool quiet, out ReadOnlySpan<ToolCmdFlow> flows)
        {
            var path = Ws.Projects().Script(project, script, FS.Cmd);
            var result = Outcome.Success;
            return RunToolScript(path, CmdVars.Empty, quiet, out flows);
        }

        public Outcome RunProjectScripts(ProjectId project, string match, ScriptId script, bool quiet, out ReadOnlySpan<ToolCmdFlow> flows)
        {
            var result = Outcome.Success;
            var buffer = list<ToolCmdFlow>();
            var paths = @readonly(Ws.Projects().Scripts(project).Files(FS.Cmd).Where(x => x.Format().StartsWith(match)));
            var count = paths.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(paths,i);
                var vars = WsVars.create();
                var id = path.FileName.WithoutExtension.Format();
                vars.SrcId = id;
                result = RunToolScript(path, vars.ToCmdVars(), quiet, out var _flows);
                if(result.Fail)
                    break;
                iter(_flows, f => buffer.Add(f));
            }

            flows = buffer.ToArray();
            return result;
        }

        public Outcome RunProjectScript(FS.FolderPath root, string src, ScriptId script, bool quiet, out ReadOnlySpan<ToolCmdFlow> flows)
        {
            var result = Outcome.Success;
            var vars = WsVars.create();
            var path = root + FS.folder("scripts") + FS.file(script.Format(), FS.Cmd);
            vars.SrcId = src;
            return RunToolScript(path, vars.ToCmdVars(), quiet, out flows);
        }

        public Outcome Run(FS.FilePath src, CmdVars vars, bool quiet, out ReadOnlySpan<TextLine> response)
            => ScriptRunner.RunCmd(
                Cmd.cmdline(src.Format(PathSeparator.BS)),
                vars,
                quiet ? ReceiveCmdStatusQuiet : ReceiveCmdStatus, ReceiveCmdError,
                out response
                );

        public ReadOnlySpan<CmdResponse> ParseResponse(ReadOnlySpan<TextLine> src)
        {
            var count = src.Length;
            if(count == 0)
                Warn("No response to parse");

            var dst = list<CmdResponse>();

            for(var i=0; i<count; i++)
            {
                if(CmdResponse.parse(skip(src,i).Content, out var response))
                    dst.Add(response);
            }
            return dst.ViewDeposited();
        }

        public Outcome Run(string content, out ReadOnlySpan<TextLine> response)
            => CmdRunner.Run(WinCmd.cmd(content), ReceiveCmdStatusQuiet, ReceiveCmdError, out response);

        public Outcome Run(FS.FilePath src, CmdVars vars, out ReadOnlySpan<TextLine> response)
            => ScriptRunner.RunCmd(Cmd.cmdline(src.Format(PathSeparator.BS)), vars, ReceiveCmdStatusQuiet, ReceiveCmdError, out response);

        public Outcome Run(FS.FilePath src, out ReadOnlySpan<TextLine> response)
            => ScriptRunner.RunCmd(Cmd.cmdline(src.Format(PathSeparator.BS)), CmdVars.Empty, ReceiveCmdStatusQuiet, ReceiveCmdError, out response);

        public Outcome Run(CmdLine cmd, CmdVars vars, FS.FilePath log, Receiver<string> status, Receiver<string> error, out ReadOnlySpan<TextLine> dst)
            => ScriptProcess.run(cmd, vars, log, status, error, out dst);

        public Outcome Run(CmdLine cmd, CmdVars vars, out ReadOnlySpan<TextLine> response)
            => ScriptRunner.RunCmd(cmd, vars, ReceiveCmdStatusQuiet, ReceiveCmdError, out response);

        public Outcome Run(ToolScript script, out ReadOnlySpan<TextLine> response)
            => ScriptRunner.RunCmd(script, ReceiveCmdStatusQuiet, ReceiveCmdError, out response);

        // public Outcome Run(CmdLine cmd, CmdVars vars, out ReadOnlySpan<TextLine> response)
        //     => ScriptRunner.RunCmd(cmd, vars, ReceiveCmdStatus, ReceiveCmdError, out response);

        // public Outcome Run(ToolScript spec, out ReadOnlySpan<TextLine> response)
        //     => ScriptRunner.RunCmd(spec, ReceiveCmdStatus, ReceiveCmdError, out response);

        public Outcome RunWinCmd(string spec, out ReadOnlySpan<TextLine> response)
            => CmdRunner.Run(WinCmd.cmd(spec), out response);

        public ReadOnlySpan<TextLine> RunCmd(CmdLine cmd, Action<Exception> error = null)
        {
            try
            {
                var process = ScriptProcess.create(cmd);
                process.Wait();
                return Lines.read(process.Output);
            }
            catch(Exception e)
            {
                if(error != null)
                    error(e);
                else
                    Error(e);
                return default;
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
                Error(e);
                return default;
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

        public Outcome RunProjectScript(ProjectId project, string src, Subject scope, ScriptId script)
            => RunProjectScript(project, src, scope, script, out _);

        public Outcome RunProjectScript(ProjectId project, string src, Subject scope, ScriptId script, bool quiet)
            => RunProjectScript(project, src, scope, script, quiet, out _);

        public Outcome RunProjectScript(ProjectId project, string src, Subject scope, ScriptId script, out ReadOnlySpan<ToolCmdFlow> flows)
            => RunProjectScript(project, src, scope, script, true, out flows);

        void ReceiveCmdStatusQuiet(in string src)
        {

        }

        void ReceiveCmdStatus(in string src)
        {
            Write(src);
        }

        void ReceiveCmdError(in string src)
        {
            Write(src, FlairKind.Error);
        }
    }
}