//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static XedModels;
    using static core;

    partial class XedCmdProvider
    {
        [CmdOp("xed/emit/expr")]
        Outcome EmitRuleExpr(CmdArgs args)
        {
            const string Pattern = "{0,-28} | {1,-6} | {2,-6} | {3}";
            var rules = CalcRules();
            var dst = text.emitter();
            dst.AppendLineFormat(Pattern, "Rule", "Kind", "Row", "Expression");
            ref readonly var specs = ref rules.Specs();
            var sz = z8;
            for(var i=0; i<specs.EntryCount; i++)
            {
                ref readonly var table = ref specs[i];
                for(var j=0; j<table.RowCount; j++)
                {
                    ref readonly var row = ref table[j];
                    var primal = primitives(row);
                    var m = MaxSize(primal);
                    if(m > sz)
                        sz = m;
                    dst.AppendLineFormat(Pattern, table.Sig.TableName, table.Sig.TableKind, row.RowIndex, format(primal));
                }
            }

            FileEmit(dst.Emit(), 1, XedPaths.RuleTarget("expressions", FS.Csv));

            Write($"Max Size:{sz}");
            return true;
        }

        static byte MaxSize(Index<CellPrimitive> src)
        {
            var max = z8;
            for(var i=0; i<src.Count; i++)
            {
                if(src[i].ValueSize > max)
                    max = src[i].ValueSize;
            }
            return max;
        }

        static Index<CellPrimitive> primitives(in RowSpec src)
        {
            var count = src.ColCount;
            var dst = alloc<CellPrimitive>(count);
            for(var i=z8; i<count; i++)
                seek(dst,i) = CellPrimitive.from(src[i]);
            return dst;
        }

        static string format(Index<CellPrimitive> src)
        {
            var dst = text.emitter();
            var count = src.Count;
            for(var i=z8; i<count; i++)
            {
                ref readonly var cell = ref src[i];

                if(cell.IsOperator && i == count - 1)
                    break;

                if(i !=0)
                    dst.Append(Chars.Space);

                dst.Append(cell.Format());
            }
            return dst.Emit();
        }
    }
}