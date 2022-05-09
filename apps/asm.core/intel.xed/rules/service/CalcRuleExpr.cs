//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedRules
    {
        public Index<RuleExpr> CalcSpecExpr(TableSpecs src)
        {
            return Data(nameof(CalcSpecExpr), Calc);

            Index<RuleExpr> Calc()
            {
                var dst = core.alloc<RuleExpr>(src.RowCount);
                var k=z16;
                for(var i=0; i<src.TableCount; i++)
                {
                    ref readonly var table = ref src[i];
                    for(var j=0; j<table.RowCount; j++, k++)
                    {
                        ref readonly var row = ref table[j];
                        seek(dst,k) = new RuleExpr(k, table.Sig, (byte)row.RowIndex, String(row.Format()));
                    }
                }
                return dst;
            }
        }

        public Index<RuleExpr> CalcCellExpr(CellTables src)
        {
            return Data(nameof(CalcCellExpr),Calc);

            Index<RuleExpr> Calc()
            {
                var dst = core.alloc<RuleExpr>(src.RowCount);
                var k=z16;
                for(var i=0; i<src.TableCount; i++)
                {
                    ref readonly var table = ref src[i];
                    for(var j=0; j<table.RowCount; j++, k++)
                    {
                        ref readonly var row = ref table[j];
                        seek(dst,k) = new RuleExpr(k, table.Sig, (byte)row.RowIndex, String(row.Format()));
                    }
                }

                return dst;
            }
        }
    }
}