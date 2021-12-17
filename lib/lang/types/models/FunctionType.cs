//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public class FunctionType : IFunctionType
    {
        public Identifier Name {get;}

        public Index<Operand> Operands {get;}

        public Operand Return {get;}

        public Facets Facets {get;}

        public ulong Kind {get;}

        public virtual Identifier KindName {get;}

        public FunctionType(Identifier name, ulong kind, Operand[] operands, Operand ret, Facets facets)
        {
            Name = name;
            Kind = kind;
            Operands = operands;
            Return = ret;
            Facets = facets;
            KindName = Identifier.Empty;
        }

        public string Format()
            => FunctionTypeFormatter.Service.Format(this);

        public override string ToString()
            => Format();
    }
}