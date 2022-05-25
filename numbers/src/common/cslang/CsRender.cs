//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using static CsModels;

    public readonly struct CsRender
    {
        public static uint replicants(string ns, string name, ReadOnlySpan<ClrEnumAdapter> src, ITextEmitter dst)
            => @enums(ns,name, recover<ClrEnumAdapter,Type>(src), dst);

        public static uint @enums(string ns, string name, ReadOnlySpan<Type> types, ITextEmitter buffer)
        {
            var offset = 0u;
            var counter = 0u;
            buffer.IndentLineFormat(offset, "namespace {0}", ns);
            buffer.IndentLine(offset, Chars.LBrace);
            offset += 4;
            buffer.IndentLineFormat(offset, "public readonly struct {0}", name);
            buffer.IndentLine(offset, Chars.LBrace);
            offset += 4;
            var enumBuffer = text.buffer();

            for(var i=0; i<types.Length; i++, counter++)
            {
                ref readonly var type = ref types[i];
                var spec = Symbols.set(type);
                CsRender.@enum(offset,spec,enumBuffer);
                buffer.Indent(offset, enumBuffer.Emit());

                if(counter != 0 && counter % 100 == 0)
                {
                    term.babble(string.Format("Generated code for {0} enums", counter));
                    counter = 0;
                }
            }

            offset -= 4;
            buffer.IndentLine(offset, Chars.RBrace);

            offset -= 4;
            buffer.Indent(offset, Chars.RBrace);
            return counter;
        }

        public static void @enum<T>(uint offset, LiteralSeq<T> src, ITextEmitter dst)
            where T : IComparable<T>, IEquatable<T>
                => @enum(offset, src.Name, string.Empty, src.View, dst);

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

        public static void @enum(uint margin, SymSet spec, ITextEmitter dst)
        {
            var counter = 0ul;
            var offset = margin;
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
                dst.Append(comment(spec.Description).Format(offset));

            if(spec.SymbolKind.IsNonEmpty)
            {
                if(spec.Flags)
                    dst.IndentLineFormat(offset,"[Flags, SymSource(\"{0}\")]", spec.SymbolKind);
                else
                    dst.IndentLineFormat(offset,"[SymSource(\"{0}\")]", spec.SymbolKind);
            }
            else
            {
                if(spec.Flags)
                    dst.IndentLine(offset,"[SymSource]");
                else
                    dst.IndentLine(offset,"[Flags,SymSource]");
            }

            dst.IndentLineFormat(offset, "public enum {0} : {1}", spec.Name, NumericKinds.kind(spec.DataType).Keyword());
            dst.IndentLine(offset,"{");
            offset += 4;

            for(var i=0; i<count; i++)
            {
                var name = CsKeywords.identifier(skip(names,i));
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
                    comment(description).Render(offset, dst);

                if(symbol.IsNonEmpty)
                {
                    // OpCode
                    ref readonly var kind = ref spec.Kinds[i];
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