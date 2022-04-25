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
    public readonly record struct BitIndicator : IComparable<BitIndicator>
    {
        [MethodImpl(Inline)]
        public static BitIndicator defined(bit state)
            => new BitIndicator(state, 1);

        public static BitIndicator Undefined => default;

        public static BitIndicator Disabled => new BitIndicator(bit.Off, bit.On);

        public static BitIndicator Enabled => new BitIndicator(bit.On, bit.On);

        public const byte Width = uint2.Width;

        readonly byte Data;

        [MethodImpl(Inline)]
        public BitIndicator(bit state, bit defined)
        {
            var data = 0u;
            data |= (uint)state;
            data |= (uint)defined << 1;
            Data = (byte)data;
        }

        public bit State
        {
            [MethodImpl(Inline)]
            get => bit.test(Data,0);
        }

        public bool IsDefined
        {
            [MethodImpl(Inline)]
            get => bit.test(Data,1);
        }

        public bool IsUndefined
        {
            [MethodImpl(Inline)]
            get => !bit.test(Data,1);
        }

        public bool IsEnabled
        {
            [MethodImpl(Inline)]
            get => bit.test(Data,1) && State;
        }

        public bool IsDisabled
        {
            [MethodImpl(Inline)]
            get => IsDefined && !bit.test(Data,0);
        }

        [MethodImpl(Inline)]
        public int CompareTo(BitIndicator src)
            => Data.CompareTo(src.Data);

        public string Format()
            => IsUndefined ? EmptyString : State.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static explicit operator bit(BitIndicator src)
            => src.State;

        [MethodImpl(Inline)]
        public static explicit operator byte(BitIndicator src)
            => src.State;

        public static BitIndicator Empty => default;
    }
}