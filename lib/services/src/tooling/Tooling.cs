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

    using SQ = SymbolicQuery;

    [ApiHost]
    public partial class Tooling : AppService<Tooling>
    {
        const NumericKind Closure = UnsignedInts;

        OmniScript OmniScript;

        protected override void Initialized()
        {
            OmniScript = Wf.OmniScript();

        }

        public ConstLookup<ToolId,ToolProfile> LoadProfiles(FS.FolderPath dir)
        {
            var src = Tables.path<ToolProfile>(dir);
            var content = src.ReadUnicode();
            var result = TextGrids.parse(content, out var grid);
            var dst = new Lookup<ToolId,ToolProfile>();
            if(result)
            {
                if(grid.ColCount != ToolProfile.FieldCount)
                    Error(Tables.FieldCountMismatch.Format(ToolProfile.FieldCount, grid.ColCount));
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

            return dst.Seal();
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


        public static ReadOnlySpan<CmdFlagSpec> flags(FS.FilePath src)
        {
            var k = z16;
            var dst = list<CmdFlagSpec>();
            using var reader = src.AsciLineReader();
            while(reader.Next(out var line))
            {
                var content = line.Codes;
                var i = SQ.index(content, AsciCode.Colon);
                var name = text.trim(text.format(SQ.left(content,i)));
                var desc = text.trim(text.format(SQ.right(content,i)));
                var flag = Cmd.flagspec(name, desc);
                dst.Add(flag);
            }
            return dst.ViewDeposited();
        }
    }
}