//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static MemDb;

    partial class XedRules
    {
        static D Data<D>(XedViewKind index, Func<D> f)
            => data<D>(index.ToString(), f);

        public static Index<TypeTableRow> CalcTypeTableRows(Index<TypeTable> src)
            => src.SelectMany(x => x.Rows).Sort().Resequence();

        public static Index<TypeTable> CalcTypeTables(IStringAllocProvider alloc)
        {
            var types = MeasuredType.symbolic(typeof(XedDb).Assembly, "xed");
            Index<TypeTable> tables = core.alloc<TypeTable>(types.Count);
            for(var i=0; i<types.Count; i++)
                tables[i] = CalcTypeTable(alloc, types[i]);
            return tables.Sort();
        }

        static TypeTable CalcTypeTable(IStringAllocProvider alloc, MeasuredType type)
        {
            var symbols = Symbols.syminfo(type.Definition);
            Index<TypeTableRow> rows = core.alloc<TypeTableRow>(symbols.Count);
            for(var j=0; j<symbols.Count; j++)
            {
                ref readonly var sym = ref symbols[j];
                ref var row = ref rows[j];
                row.Seq = DbObjects.NextSeq(ObjectKind.TypeTableRow);
                row.TypeName = alloc.Label(type.Definition.Name);
                row.LiteralName = alloc.Label(sym.Name.Text);
                row.Position = (ushort)sym.Index;
                row.PackedWidth = (byte)type.Size.PackedWidth;
                row.NativeWidth = (byte)type.Size.NativeWidth;
                row.LiteralValue = sym.Value;
                row.Symbol = alloc.Label(sym.Expr.Text);
                row.Description = alloc.String(sym.Description.Text);
            }

            return new TypeTable(
                DbObjects.NextSeq(ObjectKind.TypeTable),
                alloc.Label(type.Definition.Name),
                type.Size,
                rows
                );
        }
    }
}