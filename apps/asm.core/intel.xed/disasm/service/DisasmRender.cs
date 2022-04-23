//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedRules;
    using static XedModels;

    partial class XedDisasm
    {
        internal class DisasmRender
        {
            public const string Columns = "{0,-24} | {1}";

            public const string OpDetailPattern = "{0,-4} | {1,-8} | {2,-24} | {3,-10} | {4,-12} | {5,-12} | {6,-12} | {7,-12}";

            public static string[] OpColPatterns = new string[]{"Op{0}", "Op{0}Name", "Op{0}Val", "Op{0}Action", "Op{0}Vis", "Op{0}Width", "Op{0}WKind", "Op{0}Selector"};

            public static void render(Index<DetailBlock> src, ITextEmitter dst, bool header = true)
            {
                var formatter = Tables.formatter<DetailBlockRow>(DetailBlockRow.RenderWidths);
                if(header)
                    dst.AppendLine(FormatDetailHeader(formatter));

                for(var i=0; i<src.Count; i++)
                    render(formatter, src[i].DetailRow, dst);
            }

            public static string FormatDetailHeader(IRecordFormatter<DetailBlockRow> formatter)
            {
                var headerBase = formatter.FormatHeader();
                var j = text.lastindex(headerBase, Chars.Pipe);
                headerBase = text.left(headerBase,j);
                var opheader = text.buffer();
                for(var k=0; k<6; k++)
                {
                    opheader.Append("| ");
                    opheader.Append(DisasmRender.OpDetailHeader(k));
                }

                return string.Format("{0}{1}", headerBase, opheader.Emit());
            }

            public static string format(in DisasmBlock src)
            {
                var dst = text.buffer();
                var count = src.Lines.Count;
                for(var i=0; i<count; i++)
                {
                    ref readonly var line = ref src.Lines[i];
                    if(i != count - 1)
                        dst.AppendLine(line.Content);
                    else
                        dst.Append(line.Content);
                }
                return dst.Emit();
            }

            public static void render(IRecordFormatter<DetailBlockRow> formatter, in DetailBlockRow src, ITextEmitter dst)
                => dst.AppendLine(formatter.Format(src));

            public static string OpDetailHeader(int index)
                => string.Format(OpDetailPattern, OpColPatterns.Select(x => string.Format(x, index)));

            public static void RenderOps(in OpDetails ops, ITextEmitter dst)
            {
                const string RenderPattern = DisasmRender.Columns;
                dst.AppendLineFormat(RenderPattern, "Operands", EmptyString);
                dst.AppendLine(RP.PageBreak80);

                for(var i=0; i<ops.Count; i++)
                {
                    ref readonly var op =ref ops[i];
                    var tabledef = FS.FileUri.Empty;
                    var nonterm = op.OpInfo.Selector;

                    if(nonterm.IsNonEmpty)
                    {
                        var uri = XedPaths.Service.TableDef(RuleTableKind.ENC, nonterm);
                        if(uri.Path.Exists)
                            tabledef = uri;
                        else
                        {
                            uri = XedPaths.Service.TableDef(RuleTableKind.DEC, nonterm);
                            if(uri.Path.Exists)
                                tabledef = uri;
                        }
                    }

                    dst.AppendLine(string.Format("{0} | {1,-6} | {2,-4} | {3,-4} | {4,-4} | {5,-16} | {6}",
                        i,
                        XedRender.format(op.OpName),
                        XedRender.format(op.OpInfo.Action),
                        XedRender.format(op.OpInfo.WidthCode),
                        op.OpInfo.Visibility.Code(),
                        XedRender.format(op.OpInfo.OpType),
                        nonterm.IsNonEmpty ? string.Format("{0} => {1}", nonterm, tabledef) : op.OpInfo.SelectorName
                    ));
                }
            }
        }
    }
}