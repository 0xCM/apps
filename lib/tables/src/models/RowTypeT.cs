//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct RowType<T> : IRowType<T>
        where T : struct, IRecord<T>
    {
        public TableId<T> Table {get;}

        [MethodImpl(Inline)]
        public RowType(TableId<T> id)
            => Table = id;

        public override string ToString()
            => Format();
        public string Format()
            => Table.Format();

        [MethodImpl(Inline)]
        public static implicit operator RowType<T>(TableId<T> src)
            => new RowType<T>(src);

        [MethodImpl(Inline)]
        public static implicit operator RowType(RowType<T> src)
            => new RowType(src.Table);
    }
}