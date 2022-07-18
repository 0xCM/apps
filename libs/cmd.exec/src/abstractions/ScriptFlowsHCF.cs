//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public abstract class CmdScriptRunner<H,C,F> : WfSvc<H>
        where C : struct, IToolFlowCmd<C>
        where F : IFileFlowType<F>, new()
        where H : CmdScriptRunner<H,C,F>, new()
    {
        const string ErrorMarker = "error:";

        const string WarningMarker = "warning:";

        protected virtual void OnExecStatus(in string msg)
        {
            Write(msg, FlairKind.Status);
        }

        protected virtual void OnExecError(in string msg)
        {
            if(text.contains(msg, ErrorMarker))
                Write(msg, FlairKind.Error);
            else if(text.contains(msg, WarningMarker))
                Write(msg, FlairKind.Warning);
        }

        public void Execute(IProjectWsObsolete project, ReadOnlySpan<CmdLine> commands, CmdDescriptor descriptor, bool clean = false)
        {
            if(clean)
                project.Out().Delete();

            var runlog = project.Out() + FS.file(descriptor.Name, FS.Log);
            var running = Running();
            var counter = 0u;

            using var flows = WsLog.open(project, string.Format("{0}.flows", descriptor.Name), FileKind.Log, clean);
            var eflows = EmittingFile(flows.Path);

            void ExecCmd(CmdLine src)
            {
                Scripters.run(src, CmdVars.Empty, runlog, OnExecStatus, OnExecError, out var output);
                var responses = CmdResponse.parse(output.Where(x => !x.Contains(WarningMarker) && !x.Contains(ErrorMarker)));
                counter += (uint)responses.Length;
                iter(responses, r => flows.AppendLine(r.Format()));
            }

            iter(commands, ExecCmd);

            EmittedFile(eflows, counter);
            Ran(running);
        }

    }
}