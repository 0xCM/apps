//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;

    partial class XedPatterns
    {
        public Index<OpWidthInfo> CalcOpWidths()
            => OpWidths;

        ConstLookup<OpWidthCode,OpWidthInfo> CalcOpWidthLookup(Index<OpWidthInfo> src)
            => src.Select(x => (x.Code,x)).ToDictionary();

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

        Index<OpWidthInfo> LoadOpWidths()
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
                result = XedParsers.parse(xtype, out dst.CellType);
                if(result.Fail)
                {
                    result = (false,Msg.ParseFailure.Format(nameof(dst.CellType), xtype));
                    break;
                }

                dst.CellWidth = bitwidth(dst.Code, dst.CellType);

                result = ParseWidthValue(wdefault, out dst.Width16);
                if(result.Fail)
                {
                    result = (false,Msg.ParseFailure.Format(nameof(dst.Width16), wdefault));
                    break;
                }
                dst.Width32 = dst.Width16;
                dst.Width64 = dst.Width16;

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



                dst.Seg = SegType.define(@class(dst.Code), dst.Width64, bitwidth(dst.Code, dst.CellType));

                if(!buffer.TryAdd(dst.Code, dst))
                {
                    var present = buffer[dst.Code];
                    Warn(string.Format("Duplicate: {0} | {1} || {2} | {3}", present.Name, present.Code, dst.Name, dst.Code));
                }
            }

            if(result.Fail)
                Errors.Throw(result.Message);

            return buffer.Values.Array().Sort();
        }
    }
}