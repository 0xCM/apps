//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct AsciGrid<K>
        where K : unmanaged
    {
        readonly AsciSequence _Data;

        public ushort RowWidth {get;}

        [MethodImpl(Inline)]
        public AsciGrid(AsciSequence src, ushort rows)
        {
            _Data = src;
            RowWidth = rows;
        }

        public ReadOnlySpan<byte> Rows
        {
            [MethodImpl(Inline)]
            get => _Data.View;
        }

        public ushort RowCount
        {
            [MethodImpl(Inline)]
            get => (ushort)(_Data.Length/RowWidth);
        }

        [MethodImpl(Inline)]
        public ReadOnlySpan<byte> Row(ushort index)
            => AsciGrid.row(this, index);

        public string Format()
            => _Data.Format();

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator AsciGrid(AsciGrid<K> src)
            => new AsciGrid(src._Data, src.RowWidth);
    }
}