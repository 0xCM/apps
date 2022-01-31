//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public interface IAdditive2<T>
        where T : unmanaged
    {
        static abstract T Add(T a, T b);
    }

    public readonly struct Additive<T> : IAdditive2<Additive<T>>
        where T : unmanaged
    {
        readonly T Value;

        public Additive(T value)
        {
            Value = value;
        }

        public static Additive<T> Add(Additive<T> a, Additive<T> b)
            => gmath.add(a.Value,b.Value);

        public static implicit operator Additive<T>(T value)
            => new Additive<T>(value);
    }

    public readonly struct Additives
    {
        public static T add<T>(T a, T b)
            where T : unmanaged, IAdditive2<T>
        {
            return T.Add(a,b);
        }
    }
}