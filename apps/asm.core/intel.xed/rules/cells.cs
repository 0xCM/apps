//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;

    using CK = XedRules.RuleCellKind;

    partial class XedRules
    {
        public static Index<RuleGridRow> cells(in RuleTable src)
        {
            var buffer = alloc<RuleGridRow>(src.Body.Count);
            ref readonly var statements = ref src.Body;
            for(var j=0; j<statements.Count; j++)
            {
                var m = z8;
                ref var dst = ref seek(buffer,j);
                ref readonly var left = ref statements[j].Premise;
                for(var k=0; k<left.Count; k++)
                {
                    dst[m] = new RuleGridCell(true, m, src.TableKind, left[k]);
                    m++;
                }
                ref readonly var right = ref statements[j].Consequent;
                for(var k=0; k<right.Count; k++)
                {
                    dst[m] = new RuleGridCell(false, m, src.TableKind, right[k]);
                    m++;
                }
                dst.Count = m;
            }

            return buffer;
        }

        [Op]
        static RuleCellKind cellkind(string data)
        {
            var kind = CK.None;
            var left = EmptyString;
            if(XedParsers.IsFieldExpr(data))
            {
                XedParsers.parse(data, out OperatorKind op);
                if(op == OperatorKind.Eq)
                    kind = CK.Eq;
                else if(op == OperatorKind.Neq)
                    kind = CK.Neq;
                else
                    Errors.Throw($"{data} is not an expression");

                return kind;
            }

            if(XedParsers.IsBinaryLiteral(data))
                kind = CK.Bits;
            else if(XedParsers.IsHexLiteral(data))
                kind = CK.Hex;
            else if(XedParsers.IsIntLiteral(data))
                kind = CK.Int;

            if(kind != 0)
                return kind;

            if(XedParsers.IsBfSeg(data))
            {
                if(XedParsers.parse(data, out BfSeg _))
                {
                    kind = CK.BfSeg;
                    return kind;
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

                    return kind;
                }
            }

            if(XedParsers.IsBfSpec(data))
                kind = CK.BfSpec;
            else if(XedParsers.IsNontermCall(data))
                kind = CK.Nonterminal;
            if(kind == 0)
                kind = CK.FieldLiteral;

            return kind;
        }

        public static Index<RuleCell> cells(bool premise, string src)
        {
            var input = text.trim(text.despace(src));
            var cells = list<string>();
            if(text.contains(input, Chars.Space))
            {
                var parts = text.split(input, Chars.Space);
                var count = parts.Length;
                for(var j=0; j<count; j++)
                {
                    ref readonly var part = ref skip(parts,j);
                    if(RuleMacros.match(part, out var match))
                    {
                        var expanded = text.trim(match.Expansion);
                        if(text.contains(expanded, Chars.Space))
                        {
                            var expansions = text.split(expanded, Chars.Space);
                            for(var k=0; k<expansions.Length; k++)
                            {
                                ref readonly var x = ref skip(expansions,k);
                                cells.Add(x);
                            }
                        }
                        else
                            cells.Add(expanded);
                    }
                    else
                        cells.Add(part);
                }
            }
            else
            {
                if(RuleMacros.match(input, out var match))
                    cells.Add(match.Expansion);
                else
                    cells.Add(input);
            }

            return cells.Map(x => new RuleCell(premise, cellkind(x),x));
        }
    }
}