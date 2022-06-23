//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct SettingName<T> : INamed<SettingName<T>>
        where T : unmanaged, IAsciSeq<T>
    {
        public readonly T Data;

        [MethodImpl(Inline)]
        public SettingName(T name)
        {
            Data = name;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNull;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !Data.IsNull;
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
        public bool Equals(SettingName<T> src)
            => Data.Equals(src.Data);

        [MethodImpl(Inline)]
        public int CompareTo(SettingName<T> src)
            => Data.CompareTo(src.Data);

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator SettingName<T>(T src)
            => new SettingName<T>(src);
    }
}