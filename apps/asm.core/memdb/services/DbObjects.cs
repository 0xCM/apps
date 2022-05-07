//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class MemDb
    {
        public partial class DbObjects
        {
            public static DbObjects create()
            {
                var dst = new DbObjects();
                var kinds = CalcObjKinds();
                dst.ObjectKinds = kinds;
                dst.TypeTableSource = CalcTypeTables();
                dst.ObjColsSource = CalcColDefs(kinds);
                dst.TableSpecSource = sys.empty<Entity>();
                dst.ColSpecSource = sys.empty<ColSpec>();
                dst.RelationSource = sys.empty<Relation>();
                return dst;
            }

            internal const byte ObjTypeCount = 24;

            static Index<ObjectKind,uint> ObjSeqSource = sys.alloc<uint>(ObjTypeCount);

            Index<ObjectKind,Index<ColDef>> ObjColsSource;

            Index<Entity> TableSpecSource;

            Index<ColSpec> ColSpecSource;

            Index<Relation> RelationSource;

            Index<TypeTable> TypeTableSource;

            Index<ObjectKind> ObjectKinds;

            public ref readonly Index<ObjectKind> ObjKinds
            {
                [MethodImpl(Inline)]
                get => ref ObjectKinds;
            }

            [MethodImpl(Inline)]
            public ref readonly Index<ColDef> Cols(ObjectKind kind)
                => ref ObjColsSource[kind];

            [MethodImpl(Inline)]
            public ref readonly uint ObjectCount(ObjectKind kind)
                => ref ObjectCounts[kind];

            public ref readonly Index<ObjectKind,uint> ObjectCounts
            {
                [MethodImpl(Inline)]
                get => ref ObjSeqSource;
            }

            public uint TypeTableCount
            {
                [MethodImpl(Inline)]
                get => TypeTableSource.Count;
            }

            [MethodImpl(Inline)]
            public ref readonly TypeTable TypeTable(uint i)
                => ref TypeTableSource[i];

            [MethodImpl(Inline)]
            public ref readonly TypeTable TypeTable(int i)
                => ref TypeTableSource[i];

            DbObjects()
            {

            }

            static Index<ObjectKind> CalcObjKinds()
            {
                Index<ObjectKind> dst = alloc<ObjectKind>(ObjTypeCount);
                var kinds = Symbols.kinds<ObjectKind>();
                for(var i=0; i<kinds.Length; i++)
                    dst[i] = skip(kinds,i);
                return dst;
            }

            static Index<ObjectKind,Index<ColDef>> CalcColDefs(in Index<ObjectKind> kinds)
            {
                Index<ObjectKind,Index<ColDef>> dst = alloc<Index<ColDef>>(ObjTypeCount);

                for(var i=1; i<kinds.Count; i++)
                {
                    ref readonly var kind = ref kinds[i];
                    if(kind == 0)
                        break;

                    var seq=z16;
                    switch(kind)
                    {
                        case ObjectKind.TypeTableRow:
                            dst[kind] = MemDb.TypeTableRow.Columns(ref seq);
                        break;
                        case ObjectKind.TypeTable:
                            dst[kind] = MemDb.TypeTable.Columns(ref seq);
                        break;
                    }
                }
                return dst;
            }

            [MethodImpl(Inline)]
            static uint NextSeq(ObjectKind kind)
                => inc(ref ObjSeqSource[kind]);

            static Index<TypeTable> CalcTypeTables()
            {
                var types = MeasuredType.symbolic(typeof(XedDb).Assembly, "xed");
                Index<TypeTable> tables = alloc<TypeTable>(types.Count);
                for(var i=0; i<types.Count; i++)
                    tables[i] = CalcTypeTable(types[i]);
                return tables.Sort();
            }

            static TypeTable CalcTypeTable(MeasuredType type)
            {
                    var symbols = Symbols.syminfo(type.Definition);
                    Index<TypeTableRow> rows = alloc<TypeTableRow>(symbols.Count);
                    for(var j=0; j<symbols.Count; j++)
                    {
                        ref readonly var sym = ref symbols[j];
                        rows[j] = new TypeTableRow(NextSeq(ObjectKind.TypeTableRow), (ushort)sym.Index, sym.Name.Text, sym.Value, sym.Expr.Text, sym.Description);
                    }

                return new TypeTable(NextSeq(ObjectKind.TypeTable), type.Definition.Name, type.Size, rows);
            }
        }
    }
}