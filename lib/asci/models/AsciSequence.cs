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
    public readonly struct AsciSequence : IAsciSeq
    {
        [MethodImpl(Inline), Op]
        public static AsciSequence create(uint size)
            => new AsciSequence(alloc<byte>(size));

        [MethodImpl(Inline), Op]
        public static AsciSequence create(byte[] src)
            => new AsciSequence(src);

        [MethodImpl(Inline), Op]
        public static int search(in byte src, int count, byte match)
        {
            for(var i=0u; i<count; i++)
                if(skip(src,i) == match)
                    return (int)i;
            return NotFound;
        }

        [MethodImpl(Inline), Op]
        public static int search(ReadOnlySpan<byte> src, byte match)
        {
            var count = src.Length;
            for(var i=0u; i<count; i++)
                if(skip(src, i) == match)
                    return (int)i;
            return NotFound;
        }

        [MethodImpl(Inline), Op]
        public static int length(ReadOnlySpan<byte> src)
            => foundnot(search(src, 0), src.Length);

        public static string format(in AsciSequence src)
            => format(src.Storage.ToReadOnlySpan());

        public static string format(in ReadOnlySpan<byte> src)
        {
            var len = src.Length;
            var dst = span(alloc<char>(len));
            for(var i=0u; i<len; i++)
                seek(dst, i) = (char)skip(src,i);
            return text.format(dst);
        }

        public static string format(in AsciSequence src, uint length)
        {
            var size = min(src.Capacity,length);
            var data = slice(src.Data.View,0,size);
            var dst = alloc<char>(size);
            for(var i=0u; i<size; i++)
                seek(dst, i) = src[i];
            return text.format(dst);
        }

        public static uint render(in AsciSequence src, uint length, Span<char> dst)
        {
            var size = min(src.Capacity,length);
            var data = slice(src.Data.View,0,size);
            for(var i=0u; i<size; i++)
                seek(dst, i) = src[i];
            return size;
        }

        readonly BinaryCode Data;

        public readonly uint Capacity;

        [MethodImpl(Inline)]
        public AsciSequence(BinaryCode src)
        {
            Data = src;
            Capacity = src.Size;
        }

        public uint Size
        {
            [MethodImpl(Inline)]
            get => Data.Size;
        }

        public byte[] Storage
        {
            [MethodImpl(Inline)]
            get => Data.Storage;
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

        public string Format()
            => format(this);

        public override string ToString()
            => Format();
    }
}