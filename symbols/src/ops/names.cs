//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class Symbolic
    {
        public static SymTableSpec<K> names<K>(
            string tableNs = null,
            string indexNs = null,
            string tableName = null,
            string indexName = null,
            bool emitIndex = true,
            bool parametric = true
            )
            where K : unmanaged, Enum
        {
            var dst = new SymTableSpec<K>();
            spec(
                tableNs: TableNs<K>(tableNs),
                indexNs: IndexNs<K>(indexNs),
                tableName: Table<K>(tableName),
                indexName: Index<K>(indexName),
                emitIndex: emitIndex,
                parametric: parametric,
                entries: SymLists.names(Symbols.index<K>(), Table<K>(tableName)),
                ref dst);
            return dst;
        }
    }
}