//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Covers a value that can be interpreted as a compile-time literal constant
    /// </summary>
    public readonly struct RuntimeLiteral<T> : IRuntimeLiteral<T>
        where T : unmanaged, IEquatable<T>
    {
        public readonly StringAddress Source;

        public readonly StringAddress Name;

        public readonly T Value;

        public readonly ClrLiteralKind Kind;

        public readonly LiteralUsage Usage;

        [MethodImpl(Inline)]
        public RuntimeLiteral(StringAddress source,  StringAddress name, T value, ClrLiteralKind kind, LiteralUsage usage = default)
        {
            Source = source;
            Name = name;
            Value = value;
            Kind = kind;
            Usage = usage;
        }

        StringAddress IRuntimeLiteral.Source
            => Source;

        StringAddress IRuntimeLiteral.Name
            => Name;

        ClrLiteralKind IKinded<ClrLiteralKind>.Kind
            => Kind;

        [MethodImpl(Inline)]
        public bool Equals(RuntimeLiteral<T> src)
            => Value.Equals(src.Value) && Kind == src.Kind && Usage == src.Usage;

        [MethodImpl(Inline)]
        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        public override int GetHashCode()
            => Value.GetHashCode();

        public override bool Equals(object src)
            => src is RuntimeLiteral<T> v && Equals(v);

        public static RuntimeLiteral<T> Empty
            => default;

        T IClrLiteralValue<T>.Value
            => Value;
    }
}