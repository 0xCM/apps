//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    using System.Runtime.CompilerServices;

    using static Root;

    using api = ScalarOps;

    public readonly struct ScalarCmpPred : IScalarCmpPred<IScalarExpr>
    {
        public IScalarExpr Left {get;}

        public IScalarExpr Right {get;}

        public CmpPredKind Kind {get;}

        [MethodImpl(Inline)]
        public ScalarCmpPred(IScalarExpr a, IScalarExpr b, CmpPredKind kind)
        {
            Left = a;
            Right = b;
            Kind = kind;
        }

        public bool Eval()
            => default;

        public string Format()
            => ScalarOpFormatter.format(this);

        public override string ToString()
            => Format();
    }
}