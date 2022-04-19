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
    public partial class Tooling : AppService<Tooling>
    {
        const NumericKind Closure = UnsignedInts;

        const byte FieldCount = ToolProfile.FieldCount;

        protected override void Initialized()
        {

        }

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

        public ConstLookup<ToolId,ToolProfile> LoadProfiles(FS.FolderPath dir)
        {
            var running = Running(string.Format("Loading tool profiles from {0}", dir));
            var sources = dir.Files("tool.profiles", FS.Csv, true);
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