//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using Asm;

    using static Root;
    using static core;

    public partial class CodeGenProvider : AppCmdProvider<CodeGenProvider>
    {
        Generators Generators => Service(Wf.Generators);

        IntelSdm Sdm => Service(Wf.IntelSdm);

        [CmdOp(".matcher")]
        Outcome Matcher(CmdArgs args)
        {
            var opcodes = Sdm.LoadImportedOpCodes();
            var matcher = StringMatcher.build(opcodes.Select(x => x.Expr.Format()));
            var dst = ProjectDb.Settings() + Tables.filename<CharMatchRow>();
            EmitTable(matcher,dst);
            return true;
        }

        Index<CharMatchRow> EmitTable(StringMatcher src, FS.FilePath dst)
        {
            var entries = src.Entries;
            var chars = src.CharCounts.Chars.ToArray().Sort();
            var positions = src.CharPositions;
            var lengths = src.Lengths.Distinct().Sort();
            var points = Intervals.points(Intervals.closed(z16, src.MaxLength));
            var buffer = list<CharMatchRow>();
            var counter = 0u;
            for(var j=0; j<chars.Length; j++)
            {
                ref readonly var c = ref skip(chars,j);
                for(var k=z16; k<points.Length; k++)
                {
                    var targets = positions.Targets(c,k);
                    for(var i=0; i<targets.Length; i++)
                    {
                        var target = skip(targets,i);
                        var entry = src[target];
                        var row = default(CharMatchRow);
                        row.Char = c;
                        row.Pos = k;
                        row.TargetLength = entry.Length;
                        row.TargetId = entry.Key;
                        row.Target = entry.Target;
                        buffer.Add(row);
                    }
                }
            }

            var data = buffer.ToArray().Sort();
            var count = data.Length;
            for(var i=0u; i<count; i++)
                seek(data,i).Seq = i;
            TableEmit(@readonly(data), CharMatchRow.RenderWidths, dst);
            return data;
        }
    }
}