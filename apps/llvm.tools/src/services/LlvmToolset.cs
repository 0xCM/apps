//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.llvm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public class LlvmToolset : AppService<LlvmToolset>
    {
        OmniScript OmniScript;

        FS.FolderPath ToolsetDir;

        FS.FolderPath HelpDir;

        ConstLookup<ToolId,FS.FilePath> HelpFiles;

        ConstLookup<ToolId,ToolProfile> ToolProfiles;

        ConstLookup<ToolId,ToolHelpDoc> ToolHelpDocs;

        Toolset Toolset;

        public LlvmToolset()
        {
            Toolset = Toolset.Empty;
            ToolsetDir = FS.FolderPath.Empty;
        }

        protected override void Initialized()
        {
            OmniScript = Wf.OmniScript();
            ToolsetDir = Ws.Project("llvm.tools").Home();
            HelpDir = ToolsetDir + FS.folder("help");
            LoadProfiles();
            LoadToolset();
            CalcHelpPaths();
            InitHelpDocs();
        }

        void InitHelpDocs()
        {
            var dst = lookup<ToolId,ToolHelpDoc>();
            var src = HelpFiles.Entries;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var entry = ref skip(src,i);
                dst.Include(entry.Key, new ToolHelpDoc(entry.Value));
            }
            ToolHelpDocs = dst.Seal();
        }

        public ReadOnlySpan<ToolProfile> Profiles()
            => ToolProfiles.Values;

        public ToolHelpDoc ToolHelp(ToolId tool)
        {
            if(ToolHelpDocs.Find(tool, out var doc))
                return doc.Load();
            else
                return ToolHelpDoc.Empty;
        }

        public ReadOnlySpan<ToolId> Tools()
            => ToolProfiles.Keys;

        void CalcHelpPaths()
        {
            var dst = lookup<ToolId,FS.FilePath>();
            var src = ToolProfiles.Values;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var profile = ref skip(src,i);
                ref readonly var tool = ref profile.Id;
                if(profile.HelpCmd.IsEmpty)
                    continue;

                dst.Include(tool, HelpDir + FS.file(tool.Format(), FS.Help));
            }

            HelpFiles = dst.Seal();
        }

        public Outcome EmitHelpDocs()
        {
            var result = Outcome.Success;
            var src = ToolProfiles.Values;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var profile = ref skip(src,i);
                ref readonly var tool = ref profile.Id;
                if(profile.HelpCmd.IsEmpty)
                    continue;

                var cmdline = Cmd.cmdline(string.Format("{0} {1}", profile.Path.Format(PathSeparator.BS), profile.HelpCmd));
                Write(string.Format("Executing '{0}'", cmdline.Format()));
                result = OmniScript.Run(cmdline, CmdVars.Empty, out var response);
                if(result.Fail)
                    return result;

                if(HelpFiles.Find(tool, out var path))
                {
                    var length = response.Length;
                    var emitting = EmittingFile(path);
                    using var writer = path.UnicodeWriter();
                    for(var j=0; j<length; j++)
                        writer.WriteLine(skip(response, j).Content);
                    EmittedFile(emitting,length);
                }
                else
                    Warn(string.Format("{0} has no help path", tool));
            }

            return result;
        }

        Outcome InitializeProfiles(FS.FolderPath spec, FS.FilePath config, ToolId set)
        {
            var profiles = list<ToolProfile>();
            var result = LoadToolset();
            if(result.Fail)
                return result;
            var tools = Toolset.Deployments.View;
            var count = tools.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var tool = ref skip(tools,i);
                if(!tool.Path.Exists)
                    Error(string.Format("{0} unverified", tool));
                else
                {
                    var profile = new ToolProfile();
                    profile.Id = tool.Id;
                    profile.Path = tool.Path;
                    profile.HelpCmd = "--help";
                    profile.Memberhisp = set;
                    profiles.Add(profile);
                }
            }
            var dst = ToolsetDir + Tables.filename<ToolProfile>();
            var final = profiles.ViewDeposited();
            TableEmit(final, ToolProfile.RenderWidths, dst);
            return result;
        }

        Outcome Init()
        {
            var result = Outcome.Success;
            var config = ToolsetDir + FS.file("toolset", FS.Settings);

            var profilepath = ToolsetDir + Tables.filename<ToolProfile>();
            if(!profilepath.Exists)
                InitializeProfiles(ToolsetDir, config, "llvm");

            return LoadProfiles();
        }

        Outcome LoadProfiles()
        {
            var src = Tables.path<ToolProfile>(ToolsetDir);
            var content = src.ReadUnicode();
            var result = TextGrids.parse(content, out var grid);
            var dst = new Lookup<ToolId,ToolProfile>();
            if(result)
            {
                if(grid.ColCount != ToolProfile.FieldCount)
                    result = (false,Tables.FieldCountMismatch.Format(ToolProfile.FieldCount, grid.ColCount));
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

            ToolProfiles = dst.Seal();

            return result;
        }

        static Outcome parse(in TextRow src, out ToolProfile dst)
        {
            var result = Outcome.Success;
            dst = default;
            if(src.CellCount != ToolProfile.FieldCount)
                result = (false,Tables.FieldCountMismatch.Format(ToolProfile.FieldCount, src.CellCount));
            else
            {
                var i=0;
                dst.Id = src[i++].Text;
                dst.HelpCmd = src[i++].Text;
                dst.Memberhisp = src[i++].Text;
                dst.Path = FS.path(src[i++]);
            }
            return result;
        }

        Outcome LoadToolset()
        {
            var @base = FS.FolderPath.Empty;
            var members = Index<ToolId>.Empty;
            var config = ToolsetDir + FS.file("toolset", FS.Settings);
            if(!config.Exists)
                return (false, FS.missing(config));

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

            if(@base.IsNonEmpty && members.IsNonEmpty)
                Toolset = new Toolset(@base, ToolProfiles.Values.ToArray());

            return Toolset.IsNonEmpty;
        }
    }
}