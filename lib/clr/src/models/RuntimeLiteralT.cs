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
    /// Covers a value that can be interpreted as a compile-time literal constant
    /// </summary>
    public readonly struct RuntimeLiteral<T> : IRuntimeLiteral<T>
        where T : unmanaged, IEquatable<T>
    {
        public StringAddress Source {get;}

        public StringAddress Name {get;}

        public T Data {get;}

        public LiteralKind Kind {get;}

        public LiteralUsage Usage {get;}

        [MethodImpl(Inline)]
        public RuntimeLiteral(StringAddress source,  StringAddress name, T value, LiteralKind kind, LiteralUsage usage = default)
        {
            Source = source;
            Name = name;
            Data = value;
            Kind = kind;
            Usage = usage;
        }

        [MethodImpl(Inline)]
        public bool Equals(RuntimeLiteral<T> src)
            => Data.Equals(src.Data) && Kind == src.Kind && Usage == src.Usage;

        [MethodImpl(Inline)]
        public string Format()
            => Data.ToString();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Data.GetHashCode();

        public override bool Equals(object src)
            => src is RuntimeLiteral<T> v && Equals(v);

        public static RuntimeLiteral<T> Empty
            => default;
    }
}