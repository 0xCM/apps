//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.InteropServices;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using A = AsciBlock16;
    using B = ByteBlock16;
    using H = AsciBlock8;

    using api = AsciBlocks;

    /// <summary>
    /// Defines 16 bytes of storage
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size = Size, Pack=1)]
    public struct AsciBlock16 : IAsciBlock<A>, IReifiedType<N16,A>
    {
        public const ushort Size = 16;

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
        public Span<T> Storage<T>()
            where T : unmanaged
                => recover<T>(Bytes);

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