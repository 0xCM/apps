//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using Asm;


    partial struct XedModels
    {
        public static ConstLookup<XedRegId,RegKind> regmap()
        {
            var symsrc = Symbols.index<XedRegId>();
            var kinds = symsrc.Kinds;
            var count = kinds.Length;
            var symdst = Symbols.index<RegKind>();
            var dst = dict<XedRegId,RegKind>();
            var ok = typeof(XedRegId).Fields().Ignore().Where(x => x.IsLiteral).Map(x => (ushort)x.GetRawConstantValue()).ToHashSet();
            for(var i=0; i<count; i++)
            {
                ref readonly var id = ref skip(kinds,i);
                if(!ok.Contains((ushort)id))
                    continue;

                if(symdst.Lookup(id.ToString().ToLower(), out var sym))
                    dst.Add(id,sym.Kind);
                else
                {
                    if(symdst.Lookup(symsrc[id].Expr.Text.ToLower(), out var x))
                        dst.Add(id, x.Kind);
                    else
                        dst.Add(id,RegKind.None);
                }
            }
            return dst;
        }
    }
}