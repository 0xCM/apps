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
        [Op]
        public static void render(ByteSpanSpec src, ITextBuffer dst)
            => render(src, HexFormatter.array<byte>(src.Data), dst);

        [Op]
        public static void render<T>(ByteSpanSpec<T> src, ITextBuffer dst)
            where T : unmanaged
        {
            var bytes = recover<T,byte>(src.Data.View);
            var payload = HexFormatter.array<byte>(bytes);
            dst.Append("public");
            dst.Append(Chars.Space);
            dst.Append(src.IsStatic ? RP.rspace("static") : EmptyString);
            dst.Append(ReadOnlySpanTypePattern.Format(src.CellType));
            dst.Append(Chars.Space);
            dst.Append(src.Name);
            dst.Append(" => ");
            dst.Append(string.Concat(string.Format("new {0}", src.CellType), RP.bracket(bytes.Length), RP.embrace(payload)));
            dst.Append(Chars.Semicolon);
        }

        [Op]
        public static void render(CharSpanSpec src, ITextBuffer dst)
        {
            dst.Append("public");
            dst.Append(Chars.Space);
            dst.Append(src.IsStatic ? RP.rspace("static") : EmptyString);
            dst.Append(ReadOnlySpanTypePattern.Format(src.CellType));
            dst.Append(Chars.Space);
            dst.Append(src.Name);
            dst.Append(" => ");

            var data = src.Data;
            var count = data.Length;

            dst.Append(string.Concat(string.Format("new {0}", src.CellType), RP.bracket(count)));
            dst.Append(Open());

            for(var i=0; i<src.Data.Length; i++)
                dst.AppendFormat("'{0}',", skip(data,i));

            dst.Append(Close());
            dst.Append(Term());
        }

        public static void render<T>(uint margin, SymSpanSpec<T> src, ITextBuffer dst)
            where T : unmanaged
        {
            var tmp = text.buffer();
            tmp.Append("public");
            tmp.Append(Chars.Space);
            tmp.Append(src.IsStatic ? RP.rspace("static") : EmptyString);
            tmp.Append(ReadOnlySpanTypePattern.Format(src.CellType));
            tmp.Append(Chars.Space);
            tmp.Append(src.Name);
            tmp.Append(" => ");
            tmp.Append(string.Concat(string.Format("new {0}", src.CellType), RP.bracket(src.Data.Length), RP.embrace(format(src.Data))));
            tmp.Append(Term());
            dst.IndentLine(margin,tmp.Emit());
        }

        [Op]
        public static void render(ByteSpanSpec src, string payload, ITextBuffer dst)
        {
            dst.Append("public");
            dst.Append(Chars.Space);
            dst.Append(src.IsStatic ? RP.rspace("static") : EmptyString);
            dst.Append(ReadOnlySpanTypePattern.Format(src.CellType));
            dst.Append(Chars.Space);
            dst.Append(src.Name);
            dst.Append(" => ");
            dst.Append(string.Concat(string.Format("new {0}", src.CellType), RP.bracket(src.Data.Length), RP.embrace(payload)));
            dst.Append(Term());
        }
    }
}