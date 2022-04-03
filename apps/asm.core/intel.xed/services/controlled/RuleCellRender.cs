//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using CK = XedRules.RuleCellKind;
    using DK = XedRules.CellDataKind;

    partial class XedRules
    {
        public readonly struct RuleCellRender
        {
            public static uint render(in RuleTableSpec spec, ITextBuffer dst)
            {
                var counter=0u;
                counter += RenderRows(spec, dst);
                dst.AppendLine();
                counter += RenderContent(spec, dst);
                return counter;
            }

            public static void render(Index<RuleTableSpec> specs, ITextBuffer dst)
            {
                for(var i=0; i<specs.Count; i++)
                {
                    dst.AppendLine();
                    render(specs[i], dst);
                }
            }

            public static string format(RuleCellKind src)
            {
                var dst = EmptyString;
                dst = XedRender.format(datakind(src));
                return dst;
            }

            public static string format(in RuleCriterion src)
            {
                var result = EmptyString;
                switch(src.DataKind)
                {
                    case DK.BfSegExpr:
                    case DK.NontermExpr:
                    case DK.FieldEq:
                    case DK.FieldNeq:
                        result = src.ToFieldExpr().Format();
                    break;
                    case DK.BfSeg:
                        result = src.ToBfSeg().Format();
                    break;
                    case DK.BfSpec:
                        result = src.ToBfSpec().Format();
                    break;
                    case DK.Branch:
                    case DK.Null:
                    case DK.FieldLiteral:
                    case DK.Error:
                        result = src.ToFieldLiteral().Format();
                    break;
                    case DK.Nonterminal:
                        result = src.ToNonTerminal().Format();
                    break;
                    case DK.Operator:
                        result = src.ToOperator().Format();
                        break;
                    default:
                        Errors.Throw($"{src.Field} | {src.Operator} | {src.DataKind}");
                    break;

                }
                return result;
            }

            static Outcome split(RuleCell src, out RuleCellKind kind, out string value)
            {
                var data = src.Data;
                value = data;
                kind = CK.None;
                var left = EmptyString;
                if(src.IsExpr)
                {
                    if(src.Operator == OperatorKind.Eq)
                    {
                        kind = CK.Eq;
                        eq(data, out left, out value);
                    }
                    else if(src.Operator == OperatorKind.Neq)
                    {
                        kind = CK.Neq;
                        neq(data, out left, out value);
                    }
                    else
                        Errors.Throw($"{data} is not an expression");

                    return true;
                }

                if(XedParsers.IsBinaryLiteral(value))
                    kind |= CK.Bits;
                else if(XedParsers.IsHexLiteral(value))
                    kind |= CK.Hex;
                else if(XedParsers.IsIntLiteral(value))
                    kind |= CK.Int;

                if(kind != 0)
                    return true;

                if(XedParsers.IsBfSeg(data))
                {
                    if(XedParsers.parse(data, out BfSeg bfs))
                    {
                        value = bfs.Pattern;
                        kind |= CK.BfSeg;
                        return true;
                    }
                }

                if(FieldLiteral.test(data))
                {
                    if(FieldLiteral.parse(data, out FieldLiteral literal))
                    {
                        if(literal == FieldLiteral.Branch)
                            kind = CK.Branch;
                        else if(literal == FieldLiteral.Null)
                            kind = CK.Null;
                        else if(literal == FieldLiteral.Error)
                            kind = CK.Error;
                        else
                            kind = CK.FieldLiteral;

                        return true;
                    }
                }

                if(XedParsers.IsBfSpec(data))
                    kind |= CK.BfSpec;
                else if(XedParsers.IsNontermCall(value))
                    kind |= CK.Nonterminal;

                if(kind == 0)
                    kind = CK.FieldLiteral;

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
                var result = split(cell, out RuleCellKind cellkind, out var value);
                return string.Format(SpecRender,
                    sig.TableKind,
                    sig.ShortName,
                    row,
                    format(cellkind),
                    cell.IsPremise ? 'P' : 'C',
                    col,
                    cellkind == RuleCellKind.BfSeg
                        ? string.Format("{0}[{1}]", XedRender.format(cell.Field), value)
                        : cell.Operator.IsNonEmpty
                        ? string.Format("{0}{1}{2}", XedRender.format(cell.Field), XedRender.format(cell.Operator), value)
                        : value,
                    cell.Data
                    );
            }

            static uint RenderRows(in RuleTableSpec spec, ITextBuffer dst)
            {
                var counter = 0u;
                var statements = spec.Statements;
                for(var j=0u; j<statements.Count; j++)
                {
                    ref readonly var statement = ref statements[j];
                    byte col = 0;
                    for(byte q=0; q<statement.Premise.Count; q++, counter++)
                        dst.AppendLine(FormatRow(j, col++, spec.Sig, statement.Premise[q]));

                    for(byte q=0; q<statement.Consequent.Count; q++, counter++)
                        dst.AppendLine(FormatRow(j, col++, spec.Sig, statement.Consequent[q]));
                }
                return counter;
            }

            static uint RenderContent(in RuleTableSpec spec, ITextBuffer dst)
            {
                var counter = 0u;
                foreach(var line in spec.Format().Lines(trim:false))
                {
                    dst.AppendLineFormat("# {0}", line.Content);
                    counter++;
                }
                return counter;
            }


            const string SpecRender = "{0,-8} | {1,-32} | {2,-8} | {3,-8} | {4,-8} | {5,-8} | {6,-28} | {7}";

            public static string SpecHeader = string.Format(SpecRender, "Kind", "TableName", "Row",  "ColKind", "Logic", "Col", "Expr", "SourceExpr");
        }
    }
}