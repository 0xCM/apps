//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct SegVar
    {
        public static SegVar parse(ReadOnlySpan<char> src)
        {
            var data = 0ul;
            var count = min(src.Length, MaxLength);
            for(var i=z8; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                var c5 = Char5.parse(c);
                if(c5.IsNonEmpty)
                    data |= ((ulong)c5 << i*SegWidth);
                else
                    break;
            }
            return new SegVar(data);
        }

        public static SegVar literal(byte n, byte value)
        {
            var bits = span(string.Format("0b{0}",value.ToBitVector8().Format()));
            return parse(slice(bits,0, n + 2));
        }

        public const byte MaxLength = 12;

        const byte SegWidth = 5;

        readonly ulong Data;

        [MethodImpl(Inline)]
        public SegVar(ulong data)
        {
            Data = data;
        }

        [MethodImpl(Inline)]
        public SegVar(Char5 c)
        {
            Data = c;
        }

        [MethodImpl(Inline)]
        public SegVar(Char5 c0, Char5 c1)
        {
            Data = (ulong)c0 | ((ulong)c1 << 5);
        }

        [MethodImpl(Inline)]
        public SegVar(Char5 c0, Char5 c1, Char5 c2)
        {
            Data = (ulong)c0 | ((ulong)c1 << 5) | ((ulong)c2 << 10);
        }

        [MethodImpl(Inline)]
        public SegVar(Char5 c0, Char5 c1, Char5 c2, Char5 c3)
        {
            Data = (ulong)c0 | ((ulong)c1 << 5) | ((ulong)c2 << 10) | ((ulong)c3 << 15);
        }

        [MethodImpl(Inline)]
        public SegVar(Char5 c0, Char5 c1, Char5 c2, Char5 c3, Char5 c4)
        {
            Data = (ulong)c0 | ((ulong)c1 << 5) | ((ulong)c2 << 10) | ((ulong)c3 << 15) | ((ulong)c4 << 20);
        }

        [MethodImpl(Inline)]
        public SegVar(ReadOnlySpan<Char5> src)
        {
            var dst = 0ul;
            var count = core.min(src.Length, MaxLength);
            for(var i=0; i<count; i++)
                dst |= ((ulong)skip(src,i) << (i*SegWidth));
            Data = dst;
        }

        [MethodImpl(Inline)]
        public Char5 Char(byte index)
            => (Char5.Code)((Data >> (index*SegWidth)) & uint5.MaxValue);

        public Char5 this[byte index]
        {
            [MethodImpl(Inline)]
            get => Char(index);
        }

        [MethodImpl(Inline)]
        byte CountChars()
        {
            var w = bits.effwidth(Data);
            var d = w / SegWidth;
            var m = w % SegWidth;
            return (byte)(m == 0 ? d : d+1);
        }

        public byte Length
        {
            [MethodImpl(Inline)]
            get => CountChars();
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data != 0;
        }

        public string Format()
        {
            var dst = CharBlock12.Empty;
            var buffer = dst.Data;
            var count = Length;
            for(var i=z8; i<count; i++)
                seek(buffer,i) = this[i];
            return new string(slice(dst.Data, 0, count));
        }

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static explicit operator ulong(SegVar src)
            => src.Data;

        [MethodImpl(Inline)]
        public static explicit operator SegVar(ulong src)
            => new SegVar(src);
    }
}