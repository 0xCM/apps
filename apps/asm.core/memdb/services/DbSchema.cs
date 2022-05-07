//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class MemDb
    {
        public class DbSchema
        {
            DbObjects _DbObjects;

            Index<ObjectKind,Index<asci32>> _ColNames;

            Index<ObjectKind> _ObjKinds;

            Index<ObjectKind,Index<ColDef>> ObjColsSource;
            ref readonly DbObjects Objects
            {
                [MethodImpl(Inline)]
                get => ref _DbObjects;
            }

            [MethodImpl(Inline)]
            public ref readonly Index<asci32> ColNames(ObjectKind kind)
                => ref _ColNames[kind];

            [MethodImpl(Inline)]
            public ref readonly Index<ColDef> Cols(ObjectKind kind)
                => ref ObjColsSource[kind];

            public ref readonly Index<ObjectKind> ObjKinds
            {
                [MethodImpl(Inline)]
                get => ref _ObjKinds;
            }

            static Index<ObjectKind> CalcObjKinds()
            {
                Index<ObjectKind> dst = alloc<ObjectKind>(DbObjects.ObjTypeCount);
                var kinds = Symbols.kinds<ObjectKind>();
                for(var i=0; i<kinds.Length; i++)
                    dst[i] = skip(kinds,i);
                return dst;
            }

            Index<ObjectKind,Index<ColDef>> CalcColDefs(in Index<ObjectKind> kinds)
            {
                Index<ObjectKind,Index<ColDef>> dst = alloc<Index<ColDef>>(DbObjects.ObjTypeCount);

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
                            dst[kind] = TypeTableColumns(ref seq);
                        break;
                    }
                }
                return dst;
            }

            public DbSchema(DbObjects objects)
            {
                _DbObjects = objects;
                _ObjKinds = CalcObjKinds();
                ObjColsSource = CalcColDefs(_ObjKinds);

                const byte Count = DbObjects.ObjTypeCount;

                _ColNames = alloc<Index<asci32>>(Count);
                broadcast(Index<asci32>.Empty, _ColNames);

                for(var i=1; i<ObjKinds.Count; i++)
                {
                    ref readonly var kind = ref ObjKinds[i];
                    ref readonly var cols = ref Cols(kind);
                    switch(kind)
                    {
                        case ObjectKind.TypeTable:
                            _ColNames[kind] = map(cols, col => col.ColName);
                        break;
                        case ObjectKind.TypeTableRow:
                            _ColNames[kind] = map(cols, col => col.ColName);
                        break;
                    }
                }
            }

            public Index<ColDef> TypeTableColumns(ref ushort pos)
                =>  cols(new ColDef[TypeTable.ColCount]{
                    col(pos++, nameof(TypeTable.TypeKey), TypeTableRenderWidths()),
                    col(pos++, nameof(TypeTable.TypeName), TypeTableRenderWidths()),
                    col(pos++, nameof(TypeTable.PackedWidth), TypeTableRenderWidths()),
                    col(pos++, nameof(TypeTable.NativeWidth), TypeTableRenderWidths()),
                    col(pos++, nameof(TypeTable.RowCount), TypeTableRenderWidths()),
                        });

            static ReadOnlySpan<byte> TypeTableRenderWidths() => new byte[TypeTable.ColCount]{8,32,12,12,12};

        }
    }
}