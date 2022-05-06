//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedGrids;
    using static Markdown;
    using static core;

    partial class XedDb
    {
    }

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/grids")]
        Outcome EmitGrids(CmdArgs args)
        {
            XedDb.EmitGrids(CalcRuleCells());
            return true;
        }

        [CmdOp("xed/check/rules")]
        Outcome CheckRules(CmdArgs args)
        {
            var rules = CalcRuleCells();
            var dst = dict<Coordinate,FieldKind>();
            var tables = rules.Tables;
            for(var i=0; i<tables.Count; i++)
            {
                ref readonly var table = ref rules[i];
                var rows = table.Rows;
                for(var j=0; j<rows.Count; j++)
                {
                    ref readonly var row = ref table[j];
                    var cells = row.Cells;
                    for(var k=0; k<cells.Count; k++)
                    {
                        ref readonly var cell = ref cells[k];
                        dst.Add(cell.Location, cell.Field);
                    }
                }
            }

            var pairs = dst.Pairings();
            var count = pairs.Count;
            var located = alloc<LocatedField>(count);
            for(var i=0; i<count; i++)
            {
                ref readonly var pair = ref pairs[i];
                ref readonly var c = ref pair.Left;
                ref readonly var f = ref pair.Right;
                seek(located, i) = pair;
            }

            var path = XedPaths.DbTarget("rules.fields.points", FileKind.Csv);

            const string RenderPattern = "{0,-6} | {1,-18} | {2,-4} | {3,-26}";
            var header = string.Format(RenderPattern, "Seq", "Point",  "Code", "Field");
            var emitter = text.emitter();
            emitter.AppendLine(header);
            for(var i=0;i<located.Length; i++)
            {
                ref readonly var point = ref skip(located,i);
                emitter.AppendLineFormat("{0,-6} | {1}", i, point.Format());
            }

            FileEmit(emitter.Emit(), located.Length, path, TextEncodingKind.Asci);


            return true;
        }

        SectionHeader header(RuleCaller target)
        {
            var rule = target.ToRule();
            return new(3,rule.Format());
        }

        void Emit(Index<NontermCall> calls)
        {
            var dst = text.buffer();
            var source = RuleCaller.Empty;
            for(var i=0; i<calls.Count; i++)
            {
                ref readonly var call = ref calls[i];
                if(source.IsEmpty)
                {
                    source = call.Source;
                    dst.AppendLine(header(source));
                    dst.AppendLine();
                }

                if(source != call.Source)
                {
                    dst.AppendLine();
                    source = call.Source;
                    dst.AppendLine(header(source));
                    dst.AppendLine();
                }

                dst.AppendLine(XedPaths.MarkdownLink(call.Target));
            }

            FileEmit(dst.Emit(), calls.Count, XedPaths.DbTarget("rules.tables.deps", FileKind.Md));
        }

        [CmdOp("xed/check/rules/names")]
        Outcome CheckRuleNames(CmdArgs args)
        {
            const uint RuleCount = RuleNames.MaxCount;

            var src = Symbols.index<RuleName>();

            var names = src.Kinds;
            for(var i=0; i<names.Length; i++)
            {
                var name = names[i];
                if((ushort)name != i)
                {
                    return (false,$"{name}");
                }
            }
            Require.equal(RuleCount, (uint)names.Length);

            var dst = RuleNames.init(names);
            var buffer = alloc<RuleName>(RuleCount);
            var count = Require.equal(dst.Members(buffer), (uint)names.Length);

            for(var i=0; i<count; i++)
            {
                ref readonly var name = ref skip(names,i);
                if(!dst.Contains(name))
                    Errors.Throw($"{name} is missing");
            }

            var smaller = slice(names,100,150);
            dst.Clear();
            dst.Include(smaller);
            for(var i=0; i<RuleNames.MaxCount; i++)
            {
                var min = skip(smaller,0);
                var max = skip(smaller,smaller.Length - 1);
                var kind = (RuleName)i;
                if(kind != 0)
                {
                    if(kind >= min & kind<= max)
                        Require.invariant(dst.Contains(kind));
                    else
                        Require.invariant(!dst.Contains(kind));
                }
            }

            return true;
        }
    }
}