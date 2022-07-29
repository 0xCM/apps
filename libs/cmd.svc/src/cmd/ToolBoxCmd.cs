//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public class ToolBoxCmd : AppCmdService<ToolBoxCmd>
    {
        const byte FieldCount = ToolProfile.FieldCount;

        public IToolWs Workspace(Actor tool)
            => new ToolWs(AppDb.Toolbase().Sources(tool.Format()).Root);

        ToolWs Ws
            => new ToolWs(AppDb.Toolbase().Root);

        public FS.FilePath ScriptPath(Actor tool, string name, FileKind kind)
            => Workspace(tool).Script(name, kind);

        public Outcome Run(IToolWs tool, string name, FS.FilePath src, FS.FolderPath dst)
        {
            var cmd = new CmdLine(tool.Script(name, FileKind.Cmd).Format(PathSeparator.BS));
            var vars = WsCmdVars.create();
            vars.DstDir = dst;
            vars.SrcDir = src.FolderPath;
            vars.SrcFile = src.FileName;
            var result = OmniScript.Run(cmd, vars.ToCmdVars(), out var response);
            if(result)
            {
               var items = CmdResponse.parse(response);
               iter(items, item => Write(item));
            }
            return result;
        }

        public static SettingLookup config(FS.FilePath src)
        {
            var dst = list<Setting>();
            using var reader = src.LineReader(TextEncodingKind.Asci);
            while(reader.Next(out var line))
            {
                var content = span(line.Content);
                var length = content.Length;
                if(length != 0)
                {
                    if(SQ.hash(first(content)))
                        continue;

                    var i = SQ.index(content, Chars.Colon);
                    if(i > 0)
                    {
                        var name = text.format(SQ.left(content,i));
                        var value = text.format(SQ.right(content,i));
                        dst.Add(new Setting(name,value));
                    }
                }
            }
            return new SettingLookup(dst.ToArray());
        }

        [CmdOp("llvm/toolset")]
        void LlvmConfig(CmdArgs args)
        {
            // d:/views/llvm/llvm.config
            var path = FS.path(arg(args,0));
            var Lookup = Config(path);
            Lookup.Iter(setting => Write(setting.Format(Chars.Colon)));
        }

        public SettingLookup Config(FS.FilePath src)
            => ToolBoxSvc.config(src);

        public ConstLookup<ToolIdOld,ToolHelpDoc> LoadHelpDocs(IDbSources src)
        {
            var dst = dict<ToolIdOld,ToolHelpDoc>();
            var files = src.Files(FileKind.Help);
            iter(files, file =>{
                var fmt = file.FileName.Format();
                var i = text.index(fmt, Chars.Dot);
                if(i > 0)
                {
                    var tool = text.left(fmt,i);
                    dst.TryAdd(tool, new ToolHelpDoc(tool, file, file.ReadAsci()));
                }
            });
            return dst;
        }

        public Index<ToolHelpDoc> EmitHelp(IToolWs ws)
        {
            var result = Outcome.Success;
            var paths = CalcHelpPaths(ws.Home);
            var commands = BuildHelpCommands(ws);
            var count = commands.Length;
            var docs = list<ToolHelpDoc>();
            for(var i=0; i<count; i++)
            {
                ref readonly var cmd = ref commands[i];
                var tool = cmd.Tool;
                result = OmniScript.Run(cmd.Command, CmdVars.Empty, out var response);
                if(result.Fail)
                {
                    Error(result.Message);
                    continue;
                }

                Babble(string.Format("Executed '{0}'", cmd.Format()));

                if(paths.Find(tool, out var path))
                {
                    var length = response.Length;
                    var emitting = EmittingFile(path);
                    using var writer = path.UnicodeWriter();
                    for(var j=0; j<length; j++)
                        writer.WriteLine(skip(response, j).Content);
                    EmittedFile(emitting,length);

                    docs.Add(new ToolHelpDoc(tool,path));
                }
                else
                    Warn(string.Format("{0} has no help path", tool));
            }

            return docs.ToArray();
        }


        [CmdOp("tools/env")]
        void ShowToolEnv()
            => iter(LoadEnv(), s => Write(s));

        [CmdOp("tool/script")]
        Outcome ToolScript(CmdArgs args)
            => RunScript(arg(args,0).Value, arg(args,1).Value);

        [CmdOp("tool/setup")]
        void ConfigureTool(CmdArgs args)
            => iter(Setup(tool(args)), entry => Write(entry));

        static Actor tool(CmdArgs args, byte index = 0)
            => arg(args,index).Value;

        [CmdOp("tool/docs")]
        void ToolDocs(CmdArgs args)
            => iter(LoadDocs(arg(args,0).Value), doc => Write(doc));

        [CmdOp("tool/config")]
        void ToolConfig(CmdArgs args)
        {
            var tool = arg(args,0);
            var src = AppDb.Toolbase().Sources(tool).Path(tool, FileKind.Config);
            Write($"{tool}:{src.ToUri()}");
            var settings = config(src);
            var count = settings.Count;
            for(var i=0; i<count; i++)
            {
                ref readonly var setting = ref settings[i];
                Write($"{setting}");
            }
        }

        public Index<ToolCmdLine> BuildHelpCommands(IToolWs ws)
        {
            var profiles = LoadProfileLookup(ws.Home).Values;
            var count = profiles.Length;
            var dst = list<ToolCmdLine>();
            for(var i=0; i<count; i++)
            {
                ref readonly var profile = ref skip(profiles,i);
                ref readonly var tool = ref profile.Id;
                if(profile.HelpCmd.IsEmpty)
                    continue;
                dst.Add(CmdScripts.cmdline(ws, tool, string.Format("{0} {1}", profile.Path.Format(PathSeparator.BS), profile.HelpCmd)));
            }
            dst.Sort();
            return dst.ToArray();
        }

        public ConstLookup<Actor,FS.FilePath> CalcHelpPaths(FS.FolderPath src)
        {
            var dst = new Lookup<Actor,FS.FilePath>();
            var profiles = LoadProfileLookup(src).Values;
            var count = profiles.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var profile = ref skip(profiles,i);
                ref readonly var tool = ref profile.Id;
                if(profile.HelpCmd.IsEmpty)
                    continue;

                dst.Include(tool, src + FS.folder("help") + FS.file(tool.Format(), FS.Help));
            }

            return dst.Seal();
        }

        public ConstLookup<Actor,ToolProfile> InferProfiles(FS.FolderPath src)
        {
            var @base = FS.FolderPath.Empty;
            var members = Index<Actor>.Empty;
            var config = src + FS.file("toolset", FS.Settings);
            if(!config.Exists)
            {
                Error(FS.missing(config));
                return dict<Actor,ToolProfile>();
            }

            using var reader = config.Utf8LineReader();
            while(reader.Next(out var line))
            {
                ref readonly var content = ref line.Content;
                var i = text.index(content, Chars.Colon);
                if(i >=0)
                {
                    var name = text.left(content,i);
                    var value = text.right(content,i);
                    if(name == "InstallBase")
                    {
                        var root = FS.dir(value);
                        if(root.Exists)
                            @base = root;
                    }
                }
            }

            return LoadProfileLookup(src);
        }

        public FS.FilePath ToolPath(FS.FolderPath root, Tool tool)
        {
            if(LoadProfileLookup(root).Find(tool, out var profile))
                return profile.Path;
            else
                return FS.FilePath.Empty;
        }

        public ReadOnlySpan<string> Setup(Tool tool)
        {
            var script = Ws.ConfigScript(tool);
            var result = OmniScript.Run(script, out _);
            return Ws.ConfigPath(tool).ReadLines();
        }

        public Outcome RunScript(Actor tool, string name)
        {
            var path = Ws.Script(tool, name);
            if(!path.Exists)
                return (false, FS.missing(path));
            else
                return OmniScript.Run(path, out var _);
        }

        public void EmitIncludePaths()
        {
            var result = Outcome.Success;
            var settings = LoadEnv();
            var env = ToolEnv.load(settings);
            var dst = ProjectDb.Log("env", FS.Log);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            var headers = env.HeaderIncludes();
            writer.WriteLine("Header Includes");
            writer.WriteLine(RpOps.PageBreak120);
            headers.Iter(h => writer.WriteLine(string.Format("{0,-8} {1,-8} {2}", "Header", h.Exists ? "Found" : "Mising", h)));
            writer.WriteLine();

            var libs = env.LibIncludes();
            writer.WriteLine("Lib Includes");
            writer.WriteLine(RpOps.PageBreak120);
            libs.Iter(lib => writer.WriteLine(string.Format("{0,-8} {1,-8} {2}", "Lib", lib.Exists ? "Found" : "Mising", lib)));

            EmittedFile(emitting, 2);
        }

        public Index<string> LoadDocs(string tool)
        {
            var src = Ws.ToolDocs(tool);
            var dst = bag<string>();
            iter(src.TopFiles, file => dst.Add(file.ReadText()));
            return dst.ToIndex();
        }

        public SettingLookup LoadEnv()
        {
            var path = Ws.Home + FS.file("tools", FileKind.Env);
            return Settings.parse(path.ReadNumberedLines(), Chars.Colon);
        }

        void LoadProfiles(FS.FilePath src, Lookup<Actor,ToolProfile> dst)
        {
            var content = src.ReadUnicode();
            var result = TextGrids.parse(content, out var grid);
            if(result)
            {
                if(grid.ColCount != FieldCount)
                    Error(Tables.FieldCountMismatch.Format(FieldCount, grid.ColCount));
                else
                {
                    var count = grid.RowCount;
                    for(var i=0; i<count; i++)
                    {
                        result = parse(grid[i], out ToolProfile profile);
                        if(result)
                            dst.Include(profile.Id, profile);
                        else
                            break;
                    }
                }
            }
        }

        public ConstLookup<Actor,ToolProfile> LoadProfileLookup(FS.FolderPath dir)
        {
            var running = Running(string.Format("Loading tool profiles from {0}", dir));
            var sources = dir.Match("tool.profiles", FS.Csv, true);
            var dst = new Lookup<Actor,ToolProfile>();
            iter(sources, src => LoadProfiles(src,dst));
            var lookup = dst.Seal();
            Ran(running, string.Format("Collected {0} profile definitions", lookup.EntryCount));
            return lookup;
        }

        static Outcome parse(in TextRow src, out ToolProfile dst)
        {
            var result = Outcome.Success;
            dst = default;
            if(src.CellCount != FieldCount)
                result = (false,Tables.FieldCountMismatch.Format(FieldCount, src.CellCount));
            else
            {
                var i=0;
                dst.Id = src[i++].Text;
                dst.Modifier = src[i++].Text;
                dst.HelpCmd = src[i++].Text;
                dst.Memberhisp = src[i++].Text;
                dst.Path = FS.path(src[i++]);
            }
            return result;
        }
    }
}