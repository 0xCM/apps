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

    partial class XedCmdProvider
    {
        [MethodImpl(Inline)]
        public static GridCell gcell(in RuleCell src)
        {
            var field = src.Field;
            var type = ColType.field(field);
            if(src.IsNontermCall)
            {
                type = ColType.nonterm(src.Value.AsNonterm());
            }
            else if(src.IsCellExpr)
            {
                var expr = src.Value.ToCellExpr();
                if(expr.IsNonterm)
                    type = ColType.expr(field, expr.Operator, expr.Value.ToRuleName());
                else
                    type = ColType.expr(field, expr.Operator);
            }

            return new GridCell(src.Key, type, src.Size, src.Value);
        }

        [CmdOp("xed/check/rules")]
        Outcome CheckRules(CmdArgs args)
        {
            var src = CalcRuleCells();
            var kGrid = src.TableCount;
            var grids = alloc<RuleGrid>(kGrid);
            var gt=0u;
            var gr=0u;
            var calls = hashset<NontermCall>();
            for(var i=0; i<kGrid; i++)
            {
                ref readonly var cTable = ref src[i];
                ref readonly var sig = ref cTable.Sig;
                var kCol = gcols(cTable);
                var kRow = cTable.RowCount;
                var kCells = kRow*kCol;
                var gRowCols = alloc<Index<GridCol>>(kRow);
                seek(grids,i) = grid(sig, (ushort)kRow, (byte)kCol, alloc<GridCell>(kCells));
                ref readonly var gCells = ref skip(grids,i).Cells;

                for(ushort j=0,gc=0; j<kRow; j++)
                {
                    ref readonly var cRow = ref cTable[j];
                    seek(gRowCols, j) = alloc<GridCol>(cRow.CellCount);

                    for(var k=0; k<cRow.CellCount; k++, gc++)
                    {
                        ref readonly var cell = ref cRow[k];
                        gCells[gc] = gcell(cell);
                        gRowCols[j][k] = col(gCells[gc]);

                        if(cell.IsNonterm)
                        {
                            var nt = Nonterminal.Empty;
                            if(cell.IsNontermCall)
                                nt = cell.Value.AsNonterm();
                            else if(cell.IsNontermExpr)
                                nt = cell.Value.ToCellExpr().Value.ToNonterm();
                            calls.Add(call(sig, new RuleSig(sig.TableKind, nt.Name)));
                        }
                    }
                }
            }

            Emit(calls.Array().Index().Sort());


            var dst = text.emitter();
            var counter = 0u;
            for(var i=0; i<kGrid; i++)
            {
                ref readonly var grid = ref skip(grids,i);
                ref readonly var kRows = ref grid.RowCount;
                ref readonly var kCols = ref grid.ColCount;
                ref readonly var kCells = ref grid.CellCount;
                ref readonly var cells = ref grid.Cells;
                var gc = 0;
                for(var j=0; j<kRows; j++)
                {
                    for(var k=0; k<kCols; k++,gc++, counter++)
                    {
                        ref readonly var cell = ref cells[gc];
                        if(cell.IsEmpty)
                            continue;

                        dst.WriteLine(cell.Format());
                    }

                }
            }
            FileEmit(dst.Emit(), counter, XedDb.TargetPath("rules.tables.test", FileKind.Txt));
            return true;
        }

        AbsoluteLink link(NontermCall call)
            => Markdown.link(string.Format("{0}::{1}()",call.Target.TableKind, call.Target.TableName), XedPaths.TableDef(call.Target));

        static SectionHeader SourceHeader(RuleSig sig)
            => new(3, sig.Format());

        void Emit(Index<NontermCall> calls)
        {
            var dst = text.buffer();
            var source = RuleSig.Empty;
            for(var i=0; i<calls.Count; i++)
            {
                ref readonly var call = ref calls[i];
                if(source.IsEmpty)
                {
                    source = call.Source;
                    dst.AppendLine(SourceHeader(source));
                    dst.AppendLine();
                }

                if(source != call.Source)
                {
                    dst.AppendLine();
                    source = call.Source;
                    dst.AppendLine(SourceHeader(source));
                    dst.AppendLine();
                }

                dst.AppendLine(link(call));
            }

            FileEmit(dst.Emit(), calls.Count, XedDb.TargetPath("rules.tables.deps", FileKind.Md));
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