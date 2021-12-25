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

        public Identifier TableName {get;}

        public RecordFieldSpec[] Fields{get;}

        [MethodImpl(Inline)]
        public TableSchema(TableId id, Identifier name, RecordFieldSpec[] fields)
        {
            Id = id;
            TableName = name;
            Fields = fields;
        }

        public static TableSchema Empty
            => new TableSchema(TableId.Empty, Identifier.Empty, sys.empty<RecordFieldSpec>());
    }
}