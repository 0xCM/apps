//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Linq;
    using System.Runtime.CompilerServices;

    using static Root;
    using static Typed;

    /// <summary>
    /// Defines a permutation of natural length N over the natural numbers 0,1,...,N-1
    /// </summary>
    public readonly struct NatPerm<N>
        where N : unmanaged, ITypeNat
    {
        readonly perm perm;

        static int n => nat32i<N>();

        /// <summary>
        /// The canonical identity permutation of length N
        /// </summary>
        public static NatPerm<N> Identity
            => new NatPerm<N>(AllocIdentity());

        /// <summary>
        /// The empty permutation of length N
        /// </summary>
        public static NatPerm<N> Empty
            => new NatPerm<N>(new int[n]);

        [MethodImpl(Inline)]
        static int[] AllocIdentity()
            => gcalc.stream(0, n - 1).ToArray();

        /// <summary>
        /// Allocates an empty permutation
        /// </summary>
        [MethodImpl(Inline)]
        public static NatPerm<N> Alloc()
            => Empty.Replicate();

        /// <summary>
        /// Initializes a permutation with the identity followed by a sequence of transpostions
        /// </summary>
        /// <param name="swaps">The transpositions to apply to the identity</param>
        [MethodImpl(Inline)]
        public NatPerm(NatSwap<N>[] swaps)
        {
            perm = new perm(n, swaps.Unsized());
        }

        [MethodImpl(Inline)]
        internal NatPerm(perm src)
        {
            perm = src;
        }

        /// <summary>
        /// Initializes a permutation with array content that implicitly defines a permutation
        /// </summary>
        /// <param name="src">The source array</param>
        public NatPerm(int[] src)
        {
            if(src.Length == n)
                perm = new perm(src);
            else
            {
                var tmp = new int[n];

                var m = src.Length;
                for(var i=0; i< m; i++)
                    tmp[i] = src[i];

                for(var i=m; i< n; i++)
                    tmp[i] = Identity[i - m];
                perm = new perm(tmp);
            }
        }

        public ReadOnlySpan<int> Terms
            => perm.Terms;

        /// <summary>
        /// Term evaluator/manipulator where
        /// </summary>
        public ref int this[int i]
        {
            [MethodImpl(Inline)]
            get => ref perm[i];
        }

        /// <summary>
        /// The permutation length
        /// </summary>
        public int Length
        {
            [MethodImpl(Inline)]
            get => (int)n;
        }

        /// <summary>
        /// Effects a transposition (i,j) -> (j, i)
        /// </summary>
        /// <param name="swap">The transposition to apply</param>
        [MethodImpl(Inline)]
        public NatPerm<N> Swap(in NatSwap<N> src)
        {
            (var i, var j) = src;
            perm.Swap(src);
            return this;
        }

        /// <summary>
        /// Effects a transposition (i,j) -> (j, i)
        /// </summary>
        /// <param name="swap">The transposition to apply</param>
        [MethodImpl(Inline)]
        public NatPerm<N> Swap(int i, int j)
        {
            perm.Swap(i,j);
            return this;
        }

        /// <summary>
        /// Effects a sequence of transpositions
        /// </summary>
        /// <param name="specs">The transpositions to apply</param>
        [MethodImpl(Inline)]
        public NatPerm<N> Swap(params (int i, int j)[] specs)
        {
            perm.Swap(specs);
            return this;
        }

        /// <summary>
        /// Effects a sequence of transpositions
        /// </summary>
        public NatPerm<N> Swap(params NatSwap<N>[] specs)
        {
            for(var k=0; k<specs.Length; k++)
                perm.Swap(specs[k]);
            return this;
        }

        /// <summary>
        /// Clones the permutation
        /// </summary>
        public NatPerm<N> Replicate()
            => new NatPerm<N>(perm.Replicate());

        /// <summary>
        /// Clones the permutation and applies the transposition (i,j)
        /// </summary>
        /// <param name="i">The first term index</param>
        /// <param name="j">The second term index</param>
        public NatPerm<N> Replicate(in NatSwap<N> s)
        {
            var p = Replicate();
            p.Swap(s);
            return p;
        }

        /// <summary>
        /// Reverses the permutation in-place
        /// </summary>
        public NatPerm<N> Reverse()
        {
            perm.Reverse();
            return this;
        }

        /// <summary>
        /// Computes the inverse permutation t of the current permutation p
        /// such that p*t = t*p = I where I denotes the identity permutation
        /// </summary>
        public NatPerm<N> Invert()
            => new NatPerm<N>(perm.Invert());

        /// <summary>
        /// Creates a new permutation p via composition, p[i] = g(f(i)) for i = 0, ... n
        /// where f denotes the current permutation
        /// </summary>
        /// <param name="f">The left permutation</param>
        /// <param name="g">The right permutation</param>
        public NatPerm<N> Compose(NatPerm<N> g)
            => new NatPerm<N>(perm.Compose(g.perm));

        /// <summary>
        /// Applies a modular increment to the permutation in-place
        /// </summary>
        [MethodImpl(Inline)]
        public NatPerm<N> Inc()
        {
            perm.Inc();
            return this;
        }

        /// <summary>
        /// Applies a modular decrement to the permutation in-place
        /// </summary>
        [MethodImpl(Inline)]
        public NatPerm<N> Dec()
        {
            perm.Dec();
            return this;
        }

        public Span<Swap> CalcSwaps()
            => perm.CalcSwaps();

        /// <summary>
        /// Computes a permutation cycle originating at a specified point
        /// </summary>
        /// <param name="start">The domain point at which evaluation will begin</param>
        public PermCycle Cycle(int start)
            => perm.Cycle(start);

        [MethodImpl(Inline)]
        public bool Equals(NatPerm<N> g)
            => perm.Equals(g.perm);

        /// <summary>
        /// Formats a permutation as a 2-column matrix
        /// </summary>
        /// <param name="src">The source permutation</param>
        /// <param name="colwidth">The width of the matrix columns, if specified</param>
        [MethodImpl(Inline)]
         public string Format(int? colwidth = null)
            => perm.Format(colwidth);

         public override string ToString()
            => this.Format();

         public override int GetHashCode()
            => perm.GetHashCode();

         public override bool Equals(object o)
            => o is NatPerm<N> p  && p.perm.Equals(perm);

        /// <summary>
        /// Implicitly converts the source to an unsized permutation
        /// </summary>
        /// <param name="f">The permutation to convert</param>
        [MethodImpl(Inline)]
        public static implicit operator perm(NatPerm<N> f)
            => f.perm;

        /// <summary>
        /// Computes the composition h of f and g where h(i) = g(f(i)) for i = 0, ... n
        /// </summary>
        /// <param name="f">The left permutation</param>
        /// <param name="g">The right permutation</param>
        [MethodImpl(Inline)]
        public static NatPerm<N> operator *(NatPerm<N> f, NatPerm<N> g)
            => f.Compose(g);

        /// <summary>
        /// Computes the inverse of f
        /// </summary>
        /// <param name="f">The source permutation</param>
        [MethodImpl(Inline)]
        public static NatPerm<N> operator ~(NatPerm<N> f)
            => f.Invert();

        [MethodImpl(Inline)]
        public static NatPerm<N> operator ++(in NatPerm<N> lhs)
            => lhs.Inc();

        [MethodImpl(Inline)]
        public static NatPerm<N> operator --(in NatPerm<N> lhs)
            => lhs.Dec();

        [MethodImpl(Inline)]
        public static bool operator ==(NatPerm<N> f, NatPerm<N> g)
            => f.Equals(g);

        [MethodImpl(Inline)]
        public static bool operator !=(NatPerm<N> f, NatPerm<N> g)
            => !f.Equals(g);
    }
}