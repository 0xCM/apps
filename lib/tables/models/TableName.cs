//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TableName : INullity, ITextual
    {
        public Identifier TableSchema {get;}

        public TableId TableId {get;}

        [MethodImpl(Inline)]
        public TableName(Identifier schema, TableId id)
        {
            TableSchema = schema;
            TableId = id;
        }

        public bool IsEmpty
        {
            [MethodImpl(Inline)]
            get => TableSchema.IsEmpty || TableId.IsEmpty;
        }

        public bool IsNonEmpty
        {
            [MethodImpl(Inline)]
            get => TableSchema.IsNonEmpty && TableId.IsNonEmpty;
        }

        public string Format()
            => string.Format("{0}.{1}", TableSchema, TableId);

        public override string ToString()
            => Format();

        [MethodImpl(Inline)]
        public static implicit operator TableName((string schema, string id) src)
            => new TableName(src.schema, TableId.define(src.id));
    }
}