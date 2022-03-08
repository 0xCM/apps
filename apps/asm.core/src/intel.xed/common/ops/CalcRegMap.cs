//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using static core;

    partial class IntelXed
    {
        public XedRegMap CalcRegMap()
        {
            return Data(nameof(CalcRegMap), calc);

            static XedRegMap calc()
            {
                var symsrc = Symbols.index<XedRegId>();
                var symdst = Symbols.index<RegKind>();
                var dst = dict<XedRegId,RegOp>();

                var a = Symbols.index<RegKind>().View.Map(x => (x.Expr.Format(), x.Kind)).ToDictionary();
                var b = Symbols.index<XedRegId>().View;
                foreach(var xedreg in b)
                {
                    var match = xedreg.Expr.Format().ToLower();
                    if(a.TryGetValue(match, out var kind))
                        dst[xedreg.Kind] = kind;
                }

                return new XedRegMap(dst);
            }
        }
    }
}