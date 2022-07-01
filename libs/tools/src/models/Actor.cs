//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Actor : IDataType<Actor>, IActor
    {
        readonly asci64 Data;

        [MethodImpl(Inline)]
        public Actor(asci64 name)
        {
            Data = name;
        }

        [MethodImpl(Inline)]
        public Actor(Name<asci64> name)
        {
            Data = name.Data;
        }

        public Name<asci64> Name
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public int CompareTo(Actor src)
            => Data.CompareTo(src.Data);

        [MethodImpl(Inline)]
        public bool Equals(Actor src)
            => Data.Equals(src.Data);

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Actor(string src)
            => new Actor(src);

        [MethodImpl(Inline)]
        public static implicit operator Actor(asci64 src)
            => new Actor(src);

        public static Actor Empty => default;
    }
}