//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly record struct Hash8 : IHashCode<Hash8,byte>
    {
        [Parser]
        public static Outcome parse(string src, out Hash8 dst)
        {
            var result = Hex8.parse(src, out var hex);
            dst = 0;
            if(result)
                dst = (byte)hex;
            return result;
        }

        public byte Value {get;}

        [MethodImpl(Inline)]
        public Hash8(byte value)
            => Value = value;

        public byte Primitive
        {
            [MethodImpl(Inline)]
            get => Value;
        }

        [MethodImpl(Inline)]
        public bool Equals(Hash8 src)
            => Value == src.Value;

        [MethodImpl(Inline)]
        public int CompareTo(Hash8 src)
            => Value.CompareTo(src.Value);

        public override int GetHashCode()
            => Value;

        public string Format()
            => Value.FormatHex(zpad:true, specifier:true, uppercase:true);

        public override string ToString()
            => Format();

        Hash32 IHashed.Hash
            => Value;

        bool INullity.IsEmpty
            => Value == 0;

        [MethodImpl(Inline)]
        public static implicit operator Hash8(byte src)
            => new Hash8(src);

        [MethodImpl(Inline)]
        public static Hash16 operator | (Hash8 a, Hash8 b)
            => (ushort)((uint)a.Value | ((uint)b.Value << 8));

        [MethodImpl(Inline)]
        public static Hash8 operator ^ (Hash8 a, Hash8 b)
            => (byte)((uint)a.Value ^ (uint)b.Value);

        [MethodImpl(Inline)]
        public static Hash8 operator & (Hash8 a, Hash8 b)
            => (byte)((uint)a.Value & (uint)b.Value);
    }
}