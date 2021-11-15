//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct RowType : IRowType
    {
        public TableId Table {get;}

        [MethodImpl(Inline)]
        public RowType(TableId id)
            => Table = id;

       public override string ToString()
            => Format();
        public string Format()
            => Table.Format();

        [MethodImpl(Inline)]
        public static implicit operator RowType(TableId src)
            => new RowType(src);
    }
}