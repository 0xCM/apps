//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using System.Runtime.CompilerServices;

    using static Root;
    using static core;

    using C = Chars;

    using static CsPatterns;

    public class AsciLookupGen : Service<AsciLookupGen>
    {
        public ByteSpanSpec DefineByteSpan(Identifier name, string content)
        {
            var src = span(content);
            var count = src.Length;
            var buffer = alloc<byte>(count);
            ref var dst = ref first(buffer);
            for(var i=0; i<count; i++)
                seek(dst, i) = (byte)skip(src,i);
            return new ByteSpanSpec(name, buffer, true);
        }

        const char semi = Chars.Semicolon;

        const char lbrace = Chars.LBrace;

        const char rbrace = Chars.RBrace;

        public static RenderPattern<string> ReadOnlySpanTypeName => "ReadOnlySpan<{0}>";

        public static RenderPattern<string,string> Assign => "{0} => {1}";

        protected override void Initialized()
        {
        }

        public void EmitAsciBytes(uint indent, Identifier name, string data, ITextBuffer dst)
            => Render(indent, DefineByteSpan(name,data), dst);

        public void Render(uint indent, ByteSpanSpec spec, ITextBuffer dst)
        {
            var data = spec.Data;
            var size = spec.DataSize;
            var left = TextTools.buffer();
            var modifiers = spec.IsStatic ? string.Format("{0} {1}", @public, @static) : @public;
            left.Append(modifiers);
            left.Append(Chars.Space);
            left.Append(ReadOnlySpanTypeName.Format(spec.CellType));
            left.Append(Chars.Space);
            left.Append(spec.Name);

            var content = TextTools.buffer();
            content.Append(lbrace);

            for(var i=0; i<size; i++)
            {
                ref readonly var cell = ref skip(data,i);
                if(i != size - 1)
                    content.Append(string.Format("{0}, ", cell));
                else
                    content.Append(string.Format("{0}", cell));
            }

            content.AppendFormat("{0}{1}", rbrace, semi);

            var right = TextTools.buffer();
            right.Append(string.Concat(string.Format("new {0}", spec.CellType), RP.bracket(spec.Data.Length), content.Emit()));

            dst.IndentLine(indent, Assign.Format(left.Emit(), right.Emit()));
        }

        public static void Emit(FS.FolderPath root)
        {
            var dst = root + FS.file("asci", FS.Txt);
            using var writer = dst.Writer();
            writer.Write(BuildAsciData(false));
            writer.Write(BuildAsciData(true));
            writer.Write(BuildAsciByteSpan(256));
        }

        const char BS = '\\';

        const char SQ = '\'';

        const char QU = '\"';

        static string BuildAsciData(bool span)
        {
            var sb = text.build();
            var count = 128;
            var name = span ? "AsciData" : "AsciDataString";
            var access = "public";
            var spanPropDecl = $"{access} static ReadOnlySpan<char> {name} => new " + $"char[{count}]" +"{";
            var constPropDecl = $"{access} const string {name} = \"";
            var propDecl = span ? spanPropDecl : constPropDecl;
            var charFence = span ? "'" : "";
            var spanPropClose = "};";
            var constPropClose = "\";";
            var propClose = span ? spanPropClose : constPropClose;

            sb.Append(propDecl);
            if(span)
                sb.AppendLine();

            for(var i=0; i<count; i++)
            {
                var c = (char)i;
                sb.Append(charFence);

                if(c == 0)
                    sb.Append(C.D0);
                else if(c == 10 || c == 13)
                    sb.Append(C.D0);
                else if(c == QU)
                    sb.Append($"\\{c}");
                else if(Char.IsControl(c) || c == BS || c == SQ)
                    sb.Append($"0");
                else
                    sb.Append(c);
                sb.Append(charFence);

                if(span)
                {
                    sb.Append(", ");
                    if(i % 8 == 0 && i != 0)
                        sb.AppendLine();
                }
            }

            sb.AppendLine(propClose);

            return sb.ToString();
        }

        static string BuildAsciByteSpan(uint size, string name = "AsciBytes")
        {
            var sb = text.build();

            var propDecl = $"publid static ReadOnlySpan<byte> {name} => new " + $"byte[{size}]" +"{";
            var propClose = "};";

            sb.Append(propDecl);
            sb.AppendLine();

            var j =0;
            for(int i=0; i<size; i++)
            {
                if(i % 2 == 0)
                    sb.Append($"{j++},");
                else
                    sb.Append("0,".PadRight(6));

                if((i + 1) % 16 == 0 && i != 0)
                    sb.AppendLine();
            }

            sb.AppendLine(propClose);

            return sb.ToString();
        }
    }

    partial class XTend
    {
        public static AsciLookupGen AsciLookups(this IServiceContext context)
            => Z0.AsciLookupGen.create(context);
    }
}