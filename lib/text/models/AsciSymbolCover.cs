//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Linq;

    using static Root;
    using static core;

    public readonly struct AsciSymbolCover
    {
        /// <summary>
        /// The encoded bytes
        /// </summary>
        public readonly AsciSymbol[] Data;

        public Span<byte> ByteEdit
        {
            [MethodImpl(Inline), Op]
            get => recover<AsciSymbol,byte>(span(Data));
        }

        public ReadOnlySpan<byte> ByteView
        {
            [MethodImpl(Inline), Op]
            get => ByteEdit;
        }

        /// <summary>
        /// Returns a reference to the encoded data
        /// </summary>
        public SegRef<AsciSymbol> Ref
        {
            [MethodImpl(Inline), Op]
            get => MemorySegs.segref(first(Data), Data.Length);
        }

        public ref AsciSymbol First
        {
            [MethodImpl(Inline), Op]
            get => ref Data[0];
        }

        public uint Count
        {
            [MethodImpl(Inline), Op]
            get => (uint)Length;
        }

        public int Length
        {
            [MethodImpl(Inline), Op]
            get => Data?.Length ?? 0;
        }

        public uint Size
        {
            [MethodImpl(Inline), Op]
            get => (uint) Length;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline), Op]
            get => Length == 0;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline), Op]
            get => Length > 0;
        }

        public ref AsciSymbol this[uint index]
        {
            [MethodImpl(Inline), Op]
            get => ref Data[index];
        }

        [MethodImpl(Inline), Op]
        public AsciSymbolCover(AsciSymbol[] bytes)
            => Data = bytes ?? new AsciSymbol[0];

        [MethodImpl(Inline), Op]
        public static implicit operator AsciSymbol[](in AsciSymbolCover src)
            => src.Data;

        [MethodImpl(Inline), Op]
        public static implicit operator AsciSymbolCover(AsciSymbol[] src)
            => new AsciSymbolCover(src);

        [MethodImpl(Inline), Op]
        public static implicit operator ReadOnlySpan<byte>(in AsciSymbolCover src)
            => src.ByteEdit;

        [MethodImpl(Inline), Op]
        public static bool operator==(in AsciSymbolCover a, in AsciSymbolCover b)
            => a.Equals(b);

        [MethodImpl(Inline), Op]
        public static bool operator!=(in AsciSymbolCover a, in AsciSymbolCover b)
            => !a.Equals(b);

        [MethodImpl(Inline), Op]
        public bool Equals(AsciSymbolCover src)
        {
            if(IsNonEmpty && src.IsNonEmpty)
                return Data.SequenceEqual(src.Data);
            else
                return false;
        }

        [MethodImpl(Inline), Op]
        public string Format()
            => HexFormatter.format(ByteView, HexFormatSpecs.HexData);

        [MethodImpl(Inline), Op]
        public string Format(in HexFormatOptions config)
            => HexFormatter.format(ByteView, config);

        public override int GetHashCode()
            => Data.GetHashCode();

        public override bool Equals(object src)
            => src is AsciSymbolCover x && Equals(x);

        public override string ToString()
            => Format();

        public static AsciSymbolCover Empty
            => default;
    }
}