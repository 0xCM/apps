//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Expr
{
    using System.Runtime.CompilerServices;

    using Z0.Lang;

    using static Root;

    public readonly struct DfaState<K>
        where K : unmanaged
    {
        /// <summary>
        /// The state position within a given string
        /// </summary>
        public int Order {get;}

        public Atom<K> Symbol {get;}

        [MethodImpl(Inline)]
        public DfaState(int order, Atom<K> b)
        {
            Order = order;
            Symbol = b;
        }

        /// <summary>
        /// The state key
        /// </summary>
        public uint Key
        {
            [MethodImpl(Inline)]
            get => Symbol.Key;
        }

        public string Format()
            => Symbol.Format();

        public override string ToString()
            => Format();
    }
}