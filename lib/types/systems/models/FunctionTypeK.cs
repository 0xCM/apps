//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class FunctionType<K> : FunctionType, IFunctionType<K>
        where K : unmanaged
    {
        public new K Kind {get;}

        public FunctionType(Identifier name, K kind, Operand[] operands, Operand ret, Facets facets)
            : base(name,core.bw64(kind), operands, ret, facets)
        {
            Kind = kind;
        }

        public override Identifier KindName
            => Kind.ToString();
    }
}