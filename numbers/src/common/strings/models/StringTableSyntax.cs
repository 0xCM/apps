//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    public readonly struct StringTableSpec
    {
        [MethodImpl(Inline), Op]
        public static StringTableSpec define(Identifier tableNs, Identifier tableName, Identifier indexNs, Identifier indexName, ClrEnumKind @base, bool emitIndex = true)
            => new StringTableSpec(tableNs, tableName, indexName, indexNs, @base, true, emitIndex);

        public readonly Identifier TableNs;

        public readonly Identifier TableName;

        public readonly Identifier IndexName;

        public readonly ClrEnumKind BaseType;

        public readonly Identifier IndexNs;

        public readonly bool Parametric;

        public readonly bool EmitIndex;

        public StringTableSpec(Identifier tableNs, Identifier table, Identifier index, Identifier indexNs, ClrEnumKind @base, bool parametric, bool emitIndex = true)
        {
            TableNs = tableNs;
            TableName = table;
            IndexName = index;
            BaseType = @base;
            IndexNs = indexNs;
            Parametric = parametric;
            EmitIndex = emitIndex;
        }

        public StringTableSpec(Identifier ns, Identifier table, Identifier @enum, bool parametric, bool emitIndex = true)
        {
            TableNs = ns;
            TableName = table;
            IndexName = @enum;
            BaseType = 0;
            IndexNs = EmptyString;
            Parametric = parametric;
            EmitIndex = emitIndex;
        }
    }
}