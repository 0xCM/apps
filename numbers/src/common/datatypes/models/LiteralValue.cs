//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [Free]
    public interface IScalarValue<K,T> : IScalarValue<T>, IValue<T>, IScalarExpr
        where T : unmanaged
        where K : unmanaged
    {

    }
    public readonly struct ScalarValue<T> : IScalarValue<T>
        where T : unmanaged, IEquatable<T>
    {
        public T Value {get;}

        public BitWidth ContentWidth {get;}

        [MethodImpl(Inline)]
        public ScalarValue(T value, BitWidth content = default)
        {
            Value = value;
            ContentWidth = content == 0 ? core.width<T>() : content;
        }

        public TypeSpec ScalarType
            => TypeSyntax.scalar(TypeSyntax.infer<T>());

        [MethodImpl(Inline)]
        public bool Equals(ScalarValue<T> src)
            => Value.Equals(src.Value);

        public override bool Equals(object src)
            => src is ScalarValue<T> s &&  Equals(s);

        public override int GetHashCode()
            => Value.GetHashCode();

        public string Format()
            => Value.ToString();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static bool operator ==(ScalarValue<T> a, ScalarValue<T> b)
            => a.Equals(b);

        [MethodImpl(Inline)]
        public static bool operator !=(ScalarValue<T> a, ScalarValue<T> b)
            => !a.Equals(b);

        [MethodImpl(Inline)]
        public static implicit operator T(ScalarValue<T> src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator ScalarValue<T>(T src)
            => new ScalarValue<T>(src);
    }

    [StructLayout(StructLayout,Pack=1)]
    public readonly struct LiteralValue
    {
        public readonly TypeKey Type;

        public readonly ulong Value;

        [MethodImpl(Inline)]
        public LiteralValue(TypeKey type, ulong value)
        {
            Type = type;
            Value = value;
        }

        [MethodImpl(Inline)]
        public static implicit operator LiteralValue<ulong>(LiteralValue src)
            => new LiteralValue<ulong>(src.Type, src.Value);
    }
}