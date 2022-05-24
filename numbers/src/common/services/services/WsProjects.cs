//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class WsProjects : AppService<WsProjects>
    {
        WsUnserviced Unserviced;

        protected override void Initialized()
        {
            Unserviced = WsUnserviced.create(Ws);
        }

        public FS.FolderPath ProjectData(IProjectWs project, string scope)
            => Unserviced.ProjectData(project,scope);

        public FS.FilePath ProjectFile(IProjectWs project, string suffix, FileKind kind)
            => Unserviced.ProjectFile(project, suffix, kind);

        public FS.FilePath Table<T>(IProjectWs project)
            where T : struct
                => Unserviced.Table<T>(project);

        public FS.FolderPath CleanOutDir(IProjectWs project)
            => project.OutDir().Clear(true);

        public FS.Files SourceFiles(IProjectWs ws, Subject? scope)
        {
            if(scope != null)
                return ws.SrcFiles(scope.Value.Format());
            else
                return ws.SrcFiles();
        }

        public Outcome<Index<ToolCmdFlow>> RunBuildScripts(IProjectWs project, ScriptId scriptid, Subject? scope, Action<ToolCmdFlow> receiver)
        {
            var result = Outcome<Index<ToolCmdFlow>>.Success;
            var cmdflows = list<ToolCmdFlow>();
            if(nonempty(scriptid))
            {
                var files = SourceFiles(project, scope);
                int length = files.Length;
                for(var i=0; i<length; i++)
                {
                    var path = files[i];
                    var srcid = path.FileName.WithoutExtension.Format();
                    result = RunScript(project.Project, scriptid, srcid);
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
            }
            else
                result = (false, "Script specification unknown");

            if(cmdflows.Count != 0)
            {
                Index<ToolCmdFlow> records = cmdflows.ToArray();
                TableEmit(records.View, ToolCmdFlow.RenderWidths, ProjectFile(project,"build.flows", FileKind.Csv));
                result = (true,records);
            }

            return result;
        }

        Outcome<Index<ToolCmdFlow>> RunScript(ProjectId project, ScriptId script, string srcid)
        {
            var cmdflows = list<ToolCmdFlow>();
            var result = OmniScript.RunProjectScript(project, srcid, script, true, out var flows);
            if(result)
            {
                var count = flows.Length;
                for(var j=0; j<count; j++)
                    cmdflows.Add(skip(flows,j));
                return (true, cmdflows.ToArray());
            }

            return result;
        }

        static SortedDictionary<string,FileKind> FileKinds;

        static WsProjects()
        {
            var symbols = Symbols.index<FileKind>();
            var kinds = symbols.Kinds;
            FileKinds = symbols.View.Map(s => ("." + s.Expr.Format().ToLower(), s.Kind)).ToSortedDictionary(TextLengthComparer.create(true));
        }
    }
}