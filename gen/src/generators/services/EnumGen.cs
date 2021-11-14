//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static CsModels;

    public class EnumGen : CodeGenerator
    {
        public Outcome Generate(uint offset, SymSet spec, ITextBuffer dst)
        {
            var counter = 0ul;
            var indent = offset;
            var names = spec.Names.View;
            var count = names.Length;
            var values = spec.Values.IsNonEmpty;
            if(values)
                Require.equal(count, spec.Values.Length);

            var symbols = spec.Symbols.IsNonEmpty;
            if(symbols)
                Require.equal(count, spec.Symbols.Length);

            var descriptions = spec.Descriptions.IsNonEmpty;
            if(descriptions)
                Require.equal(count, spec.Descriptions.Length);

            if(spec.Description.IsNonEmpty)
                comment(spec.Description).Render(indent, dst);

            if(spec.Flags)
                dst.IndentLine(indent,"[Flags]");

            if(spec.SymbolKind.IsNonEmpty)
                dst.IndentLineFormat(indent,"[SymSource(\"{0}\")]", spec.SymbolKind);
            else
                dst.IndentLine(indent,"[SymSource]");

            var datatype = NumericKinds.kind(spec.DataType).Keyword();
            dst.IndentLineFormat(indent, "public enum {0} : {1}", spec.Name, datatype);
            dst.IndentLine(indent,"{");
            indent += 4;

            for(var i=0; i<count; i++)
            {
                var name = skip(names,i);
                var description = "";
                var value = (ulong)i;
                var symbol = SymExpr.Empty;
                if(values)
                    value = spec.Values[i];
                if(symbols)
                    symbol = spec.Symbols[i];
                if(descriptions)
                    description = spec.Descriptions[i];

                if(nonempty(description))
                    comment(description).Render(indent, dst);

                if(symbol.IsNonEmpty)
                {
                    if(nonempty(description))
                        dst.IndentLineFormat(indent, "[Symbol(\"{0}\",\"{1}\")]", symbol, description);
                    else
                        dst.IndentLineFormat(indent, "[Symbol(\"{0}\")]", symbol);
                }
                dst.IndentLineFormat(indent, "{0} = {1},", name, value);
                if(i != count -1)
                    dst.AppendLine();
            }
            indent -= 4;
            dst.IndentLine(indent,"}");

            return true;
        }
    }
}