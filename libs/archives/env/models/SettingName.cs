//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct SettingName : INamed<SettingName>
    {
        public readonly asci64 Data;

        [MethodImpl(Inline)]
        public SettingName(asci64 data)
        {
            Data = data;
        }

        Name INamed.Name
            => Data.Format();

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

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data.Hash;
        }

        public override int GetHashCode()
            => Hash;

        [MethodImpl(Inline)]
        public bool Equals(SettingName src)
            => Data.Equals(src.Data);

        [MethodImpl(Inline)]
        public int CompareTo(SettingName src)
            => Data.CompareTo(src.Data);

        public string Format()
            => Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator SettingName(string src)
            => new SettingName(src);
    }
}