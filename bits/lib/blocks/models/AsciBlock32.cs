//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using A = AsciBlock32;
    using B = ByteBlock32;
    using H = AsciBlock16;

    using api = AsciBlocks;

    /// <summary>
    /// Defines 32 bytes of storage
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = Size, Pack=1)]
    [DataWidth(Size*8,Size*8)]
    public struct AsciBlock32 : IAsciBlock<A>
    {
        public const ushort Size = 32;

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(this);
        }

        public Span<AsciCode> Codes
        {
            [MethodImpl(Inline)]
            get => recover<AsciCode>(Bytes);
        }

        public ref AsciCode this[int index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Codes,index);
        }

        public ref AsciCode this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref seek(Codes,index);
        }

        public ref byte First
        {
            [MethodImpl(Inline)]
            get => ref first(Bytes);
        }

        public ref H Lo
        {
            [MethodImpl(Inline)]
            get => ref @as<H>(First);
        }

        public ref H Hi
        {
            [MethodImpl(Inline)]
            get => ref seek(@as<H>(First), 1);
        }

        [MethodImpl(Inline)]
        public Span<T> Storage<T>()
            where T : unmanaged
                => recover<T>(Bytes);

        public ReadOnlySpan<char> Chars
        {
            [MethodImpl(Inline)]
            get => api.decode(this);
        }

        public string Format()
            => text.format(Chars);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator B(A src)
            => @as<A,B>(src);

        [MethodImpl(Inline)]
        public static implicit operator A(ReadOnlySpan<AsciCode> src)
            => api.load(src, out A _);

        [MethodImpl(Inline)]
        public static implicit operator A(string src)
            => api.encode(src, out A _);

        [MethodImpl(Inline)]
        public static implicit operator A(ReadOnlySpan<char> src)
            => api.encode(src, out A _);

        public static A Empty => default;
    }
}