//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Name<T> : INamed<Name<T>>
        where T : unmanaged, ICharBlock<T>
    {
        public readonly T Data;

        [MethodImpl(Inline)]
        public Name(T name)
        {
            Data = name;
        }

        Name INamed.Name
            => Data.Format();

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(Name<T> src)
            => Data.CompareTo(src.Data);

        [MethodImpl(Inline)]
        public bool Equals(Name<T> src)
            => Data.Equals(src.Data);

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Name<T>(T src)
            => new Name<T>(src);
    }
}