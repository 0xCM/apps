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

            public static string OpDetailHeader(int index)
                => string.Format(OpDetailPattern, OpColPatterns.Select(x => string.Format(x, index)));

            public static void RenderOps(in DisasmOpDetails ops, ITextBuffer dst)
            {
                const string RenderPattern = DisasmRender.Columns;
                dst.AppendLineFormat(RenderPattern, "Operands", EmptyString);
                dst.AppendLine(RP.PageBreak80);

                for(var i=0; i<ops.Count; i++)
                {
                    ref readonly var op =ref ops[i];
                    var tabledef = FS.FileUri.Empty;
                    if(XedParsers.parse(op.OpInfo.Selector.Format(), out Nonterminal nonterm))
                    {
                        var path = XedPaths.Service.TableDef(RuleTableKind.Enc, nonterm);
                        if(path.Exists)
                            tabledef = path;
                        else
                        {
                            path = XedPaths.Service.TableDef(RuleTableKind.Dec, nonterm);
                            if(path.Exists)
                                tabledef = path;
                        }
                    }

                    dst.AppendLine(string.Format("{0} | {1,-6} | {2,-4} | {3,-4} | {4,-4} | {5,-4} | {6}",
                        i,
                        XedRender.format(op.OpName),
                        XedRender.format(op.OpInfo.Action),
                        XedRender.format(op.OpInfo.WidthCode),
                        op.OpInfo.Visiblity.Code(),
                        XedRender.format(op.OpInfo.OpType),
                        nonterm.IsNonEmpty ? string.Format("{0} => {1}", nonterm, tabledef) : op.OpInfo.Selector
                    ));
                }
            }
        }
    }
}