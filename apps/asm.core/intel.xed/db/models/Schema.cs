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
        public static Schema schema(IWfRuntime wf)
            => Schema.calc(wf);

        public class Schema
        {
            internal static ushort NextTypeId()
                => (ushort)inc(ref Schema.TypeIdSeq);

            internal static ushort NextTableId()
                => (ushort)inc(ref Schema.TableIdSeq);

            internal static ushort NextColId()
                => (ushort)inc(ref Schema.ColIdSeq);

            internal static Schema calc(IWfRuntime wf)
            {
                var dst = new Schema();
                (var types,var tables) = CalcTypeTables();
                dst._TypeTableTypes = types;
                dst._TypeTableDefs = tables;

                var td = TypeTable.Def;
                var tr = TypeTableRow.Columns;
                return dst;
            }

            public ref readonly Index<TypeTable> TypeTables
            {
                [MethodImpl(Inline)]
                get => ref _TypeTableDefs;
            }

            Index<TableSpec> _Tables;

            Index<ColSpec> _Cols;

            Index<Relation> _Rels;

            Index<TypeTable> _TypeTableDefs;

            Index<Type> _TypeTableTypes;

            public Schema()
            {
            }

            [FixedAddressValueType]
            static int TypeIdSeq = 31;

            [FixedAddressValueType]
            static int TableIdSeq = 31;

            [FixedAddressValueType]
            static int ColIdSeq = 127;

        }
    }
}