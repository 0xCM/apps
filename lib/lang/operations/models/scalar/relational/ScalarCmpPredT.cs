//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Ops
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct ScalarCmpPred<T> : IScalarCmpPred<ScalarCmpPred<T>,T>
        where T : IScalarExpr
    {
        public T Left {get;}

        public T Right {get;}

        public CmpPredKind Kind {get;}

        [MethodImpl(Inline)]
        public ScalarCmpPred(T a, T b, CmpPredKind kind)
        {
            Left = a;
            Right = b;
            Kind = kind;
        }

        public Name OpName
            => "cmp<t:{0}>";

        public string Format()
            => ScalarOpFormatter.format(this);

        public override string ToString()
            => Format();

        public ScalarCmpPred<T> Create(T a, T b)
            => new ScalarCmpPred<T>(a, b, Kind);
    }
}