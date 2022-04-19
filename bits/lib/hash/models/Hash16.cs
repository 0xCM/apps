//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    [DataType("hash<w:16>")]
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


        public ushort Value {get;}

        [MethodImpl(Inline)]
        public Hash16(ushort value)
            => Value = value;

        public ushort Primitive
        {
            [MethodImpl(Inline)]
           get => Value;
        }

        [MethodImpl(Inline)]
        public string Format()
            => Value.FormatHex(zpad:true, specifier:true, uppercase:true);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator Hash16(ushort src)
            => new Hash16(src);
    }
}