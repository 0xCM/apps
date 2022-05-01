//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedDataTypes
    {
        [StructLayout(LayoutKind.Sequential,Size=4), DataWidth(MetaWidth)]
        public readonly record struct TypeKey : IComparable<TypeKey>
        {
            public const uint MetaWidth = 32;

            public const byte FirstKey = 0;

            public static TypeKey Zero => FirstKey;

            public uint Value
            {
                [MethodImpl(Inline)]
                get => core.@as<TypeKey,uint>(this);
            }

            public bool IsNonEmpty
            {
                [MethodImpl(Inline)]
                get => ((int)this) >= 0;
            }

            public bool IsEmpty
            {
                [MethodImpl(Inline)]
                get => ((int)this) == -1;
            }

            [MethodImpl(Inline)]
            public TypeKey Next()
                => math.inc(this);

            [MethodImpl(Inline)]
            public TypeKey Prior()
                => math.dec(this);

            public string Format()
                => Value.ToString();

            public override string ToString()
                => Format();

            public override int GetHashCode()
                => (int)this;

            [MethodImpl(Inline)]
            public int CompareTo(TypeKey src)
                => Value.CompareTo(src.Value);

            [MethodImpl(Inline)]
            public static implicit operator TypeKey(uint src)
                => core.@as<uint,TypeKey>(src);

            [MethodImpl(Inline)]
            public static implicit operator uint(TypeKey src)
                => src.Value;

            [MethodImpl(Inline)]
            public static explicit operator int(TypeKey src)
                => core.@as<TypeKey,int>(src);

            [MethodImpl(Inline)]
            public static explicit operator TypeKey(int src)
                => core.@as<int,TypeKey>(src);

            [MethodImpl(Inline)]
            public static TypeKey operator +(TypeKey a, TypeKey b)
                => a.Value + b.Value;

            [MethodImpl(Inline)]
            public static TypeKey operator -(TypeKey a, TypeKey b)
                => a.Value - b.Value;

            [MethodImpl(Inline)]
            public static bool operator >(TypeKey a, TypeKey b)
                => (int)a.Value > (int)b.Value;

            [MethodImpl(Inline)]
            public static bool operator >=(TypeKey a, TypeKey b)
                => (int)a.Value >= (int)b.Value;

            [MethodImpl(Inline)]
            public static bool operator <(TypeKey a, TypeKey b)
                => (int)a.Value < (int)b.Value;

            [MethodImpl(Inline)]
            public static bool operator <=(TypeKey a, TypeKey b)
                => (int)a.Value <= (int)b.Value;

            [MethodImpl(Inline)]
            public static TypeKey operator ++(TypeKey src)
                => src.Next();

            [MethodImpl(Inline)]
            public static TypeKey operator --(TypeKey src)
                => src.Prior();

            public static TypeKey Empty => (TypeKey)(-1);

        }
    }
}