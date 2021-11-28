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

    /// <summary>
    /// Defines a natural sequence of 4-bit cells
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct HexVector4
    {
        readonly Index<byte> Data;

        [MethodImpl(Inline)]
        public HexVector4(byte[] data)
        {
            Data = data;
        }

        public BitWidth CellWidth => 4;

        public uint CellCount
        {
            [MethodImpl(Inline)]
            get => (uint)Data.Length * 2;
        }

        public ByteSize VectorSize
        {
            [MethodImpl(Inline)]
            get => Data.Length;
        }

        public Span<byte> Bytes
        {
            [MethodImpl(Inline)]
            get => bytes(Data);
        }
    }
}