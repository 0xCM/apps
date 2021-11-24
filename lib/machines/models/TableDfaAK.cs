//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using Z0.Lang;

    /// <summary>
    /// Defines a table-driven dfa
    /// </summary>
    /// <typeparam name="K"></typeparam>
    public sealed class TableDfa<A,K> : Dfa<A,K>
        where K : unmanaged
        where A : unmanaged
    {
        readonly Grid<Atom<K>> Transitions;

        public TableDfa(Alphabet<A> alphabet, DfaState<K>[] states, DfaState<K>[] terminals, DfaState<K> s0, Grid<Atom<K>> transitions)
            : base(alphabet, states, terminals, s0)
        {
            Transitions = transitions;
        }

        protected override DfaState<K> Evaluate(Atom<K> src)
        {
            var i = CurrentState.Key;
            var j = src.Key;
            if(i < Transitions.RowCount && j<Transitions.ColCount)
            {
                var order = Transitions.ColCount*i + j;
                return Dfa.state((int)order, Transitions[i,j]);
            }

            return default;
        }
    }
}