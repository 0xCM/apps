//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0.Asm
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    /// <summary>
    /// Defines a sequence of bits that specifies an instruction encoding
    /// </summary>
    public readonly struct AsmBitstring
    {
        [MethodImpl(Inline), Op]
        public static uint render(in AsmHexCode src, Span<char> dst)
        {
            var i=0u;
            return BitRender.render8x4(slice(src.Bytes, 0, src.Size), ref i, dst);
        }

        [Op]
        public static uint bitstring(ReadOnlySpan<byte> src, Span<char> dst)
        {
            var i=0u;
            return BitRender.render8x4(src, ref i, dst);
        }

        [Op]
        public static AsmBitstring bitstring(in AsmHexCode src)
        {
            if(src.IsEmpty)
                return default;

            CharBlocks.alloc(n256, out var block);
            var dst = block.Data;
            var count = render(src, dst);
            if(count == 0)
                return Empty;

            return new AsmBitstring(text.format(slice(dst, 0, count)));
        }

        readonly TextBlock Data {get;}

        [MethodImpl(Inline)]
        internal AsmBitstring(string src)
        {
            Data = src;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => Data.IsEmpty;
        }

        public uint Hash
        {
            [MethodImpl(Inline)]
            get => Data.Hash;
        }

        public string Format()
            => Data;

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsmBitstring(AsmHexCode src)
            => bitstring(src);

        public static AsmBitstring Empty
        {
            [MethodImpl(Inline)]
            get => new AsmBitstring(TextBlock.Empty);
        }
    }
}