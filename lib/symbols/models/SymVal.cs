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

        public NumericBaseKind Base {get;}

        [MethodImpl(Inline)]
        public SymVal(ulong value, NumericBaseKind @base = NumericBaseKind.Base10)
        {
            Value = value;
            Base = @base;
        }

        [MethodImpl(Inline)]
        public bool Equals(SymVal src)
            => Value.Equals(src.Value);

        public string Format()
            => NumericFormats.format(Value, Base, null, true);

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
        public static implicit operator SymVal((ulong src, NumericBaseKind nbk) x)
            => new SymVal(x.src, x.nbk);

        [MethodImpl(Inline)]
        public static implicit operator SymVal(long src)
            => new SymVal((ulong)src);

        [MethodImpl(Inline)]
        public static implicit operator SymVal((long src, NumericBaseKind nbk) x)
            => new SymVal((ulong)x.src, x.nbk);

        [MethodImpl(Inline)]
        public static implicit operator ulong(SymVal src)
            => src.Value;
    }
}