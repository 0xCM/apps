//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class WsScripts : WfSvc<WsScripts>
    {
        OmniScript OmniScript => Wf.OmniScript();

        public FS.FolderPath CleanOutDir(IWsProject project)
            => project.BuildOut().Clear(true);

        public void BuildAsm(IWsProject src)
            => RunBuildScripts(src, FileKind.Asm, src.Script("build-asm"), false);

        public void BuildC(IWsProject src, bool runexe = false)
            => RunBuildScripts(src, FileKind.C, src.Script("build-c"), runexe);

        public void BuildCpp(IWsProject src, bool runexe = false)
            => RunBuildScripts(src, FileKind.Cpp, src.Script("build-cpp"), runexe);

        public void RunBuildScripts(IWsProject project ,FileKind kind, FS.FilePath script, bool runexe)
            => RunBuildScript(project, kind, script, flow => OnExec(flow, runexe));

        void RunExe(CmdFlow flow)
        {
            var running = Running(string.Format("Executing {0}", flow.TargetPath.ToUri()));
            var result = OmniScript.Run(flow.TargetPath, CmdVars.Empty, quiet: true, out var response);
            if (result.Fail)
                Error(result.Message);
            else
            {
                for (var i=0; i<response.Length; i++)
                    Write(string.Format("exec >> {0}",skip(response, i).Content), FlairKind.StatusData);

                Ran(running, string.Format("Executed {0}", flow.TargetPath.ToUri()));
            }
        }

        void OnExec(CmdFlow flow, bool runexe)
        {
            if(flow.TargetPath.FileName.Is(FS.Exe) && runexe)
                RunExe(flow);
        }

        public void RunBuildScript(IWsProject project, FileKind kind, FS.FilePath script, Action<CmdFlow> receiver)
        {
            var flows = list<CmdFlow>();
            var files = project.SrcFiles(kind, false);
            int length = files.Length;
            for(var i=0; i<length; i++)
            {
                var path = files[i];
                var srcid = path.FileName.WithoutExtension.Format();
                var result = OmniScript.RunScript(project, script, srcid);
                if(result)
                {
                    flows.AddRange(result.Data);
                    foreach(var flow in result.Data)
                    {
                        Status(flow.Format());
                        receiver.Invoke(flow);
                    }
                }
            }

            if(flows.Count != 0)
                TableEmit(flows.ViewDeposited(), Flows.path(project));
        }
    }
}