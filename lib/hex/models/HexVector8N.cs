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

    /// <summary>
    /// Defines a natural sequence of 8-bit cells
    /// </summary>
    [DataType("vhex<n:{0},w:8>")]
    public readonly struct HexVector8<N>
        where N : unmanaged, ITypeNat
    {
        readonly Index<Hex8> Data;

        [MethodImpl(Inline)]
        public HexVector8(Hex8[] data)
        {
            Data = data;
        }

        public static ByteSize CellSize => 1;

        public static BitWidth CellWidth => 8;

        public static uint CellCount
        {
            [MethodImpl(Inline)]
            get => (uint)NatValues.value<N>();
        }

        public static ByteSize VectorSize
        {
            [MethodImpl(Inline)]
            get => CellCount*CellSize;
        }

        public static BitWidth VectorWidth
        {
            [MethodImpl(Inline)]
            get => CellCount*CellWidth;
        }

        public ref Hex8 this[uint index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public ref Hex8 this[int index]
        {
            [MethodImpl(Inline)]
            get => ref Data[index];
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(Data);
        }

        [MethodImpl(Inline), Op]
        public uint Bitstring(uint offset, Span<char> dst)
            => HexVector.bitstring<N>(this, offset, dst);

        public string Format()
            => string.Format("<{0}>", Bytes.FormatHex());

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator HexVector8(HexVector8<N> src)
            => new HexVector8(src.Data);
    }
}