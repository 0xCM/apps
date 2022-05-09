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
            var tables = CalcRules();
            var expr = Rules.CalcSpecExpr(tables.Specs());
            Rules.Emit(expr);
            return true;
        }
    }
}