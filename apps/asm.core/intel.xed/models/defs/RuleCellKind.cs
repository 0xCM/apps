//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using DK = XedRules.CellDataKind;
    using CK = XedRules.RuleCellKind;

    partial class XedRules
    {
        [SymSource(xed)]
        public enum CellDataKind : byte
        {
            [Symbol("")]
            None,

            [Symbol("neq(x)")]
            FieldNeq,

            [Symbol("eq(x)")]
            FieldEq,

            [Symbol("nt")]
            Nonterminal,

            [Symbol("nt(x)")]
            NontermExpr,

            [Symbol("bfseg(x)")]
            BfSegExpr,

            [Symbol("bfseg")]
            BfSeg,

            [Symbol("number")]
            Number,

            [Symbol("bfspec")]
            BfSpec,

            [Symbol("branch")]
            Branch,

            [Symbol("null")]
            Null,

            [Symbol("error")]
            Error,

            [Symbol("literal")]
            FieldLiteral,

            [Symbol("?")]
            Unknown,
        }

        public enum RuleCellKind : ushort
        {
            None,

            FieldLiteral = 1,

            Nonterminal = 2,

            Error = 4,

            Eq = 8,

            Neq = 16,

            BfSeg = 32,

            BfSpec = 64,

            Bits = 128,

            Int = 256,

            Hex = 512,

            Branch = 1024,

            Null = 2048,
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
                default:
                    Errors.Throw($"{src.Field} | {src.Operator} | {src.DataKind}");
                break;

            }
            return result;
        }

        public static bool IsFieldLiteral(string src)
        {
            var result = false;
            switch(src)
            {
                case "default":
                case "else":
                case "otherwise":
                case "nothing":
                case "null":
                case "error":
                case "@":
                    result = true;
                break;
            }
            return result;
        }

        public static bool parse(string src, out FieldLiteral dst)
        {
            var result = true;
            var input = text.trim(src);
            dst = FieldLiteral.Empty;
            switch(input)
            {
                case "default":
                    dst = FieldLiteral.Default;
                    break;
                case "else":
                case "otherwise":
                    dst = FieldLiteral.Branch;
                break;
                case "nothing":
                case "null":
                    dst = FieldLiteral.Null;
                break;
                case "error":
                    dst = FieldLiteral.Error;
                break;
                case "@":
                    dst = FieldLiteral.Wildcard;
                break;
                default:
                    if(src.Length <= 8)
                        dst = FieldLiteral.Text(input);
                    else
                        result = false;
                break;
            }

            return result;
        }

        public static Outcome split(RuleCell src, out RuleCellKind kind, out string value)
        {
            var data = src.Data;
            value = data;
            kind = CK.None;
            var left = EmptyString;
            if(src.IsExpr)
            {
                if(src.Operator == RuleOperator.Eq)
                {
                    kind = CK.Eq;
                    XedParsers.Eq(data, out left, out value);
                }
                else if(src.Operator == RuleOperator.Neq)
                {
                    kind = CK.Neq;
                    XedParsers.Neq(data, out left, out value);
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

            if(IsFieldLiteral(data))
            {
                if(parse(data, out FieldLiteral fl))
                {
                    if(fl == FieldLiteral.Branch)
                        kind = CK.Branch;
                    else if(fl == FieldLiteral.Null)
                        kind = CK.Null;
                    else if(fl == FieldLiteral.Error)
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

        public static CellDataKind datakind(RuleCellKind src)
        {
            var nt = src.Test(CK.Nonterminal);
            var bfseg = src.Test(CK.BfSeg);
            var eq = src.Test(CK.Eq);
            var neq = src.Test(CK.Neq);
            var expr = eq || neq;
            if(expr && nt)
                return DK.NontermExpr;
            else if(expr && bfseg)
                return DK.BfSegExpr;
            else if(eq)
                return DK.FieldEq;
            else if(neq)
                return DK.FieldNeq;
            else if(bfseg)
                return DK.BfSeg;
            else if(src.Test(CK.Bits) || src.Test(CK.Hex) || src.Test(CK.Int))
                return DK.Number;
            else if(nt)
                return DK.Nonterminal;
            else if(src.Test(CK.BfSpec))
                return DK.BfSpec;

            switch(src)
            {
                case CK.Branch:
                    return DK.Branch;
                case CK.Null:
                    return DK.Null;
                case CK.Error:
                    return DK.Error;
                case CK.FieldLiteral:
                    return DK.FieldLiteral;
            }

            return DK.Unknown;
        }
   }
}