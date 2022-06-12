//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using api = Lines;

    public ref struct AsciLine
    {
        /// <summary>
        /// The line content
        /// </summary>
        readonly ReadOnlySpan<byte> Data;

        [MethodImpl(Inline)]
        public AsciLine(ReadOnlySpan<AsciSymbol> src)
        {
            Data = recover<AsciSymbol,byte>(src);
        }

        [MethodImpl(Inline)]
        public AsciLine(ReadOnlySpan<AsciCode> src)
        {
            Data = recover<AsciCode,byte>(src);
        }

        [MethodImpl(Inline)]
        public AsciLine(ReadOnlySpan<byte> src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public AsciLine(Span<byte> src)
        {
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

        [MethodImpl(Inline)]
        public uint Render(Span<char> dst)
        {
            var i=0u;
            return AsciLines.render(this, ref i, dst);
        }

        public string Format()
            => api.format(this);
        // {
        //     Span<char> buffer = stackalloc char[RenderLength];
        //     var i=0u;
        //     AsciLines.render(this, ref i, buffer);
        //     return text.format(buffer);
        // }

        public static AsciLine Empty
        {
            [MethodImpl(Inline)]
            get => new AsciLine(default(ReadOnlySpan<byte>));
        }
    }
}