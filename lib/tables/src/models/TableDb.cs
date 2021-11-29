//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Collections.Generic;

    using static Root;

    public class TableDb
    {
        ConstLookup<TableId, TableSchema> _Schemas;

        public TableDb(TableSchema[] schemas)
        {
            _Schemas = schemas.Map(s => (s.Id, s)).ToConstLookup();
        }


        public bool Schema(TableId table, out TableSchema schema)
            => _Schemas.Find(table, out schema);

        public ReadOnlySpan<TableSchema> TableSchemas
        {
            [MethodImpl(Inline)]
            get => _Schemas.Values;
        }

        public ReadOnlySpan<TableId> TableNames
        {
            [MethodImpl(Inline)]
            get => _Schemas.Keys;
        }
    }
}