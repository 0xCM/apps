//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly record struct LiteralBits : IComparable<LiteralBits>
    {
        public static Outcome parse(string src, out LiteralBits dst)
        {
            var result = Outcome.Success;
            dst = LiteralBits.Empty;
            var n = z8;
            if(text.begins(src, "0b"))
            {
                var input = text.trim(text.remove(text.replace(src,"0b",EmptyString), Chars.Underscore));
                n = (byte)input.Length;
                if(n > 6)
                {
                    result = (false, "Unsupported bit length");
                }
                else
                {
                    var data = span(input);
                    var storage = ByteBlock8.Empty;
                    var buffer = recover<bit>(storage.Bytes);
                    var k=n-1;
                    for(var i=0; i<n; i++,k--)
                    {
                        ref readonly var c = ref skip(data,i);
                        if(c == '0')
                            buffer[k] = bit.Off;
                        else if(c == '1')
                            buffer[k] = bit.On;
                        else
                        {
                            result = (false, $"Unsupported character '{c}'");
                            break;
                        }
                    }

                    if(result)
                        dst = new LiteralBits(n, BitPack.scalar<byte>(buffer));
                }
            }
            return result;
        }

        readonly byte Data;

        [MethodImpl(Inline)]
        internal LiteralBits(byte n, byte value)
        {
            Data = (byte)((uint)n << 5 | (uint)value);
        }

        public byte N
        {
            [MethodImpl(Inline)]
            get => (byte)(Data >> 5);
        }

        public byte Value
        {
            [MethodImpl(Inline)]
            get => (byte)(Data & uint5.MaxValue);
        }

        public string Format()
        {
            var dst = EmptyString;
            switch(N)
            {
                case 1:
                {
                    uint1 value = Value;
                    dst = string.Format("0b{0}",value);
                    break;
                }
                case 2:
                {
                    uint2 value = Value;
                    dst = string.Format("0b{0}",value);
                    break;
                }
                case 3:
                {
                    uint3 value = Value;
                    dst = string.Format("0b{0}",value);
                    break;
                }
                case 4:
                {
                    uint4 value = Value;
                    dst = string.Format("0b{0}",value);
                    break;
                }
                case 5:
                {
                    uint5 value = Value;
                    dst = string.Format("0b{0}",value);
                    break;
                }
                case 6:
                {
                    uint6 value = Value;
                    dst = string.Format("0b{0}",value);
                    break;
                }
            }
            return dst;
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public int CompareTo(LiteralBits src)
            => Value.CompareTo(src.Value);

        [MethodImpl(Inline)]
        public static implicit operator byte(LiteralBits src)
            => src.Value;

        [MethodImpl(Inline)]
        public static implicit operator LiteralBits(uint5 src)
            => new LiteralBits(5,src);

        [MethodImpl(Inline)]
        public static implicit operator LiteralBits(uint4 src)
            => new LiteralBits(4,src);

        [MethodImpl(Inline)]
        public static implicit operator LiteralBits(uint3 src)
            => new LiteralBits(3,src);

        [MethodImpl(Inline)]
        public static implicit operator LiteralBits(uint2 src)
            => new LiteralBits(2,src);

        [MethodImpl(Inline)]
        public static implicit operator LiteralBits(uint1 src)
            => new LiteralBits(1,src);

        [MethodImpl(Inline)]
        public static implicit operator LiteralBits(bit src)
            => new LiteralBits(1,src);

        [MethodImpl(Inline)]
        public static implicit operator LiteralBits(num5 src)
            => new LiteralBits(5,src);

        [MethodImpl(Inline)]
        public static implicit operator LiteralBits(num4 src)
            => new LiteralBits(4,src);

        [MethodImpl(Inline)]
        public static implicit operator LiteralBits(num3 src)
            => new LiteralBits(3,src);

        [MethodImpl(Inline)]
        public static implicit operator LiteralBits(num2 src)
            => new LiteralBits(2,src);

        [MethodImpl(Inline)]
        public static implicit operator LiteralBits(num1 src)
            => new LiteralBits(1,src);

        public static LiteralBits Empty => default;
    }
}