//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    /// <summary>
    /// Covers a sequence of asci-encoded bytes
    /// </summary>
    public readonly struct AsciSeq : IAsciSeq
    {
        public static string format(AsciSeq src)
            => format(src.Storage.ToReadOnlySpan());

        static string format(ReadOnlySpan<byte> src)
        {
            var len = src.Length;
            var dst = span(alloc<char>(len));
            for(var i=0u; i<len; i++)
                seek(dst, i) = (char)skip(src,i);
            return text.format(dst);
        }

        public readonly BinaryCode Data;

        public readonly uint Capacity;

        [MethodImpl(Inline)]
        public AsciSeq(BinaryCode src)
        {
            Data = src;
            Capacity = src.Size;
        }

        public ByteSize Size
        {
            [MethodImpl(Inline)]
            get => Data.Size;
        }

        public BitWidth Width
        {
            [MethodImpl(Inline)]
            get => Data.Width;
        }

        public byte[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
        }

        public Hash32 Hash
        {
            [MethodImpl(Inline)]
            get => Data.Hash;
        }

        public Span<AsciCode> Codes
        {
            [MethodImpl(Inline)]
            get => recover<byte,AsciCode>(Data.Edit);
        }

        public Span<AsciSymbol> Symbols
        {
            [MethodImpl(Inline)]
            get => recover<byte,AsciSymbol>(Data.Edit);
        }

        public ReadOnlySpan<byte> Cells
        {
            [MethodImpl(Inline)]
            get => View;
        }

        public Span<byte> Edit
        {
            [MethodImpl(Inline)]
            get => Data.Edit;
        }

        public ref AsciSymbol this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Symbols,index);
        }

        public ref AsciSymbol this[int index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Symbols,index);
        }

        public ReadOnlySpan<byte> View
        {
            [MethodImpl(Inline)]
            get => Data.View;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public TextBlock Text
        {
            [MethodImpl(Inline)]
            get => Format();
        }

        int IByteSeq.Length
            => (int)Capacity;

        int IByteSeq.Capacity
            => (int)Capacity;

        public bool IsBlank
        {
            [MethodImpl(Inline)]
            get => SQ.whitespace(Codes);
        }

        public bool IsNull
        {
            [MethodImpl(Inline)]
            get => SQ.@null(Codes);
        }

        public string Format()
            => format(this);

        public override string ToString()
            => Format();
    }
}