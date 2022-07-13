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

        public FS.Files SourceFiles(IWsProject src, FileKind kind, bool recurse = false)
            => src.SrcFiles(kind, recurse);

        FS.FilePath Script(IWsProject src, string name)
            => src.Script(name);

        public Outcome<Index<CmdFlow>> BuildAsm(IWsProject src)
            => RunBuildScripts(src, FileKind.Asm, Script(src,"build-asm"), false);

        public Outcome<Index<CmdFlow>> BuildC(IWsProject src, bool runexe = false)
            => RunBuildScripts(src, FileKind.C, Script(src,"build-c"), runexe);

        public Outcome<Index<CmdFlow>> BuildCpp(IWsProject src, bool runexe = false)
            => RunBuildScripts(src, FileKind.Cpp, Script(src,"build-cpp"), runexe);

        public Outcome<Index<CmdFlow>> RunBuildScripts(IWsProject project ,FileKind kind, FS.FilePath script, bool runexe)
            => RunBuildScript(project, kind, script, flow => HandleBuildResponse(flow, runexe));

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

        void HandleBuildResponse(CmdFlow flow, bool runexe)
        {
            if(flow.TargetPath.FileName.Is(FS.Exe) && runexe)
                RunExe(flow);
        }

        public Outcome<Index<CmdFlow>> RunBuildScript(IWsProject project, FileKind kind, FS.FilePath script, Action<CmdFlow> receiver)
        {
            var result = Outcome<Index<CmdFlow>>.Success;
            var cmdflows = list<CmdFlow>();
            var files = SourceFiles(project,kind);
            int length = files.Length;
            for(var i=0; i<length; i++)
            {
                var path = files[i];
                var srcid = path.FileName.WithoutExtension.Format();
                result = OmniScript.RunScript(project, script, srcid);
                if(result)
                {
                    cmdflows.AddRange(result.Data);
                    foreach(var flow in result.Data)
                    {
                        Status(flow.Format());
                        receiver?.Invoke(flow);
                    }
                }
            }

            if(cmdflows.Count != 0)
            {
                var records = cmdflows.ToArray();
                TableEmit(records, project.BuildFlows());
                result = (true,records);
            }

            return result;
        }
    }
}