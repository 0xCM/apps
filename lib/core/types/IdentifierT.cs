//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    /// <summary>
    /// Represents a legal identifier
    /// </summary>
    [DataType("identifier<t:{0}>")]
    public readonly struct Identifier<T> : IIdentifier<Identifier<T>,T>
        where T : IComparable<T>
    {
        public T Value {get;}

        [MethodImpl(Inline)]
        public Identifier(T src)
            => Value = src;

        public Name Name
        {
            [MethodImpl(Inline)]
            get => Value?.ToString() ?? EmptyString;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Name.Format();

        public override string ToString()
            => Format();

        public bool Equals(Identifier<T> src)
            => Name.Equals(src.Name);
        public int CompareTo(Identifier<T> other)
            => Value?.CompareTo(other.Value) ?? 0;

        [MethodImpl(Inline)]
        public static implicit operator Identifier<T>(T src)
            => new Identifier<T>(src);
    }
}