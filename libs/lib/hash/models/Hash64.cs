//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Hash64 : IHashCode<Hash64,ulong>
    {
        [Parser]
        public static Outcome parse(string src, out Hash64 dst)
        {
            var result = Hex64.parse(src, out var hex);
            dst = 0;
            if(result)
                dst = (ulong)hex;
            return result;
        }

        public readonly ulong Value;

        [MethodImpl(Inline)]
        public Hash64(ulong value)
            => Value = value;

        public ulong Primitive
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        ulong IHashCode<ulong>.Value
            => Value;

        [MethodImpl(Inline)]
        public bool Equals(Hash64 src)
            => Value == src.Value;

        [MethodImpl(Inline)]
        public int CompareTo(Hash64 src)
            => Value.CompareTo(src.Value);

        public override int GetHashCode()
            => Value.GetHashCode();

        Hash32 IHashed.Hash
            => GetHashCode();

        bool INullity.IsEmpty
            => Value == 0;

        public string Format()
            => Value.FormatHex(zpad:true, specifier:true, uppercase:true);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Hash64(ulong src)
            => new Hash64(src);
    }
}