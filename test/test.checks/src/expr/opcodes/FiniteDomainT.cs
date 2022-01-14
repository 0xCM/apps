//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public abstract class FiniteDomain<T>
    {
        public Name Name {get;}

        protected Index<T> Data;

        protected FiniteDomain(Name name)
        {
            Name = name;
        }

        public uint MemberCount
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public ReadOnlySpan<T> Members
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref readonly T this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref readonly T this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }
    }
}