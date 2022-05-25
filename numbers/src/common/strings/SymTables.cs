//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------

namespace Z0
{
    using static core;

    public readonly struct SymTables
    {
        const string DefaultIndexNs = "Z0";

        const string DefaultTableNs = "Z0.Strings";

        public static StringTable expressions<K>(string ixname = null, string tn = null, string ixns = DefaultIndexNs, string tns = DefaultTableNs)
            where K : unmanaged, Enum
                => expressions<K>(spec<K>(ixname, tn, ixns, tns, false));

        public static StringTable names<K>(string ixname = null, string tn = null, string ixns = DefaultIndexNs, string tns = DefaultTableNs)
            where K : unmanaged, Enum
                => names<K>(spec<K>(ixname, tn, ixns, tns, false));

        public static StringTable expressions<K>(SymTableSpec spec)
            where K : unmanaged, Enum
                => StringTables.define(syntax(spec), SymLists.expressions(Symbols.index<K>()));

        public static StringTable names<K>(SymTableSpec spec)
            where K : unmanaged, Enum
                => StringTables.define(syntax(spec), SymLists.names(Symbols.index<K>()));

        public static SymTableSpec spec<K>(string tableNs, string tableName, string indexNs, string indexName, bool emitIndex)
            where K : unmanaged
        {
            var dst = new SymTableSpec();
            dst.IndexName = indexName;
            dst.TableName = tableName;
            dst.IndexNs = indexNs;
            dst.TableNs = tableNs;
            dst.IndexKind = Enums.kind<K>();
            dst.Parametric = true;
            dst.EmitIndex = emitIndex;
            return dst;
        }

        [MethodImpl(Inline), Op]
        static StringTableSpec syntax(SymTableSpec spec)
            => new StringTableSpec(
                index: spec.IndexName,
                table: spec.TableName,
                indexNs: spec.IndexNs,
                tableNs: spec.TableNs,
                @base: spec.IndexKind,
                parametric: spec.Parametric
                );
    }
}