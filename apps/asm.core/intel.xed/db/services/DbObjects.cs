//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class XedDb
    {
        public class DbObjects
        {
            public static DbObjects create()
            {
                var dst = new DbObjects();
                Calc(out dst.ObjectKinds);
                Calc(out dst.TypeTableSource);
                Calc(dst.ObjectKinds, out dst.ObjColsSource);
                dst.TableSpecSource = sys.empty<TableSpec>();
                dst.ColSpecSource = sys.empty<ColSpec>();
                dst.RelationSource = sys.empty<Relation>();
                return dst;
            }

            internal const byte ObjTypeCount = 24;

            static Index<ObjectKind,uint> ObjSeqSource = sys.alloc<uint>(ObjTypeCount);

            Index<ObjectKind,Index<ColDef>> ObjColsSource;

            Index<TableSpec> TableSpecSource;

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

            public ref readonly Index<TypeTable> TypeTables
            {
                [MethodImpl(Inline)]
                get => ref TypeTableSource;
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

            static void Calc(out Index<ObjectKind> dst)
            {
                dst = alloc<ObjectKind>(ObjTypeCount);
                var kinds = Symbols.kinds<ObjectKind>();
                for(var i=0; i<kinds.Length; i++)
                    dst[i] = skip(kinds,i);
            }

            static void Calc(in Index<ObjectKind> kinds, out Index<ObjectKind,Index<ColDef>> dst)
            {
                dst = alloc<Index<ColDef>>(ObjTypeCount);

                for(var i=1; i<kinds.Count; i++)
                {
                    ref readonly var kind = ref kinds[i];
                    if(kind == 0)
                        break;

                    var seq=z16;

                    switch(kind)
                    {
                        case ObjectKind.TypeTableField:
                            dst[kind] = XedDb.TypeTableField.Columns(ref seq);
                        break;
                        case ObjectKind.TypeTable:
                            dst[kind] = XedDb.TypeTable.Columns(ref seq);
                        break;
                    }
                }
            }

            [MethodImpl(Inline)]
            static uint NextSeq(ObjectKind kind)
                => inc(ref ObjSeqSource[kind]);

            static void Calc(out Index<TypeTable> tables)
            {
                var attribs = typeof(XedDb).Assembly.Enums().Attributions<SymSourceAttribute>().Where(x => x.Tag.SymGroup == "xed").ToIndex();
                var count = attribs.Count;
                tables = alloc<TypeTable>(count);
                for(var i=0; i<count; i++)
                {
                    var type = attribs[i].Type;
                    var width = (byte)PrimalBits.width(Enums.@base(type));
                    var symbols = Symbols.syminfo(type);
                    var symcount = symbols.Count;
                    Index<TypeTableField> rows = alloc<TypeTableField>(symcount);
                    for(var j=0; j<symcount; j++)
                    {
                        ref readonly var sym = ref symbols[j];
                        rows[j] = new TypeTableField(NextSeq(ObjectKind.TypeTableField), (ushort)sym.Index, width, sym.Name.Text, sym.Value, sym.Expr.Text, sym.Description);
                    }

                    tables[i] = new TypeTable(NextSeq(ObjectKind.TypeTable), type.Name, width, rows);
                }
            }
        }
    }
}