//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static Root;
    using static core;
    using static CsPatterns;

    partial struct SpanRes
    {
        const char semi = Chars.Semicolon;

        public static ByteSpanSpec ascirender(uint indent, Identifier name, string data, ITextBuffer dst)
        {
            var payload = text.buffer();
            var src = span(data);
            var count = src.Length;
            var buffer = alloc<byte>(count);
            ref var target = ref first(buffer);
            for(var i=0; i<count; i++)
                seek(target, i) = (byte)skip(src,i);
            var spec = specify(name, buffer, true);
            ascirender(indent, spec, dst);
            return spec;
        }

        [Op]
        public static void ascirender(uint indent, ByteSpanSpec spec, ITextBuffer dst)
        {
            var data = spec.Data.View;
            var size = spec.DataSize;
            var left = text.buffer();
            var modifiers = spec.IsStatic ? string.Format("{0} {1}", @public, @static) : @public;
            left.Append(modifiers);
            left.Append(Chars.Space);
            left.Append(ReadOnlySpanTypePattern.Format(spec.CellType));
            left.Append(Chars.Space);
            left.Append(spec.Name);

            var content = text.buffer();
            content.Append(Open());

            for(var i=0; i<size; i++)
            {
                ref readonly var cell = ref skip(data,i);
                if(i != size - 1)
                    content.Append(string.Format("{0}, ", cell));
                else
                    content.Append(string.Format("{0}", cell));
            }

            content.AppendFormat("{0}{1}", Close(), semi);

            var right = text.buffer();
            right.Append(string.Concat(string.Format("new {0}", spec.CellType), RP.bracket(size), content.Emit()));

            dst.IndentLine(indent, ExpressionBody.Format(left.Emit(), right.Emit()));
        }
    }
}