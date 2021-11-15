//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    public ref struct AsciLine
    {
        /// <summary>
        /// The 1-based document-relative line number
        /// </summary>
        public LineNumber LineNumber {get;}

        /// <summary>
        /// The line content
        /// </summary>
        readonly ReadOnlySpan<byte> Data;

        [MethodImpl(Inline)]
        public AsciLine(uint number, uint start, ReadOnlySpan<AsciSymbol> src)
        {
            LineNumber = number;
            Data = recover<AsciSymbol,byte>(src);
        }

        [MethodImpl(Inline)]
        public AsciLine(uint number, uint start, ReadOnlySpan<AsciCode> src)
        {
            LineNumber = number;
            Data = recover<AsciCode,byte>(src);
        }

        [MethodImpl(Inline)]
        public AsciLine(uint number, ReadOnlySpan<byte> src)
        {
            LineNumber = number;
            Data = src;
        }

        public ReadOnlySpan<AsciCode> Codes
        {
            [MethodImpl(Inline)]
            get => recover<byte,AsciCode>(Data);
        }

        public int Length
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public int RenderLength
        {
            [MethodImpl(Inline)]
            get => Data.Length + LineNumber.RenderLength;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Length == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => Length != 0;
        }

        public ref readonly AsciSymbol this[ulong index]
        {
            [MethodImpl(Inline)]
            get => ref @as<byte,AsciSymbol>(skip(Data,index));
        }

        public ref readonly AsciSymbol this[long index]
        {
            [MethodImpl(Inline)]
            get => ref @as<byte,AsciSymbol>(skip(Data,index));
        }

        public string Format()
        {
            Span<char> buffer = stackalloc char[RenderLength];
            var i=0u;
            Lines.render(this, ref i, buffer);
            return text.format(buffer);
        }

        public static AsciLine Empty
        {
            [MethodImpl(Inline)]
            get => new AsciLine(0,default(ReadOnlySpan<byte>));
        }
    }
}