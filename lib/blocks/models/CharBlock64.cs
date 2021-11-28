//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    using static Root;
    using static core;

    using api = CharBlocks;
    using B = CharBlock64;

    /// <summary>
    /// Defines a character block b with capacity(b) = 64x16u
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Size= (int)SZ, Pack=2)]
    public struct CharBlock64 : ICharBlock<B>
    {
        /// <summary>
        /// The block capacity
        /// </summary>
        public const ushort CharCount = 64;

        /// <summary>
        /// The size of the block, in bytes
        /// </summary>
        public const uint SZ = CharCount * 2;

        CharBlock32 Lo;

        CharBlock32 Hi;

        public Span<char> Data
        {
            [MethodImpl(Inline)]
            get => cover<B,char>(this, CharCount);
        }

        /// <summary>
        /// If the block contains no null-terminators, returns a readonly view of the data source; otherwise
        /// returns the content preceding the first null-terminator
        /// </summary>
        public ReadOnlySpan<char> String
        {
            [MethodImpl(Inline)]
            get => text.@string(Data);
        }

        /// <summary>
        /// Specifies a reference to the leading cell
        /// </summary>
        public ref char First
        {
            [MethodImpl(Inline)]
            get => ref first(Data);
        }

        public uint Capacity
            => CharCount;

        public int Length
        {
            [MethodImpl(Inline)]
            get => api.length(this);
        }

        [MethodImpl(Inline)]
        public ref CharBlock16 Block(N0 n, N16 w)
        {
            ref var c = ref seek(Data,0);
            return ref @as<char,CharBlock16>(c);
        }

        [MethodImpl(Inline)]
        public ref CharBlock16 Block(N1 n, N16 w)
        {
            ref var c = ref seek(Data,16);
            return ref @as<char,CharBlock16>(c);
        }

        [MethodImpl(Inline)]
        public ref CharBlock16 Block(N2 n, N16 w)
        {
            ref var c = ref seek(Data,32);
            return ref @as<char,CharBlock16>(c);
        }

        [MethodImpl(Inline)]
        public ref CharBlock16 Block(N3 n, N16 w)
        {
            ref var c = ref seek(Data,48);
            return ref @as<char,CharBlock16>(c);
        }

        public string Format()
            => TextTools.format(String);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator B(string src)
            => api.init(src, out B dst);

        [MethodImpl(Inline)]
        public static implicit operator string(B src)
            => src.Format();

        [MethodImpl(Inline)]
        public static implicit operator B(ReadOnlySpan<char> src)
            => api.init(src, out B dst);

        public static B Empty => RP.Spaced64;

        public static B Null => default;
    }
}