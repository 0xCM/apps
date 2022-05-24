//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    partial class MemDb
    {
        [MethodImpl(Inline), Op]
        public static DbDataType type(uint seq, asci32 name, asci32 primitive, DataSize size, asci32 refinement = default)
            => new DbDataType(seq, name, primitive, size, !refinement.IsNull, refinement);

        public static Index<TypeTableRow> rows(Index<TypeTable> src)
            => src.SelectMany(x => x.Rows).Sort().Resequence();

        public static Index<TypeTable> typetables(IStringAllocProvider alloc, Assembly src, string group)
        {
            var types = MeasuredType.symbolic(src, group);
            Index<TypeTable> tables = core.alloc<TypeTable>(types.Count);
            for(var i=0; i<types.Count; i++)
                tables[i] = MemDb.typetable(alloc, types[i]);
            return tables.Sort();
        }

        public static TypeTable typetable(IStringAllocProvider alloc, MeasuredType type)
        {
            var symbols = Symbols.syminfo(type.Definition);
            Index<TypeTableRow> rows = alloc<TypeTableRow>(symbols.Count);
            for(var j=0; j<symbols.Count; j++)
            {
                ref readonly var sym = ref symbols[j];
                ref var row = ref rows[j];
                row.Seq = NextSeq(ObjectKind.TypeTableRow);
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
                NextSeq(ObjectKind.TypeTable),
                alloc.Label(type.Definition.Name),
                type.Size,
                rows
                );
        }
    }
}