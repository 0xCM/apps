//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public class TableDb
    {
        ConstLookup<TableId,TableDef> _Defs;

        public TableDb(TableDef[] schemas)
        {
            _Defs = schemas.Map(s => (s.TableId, s)).ToConstLookup();
        }

        public bool Schema(TableId table, out TableDef schema)
            => _Defs.Find(table, out schema);

        public ReadOnlySpan<TableDef> TableDefs
        {
            [MethodImpl(Inline)]
            get => _Defs.Values;
        }

        public ReadOnlySpan<TableId> TableNames
        {
            [MethodImpl(Inline)]
            get => _Defs.Keys;
        }
    }
}