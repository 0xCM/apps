//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public readonly struct NativeTypeSeq : ISeq<N16,NativeType>
    {
        readonly ByteBlock32 Storage;

        static N16 N => default;

        Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => Storage.Bytes;
        }

        public byte MaxCount
        {
            [MethodImpl(Inline)]
            get => (byte)N.NatValue;
        }

        public byte Count
        {
            [MethodImpl(Inline)]
            get => NativeTypes.nonempty(this);
        }

        public Span<NativeType> Edit
        {
            [MethodImpl(Inline)]
            get => recover<NativeType>(Bytes);
        }

        public ReadOnlySpan<NativeType> View
        {
            [MethodImpl(Inline)]
            get => recover<NativeType>(Bytes);
        }

        public ref NativeType this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Edit,i);
        }

        public ref NativeType this[int i]
        {
            [MethodImpl(Inline)]
            get => ref seek(Edit,i);
        }
    }
}