//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct BinaryDigits : IIndex<BinaryDigit>
    {
        readonly Index<BinaryDigit> Data;

        [MethodImpl(Inline)]
        public BinaryDigits(BinaryDigit[] src)
        {
            Data = src;
        }

        public ReadOnlySpan<BinaryDigit> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsNonEmpty;
        }

        public BinaryDigit[] Storage
        {
            [MethodImpl(Inline)]
            get => Data;
        }

        public ref BinaryDigit this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public ref BinaryDigit this[int i]
        {
            [MethodImpl(Inline)]
            get => ref Data[i];
        }

        public uint Count
        {
            [MethodImpl(Inline)]
            get => Data.Count;
        }

        public string Format()
            => Digital.format(Storage);

        public override string ToString()
            => Format();

        public static BinaryDigits Empty => new BinaryDigits(sys.empty<BinaryDigit>());
    }
}