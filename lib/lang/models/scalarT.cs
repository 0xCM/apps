//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    [DataType(TypeSyntax.Scalar)]
    public readonly struct scalar<T> : IScalarValue<T>
        where T : unmanaged, IEquatable<T>
    {
        public T Value {get;}

        public BitWidth ContentWidth {get;}

        [MethodImpl(Inline)]
        public scalar(T value, BitWidth content = default)
        {
            Value = value;
            ContentWidth = content == 0 ? core.width<T>() : content;
        }

        public TypeSpec ScalarType
            => TypeSyntax.scalar(TypeSyntax.infer<T>());

        [MethodImpl(Inline)]
        public bool Equals(scalar<T> src)
            => Value.Equals(src.Value);

        public override bool Equals(object src)
            => src is scalar<T> s &&  Equals(s);

        public override int GetHashCode()
            => Value.GetHashCode();

        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static bool operator ==(scalar<T> a, scalar<T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(scalar<T> a, scalar<T> b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator T(scalar<T> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator scalar<T>(T src)
            => new scalar<T>(src);
    }
}