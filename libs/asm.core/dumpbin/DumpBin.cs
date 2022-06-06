//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public partial class DumpBin : ToolService<DumpBin>
    {
        public Identifier ScriptId(CmdId cmd, FS.FileExt ext)
            => string.Format("{0}.{1}.{2}", Id, ext.Name, CmdSymbols[cmd].Expr);

        public DumpBinProcessor AsmProcessor()
            => DumpBinProcessor.create(Wf);

        public Outcome ParseRawData(FS.FilePath src)
        {
            const string Marker = "RAW DATA #";
            var result = Outcome.Success;
            var block = 0u;
            var offset = Hex32.Zero;
            var data = BinaryCode.Empty;
            var parsing = false;
            var records = list<HexCsvRow>();
            var formatter = Tables.formatter<HexCsvRow>(16);
            using var reader = src.LineReader(TextEncodingKind.Asci);
            while(reader.Next(out var line))
            {
                var content = line.Content;
                if(parsing)
                {
                    if(line.IsEmpty)
                    {
                        if(records.Count != 0)
                        {
                            iter(records, r => Write(formatter.Format(r)));
                            records.Clear();
                        }
                        parsing = false;
                    }
                    else
                    {
                        var i = text.index(content, Chars.Colon);
                        if(i<0)
                            return (false, "Unexpected content");

                        result = DataParser.parse(text.left(content,i), out offset);
                        if(result.Fail)
                            return (false, "Unable to parse offset");

                        result = DataParser.parse(text.right(content,i), out data);
                        if(result.Fail)
                            return result;
                    }
                }
                else
                {
                    var i = text.index(content,Marker);
                    if(i>0)
                    {
                        result = DataParser.parse(text.right(content,i), out block);
                        if(result.Fail)
                            return (false, "Unable to parse block number");
                        parsing = true;
                    }
                }
            }
            return result;
        }

        public Outcome DumpModules(IProjectWs project, FileModuleKind kind)
        {
            var result = Outcome.Success;
            var script = kind switch{
                FileModuleKind.Obj => "dump-obj",
                FileModuleKind.Exe => "dump-exe",
                FileModuleKind.Lib => "dump-lib",
                FileModuleKind.Dll => "dump-dll",
                _ => EmptyString
            };

            var ext = kind switch{
                FileModuleKind.Obj => FS.Obj,
                FileModuleKind.Exe => FS.Exe,
                FileModuleKind.Lib => FS.Lib,
                FileModuleKind.Dll => FS.Dll,
                _ => FS.FileExt.Empty
            };

            if(empty(script))
                return (false, string.Format("{0} not supported", kind));

            var outdir = ProjectDb.ProjectData();
            var cmd = Cmd.cmdline(Ws.Tools().Script(dumpbin, script).Format(PathSeparator.BS));
            var input = project.Files(ext);
            var count = input.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var path = ref input[i];
                var vars = WsVars.create();
                vars.DstDir = outdir;
                vars.SrcDir = path.FolderPath;
                vars.SrcFile = path.FileName;
                result = OmniScript.RunCmd(cmd, vars.ToCmdVars(), out _);
            }
            return result;
        }

        public Index<FS.FilePath> EmitScripts(FS.FolderPath src, FS.FolderPath dst)
        {
            var paths = list<FS.FilePath>();
            var archive = FileArchives.modules(src);
            var exe = archive.NativeExe();
            var lib = archive.Lib();
            var dll = archive.NativeDll();
            var obj = archive.Obj();
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

        FS.FilePath EmitScript<T>(CmdId cmd, Index<T> src, FS.FileExt ext, FS.FolderPath dst)
            where T : IFileModule
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
            :base(dumpbin)
        {
            Args =  alloc<ToolCmdArg<Flag,object>>(MaxVarCount);
            ArgIndex = 0;
            CmdSymbols = Symbols.index<CmdId>();
        }
    }
}