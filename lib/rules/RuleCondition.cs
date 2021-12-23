//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;

    using Ops;

    public class Assignment<V>
        where V : IValue
    {
        public Identifier Name {get;}

        public V Value {get;}

        public Assignment(Identifier name, V value)
        {
            Name = name;
            Value = value;
        }
    }

    public class CmpCondition<C,V>
        where C : IScalarExpr
        where V : IValue
    {
        public Identifier Name {get;}

        public ScalarCmpPred<C> Predicate {get;}

        public Assignment<V> Consequent {get;}

        public CmpCondition(Identifier name, ScalarCmpPred<C> pred, Assignment<V> a)
        {
            Name = name;
            Predicate = pred;
            Consequent = a;
        }
    }
}