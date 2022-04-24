//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct BfVar
    {
        public static BfVar parse(ReadOnlySpan<char> src)
        {
            var data = 0ul;
            var count = min(src.Length, MaxCount);
            for(var i=z8; i<count; i++)
            {
                ref readonly var c = ref skip(src,i);
                var c5 = Char5.parse(c);
                if(c5.IsNonEmpty)
                    data |= ((ulong)c5 << i*SegWidth);
                else
                    break;
            }
            return new BfVar(data);
        }

        const byte MaxCount = 12;

        const byte SegWidth = 5;

        readonly ulong Data;

        [MethodImpl(Inline)]
        BfVar(ulong data)
        {
            Data = data;
        }

        [MethodImpl(Inline)]
        public BfVar(Char5 c)
        {
            Data = c;
        }

        [MethodImpl(Inline)]
        public BfVar(Char5 c0, Char5 c1)
        {
            Data = (ulong)c0 | ((ulong)c1 << 5);
        }

        [MethodImpl(Inline)]
        public BfVar(Char5 c0, Char5 c1, Char5 c2)
        {
            Data = (ulong)c0 | ((ulong)c1 << 5) | ((ulong)c2 << 10);
        }

        [MethodImpl(Inline)]
        public BfVar(Char5 c0, Char5 c1, Char5 c2, Char c3)
        {
            Data = (ulong)c0 | ((ulong)c1 << 5) | ((ulong)c2 << 10) | ((ulong)c3 << 15);
        }

        [MethodImpl(Inline)]
        public BfVar(params Char5[] src)
        {
            var dst = 0ul;
            var count = core.min(src.Length, MaxCount);
            for(var i=0; i<count; i++)
                dst |= ((ulong)skip(src,i) << (i*SegWidth));
            Data = dst;
        }

        [MethodImpl(Inline)]
        public Char5 Char(byte index)
            => (Char5)((Data >> (index*SegWidth)) & uint5.MaxValue);

        public Char5 this[byte index]
        {
            [MethodImpl(Inline)]
            get => Char(index);
        }

        public byte CharCount
        {
            [MethodImpl(Inline)]
            get => math.div(bits.effwidth(Data), SegWidth);
        }

        public string Format()
        {
            var dst = CharBlock12.Empty;
            var buffer = dst.Data;
            var count = CharCount;
            for(var i=z8; i<count; i++)
                seek(buffer,i) = this[i];
            return new string(slice(dst.Data, 0, count));
        }

        public override string ToString()
            => Format();
    }
}