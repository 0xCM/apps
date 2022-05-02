//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedGrids;
    using static core;

    partial class XedCmdProvider
    {
        [MethodImpl(Inline)]
        public static GridCell gcell(in RuleCell src)
        {
            var field = src.Field;
            var type = ColType.field(field);
            var size = XedFields.field(field).Size;
            if(src.IsNontermCall)
            {
                type = ColType.nonterm(src.Value.AsNonterm());
                size = Nonterminal.DataSize;
            }
            else if(src.IsCellExpr)
            {
                var expr = src.Value.ToCellExpr();
                if(expr.IsNonterm)
                    type = ColType.expr(field, expr.Operator, expr.Value.ToRuleName());
                else
                    type = ColType.expr(field, expr.Operator);
            }

            return new GridCell(src.Key, type, size, src.Value);
        }

        [CmdOp("xed/check/rules")]
        Outcome CheckRules(CmdArgs args)
        {
            var src = CalcRuleCells();
            var kGrid = src.TableCount;
            var grids = alloc<RuleGrid>(kGrid);
            var gt=0u;
            var gr=0u;
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
                        gCells[gc] = gcell(cRow[k]);
                        gRowCols[j][k] = col(gCells[gc]);
                    }
                }
            }

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