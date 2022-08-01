//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace fp.cs
{
    /**
    * A meet-semilattice (or lower semilattice) is a semilattice whose operation is called `meet`, and which can be thought
    * of as a greatest lower bound.
    *
    * A `MeetSemilattice` must satisfy the following laws:
    *
    * - Associativity: `a ∧ (b ∧ c) <-> (a ∧ b) ∧ c`
    * - Commutativity: `a ∧ b <-> b ∧ a`
    * - Idempotency:   `a ∧ a <-> a`
    *
    * @since 2.0.0
    */
    /**
    * @category type classes
    * @since 2.0.0
    */

    public interface IMeetSemiLattice<A>
    {
        A Meet(A x, A y);
    }
    
    public interface IMeetSemiLattice<F,A> : IMeetSemiLattice<A>
        where F : IMeetSemiLattice<F,A>, new()
    {

    }

    public class MeetSemilattice
    {
        public static MeetSemilattice<F,A> impl<F,A>()
            where F : IMeetSemiLattice<F,A>, new()
                => new F();
    }

    public readonly struct MeetSemilattice<F,A> : IMeetSemiLattice<A>
        where F : IMeetSemiLattice<F,A>, new()
    {            
        static F Instance = new();

        [MethodImpl(Inline)]
        public static A meet(A x, A y) 
            => Instance.Meet(x,y);

        public A Meet(A x, A y)
            => meet(x,y);

        [MethodImpl(Inline)]
        public static implicit operator MeetSemilattice<F,A>(F src)
            => Instance;
    }
}