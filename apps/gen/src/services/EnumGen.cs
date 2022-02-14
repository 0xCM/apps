//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static core;
    using static CsModels;

    public class EnumGen : CodeGenerator
    {
        public Outcome Emit<T>(uint offset, LiteralSeq<T> literals, ITextBuffer dst)
            where T : IComparable<T>, IEquatable<T>
                => Emit(offset, literals.Name, string.Empty, literals.Elements, dst);

        public Outcome Emit<T>(uint offset, Identifier name, ReadOnlySpan<Literal<T>> literals, ITextBuffer dst)
            => Emit(offset, name, string.Empty, literals, dst);

        public Outcome Emit<T>(uint offset, Identifier name, string symsource, ReadOnlySpan<Literal<T>> literals, ITextBuffer dst)
        {
            var counter = 0ul;
            var indent = offset;
            var @base = typeof(T).NumericKind();
            if(nonempty(symsource))
                dst.IndentLineFormat(indent,"[SymSource(\"{0}\")]", symsource);
            else
                dst.IndentLine(indent,"[SymSource]");

            dst.IndentLineFormat(indent, "public enum {0} : {1}", name, @base.Keyword());
            dst.IndentLine(indent,"{");
            indent += 4;

            var count = literals.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var literal = ref skip(literals,i);
                dst.IndentLineFormat(indent, "{0} = {1},", literal.Name, literal.Value);
                if(i != count -1)
                    dst.AppendLine();
            }

            indent -= 4;
            dst.IndentLine(indent,"}");

            return default;
        }

        public void Emit(uint margin, SymSet spec, ITextBuffer dst)
        {
            var counter = 0ul;
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
                comment(spec.Description).Render(margin, dst);

            if(spec.Flags)
                dst.IndentLine(margin,"[Flags]");

            if(spec.SymbolKind.IsNonEmpty)
                dst.IndentLineFormat(margin,"[SymSource(\"{0}\")]", spec.SymbolKind);
            else
                dst.IndentLine(margin,"[SymSource]");

            dst.IndentLineFormat(margin, "public enum {0} : {1}", spec.Name, NumericKinds.kind(spec.DataType).Keyword());
            dst.IndentLine(margin,"{");
            margin += 4;

            for(var i=0; i<count; i++)
            {
                var name = skip(names,i);
                var description = EmptyString;
                var value = (ulong)i;
                var symbol = SymExpr.Empty;
                if(values)
                    value = spec.Values[i];
                if(symbols)
                    symbol = spec.Symbols[i];
                if(descriptions)
                    description = text.ifempty(spec.Descriptions[i],EmptyString);

                if(nonempty(description))
                    comment(description).Render(margin, dst);

                var kind = text.ifempty(spec.Kinds[i], description);

                if(symbol.IsNonEmpty)
                    dst.IndentLineFormat(margin, "[Symbol(\"{0}\",\"{1}\")]", symbol, kind);

                dst.IndentLineFormat(margin, "{0} = {1},", name, value);
                if(i != count -1)
                    dst.AppendLine();
            }
            margin -= 4;
            dst.IndentLine(margin,"}");
        }
    }
}