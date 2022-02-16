//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    public readonly struct AsmAddressLabel : IAsmSourcePart
    {
        public readonly MemoryAddress Address;

        [MethodImpl(Inline)]
        public AsmAddressLabel(MemoryAddress address)
        {
            Address = address;
        }

        public AsmPartKind PartKind
        {
            [MethodImpl(Inline)]
            get => AsmPartKind.Label;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Address == ulong.MaxValue;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => !IsEmpty;
        }

        public string Format()
            => string.Format("_@{0}:", Address);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmAddressLabel(MemoryAddress src)
            => new AsmAddressLabel(src);

        [MethodImpl(Inline)]
        public static implicit operator MemoryAddress(AsmAddressLabel src)
            => src.Address;

        public static AsmAddressLabel Empty => new AsmAddressLabel(ulong.MaxValue);
    }
}