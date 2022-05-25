//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class StringTables
    {
        [MethodImpl(Inline), Op]
        public static StringTableSpec spec<K>(SymTableSpec<K> spec)
            where K : unmanaged
            => new StringTableSpec(
                index: spec.IndexName,
                table: spec.TableName,
                indexNs: spec.IndexNs,
                tableNs: spec.TableNs,
                @base: spec.IndexKind,
                emitIndex: spec.EmitIndex,
                parametric: spec.Parametric
                );

        [MethodImpl(Inline), Op]
        public static StringTableSpec spec(Identifier tableNs, Identifier tableName, Identifier indexNs, Identifier indexName, ClrEnumKind @base, bool emitIndex)
            => new StringTableSpec(tableNs, tableName, indexName, indexNs, @base, true, emitIndex);
    }
}