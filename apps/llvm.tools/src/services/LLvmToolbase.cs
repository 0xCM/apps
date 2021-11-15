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

    public class LlvmToolbase : AppService<LlvmToolbase>
    {
        OmniScript OmniScript;

        protected override void Initialized()
        {
            OmniScript = Wf.OmniScript();
        }

        Outcome InitializeProfiles(FS.FolderPath spec, FS.FilePath config, ToolId set)
        {
            var profiles = list<ToolProfile>();
            var result = LoadToolset(config, out var toolset);
            var tools = toolset.Deployments.View;
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
            var dst = spec + Tables.filename<ToolProfile>();
            var final = profiles.ViewDeposited();
            TableEmit(final, ToolProfile.RenderWidths, dst);
            return result;
        }

        public Outcome Create(FS.FolderPath spec, FS.FolderPath toolbase)
        {
            var result = Outcome.Success;
            var config = spec + FS.file("llvm", FS.Settings);
            result = LoadToolset(config, out var toolset);
            if(result.Fail)
                return result;

            var profilepath = spec + Tables.filename<ToolProfile>();
            if(!profilepath.Exists)
                InitializeProfiles(spec,config, "llvm");

            return Load(LoadProfiles(profilepath), toolbase);
        }

        ReadOnlySpan<ToolProfile> LoadProfiles(FS.FilePath src)
        {
            var content = src.ReadUnicode();
            var result = TextGrids.parse(content, out var grid);
            var dst = list<ToolProfile>();
            if(result)
            {
                if(grid.ColCount != ToolProfile.FieldCount)
                {
                    result = (false,Tables.FieldCountMismatch.Format(ToolProfile.FieldCount, grid.ColCount));
                }
                var count = grid.RowCount;
                for(var i=0; i<count; i++)
                {
                    ref readonly var row = ref grid[i];
                    result = parse(row, out ToolProfile profile);
                    if(result)
                    {
                        dst.Add(profile);
                    }
                }
            }

            if(result.Fail)
                Error(result.Message);

            return dst.ViewDeposited();
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

        Outcome Load(ReadOnlySpan<ToolProfile> src, FS.FolderPath dst)
        {
            var result = Outcome.Success;
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var profile = ref skip(src,i);
                ref readonly var tool = ref profile.Id;
                var home = (dst + FS.folder(tool.Format())).Create();
                if(profile.HelpCmd.IsEmpty)
                    continue;

                var docs = (home + FS.folder("docs")).Create();
                var cmdline = Cmd.cmdline(string.Format("{0} {1}", profile.Path.Format(PathSeparator.BS), profile.HelpCmd));
                Write(string.Format("Executing '{0}'", cmdline.Format()));
                result = OmniScript.Run(cmdline, CmdVars.Empty, out var response);
                if(result.Fail)
                    return result;

                var length = response.Length;
                var path = docs + FS.file(tool.Format(),FS.Help);
                var emitting = EmittingFile(path);
                using var writer = path.UnicodeWriter();
                for(var j=0; j<length; j++)
                {
                    writer.WriteLine(skip(response, j).Content);
                }
                EmittedFile(emitting,length);
            }

            return result;
        }

        Outcome LoadToolset(FS.FilePath config, out Toolset dst)
        {
            var @base = FS.FolderPath.Empty;
            var members = Index<ToolId>.Empty;
            dst = Toolset.Empty;
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
                        {
                            @base = root;
                        }
                    }
                    else if(name == "Members")
                    {
                        var inventory = FS.path(value);
                        if(inventory.Exists)
                            members = inventory.ReadLines().Select(x => new ToolId(x));
                    }
                }
            }

            if(@base.IsNonEmpty && members.IsNonEmpty)
                dst = new Toolset(@base, members);

            return dst.IsNonEmpty;
        }
    }
}