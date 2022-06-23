//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class OmniScript : WfSvc<OmniScript>
    {
        ScriptRunner ScriptRunner => Wf.ScriptRunner();

        CmdLineRunner CmdRunner => Wf.CmdLineRunner();

        public Outcome<Index<CmdFlow>> RunScript(IWsProject project, ScriptId script, string srcid)
        {
            var cmdflows = list<CmdFlow>();
            var result = RunProjectScript(project, srcid, script, true, out var flows);
            if(result)
            {
                var count = flows.Length;
                for(var j=0; j<count; j++)
                    cmdflows.Add(skip(flows,j));
                return (true, cmdflows.ToArray());
            }

            return result;
        }

        public Outcome RunToolScript(FS.FilePath src, CmdVars vars, bool quiet, out ReadOnlySpan<CmdFlow> flows)
        {
            flows = default;
            var result = Outcome.Success;
            if(!src.Exists)
                return (false, FS.missing(src));

            result = ScriptRunner.RunCmd(
                CmdScripts.cmdline(src.Format(PathSeparator.BS)),
                vars,
                quiet ? ReceiveCmdStatusQuiet : ReceiveCmdStatus, ReceiveCmdError,
                out var response
                );

            if(result.Fail)
                return result;

            flows = CmdFlows.parse(response);

            return result;
        }

        public Outcome RunProjectScript(IWsProject project, string srcid, ScriptId script, bool quiet, out ReadOnlySpan<CmdFlow> flows)
        {
            var path = project.Script(script, FileKind.Cmd);
            var result = Outcome.Success;
            var vars = WsCmdVars.create();
            vars.SrcId = srcid;
            return RunToolScript(path, vars.ToCmdVars(), quiet, out flows);
        }

        public Outcome Run(FS.FilePath src, CmdVars vars, bool quiet, out ReadOnlySpan<TextLine> response)
            => ScriptRunner.RunCmd(
                CmdScripts.cmdline(src.Format(PathSeparator.BS)),
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

        public Outcome Run(FS.FilePath src, out ReadOnlySpan<TextLine> response)
            => ScriptRunner.RunCmd(CmdScripts.cmdline(src.Format(PathSeparator.BS)), CmdVars.Empty, ReceiveCmdStatusQuiet, ReceiveCmdError, out response);

        public Outcome Run(CmdLine cmd, CmdVars vars, out ReadOnlySpan<TextLine> response)
            => ScriptRunner.RunCmd(cmd, vars, ReceiveCmdStatusQuiet, ReceiveCmdError, out response);

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