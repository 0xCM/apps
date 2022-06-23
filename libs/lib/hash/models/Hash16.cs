//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct Hash16 : IHashCode<ushort,ushort>
    {
        [Parser]
        public static Outcome parse(string src, out Hash16 dst)
        {
            var result = Hex16.parse(src, out var hex);
            dst = 0;
            if(result)
                dst = (ushort)hex;
            return result;
        }

        public readonly ushort Value;

        [MethodImpl(Inline)]
        public Hash16(ushort value)
            => Value = value;

        public ushort Primitive
        {
            [MethodImpl(Inline)]
           get => Value;
        }

        ushort IHashCode<ushort>.Value
            => Value;

        [MethodImpl(Inline)]
        public string Format()
            => Value.FormatHex(zpad:true, specifier:true, uppercase:true);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Hash16(ushort src)
            => new Hash16(src);

        [MethodImpl(Inline)]
        public static Hash32 operator | (Hash16 a, Hash16 b)
            => (uint)a.Value | ((uint)b.Value << 16);

        [MethodImpl(Inline)]
        public static Hash16 operator ^ (Hash16 a, Hash16 b)
            => (ushort)((uint)a.Value ^ (uint)b.Value);

        [MethodImpl(Inline)]
        public static Hash16 operator & (Hash16 a, Hash16 b)
            => (ushort)((uint)a.Value & (uint)b.Value);
    }
}