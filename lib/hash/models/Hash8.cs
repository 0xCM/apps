//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [DataType("hash<w:8>")]
    public readonly struct Hash8 : IHashCode<byte,byte>
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

        public string Format()
            => Value.FormatHex(zpad:true, specifier:true, uppercase:true);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Hash8(byte src)
            => new Hash8(src);

        [MethodImpl(Inline)]
        public static implicit operator Hash<byte,byte>(Hash8 src)
            => new Hash<byte,byte>(src.Value);
    }
}