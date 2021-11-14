//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    [ApiHost]
    public partial class DumpBin : ToolService<DumpBin>
    {
        public Identifier ScriptId(CmdId cmd, FS.FileExt ext)
            => string.Format("{0}.{1}.{2}", Id, ext.Name, CmdSymbols[cmd].Expr);

        public DumpBinProcessor AsmProcessor()
            => DumpBinProcessor.create(Wf);

        public Index<FS.FilePath> EmitScripts(FS.FolderPath src, FS.FolderPath dst)
        {
            var paths = list<FS.FilePath>();
            var archive = ModuleArchive.create(src);
            var exe = archive.NativeExeFiles();
            var lib = archive.StaticLibs();
            var dll = archive.NativeDllFiles();
            var obj = archive.ObjFiles();
            var sid = Identifier.Empty;
            var cmd = DumpBin.CmdId.None;
            var ext = FS.FileExt.Empty;

            cmd = DumpBin.CmdId.EmitHeaders;
            paths.Add(EmitScript(cmd, dll, FS.Dll, dst));

            cmd = DumpBin.CmdId.EmitAsm;
            paths.Add(EmitScript(cmd, dll, FS.Dll, dst));

            cmd = DumpBin.CmdId.EmitRawData;
            paths.Add(EmitScript(cmd, dll,FS.Dll, dst));

            cmd = DumpBin.CmdId.EmitRelocations;
            paths.Add(EmitScript(cmd, dll, FS.Dll, dst));

            cmd = DumpBin.CmdId.EmitLoadConfig;
            paths.Add(EmitScript(cmd, dll, FS.Dll, dst));

            cmd = DumpBin.CmdId.EmitExports;
            paths.Add(EmitScript(cmd, dll, FS.Dll, dst));

            return paths.ToArray();
        }

        FS.FilePath EmitScript(CmdId cmd, FileModule[] src, FS.FileExt ext, FS.FolderPath dst)
        {
            var sid = ScriptId(cmd, ext);
            var script = Script(sid, cmd, src, dst);
            var path = dst + FS.file(script.Id.Format(), FS.Cmd);
            var emitting = Wf.EmittingFile(path);
            path.Overwrite(script.Format());
            Wf.EmittedFile(emitting,1);
            return path;
        }

        const byte MaxVarCount = 12;

        const byte MaxVarIndex = MaxVarCount - 1;

        uint ArgIndex;

        public ToolCmdArgs<Flag,object> Args {get;}

        Symbols<CmdId> CmdSymbols {get;}

        [MethodImpl(Inline)]
        public DumpBin()
            :base(Toolspace.dumpbin)
        {
            Args =  alloc<ToolCmdArg<Flag,object>>(MaxVarCount);
            ArgIndex = 0;
            CmdSymbols = Symbols.index<CmdId>();
        }
    }
}