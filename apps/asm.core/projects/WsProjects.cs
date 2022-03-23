//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using llvm;
    using Asm;

    using static core;
    using static llvm.SubtargetKind;
    using static XedDisasm;

    public class WsProjects : AppService<WsProjects>
    {
        public WsProjects()
        {
            var symbols = Symbols.index<FileKind>();
            var kinds = symbols.Kinds;
            FileKindMatch = symbols.View.Map(s => ("." + s.Expr.Format().ToLower(), s.Kind)).ToSortedDictionary(TextLengthComparer.create(true));
        }

        public Outcome<Index<ToolCmdFlow>> BuildAsm(IProjectWs project)
            => RunBuildScripts(project, "build", "asm", false);

        public Outcome<Index<ToolCmdFlow>> BuildLlc(IProjectWs project, SubtargetKind subtarget, bool runexe = false)
        {
            var result = Outcome.Success;
            var scriptid = subtarget switch
            {
                Sse => "llc-build-sse",
                Sse2 => "llc-build-sse2",
                Sse3 => "llc-build-sse3",
                Sse41 => "llc-build-sse41",
                Sse42 => "llc-build-sse42",
                Avx => "llc-build-avx",
                Avx2 => "llc-build-avx2",
                Avx512 => "llc-build-avx512",
                _ => EmptyString
            };

            return RunBuildScripts(project, scriptid, EmptyString,runexe);
        }

        FS.FolderPath ProjectData(IProjectWs project)
            => ProjectDb.ProjectData() + FS.folder(project.Name.Format());

        FS.FolderPath ProjectData(IProjectWs project, string scope)
            => ProjectData(project) + FS.folder(scope);

        FS.FilePath ProjectDataFile(IProjectWs project, FileKind kind)
            => ProjectData(project) + FS.file(project.Name.Format(), kind.Ext());

        FS.FilePath Table<T>(IProjectWs project, string scope)
            where T : struct
                => ProjectData(project, scope) + FS.file(string.Format("{0}.{1}", project.Name, TableId.identify<T>()),FS.Csv);

        FS.FilePath ScriptFlowPath(IProjectWs project, ScriptId scriptid)
            => ProjectData(project) + Tables.filename<ToolCmdFlow>(scriptid);

        public FS.FilePath Table<T>(IProjectWs project)
            where T : struct
                => ProjectDb.ProjectData() + FS.folder(project.Name.Format()) + FS.file(string.Format("{0}.{1}", project.Name, TableId.identify<T>()),FS.Csv);

        public FS.Files XedDisasmSources(IProjectWs project)
            => project.OutFiles(FileKind.XedRawDisasm);

        public FS.Files SynAsmSources(IProjectWs project)
            => project.OutFiles(FileKind.SynAsm);

        public FS.Files McAsmSources(IProjectWs project)
            => project.OutFiles(FileKind.McAsm);

        public FS.FolderPath ObjHexDir(IProjectWs project)
            => ProjectData(project, "obj.hex");

        public FS.FilePath AsmSyntaxTable(IProjectWs project)
            => Table<AsmSyntaxRow>(project);

        public FS.FilePath AsmInstructionTable(IProjectWs project)
            => Table<AsmInstructionRow>(project);

        public FS.FilePath AsmEncodingTable(IProjectWs project)
            => Table<AsmDisasmSummary>(project);

        public FS.FolderPath AsmCodeDir(IProjectWs project)
            => ProjectData(project, "asm.code");

        public FS.FilePath AsmCodePath(IProjectWs project, string origin)
            => AsmCodeDir(project) + FS.file(string.Format("{0}.code", origin), FS.Csv);

        public FS.FilePath ObjBlockPath(IProjectWs project)
            => Table<ObjBlock>(project);

        public FS.FilePath XedDisasmSummary(IProjectWs project)
            => ProjectDataFile(project, FileKind.XedSummaryDisasm);

        public FS.FolderPath XedDisasmDir(IProjectWs project)
            => ProjectData(project, "xed.disasm");

        public FS.FilePath BuildFlowPath(IProjectWs project)
            => ProjectData(project) + FS.file(string.Format("{0}.build.flows", project.Name), FS.Csv);

        public FS.FolderPath RecodedSrcDir(IProjectWs project)
            => Ws.Project(ProjectNames.McRecoded).SrcDir(project.Project.Format());

        public FS.FilePath CoffSymPath(IProjectWs project)
            => Table<CoffSymRecord>(project);

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

        public WsDataFlows LoadBuildFlowIndex(IProjectWs project)
            => WsDataFlows.create(FileCatalog.load(project), LoadBuildFlows(project));

        public WsContext Context(IProjectWs project, WsEventReceiver receiver = null)
            => WsContext.create(project, LoadBuildFlowIndex(project), receiver);

        public Outcome<Index<ToolCmdFlow>> BuildScoped(IProjectWs project, ScriptId script, string scope)
            => RunBuildScripts(project, script, scope, false);

        public Outcome<Index<ToolCmdFlow>> BuildC(IProjectWs project, bool runexe = false)
            => RunBuildScripts(project, "c-build", "c", runexe);

        public Outcome<Index<ToolCmdFlow>> BuildCpp(IProjectWs project, bool runexe = false)
            => RunBuildScripts(project, "cpp-build", "cpp", runexe);

        public FS.FolderPath CleanOutDir(IProjectWs project)
            => project.OutDir().Clear(true);

        void EmitCatalog(IProjectWs project, FileCatalog catalog)
            => TableEmit(catalog.Entries().View, FileRef.RenderWidths, ProjectDb.ProjectTable<FileRef>(project));

        public FileCatalog EmitCatalog(WsContext context)
        {
            var catalog = context.Catalog;
            EmitCatalog(context.Project, catalog);
            return catalog;
        }

        public FileCatalog EmitCatalog(IProjectWs project)
        {
            var catalog = project.FileCatalog();
            EmitCatalog(project, catalog);
            return catalog;
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

        Index<ToolCmdFlow> LoadBuildFlows(IProjectWs project)
        {
            const byte FieldCount = ToolCmdFlow.FieldCount;
            var lines = BuildFlowPath(project).ReadLines(TextEncodingKind.Asci,true);
            var buffer = alloc<ToolCmdFlow>(lines.Length - 1);
            var src = lines.Reader();
            src.Next(out _);
            var i = 0u;
            while(src.Next(out var line))
            {
                var cells = text.trim(text.split(line,Chars.Pipe));
                Require.equal(cells.Length,FieldCount);
                var reader = cells.Reader();
                ref var dst = ref seek(buffer,i++);
                DataParser.parse(reader.Next(), out dst.Tool).Require();
                DataParser.parse(reader.Next(), out dst.SourceName).Require();
                DataParser.parse(reader.Next(), out dst.TargetName).Require();
                DataParser.parse(reader.Next(), out dst.SourcePath).Require();
                DataParser.parse(reader.Next(), out dst.TargetPath).Require();
            }
            return buffer;
        }

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


                    TableEmit(@readonly(data), ToolCmdFlow.RenderWidths, ScriptFlowPath(project,scriptid));

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

        Outcome<Index<ToolCmdFlow>> RunBuildScripts(IProjectWs project, ScriptId scriptid, Subject? scope, bool runexe)
            => RunBuildScripts(project, scriptid, scope, flow => HandleBuildResponse(flow, runexe));

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
                TableEmit(records.View, ToolCmdFlow.RenderWidths, BuildFlowPath(project));
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