//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedRules;
    using static core;

    partial class XedCmdProvider
    {
        string Format(in CellRow src)
        {
            var dst = text.emitter();
            for(var i=0; i<src.CellCount; i++)
            {
                if(i != 0)
                    dst.Append(Chars.Space);

                ref readonly var cell = ref src[i];
                if(i == src.Count-1 && cell.IsOperator)
                    break;

                dst.Append(cell.Format());

            }
            return dst.Emit();
        }

        [CmdOp("xed/emit/expr")]
        Outcome EmitRuleExpr(CmdArgs args)
        {
            var rules = CalcRules();
            var src = CalcRuleCells();
            var dst = core.alloc<RuleExpr>(src.RowCount);
            var k=z16;
            for(var i=0; i<src.TableCount; i++)
            {
                ref readonly var table = ref src[i];
                for(var j=0; j<table.RowCount; j++,k++)
                {
                    ref readonly var row = ref table[j];
                    seek(dst,k) = new RuleExpr(k, table.Sig, (byte)row.RowIndex, Ref(Format(row)));
                }
            }
            // var k=z16;
            // for(var i=0; i<src.EntryCount; i++)
            // {
            //     ref readonly var table = ref src[i];
            //     for(var j=0; j<table.RowCount; j++, k++)
            //     {
            //         ref readonly var row = ref table[j];
            //         seek(dst,k) = new RuleExpr(k, table.Sig, (byte)row.RowIndex, Ref(row.Format()));
            //     }
            // }

            AppSvc.TableEmit(dst, XedPaths.RuleTable<RuleExpr>("test"));

            return true;
        }
    }
}