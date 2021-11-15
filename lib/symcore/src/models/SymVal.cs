//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct SymVal : IEquatable<SymVal>, ISymVal<ulong>
    {
        public ulong Value {get;}

        [MethodImpl(Inline)]
        public SymVal(ulong value)
        {
            Value = value;
        }

        [MethodImpl(Inline)]
        public bool Equals(SymVal src)
            => Value.Equals(src.Value);

        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Value.GetHashCode();

        public override bool Equals(object src)
            => src is SymVal x && Equals(x);

        [MethodImpl(Inline)]
        public static implicit operator SymVal(ulong src)
            => new SymVal(src);

       [MethodImpl(Inline)]
        public static implicit operator ulong(SymVal src)
            => src.Value;
    }
}