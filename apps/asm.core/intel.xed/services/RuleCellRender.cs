//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    partial class XedRules
    {
        public readonly struct RuleCellRender
        {
            public static void render(Index<RuleTableSpec> specs, ITextBuffer dst)
            {
                for(var i=0; i<specs.Count; i++)
                {
                    dst.AppendLine();
                    render(specs[i], dst);
                }
            }

            public static void render(in RuleTableSpec spec, ITextBuffer dst)
            {
                RenderRows(spec, dst);
                dst.AppendLine();
                RenderContent(spec, dst);
            }

            static Outcome split(RuleCell src, out string value)
            {
                var data = src.Data;
                value = data;
                var left = EmptyString;
                if(src.IsExpr)
                {
                    if(src.Operator == OperatorKind.Eq)
                        eq(data, out left, out value);
                    else if(src.Operator == OperatorKind.Neq)
                        neq(data, out left, out value);
                    else
                        Errors.Throw($"{data} is not an expression");

                    return true;
                }

                if(XedParsers.IsBfSeg(data) && XedParsers.parse(data, out BfSeg bfs))
                    value = bfs.Pattern;

                return true;
            }

            static bool eq(string src, out string left, out string right)
            {
                var result = false;
                if(XedParsers.IsEq(src))
                {
                    var i = text.index(src, Chars.Eq);
                    left = text.left(src,i);
                    right = text.right(src,i);
                    result = true;
                }
                else
                {
                    left = EmptyString;
                    right = EmptyString;
                }
                return result;
            }

            static bool neq(string src, out string left, out string right)
            {
                var result = false;
                if(XedParsers.IsNeq(src))
                {
                    var i = text.index(src, Chars.Bang);
                    left = text.left(src,i);
                    right = text.right(src,i+1);
                    result = true;
                }
                else
                {
                    left = EmptyString;
                    right = EmptyString;
                }
                return result;
            }

            static string FormatRow(uint row, byte col, RuleSig sig, RuleCell cell)
            {
                var result = split(cell, out var value);
                return string.Format(SpecRender,
                    sig.TableKind,
                    sig.ShortName,
                    row,
                    XedRender.format(cell.Kind),
                    cell.IsPremise ? 'P' : 'C',
                    col,
                    cell.Kind == RuleCellKind.BfSeg
                        ? string.Format("{0}[{1}]", XedRender.format(cell.Field), value)
                        : cell.Operator.IsNonEmpty
                        ? string.Format("{0}{1}{2}", XedRender.format(cell.Field), XedRender.format(cell.Operator), value)
                        : value,
                    cell.Data
                    );
            }

            static void RenderRows(in RuleTableSpec spec, ITextBuffer dst)
            {
                var statements = spec.Statements;
                for(var j=0u; j<statements.Count; j++)
                {
                    ref readonly var statement = ref statements[j];
                    byte col = 0;
                    for(byte q=0; q<statement.Premise.Count; q++)
                        dst.AppendLine(FormatRow(j, col++, spec.Sig, statement.Premise[q]));

                    for(byte q=0; q<statement.Consequent.Count; q++)
                        dst.AppendLine(FormatRow(j, col++, spec.Sig, statement.Consequent[q]));
                }
            }

            static void RenderContent(in RuleTableSpec spec, ITextBuffer dst)
            {
                foreach(var line in spec.Format().Lines(trim:false))
                    dst.AppendLineFormat("# {0}", line.Content);
            }

            const string SpecRender = "{0,-8} | {1,-32} | {2,-8} | {3,-8} | {4,-8} | {5,-8} | {6,-28} | {7}";

            public static string SpecHeader = string.Format(SpecRender, "Kind", "TableName", "Row",  "ColKind", "Logic", "Col", "Expr", "SourceExpr");
        }
    }
}