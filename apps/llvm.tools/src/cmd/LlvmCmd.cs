//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;

    using static core;

    using static LlvmNames;

    public sealed partial class LlvmCmd : AppCmdService<LlvmCmd,CmdShellState>
    {
        LlvmEtl LlvmEtl;

        LlvmToolset Toolset;

        LlvmPaths LlvmPaths;

        LlvmProjectCollector ProjectCollector;

        LlvmRepo LlvmRepo;

        ToolId SelectedTool;

        LlvmReadObj ReadObj;

        LlvmDataProvider DataProvider;

        LlvmDataEmitter DataEmitter;

        LlvmMc Mc;

        LlvmCodeGen CodeGen;

        IProjectWs Data;

        public LlvmCmd()
        {
            SelectedTool = ToolId.Empty;
        }

        protected override void Initialized()
        {
            LlvmPaths = Wf.LlvmPaths();
            LlvmEtl = Wf.LlvmRecordEtl();
            ProjectCollector = Wf.LlvmProjectCollector();
            Toolset = Wf.LLvmToolset();
            ReadObj = Wf.LlvmReadObj();
            LlvmRepo = Wf.LlvmRepo();
            DataProvider = Wf.LlvmDataProvider();
            Mc = Wf.LlvmMc();
            CodeGen = Wf.LlvmCodeGen();
            Data = Ws.Project(Projects.LlvmData);
            DataEmitter = Wf.LlvmDataEmitter();
            State.Init(Wf, Ws);
            State.Project(Data);
        }

        Outcome ObjDump(FS.FilePath src, FS.FolderPath dst)
        {
            var tool = LlvmNames.Tools.llvm_objdump;
            var cmd = Cmd.cmdline(Ws.Tools().Script(tool, "run").Format(PathSeparator.BS));
            var vars = WsVars.create();
            vars.DstDir = dst;
            vars.SrcDir = src.FolderPath;
            vars.SrcFile = src.FileName;
            var result = OmniScript.Run(cmd, vars.ToCmdVars(), out var response);
            if(result)
            {
               var items = ParseCmdResponse(response);
               iter(items, item => Write(item));
            }
            return result;
        }

        Outcome Flow(FS.Files src)
        {
            Files(src);
            return true;
        }

        Outcome Flow(string query, FS.Files src)
        {
            Files(src);

            DataEmitter.EmitQueryResults(query, @readonly(src.View.Map(x => x.ToUri())));
            return true;
        }

        Outcome Flow<T>(string query, string args, ReadOnlySpan<T> src)
        {
            DataEmitter.EmitQueryResults(query, args, src);
            return true;
        }

        Outcome Flow<T>(string query, ReadOnlySpan<T> src)
        {
            DataEmitter.EmitQueryResults(query, src);
            return true;
        }

        Outcome Flow<T>(string query, T[] src)
        {
            DataEmitter.EmitQueryResults(query, @readonly(src));
            return true;
        }

        Outcome Flow<T>(string query, Index<T> src)
        {
            DataEmitter.EmitQueryResults(query, src.View);
            return true;
        }
    }
}