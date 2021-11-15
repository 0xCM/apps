//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;

    using static Root;
    using static core;
    using static CsPatterns;
    using static CsModels;

    partial struct SpanRes
    {
        public static void symrender<E>(Identifier container, ITextBuffer dst)
            where E : unmanaged, Enum
        {
            var n = 0u;
            var type = typeof(E);
            var IndexName = "Index";
            dst.IndentLineFormat(n, "{0} {1}", @namespace, "Z0");
            dst.IndentLine(n, Open());
            n+= 4;
            dst.IndentLineFormat(n, "{0} {1}{2}", @using, nameof(System), Term());
            if(type.IsNested)
                dst.IndentLineFormat(n, "{0} {1} {2}{3}", @using, @static, type.DeclaringType.DottedName(), Term());
            dst.IndentLineFormat(n, "{0} {1} {2}{3}", @using, @static, type.DottedName(), Term());

            dst.AppendLine();
            dst.IndentLineFormat(n, "{0} {1} {2} {3}", @public, Readonly(), @struct, container);
            dst.IndentLine(n, Open());
            n+=4;

            var spec = SpanRes.specify<E>(IndexName);
            symrender(n, spec, dst, false);
            dst.IndentLine(n, Close());
            n-=4;
            dst.IndentLine(n, Close());
        }

        [Op]
        public static void symrender<T>(uint indent, SymSpanSpec<T> spec, ITextBuffer dst, bool compact)
            where T : unmanaged
        {
            var payload = text.buffer();
            sympayload(indent, spec, payload, compact);
            var left = text.buffer();
            var modifiers = spec.IsStatic ? string.Format("{0} {1}", @public, @static) : @public;
            left.Append(modifiers);
            left.Append(Chars.Space);
            left.Append(ReadOnlySpanTypePattern.Format(spec.CellType));
            left.Append(Chars.Space);
            left.Append(spec.Name);

            var right = text.buffer();
            right.Append(string.Concat(string.Format("new {0}", spec.CellType), RP.bracket(spec.Data.Length), payload.Emit()));

            var assignment = ExpressionBody.Format(left.Emit(), right.Emit());
            dst.IndentLine(indent, assignment);
        }

        static void sympayload<T>(uint indent, in SymSpanSpec<T> spec, ITextBuffer dst, bool compact)
            where T : unmanaged
        {
            dst.Append(Open());
            if(compact)
            {
                symlist(spec.Data, dst);
                dst.AppendFormat("{0}{1}", Close(), Term());
            }
            else
            {
                symlines(indent + 4, spec.Data, dst);
                dst.IndentLineFormat(indent + 4, "{0}{1}", Close(), Term());
            }
        }

        static void symliteral<T>(uint indent, in Sym<T> src, ITextBuffer dst)
            where T : unmanaged
        {
            if(src.Description.IsNonEmpty)
                comment(src.Description).Render(indent, dst);
            dst.IndentLineFormat(indent, "{0},", src.Name);
        }

        static void symlines<T>(uint indent, ReadOnlySpan<Sym<T>> src, ITextBuffer dst)
            where T : unmanaged
        {
            var count = src.Length;
            dst.AppendLine();
            for(var i=0; i<count; i++)
                symliteral(indent, skip(src,i), dst);
            dst.AppendLine();
        }

        static void symlist<T>(ReadOnlySpan<Sym<T>> src, ITextBuffer dst)
            where T : unmanaged
        {
            var count = src.Length;
            for(var i=0; i<count; i++)
            {
                ref readonly var cell = ref skip(src,i);
                if(i != count - 1)
                    dst.Append(string.Format("{0}, ", cell.Name));
                else
                    dst.Append(cell.Name);
            }
        }
    }
}