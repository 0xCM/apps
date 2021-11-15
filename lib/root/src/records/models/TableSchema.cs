//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TableSchema
    {
        public TableId Id {get;}

        public RecordFieldSpec[] Fields{get;}

        [MethodImpl(Inline)]
        public TableSchema(TableId id, RecordFieldSpec[] fields)
        {
            Id = id;
            Fields = fields;
        }

        public static TableSchema Empty
            => default;
    }
}