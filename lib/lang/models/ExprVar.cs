//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class ExprVar : INamedTerm
    {
        public VarSymbol Name {get;}

        public ExprVar(VarSymbol name)
        {
            Name = name;
        }

        public IExpr Eval(IExprContext context)
            => context.Resolve(Name);

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Name.IsEmpty;
        }

        Name INamed.Name
            => Name.Format();
    }
}