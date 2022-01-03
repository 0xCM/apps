//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;

    public readonly struct TableDef
    {
        public TableId TableId {get;}

        public Identifier TypeName {get;}

        public TableFieldDef[] Fields {get;}

        [MethodImpl(Inline)]
        public TableDef(TableId id, Identifier name, TableFieldDef[] fields)
        {
            TableId = id;
            TypeName = name;
            Fields = fields;
        }

        public static TableDef Empty
            => new TableDef(TableId.Empty, Identifier.Empty, sys.empty<TableFieldDef>());
    }
}