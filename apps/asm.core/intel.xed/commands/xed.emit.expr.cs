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
        [CmdOp("xed/emit/expr")]
        Outcome EmitRuleExpr(CmdArgs args)
        {
            var rules = CalcRules();
            ref readonly var src = ref rules.Specs();
            var dst = core.alloc<RuleExpr>(src.RowCount);
            var k=z16;
            for(var i=0; i<src.EntryCount; i++)
            {
                ref readonly var table = ref src[i];
                for(var j=0; j<table.RowCount; j++, k++)
                {
                    ref readonly var row = ref table[j];
                    seek(dst,k) = new RuleExpr(k, table.Sig, (byte)row.RowIndex, Ref(row.Format()));
                }
            }

            AppSvc.TableEmit(dst, XedPaths.RuleTable<RuleExpr>());

            return true;
        }
    }
}