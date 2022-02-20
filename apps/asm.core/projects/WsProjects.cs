//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class WsProjects : AppService<WsProjects>
    {
        public WsProjects()
        {
            var symbols = Symbols.index<FileKind>();
            var kinds = symbols.Kinds;
            FileKindMatch = symbols.View.Map(s => ("." + s.Expr.Format().ToLower(), s.Kind)).ToSortedDictionary(TextLengthComparer.create(true));
        }

        SortedDictionary<string,FileKind> FileKindMatch;

        public Index<IFileFlowType> FileFlowTypes()
        {
            return Data(nameof(FileFlowTypes), Load);

            Index<IFileFlowType> Load()
            {
                var src = ApiRuntimeCatalog.Components.Storage;
                var types = src.Types().Tagged<FileFlowTypeAttribute>().Concrete();
                var count = types.Length;
                var dst = alloc<IFileFlowType>(count);
                for(var i=0; i<count; i++)
                {
                    ref readonly var type = ref skip(types,i);
                    seek(dst,i) = (IFileFlowType)Activator.CreateInstance(type);
                }
                return dst;
            }
        }

        public FS.FilePath Table<T>(IProjectWs project)
            where T : struct
                => ProjectDb.ProjectTable<T>(project);

        public FS.FolderPath ProjectData()
            => ProjectDb.ProjectData();

        public FS.FolderPath ProjectData(IProjectWs project)
            => ProjectData() + FS.folder(project.Name.Format());

        public FS.FolderPath ProjectData(IProjectWs project, string suffix)
            => ProjectData() + FS.folder(string.Format("{0}.{1}", project.Name, suffix));

        public FileCatalog EmitCatalog(IProjectWs project)
        {
            var catalog = project.FileCatalog();
            EmitCatalog(project,catalog);
            return catalog;
        }

        void EmitCatalog(IProjectWs project, FileCatalog catalog)
        {
            var entries = catalog.Entries();
            TableEmit(entries.View, FileRef.RenderWidths, ProjectDb.ProjectTable<FileRef>(project));
        }

        public void EmitCatalog(CollectionContext context)
        {
            EmitCatalog(context.Project, context.Files);
        }

        public FileKind Match(FS.FilePath src)
        {
            var name = src.FileName.Format().ToLower();
            var kind = FileKind.None;
            foreach(var expr in FileKindMatch)
            {
                if(name.EndsWith(expr.Key))
                {
                    kind = expr.Value;
                    break;
                }
            }
            return kind;
        }

        public Pairings<FS.FilePath,FileKind> Match(ReadOnlySpan<FS.FilePath> src)
        {
            var count = src.Length;
            var dst = alloc<Paired<FS.FilePath,FileKind>>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                seek(dst,i) = (path, Match(path));
            }
            return dst;
        }

        public FS.Files SourceFiles(IProjectWs ws, Subject? scope)
        {
            if(scope != null)
                return ws.SrcFiles(scope.Value.Format());
            else
                return ws.SrcFiles();
        }

        public Outcome RunScript(IProjectWs ws, CmdArgs args, ScriptId script, Subject? scope = null)
        {
            var result = Outcome.Success;
            if(args.Count != 0)
            {
                result = OmniScript.RunProjectScript(ws.Project, arg(args,0).Value, script, false, out _);
                return result;
            }

            var src = SourceFiles(ws, scope).View;
            if(result.Fail)
                return result;

            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref skip(src,i);
                RunProjectScript(ws,path,script);
            }

            return result;
        }

        public ReadOnlySpan<CmdResponse> ParseCmdResponse(ReadOnlySpan<TextLine> src)
            => CmdResponse.parse(src);

        public Outcome RunProjectScript(IProjectWs project, FS.FilePath path, ScriptId script)
        {
            var srcid = path.FileName.WithoutExtension.Format();
            OmniScript.RunProjectScript(project.Project, srcid, script, true, out var flows);
            for(var j=0; j<flows.Length; j++)
            {
                ref readonly var flow = ref skip(flows, j);
                Write(flow.Format());
            }
            return true;
        }

        FS.FilePath FlowLogPath(IProjectWs project, ScriptId scriptid)
            => ProjectDb.ProjectData(project,"logs") + Tables.filename<ToolCmdFlow>(scriptid);

        public Outcome<Index<ToolCmdFlow>> RunScript(IProjectWs project, ScriptId scriptid, bool runexe = true, Action<ToolCmdFlow> receiver = null)
        {
            var result = OmniScript.RunProjectScript(project.Project, scriptid, true, out var flows);
            if(result)
            {
                var exeflow = default(ToolCmdFlow?);
                var count = flows.Length;
                if(count != 0)
                {
                    var data = alloc<ToolCmdFlow>(count);
                    for(var j=0; j<count; j++)
                    {
                        ref readonly var flow = ref skip(flows,j);
                        seek(data,j) = flow;
                        Status(flow.Format());
                        receiver?.Invoke(flow);
                        if(flow.TargetPath.FileName.Is(FS.Exe))
                            exeflow = flow;
                    }


                    TableEmit(@readonly(data), ToolCmdFlow.RenderWidths, FlowLogPath(project,scriptid));

                    if(runexe && exeflow != null)
                        RunExe(exeflow.Value);

                    return (true, data);
                }
                else
                    return true;
            }
            else
                return result;

        }

        public Outcome<Index<ToolCmdFlow>> RunScripts(IProjectWs project, ScriptId scriptid, Subject? scope, Action<ToolCmdFlow> receiver = null)
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
                var dst = ProjectDb.Logs() + FS.folder("flows") + Tables.filename<ToolCmdFlow>(scriptid);
                Index<ToolCmdFlow> records = cmdflows.ToArray();
                TableEmit(records.View, ToolCmdFlow.RenderWidths, dst);
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

        void RunExe(ToolCmdFlow flow)
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

        public void HandleBuildResponse(ToolCmdFlow flow, bool runexe)
        {
            if(flow.TargetPath.FileName.Is(FS.Exe) && runexe)
                RunExe(flow);
        }

        public Index<SymInfo> EmitTokens(IProjectWs project, ITokenSet src)
        {
            var records = Symbols.syminfo(src.Types());
            var dst = project.TablePath<SymInfo>("tokens", src.Name);
            TableEmit(records.View, SymInfo.RenderWidths, dst);
            return records;
        }

        public Outcome EmitToolCatalog()
        {
            var subdirs = Tools.Root.SubDirs();
            var counter = 0u;
            var formatter = Tables.formatter<ToolConfig>();
            var dst = Tools.Inventory();
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            foreach(var dir in subdirs)
            {
                var configCmd = dir + FS.file(WsAtoms.config, FS.Cmd);
                if(configCmd.Exists)
                {
                    var config =  dir + FS.folder(WsAtoms.logs) + FS.file(WsAtoms.config, FS.Log);
                    if(config.Exists)
                    {
                        var result = Tooling.parse(config.ReadText(), out var c);
                        if(result.Fail)
                        {
                            Error(string.Format("{0}:{1}", config.ToUri(), result.Message));
                            continue;
                        }

                        var settings = formatter.Format(c,RecordFormatKind.KeyValuePairs);
                        var title = string.Format("# {0}", c.ToolId);
                        var sep = string.Format("# {0}", RP.PageBreak80);

                        Write(title, FlairKind.Status);
                        Write(sep);
                        Write(settings);
                        writer.WriteLine(title);
                        writer.WriteLine(sep);
                        writer.WriteLine(settings);
                        counter++;
                    }
                }
            }

            EmittedFile(emitting, counter);
            return true;
        }
    }
}