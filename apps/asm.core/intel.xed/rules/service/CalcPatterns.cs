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
        public Index<TypeTable> CalcTypeTables()
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
                ref var row = ref rows[j];
                row.Seq = DbObjects.NextSeq(ObjectKind.TypeTableRow);
                row.TypeName = Label(type.Definition.Name);
                row.LiteralName = Label(sym.Name.Text);
                row.Position = (ushort)sym.Index;
                row.PackedWidth = (byte)type.Size.PackedWidth;
                row.NativeWidth = (byte)type.Size.NativeWidth;
                row.LiteralValue = sym.Value;
                row.Symbol = Label(sym.Expr.Text);
                row.Description = String(sym.Description.Text);
            }

            return new TypeTable(
                DbObjects.NextSeq(ObjectKind.TypeTable),
                Label(type.Definition.Name),
                type.Size,
                rows
                );
        }

        public Index<InstPattern> CalcPatterns()
            => CalcInstPatterns(CalcInstDefs());
    }
}