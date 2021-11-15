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

    public readonly struct AsciGrid
    {
        [Op, Closures(UInt8k)]
        public static ReadOnlySpan<byte> row<T>(in AsciGrid<T> src, ushort index)
            where T : unmanaged
        {
            var offset = index*src.RowWidth;
            return slice(src.Rows, offset, src.RowWidth);
        }

        [Op, Closures(UInt8k)]
        public static ReadOnlySpan<byte> row(in AsciGrid src, ushort index)
        {
            var offset = index*src.RowWidth;
            return slice(src.Rows, offset, src.RowWidth);
        }

        readonly AsciSequence _Data;

        public ushort RowWidth {get;}

        public ushort RowCount
        {
            [MethodImpl(Inline)]
            get => (ushort)(_Data.Length/RowWidth);
        }

        [MethodImpl(Inline)]
        public AsciGrid(AsciSequence src, ushort width)
        {
            _Data = src;
            RowWidth = width;
        }

        public ReadOnlySpan<byte> Rows
        {
            [MethodImpl(Inline)]
            get => _Data.View;
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> Row(ushort index)
            => row(this, index);

        public string Format()
            => _Data.Format();

        public override string ToString()
            => Format();
    }
}