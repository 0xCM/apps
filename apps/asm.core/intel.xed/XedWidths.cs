//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    public class XedWidths
    {
        [MethodImpl(Inline)]
        public static OpWidthInfo describe(OpWidthCode code)
            => code == 0 ? OpWidthInfo.Empty : Lookup[code];

        public static ref readonly Index<OpWidthInfo> Records
        {
            [MethodImpl(Inline)]
            get => ref Index;
        }

        public static OpWidth width(MachineMode mode, OpWidthCode code)
        {
            var dst = OpWidth.Empty;
            if(code == 0)
                return dst;
            else if(Lookup.Find(code, out var info))
            {
                switch(mode.Class)
                {
                    case ModeClass.Mode16:
                        dst = new OpWidth(code, info.Width16);
                    break;
                    case ModeClass.Not64:
                    case ModeClass.Mode32:
                        dst = new OpWidth(code, info.Width32);
                    break;

                    default:
                        dst = new OpWidth(code, info.Width64);
                    break;
                }
            }
            else
                Errors.Throw(code.ToString());
            return dst;
        }

        static XedPaths XedPaths => XedPaths.Service;

        static Index<OpWidthInfo> Index;

        static ConstLookup<OpWidthCode,OpWidthInfo> Lookup;

        static Outcome ParseWidthValue(string src, out ushort bits)
        {
            var result = Outcome.Success;
            bits = 0;
            var i = text.index(src, "bits");
            if(i > 0)
                result = DataParser.parse(text.left(src,i), out bits);
            else
            {
                result = DataParser.parse(src, out ushort bytes);
                if(result)
                    bits = (ushort)(bytes*8);
            }
            return result;
        }

        static XedWidths()
        {
            Index = load();
            Lookup = Index.Select(x => (x.Code,x)).ToDictionary();
        }

        static Index<OpWidthInfo> load()
        {
            var buffer = dict<OpWidthCode,OpWidthInfo>();
            var symbols = Symbols.index<OpWidthCode>();
            var src = XedPaths.DocSource(XedDocKind.Widths);
            using var reader = src.Utf8LineReader();
            var result = Outcome.Success;
            while(reader.Next(out var line))
            {
                var content = text.trim(line.Content);
                if(text.empty(content) || content.StartsWith(Chars.Hash))
                    continue;

                var i = text.index(content, Chars.Hash);
                if(i>0)
                    content = text.left(content,i);

                var cells = text.split(text.despace(content), Chars.Space);
                if(cells.Length < 3)
                {
                    result = (false, content);
                    break;
                }

                ref readonly var code = ref skip(cells,0);
                ref readonly var xtype = ref skip(cells,1);
                ref readonly var wdefault = ref skip(cells,2);

                var dst = OpWidthInfo.Empty;
                result = XedParsers.parse(code, out dst.Code);

                if(result.Fail)
                {
                    result = (false, Msg.ParseFailure.Format(nameof(dst.Code), code));
                    break;
                }

                if(dst.Code == 0)
                    continue;

                symbols.MapKind(dst.Code, out var sym);
                dst.Name = sym.Expr.Format();
                result = XedParsers.parse(xtype, out dst.ElementType);
                if(result.Fail)
                {
                    result = (false,Msg.ParseFailure.Format(nameof(dst.ElementType), xtype));
                    break;
                }

                dst.CellWidth = OpWidthSpec.bitwidth(dst.Code, dst.ElementType);

                result = ParseWidthValue(wdefault, out dst.Width16);
                if(result.Fail)
                {
                    result = (false,Msg.ParseFailure.Format(nameof(dst.Width16), wdefault));
                    break;
                }
                else
                {
                    dst.Width32 = dst.Width16;
                    dst.Width64 = dst.Width16;
                }

                if(cells.Length >= 4)
                    result = ParseWidthValue(skip(cells,3), out dst.Width32);

                if(result.Fail)
                {
                    result = (false,Msg.ParseFailure.Format(nameof(dst.Width32), skip(cells,3)));
                    break;
                }

                if(cells.Length >= 5)
                    result = ParseWidthValue(skip(cells,4), out dst.Width64);

                if(result.Fail)
                {
                    result = (false,Msg.ParseFailure.Format(nameof(dst.Width64), skip(cells,4)));
                    break;
                }

                dst.SegType = BitSegType.define(OpWidthSpec.@class(dst.Code), dst.Width64, dst.CellWidth);
                buffer.TryAdd(dst.Code, dst);

            }

            if(result.Fail)
                Errors.Throw(result.Message);

            return buffer.Values.Array().Sort();
        }
    }
}