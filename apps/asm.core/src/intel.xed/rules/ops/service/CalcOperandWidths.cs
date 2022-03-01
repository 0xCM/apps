//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;

    partial class XedRules
    {
        public Index<OperandWidth> CalcOperandWidths()
        {
            var buffer = list<OperandWidth>();
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

                ref readonly var c0 = ref skip(cells,0);
                ref readonly var c1 = ref skip(cells,1);
                ref readonly var c2 = ref skip(cells,2);

                var dst = default(OperandWidth);

                result = OpWidthTypes.ExprKind(c0, out dst.Code);
                if(result.Fail)
                {
                    result = (false,Msg.ParseFailure.Format(nameof(dst.Code), c0));
                    break;
                }

                dst.Name = OpWidthTypes[dst.Code].Expr.Format();

                result = DataTypes.ExprKind(c1, out dst.BaseType);
                if(result.Fail)
                {
                    result = (false,Msg.ParseFailure.Format(nameof(dst.BaseType), c1));
                    break;
                }

                static Outcome ParseWidthValue(string src, out uint bits)
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
                            bits = (uint)(bytes*8);
                    }
                    return result;
                }

                result = ParseWidthValue(c2, out dst.Width16);
                if(result.Fail)
                {
                    result = (false,Msg.ParseFailure.Format(nameof(dst.Width16), c2));
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

                buffer.Add(dst);
            }

            if(result.Fail)
                Error(result.Message);

            return buffer.ToArray();
        }
    }
}