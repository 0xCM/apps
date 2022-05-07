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
            internal static DbObjects create(MemDb db)
                => new DbObjects(db);

            internal const byte ObjTypeCount = 24;

            static Index<ObjectKind,uint> ObjSeqSource = sys.alloc<uint>(ObjTypeCount);

            Index<Entity> TableSpecSource;

            Index<ColSpec> ColSpecSource;

            Index<Relation> RelationSource;

            Index<TypeTable> _TypeTables;

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
                get => _TypeTables.Count;
            }

            [MethodImpl(Inline)]
            public ref readonly TypeTable TypeTable(uint i)
                => ref _TypeTables[i];

            [MethodImpl(Inline)]
            public ref readonly TypeTable TypeTable(int i)
                => ref _TypeTables[i];

            public ref readonly Index<TypeTable> TypeTables
            {
                [MethodImpl(Inline)]
                get => ref _TypeTables;
            }

            readonly MemDb Db;

            ref readonly Alloc Alloc
            {
                [MethodImpl(Inline)]
                get => ref (Db as IMemDbInternal).Alloc;
            }

            DbObjects(MemDb db)
            {
                Db = db;
                _TypeTables = CalcTypeTables();
                TableSpecSource = sys.empty<Entity>();
                ColSpecSource = sys.empty<ColSpec>();
                RelationSource = sys.empty<Relation>();
            }

            [MethodImpl(Inline)]
            static uint NextSeq(ObjectKind kind)
                => inc(ref ObjSeqSource[kind]);

            Index<TypeTable> CalcTypeTables()
            {
                var types = MeasuredType.symbolic(typeof(XedDb).Assembly, "xed");
                Index<TypeTable> tables = alloc<TypeTable>(types.Count);
                for(var i=0; i<types.Count; i++)
                    tables[i] = CalcTypeTable(types[i]);
                return tables.Sort();
            }

            TypeTable CalcTypeTable(MeasuredType type)
            {
                    var symbols = Symbols.syminfo(type.Definition);
                    Index<TypeTableRow> rows = alloc<TypeTableRow>(symbols.Count);
                    for(var j=0; j<symbols.Count; j++)
                    {
                        ref readonly var sym = ref symbols[j];
                        rows[j] = new TypeTableRow(
                            NextSeq(ObjectKind.TypeTableRow),
                            (ushort)sym.Index,
                            Alloc.Label(sym.Name.Text),
                            sym.Value,
                            Alloc.Label(sym.Expr.Text),
                            Alloc.String(sym.Description.Text)
                            );
                    }

                return new TypeTable(
                    NextSeq(ObjectKind.TypeTable),
                    Alloc.Label(type.Definition.Name),
                    type.Size,
                    rows
                    );
            }
        }
    }
}