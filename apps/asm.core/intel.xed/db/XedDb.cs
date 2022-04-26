//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRules;
    using static core;

    public partial class XedDb : AppService<XedDb>
    {
        public Schema DbSchema => Data(nameof(DbSchema), () => schema(Wf));

        [MethodImpl(Inline)]
        public static ColDef col(ushort pos, ColKind type, asci32 name)
            => new ColDef(pos, type, name);

        [MethodImpl(Inline)]
        public static TableDef table(asci32 name, params ColDef[] cols)
            => new TableDef(name,cols);

        static (Index<Type> Types, Index<TypeTable> Tables) CalcTypeTables()
        {
            var attribs = typeof(XedDb).Assembly.Enums().Attributions<SymSourceAttribute>().Where(x => x.Tag.SymGroup == "xed").ToIndex();
            var count = attribs.Count;
            Index<Type> types = alloc<Type>(count);
            Index<TypeTable> tables = alloc<TypeTable>(count);
            for(var i=0; i<count; i++)
            {
                var type = attribs[i].Type;
                var width = (byte)PrimalBits.width(Enums.@base(type));
                var symbols = Symbols.syminfo(type);
                var symcount = symbols.Count;
                Index<TypeTableRow> rows = alloc<TypeTableRow>(symcount);
                for(var j=0; j<symcount; j++)
                {
                    ref readonly var sym = ref symbols[j];
                    rows[j] = new TypeTableRow((ushort)sym.Index, width, sym.Name.Text, sym.Value, sym.Expr.Text, sym.Description);
                }

                types[i] = type;
                tables[i] = new TypeTable(type.Name, width, rows);
            }

            return (types,tables);
        }
    }
}