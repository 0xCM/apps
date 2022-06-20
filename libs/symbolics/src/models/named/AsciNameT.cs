//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct AsciName<T> : INamed<AsciName<T>>
        where T : unmanaged, IAsciSeq<T>
    {
        public readonly T Data;

        [MethodImpl(Inline)]
        public AsciName(T name)
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
        public bool Equals(AsciName<T> src)
            => Data.Equals(src.Data);

        [MethodImpl(Inline)]
        public int CompareTo(AsciName<T> src)
            => Data.CompareTo(src.Data);

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsciName<T>(T src)
            => new AsciName<T>(src);
    }
}