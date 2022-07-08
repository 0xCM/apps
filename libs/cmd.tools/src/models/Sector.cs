//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Sector : IDataType<Sector>
    {
        readonly asci64 Data;

        [MethodImpl(Inline)]
        public Sector(asci64 src)
        {
            Data = src;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data.Hash;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNull;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public bool Equals(Sector src)
            => Data == src.Data;

        [MethodImpl(Inline)]
        public int CompareTo(Sector src)
            => Data.CompareTo(src.Data);

        [MethodImpl(Inline)]
        public static implicit operator Sector(string src)
            =>new Sector(src);

        [MethodImpl(Inline)]
        public static implicit operator Sector(asci64 src)
            =>new Sector(src);
    }
}