//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static CsModels;
    using static CsLang;

    public readonly struct CsRender
    {
        public static void EnumReplicants(EnumReplicantSpec spec, ReadOnlySpan<Type> types, ITextEmitter dst, Action<IWfEvent> log)
        {
            var offset = 0u;
            dst.IndentLineFormat(offset, "namespace {0}", spec.Namespace);
            dst.IndentLine(offset, Chars.LBrace);
            offset += 4;

            if(text.nonempty(spec.DeclaringType))
            {
                dst.IndentLineFormat(offset, "public readonly struct {0}", spec.DeclaringType);
                dst.IndentLine(offset, Chars.LBrace);
                offset += 4;
            }

            for(var i=0; i<types.Length; i++)
            {
                EnumReplicant(offset, types[i], dst);
                if(i != 0 && i % 128 == 0)
                    log(EventFactory.babble(typeof(CsRender), string.Format("Generated code for {0} enums", i)));
            }

            if(text.nonempty(spec.DeclaringType))
            {
                offset -= 4;
                dst.IndentLine(offset, Chars.RBrace);
            }

            offset -= 4;
            dst.Indent(offset, Chars.RBrace);
        }

        public static void EnumReplicant(uint offset, Type type, ITextEmitter dst)
        {
            dst.AppendLine();
            CsRender.@enum(offset, Symbols.set(type), dst);
        }

        public static void @enum<T>(uint offset, Identifier name, ReadOnlySpan<Literal<T>> literals, ITextEmitter dst)
            => @enum(offset, name, string.Empty, literals, dst);

        public static void @enum<T>(uint offset, Identifier name, string symsource, ReadOnlySpan<Literal<T>> literals, ITextEmitter dst)
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
        }

        public static void @enum(uint offset, SymSet src, ITextEmitter dst)
        {
            var counter = 0ul;
            var names = src.Names.View;
            var count = names.Length;
            var values = src.Values.IsNonEmpty;
            if(values)
                Require.equal(count, src.Values.Length);

            var symbols = src.Symbols.IsNonEmpty;
            if(symbols)
                Require.equal(count, src.Symbols.Length);

            var descriptions = src.Descriptions.IsNonEmpty;
            if(descriptions)
                Require.equal(count, src.Descriptions.Length);

            if(src.Description.IsNonEmpty)
                dst.Append(comment(src.Description).Format(offset));

            Span<string> attribs = new string[12];
            var k=0u;
            if(src.Flags)
                seek(attribs,k++) = "Flags";
            if(src.SymbolKind.IsNonEmpty)
                seek(attribs,k++) = string.Format("SymSource(\"{0}\")", src.SymbolKind);
            else
                seek(attribs,k++) = "SymSource";
            if(src.SymSize.Packed != src.SymSize.Native)
                seek(attribs,k++) = $"DataWidth({src.SymSize.Packed})";

            dst.IndentLine(offset, text.bracket(text.join(", ", slice(attribs,0,k).ToArray())));
            dst.IndentLineFormat(offset, "public enum {0} : {1}", src.Name, NumericKinds.kind(src.DataType).Keyword());
            dst.IndentLine(offset,"{");

            offset += 4;
            for(var i=0; i<count; i++)
            {
                var name = CsKeywords.identifier(skip(names,i));
                var description = EmptyString;
                var value = (ulong)i;
                var symbol = SymExpr.Empty;
                if(values)
                    value = src.Values[i];
                if(symbols)
                    symbol = src.Symbols[i];
                if(descriptions)
                    description = text.ifempty(src.Descriptions[i],EmptyString);

                if(nonempty(description))
                    comment(description).Render(offset, dst);

                if(symbol.IsNonEmpty)
                {
                    if(nonempty(description))
                        dst.IndentLineFormat(offset, "[Symbol(\"{0}\",\"{1}\")]", symbol, description);
                    else
                        dst.IndentLineFormat(offset, "[Symbol(\"{0}\")]", symbol);
                }

                dst.IndentLineFormat(offset, "{0} = {1},", name, value);
                if(i != count -1)
                    dst.AppendLine();
            }
            offset -= 4;

            dst.IndentLine(offset,"}");
        }
    }
}