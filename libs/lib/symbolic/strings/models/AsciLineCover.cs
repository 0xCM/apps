//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    public ref struct AsciLineCover
    {
        /// <summary>
        /// The line content
        /// </summary>
        readonly ReadOnlySpan<byte> Data;

        [MethodImpl(Inline)]
        public AsciLineCover(ReadOnlySpan<AsciSymbol> src)
        {
            Data = recover<AsciSymbol,byte>(src);
        }

        [MethodImpl(Inline)]
        public AsciLineCover(ReadOnlySpan<AsciCode> src)
        {
            Data = recover<AsciCode,byte>(src);
        }

        [MethodImpl(Inline)]
        public AsciLineCover(ReadOnlySpan<byte> src)
        {
            Data = src;
        }

        [MethodImpl(Inline)]
        public AsciLineCover(Span<byte> src)
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
            return render(this, ref i, dst);
        }

        public static uint render(in AsciLineCover src, ref uint i, Span<char> dst)
        {
            var i0 = i;
            if(src.IsNonEmpty)
                text.render(src.Codes, ref i, dst);
            return i - i0;
        }

        [Op]
        public static string format<T>(in AsciLineCover<T> src)
            where T : unmanaged
        {
            Span<char> buffer = stackalloc char[src.RenderLength];
            var i=0u;
            text.render(recover<T,AsciCode>(src.View), ref i, buffer);
            return text.format(buffer);
        }

        public static string format(in AsciLineCover src)
        {
            Span<char> buffer = stackalloc char[src.RenderLength];
            var i=0u;
            text.render(src.Codes, ref i, buffer);
            return text.format(buffer);
        }

        public string Format()
            => format(this);

        public static AsciLineCover Empty
        {
            [MethodImpl(Inline)]
            get => new AsciLineCover(default(ReadOnlySpan<byte>));
        }
    }
}