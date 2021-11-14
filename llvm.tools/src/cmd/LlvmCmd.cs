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
        LlvmRecordEtl RecordEtl;

        LlvmToolbase Toolbase;

        LlvmPaths LlvmPaths;

        LlvmProjectEtl ProjectEtl;

        LlvmRepo LlvmRepo;

        ToolId SelectedTool;

        new LlvmDb Db
        {
            get
            {
                if(_Db == null)
                    _Db = Wf.LlvmDb();
                return _Db;
            }
        }

        LlvmDb _Db;

        IProjectWs Data;

        public LlvmCmd()
        {
            SelectedTool = ToolId.Empty;
        }

        protected override void Initialized()
        {
            LlvmPaths = Wf.LlvmPaths();
            RecordEtl = Wf.LlvmRecordEtl();
            ProjectEtl = Wf.LlvmProjectEtl();
            Toolbase = Wf.LLvmToolbase();
            LlvmRepo = Wf.LlvmRepo();
            Data = Ws.Project(Projects.LlvmData);
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

        Outcome Flow<T>(ReadOnlySpan<T> src)
        {
            iteri(src, (i,item) => Write(string.Format("{0:D5} {1}", i, item)));
            return true;
        }

        Outcome Flow<T>(Label kind, ReadOnlySpan<T> src)
        {
            iteri(src, (i,item) => Write(string.Format("{0:D5} {1}", i, item)));
            return true;
        }

        Outcome Flow<T>(Label kind, Span<T> src)
        {
            iteri(src, (i,item) => Write(string.Format("{0:D5} {1}", i, item)));
            return true;
        }

        Outcome Flow<T>(Span<T> src)
        {
            iteri(src, (i,item) => Write(string.Format("{0:D5} {1}", i, item)));
            return true;
        }
    }
}