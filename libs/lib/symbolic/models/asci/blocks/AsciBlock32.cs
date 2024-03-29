//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static sys;

    using A = AsciBlock32;
    using B = ByteBlock32;
    using H = AsciBlock16;
    using N = N32;
    using C = AsciCode;
    using S = AsciSymbol;
    using api = AsciBlocks;

    /// <summary>
    /// Defines 32 bytes of storage
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = Size, Pack=1), ApiComplete]
    public struct AsciBlock32 : IAsciBlock<A>
    {
        public const ushort Size = 32;

        public static N N => default;

        public static A zero() => Empty;

        public A Zero => zero();

        [MethodImpl(Inline)]
        public static A load(ReadOnlySpan<C> src)
            => api.load(src, out A _);

        [MethodImpl(Inline)]
        public static A load(ReadOnlySpan<S> src)
            => api.load(src, out A _);

        [MethodImpl(Inline)]
        public static A encode(string src)
            => api.encode(src, out A _);

        [MethodImpl(Inline)]
        public static A encode(ReadOnlySpan<char> src)
            => api.encode(src, out A _);

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(this);
        }

        public Span<C> Codes
        {
            [MethodImpl(Inline)]
            get => recover<C>(Bytes);
        }

        public Span<S> Symbols
        {
            [MethodImpl(Inline)]
            get => recover<S>(Bytes);
        }

        public ref S this[int index]
        {
            [MethodImpl(Inline)]
            get => ref sys.seek(Symbols,index);
        }

        public ref S this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref sys.seek(Symbols,index);
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
        public static implicit operator A(string src)
            => encode(src);

        [MethodImpl(Inline)]
        public static implicit operator A(ReadOnlySpan<char> src)
            => encode(src);

        [MethodImpl(Inline)]
        public static implicit operator A(ReadOnlySpan<C> src)
            => load(src);

        [MethodImpl(Inline)]
        public static implicit operator A(ReadOnlySpan<S> src)
            => load(src);

        public static A Empty => default;
    }
}