//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public class BitfieldSeg<S,T>
        where S : unmanaged
        where T : unmanaged
    {
        protected ClosedInterval<byte> SegRange {get;}

        public S Mask {get;}

        public byte MinPos
        {
            [MethodImpl(Inline)]
            get => SegRange.Min;
        }

        public byte MaxPos
        {
            [MethodImpl(Inline)]
            get => SegRange.Max;
        }

        public byte Width
        {
            [MethodImpl(Inline)]
            get => (byte)(MaxPos - MinPos + 1);
        }

        S SourceValue;

        public T Value
        {
            [MethodImpl(Inline)]
            get => @as<S,T>(Bitfields.extract(SourceValue, SegRange.Min, SegRange.Max));

            [MethodImpl(Inline)]
            set => SourceValue = Bitfields.or(Bitfields.scatter(@as<T,S>(value), Mask), Bitfields.and(SourceValue, Bitfields.not(Mask)));
        }

        public BitfieldSeg(S mask, ClosedInterval<byte> seg)
        {
            Mask = mask;
            SegRange = seg;
        }

        [MethodImpl(Inline)]
        public S Source()
            => SourceValue;

        [MethodImpl(Inline)]
        public void Source(S src)
            => SourceValue = src;

        [MethodImpl(Inline)]
        public byte Render(Span<char> dst)
            => (byte)BitRender.render(bytes(Value), Width, dst);

        [MethodImpl(Inline)]
        public byte Render(uint offset, Span<char> dst)
            => (byte)BitRender.render(bytes(Value), Width, slice(dst,offset));
    }
}