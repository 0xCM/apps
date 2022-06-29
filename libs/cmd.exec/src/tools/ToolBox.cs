//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    [ApiHost]
    public class ToolBox : WfSvc<ToolBox>
    {
        public static Settings config(FS.FilePath src)
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
            return new Settings(dst.ToArray());
        }

        const byte FieldCount = ToolProfile.FieldCount;

        ToolWs ToolWs => new ToolWs(AppDb.Toolbase());

        OmniScript OmniScript => Wf.OmniScript();

        public Index<ToolCmdLine> BuildHelpCommands(FS.FolderPath src)
        {
            var profiles = LoadProfileLookup(src).Values;
            var count = profiles.Length;
            var dst = list<ToolCmdLine>();
            for(var i=0; i<count; i++)
            {
                ref readonly var profile = ref skip(profiles,i);
                ref readonly var tool = ref profile.Id;
                if(profile.HelpCmd.IsEmpty)
                    continue;
                dst.Add(ToolCmd.cmdline(tool, string.Format("{0} {1}", profile.Path.Format(PathSeparator.BS), profile.HelpCmd)));
            }
            dst.Sort();
            return dst.ToArray();
        }

        public ConstLookup<ToolId,FS.FilePath> CalcHelpPaths(FS.FolderPath src)
        {
            var dst = new Lookup<ToolId,FS.FilePath>();
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

        public ConstLookup<ToolId,ToolProfile> InferProfiles(FS.FolderPath src)
        {
            var @base = FS.FolderPath.Empty;
            var members = Index<ToolId>.Empty;
            var config = src + FS.file("toolset", FS.Settings);
            if(!config.Exists)
            {
                Error(FS.missing(config));
                return dict<ToolId,ToolProfile>();
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

        public FS.FilePath ToolPath(FS.FolderPath root, ToolId tool)
        {
            if(LoadProfileLookup(root).Find(tool, out var profile))
                return profile.Path;
            else
                return FS.FilePath.Empty;
        }

        public ReadOnlySpan<string> Configure(ToolId tool)
        {
            var script = ToolWs.ConfigScript(tool);
            var result = OmniScript.Run(script, out _);
            return ToolWs.ConfigPath(tool).ReadLines();
        }

        public Outcome RunScript(ToolId tool, string name)
        {
            var path = ToolWs.Script(tool, name);
            if(!path.Exists)
                return (false, FS.missing(path));
            else
                return OmniScript.Run(path, out var _);
        }

        public void EmitIncludePaths()
        {
            var result = Outcome.Success;
            var settings = LoadEnv();
            var env = EnvDb.tools(settings);
            var dst = ProjectDb.Log("env", FS.Log);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            var headers = env.HeaderIncludes();
            writer.WriteLine("Header Includes");
            writer.WriteLine(RP.PageBreak120);
            headers.Iter(h => writer.WriteLine(string.Format("{0,-8} {1,-8} {2}", "Header", h.Exists ? "Found" : "Mising", h)));
            writer.WriteLine();

            var libs = env.LibIncludes();
            writer.WriteLine("Lib Includes");
            writer.WriteLine(RP.PageBreak120);
            libs.Iter(lib => writer.WriteLine(string.Format("{0,-8} {1,-8} {2}", "Lib", lib.Exists ? "Found" : "Mising", lib)));

            EmittedFile(emitting, 2);
        }

        public Settings LoadConfig(ToolId tool)
        {
            var dst = Settings.Empty;
            var src = ToolWs.ConfigPath(tool);
            if(src.Exists)
                dst = config(src);
            return dst;
        }

        public Index<string> LoadDocs(ToolId tool)
        {
            var src = ToolWs.ToolDocs(tool);
            var dst = bag<string>();
            iter(src.TopFiles, file => dst.Add(file.ReadText()));
            return dst.ToIndex();
        }

        public Settings UpdateEnv()
        {
            var path = ToolWs.ToolBox.Path(FS.file("show-env-config", FS.Cmd));
            var cmd = CmdScripts.cmdline(path.Format(PathSeparator.BS));
            return Settings.parse(OmniScript.RunCmd(cmd));
        }

        public Settings LoadEnv()
        {
            var path = ToolWs.ToolBox.Path(FS.file("tools", FileKind.Env));
            return Settings.parse(path.ReadNumberedLines());
        }

        // public Outcome EmitCatalog()
        // {
        //     var subdirs = ToolWs.Root.SubDirs();
        //     var counter = 0u;
        //     var formatter = Tables.formatter<ToolConfig>(16,RecordFormatKind.KeyValuePairs);
        //     var dst = ToolWs.Inventory();
        //     var emitting = EmittingFile(dst);
        //     using var writer = dst.AsciWriter();
        //     foreach(var dir in subdirs)
        //     {
        //         var configCmd = dir + FS.file(WsAtoms.config, FS.Cmd);
        //         if(configCmd.Exists)
        //         {
        //             var config =  dir + FS.folder(WsAtoms.logs) + FS.file(WsAtoms.config, FS.Log);
        //             if(config.Exists)
        //             {
        //                 var result = ToolWs.parse(config.ReadText(), out var c);
        //                 if(result.Fail)
        //                 {
        //                     Error(string.Format("{0}:{1}", config.ToUri(), result.Message));
        //                     continue;
        //                 }

        //                 var settings = formatter.Format(c);
        //                 var title = string.Format("# {0}", c.ToolId);
        //                 var sep = string.Format("# {0}", RP.PageBreak80);

        //                 Write(title, FlairKind.Status);
        //                 Write(sep);
        //                 Write(settings);
        //                 writer.WriteLine(title);
        //                 writer.WriteLine(sep);
        //                 writer.WriteLine(settings);
        //                 counter++;
        //             }
        //         }
        //     }

        //     EmittedFile(emitting, counter);
        //     return true;
        // }

        void LoadProfiles(FS.FilePath src, Lookup<ToolId,ToolProfile> dst)
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

        public ConstLookup<ToolId,ToolProfile> LoadProfileLookup(FS.FolderPath dir)
        {
            var running = Running(string.Format("Loading tool profiles from {0}", dir));
            var sources = dir.Match("tool.profiles", FS.Csv, true);
            var dst = new Lookup<ToolId,ToolProfile>();
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