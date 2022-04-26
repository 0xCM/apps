//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    /// <summary>
    /// Specifies the presence of a bit and,if present, specifies its state
    /// </summary>
    [DataWidth(Width, 2)]
    public readonly record struct BitIndicator : IIndicator<BitIndicator,bit>
    {
        [MethodImpl(Inline)]
        public static BitIndicator defined(bit state)
            => new BitIndicator(state, 1);

        public const byte Width = uint2.Width;

        readonly byte Data;

        [MethodImpl(Inline)]
        public BitIndicator(bit state, bit enabled)
        {
            var data = 0u;
            data |= (uint)state;
            data |= (uint)enabled << 1;
            Data = (byte)data;
        }

        public bit Value
        {
            [MethodImpl(Inline)]
            get => bit.test(Data,0);
        }

        public bit Enabled
        {
            [MethodImpl(Inline)]
            get => bit.test(Data,1);
        }

        public bit Disabled
        {
            [MethodImpl(Inline)]
            get => !bit.test(Data,1);
        }

        [MethodImpl(Inline)]
        public int CompareTo(BitIndicator src)
            => Data.CompareTo(src.Data);

        public string Format()
            => Disabled ? EmptyString : Value.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static explicit operator bit(BitIndicator src)
            => src.Value;

        [MethodImpl(Inline)]
        public static explicit operator byte(BitIndicator src)
            => src.Value;

        public static BitIndicator Empty => default;
    }
}