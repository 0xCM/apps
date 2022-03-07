//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
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
                var symexpr = dict<string,XedRegId>();
                var symdst = Symbols.index<RegKind>();
                var dst = dict<XedRegId,RegOp>();
                foreach(var kind in symsrc.Kinds)
                {
                    if(kind == 0)
                        continue;
                    symexpr[kind.ToString().ToLower()] = kind;
                }

                foreach(var k in symexpr.Keys)
                {
                    if(symdst.Lookup(k, out var sym))
                        dst[symexpr[k]] = sym.Kind;
                }

                return new XedRegMap(dst);
            }
        }
    }
}