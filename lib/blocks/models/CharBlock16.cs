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

    using B = CharBlock16;
    using api = CharBlocks;

    /// <summary>
    /// Defines a character block b with capacity(b) = 16x16u
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack=2, Size=(int)Size), DataType("block<n:16,t:c16>")]
    public struct CharBlock16 : ICharBlock<B>
    {
        /// <summary>
        /// The block capacity
        /// </summary>
        public const ushort CharCount = 16;

        /// <summary>
        /// The size of the block, in bytes
        /// </summary>
        public const uint Size = CharCount*2;

        CharBlock8 Lo;

        CharBlock8 Hi;

        /// <summary>
        /// The block content presented as an editable buffer
        /// </summary>
        public Span<char> Data
        {
            [MethodImpl(Inline)]
            get => cover<B,char>(this, CharCount);
        }

        /// <summary>
        /// Specifies a reference to the leading cell
        /// </summary>
        public ref char First
        {
            [MethodImpl(Inline)]
            get => ref first(Data);
        }

        public ref char this[uint i]
        {
            [MethodImpl(Inline)]
            get => ref seek(First,i);
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

        public uint Capacity
            => CharCount;

        public int Length
        {
            [MethodImpl(Inline)]
            get => api.length(this);
        }

        public string Format()
            => text.format(String);

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

        public static B Empty => RP.Spaced16;

        public static B Null => default;
    }
}