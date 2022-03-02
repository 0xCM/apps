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
        Outcome CalcOperands(string src, out Index<RuleOpSpec> dst)
        {
            var result = Outcome.Success;
            dst = sys.empty<RuleOpSpec>();
            var buffer = list<RuleOpSpec>();
            var input = text.despace(src);
            if(input.Contains(Chars.Space))
            {
                var opssrc = text.split(input, Chars.Space);
                var count = opssrc.Length;
                for(var j=0; j<count; j++)
                {
                    result = ParseOperand(skip(opssrc, j), out var op);
                    if(result)
                        buffer.Add(op);
                    else
                        break;
                }
            }
            else
            {
                result = ParseOperand(input, out var op);
                if(result)
                    buffer.Add(op);
            }
            if(result)
                dst = buffer.ToArray();
            return result;
        }

        Outcome ParseOpDirection(string src, out OpDirection dst)
        {
            var result = Outcome.Success;
            switch(src)
            {
                case "r":
                    dst = OpDirection.In;
                break;
                case "w":
                    dst = OpDirection.Out;
                break;
                case "rw":
                    dst = OpDirection.IO;
                break;
                default:
                    dst = 0;
                    result = (false, string.Format("Unexpected direction specification in {0}", src));
                break;
            }
            return result;
        }

        Outcome ParseOperand(RuleOpName name, string[] attribs, out RuleOpSpec dst)
        {
            var result = Outcome.Success;
            dst = new RuleOpSpec();
            dst.Name = name;
            dst.Kind = XedRules.opkind(name);
            dst.Name = name;
            dst.Function = TableFunction.Empty;
            dst.Attributes = attribs;
            switch(dst.Kind)
            {
                case RuleOpKind.Agen:
                break;

                case RuleOpKind.Base:
                break;

                case RuleOpKind.Disp:
                break;

                case RuleOpKind.Imm:
                break;

                case RuleOpKind.Index:
                break;

                case RuleOpKind.Mem:
                break;

                case RuleOpKind.Ptr:
                break;

                case RuleOpKind.Reg:
                break;

                case RuleOpKind.RelBr:
                break;

                case RuleOpKind.Scale:
                break;

                case RuleOpKind.Seg:
                break;

            }
            return result;
        }

        Outcome ParseImmOperand(RuleOpName name, string[] attribs, out RuleOpSpec dst)
        {
            var result = Outcome.Success;
            var dir = OpDirection.None;
            var refinement = EmptyString;
            dst = default;
            return result;
        }

        Outcome ParseMemOperand(RuleOpName name, string[] attribs, out RuleOpSpec dst)
        {
            var result = Outcome.Success;
            var dir = OpDirection.None;
            var refinement = EmptyString;
            dst = default;
            return result;
        }

        Outcome ParseRegOperand(RuleOpName name, string[] attribs, out RuleOpSpec dst)
        {
            var result = Outcome.Success;
            var dir = OpDirection.None;
            var fx = default(TableFunction);
            var refinement = EmptyString;
            var width = OperandWidth.Empty;
            dst = default;
            return result;
        }

        Outcome ParseOpWidth(string src, out OperandWidth dst)
        {
            var result = Outcome.Success;
            var widths = OperandWidths();
            result = widths.Find(src, out dst);
            if(result.Fail)
                result = (false, string.Format("Unexpected width expression:{0}", src));
            return result;
        }

        Outcome ParseOpName(string src, out RuleOpName dst)
        {
            var result = Outcome.Success;
            var i = text.index(src, Chars.Eq, Chars.Colon);
            dst = RuleOpName.None;
            if(i > 0)
            {
                var name = text.left(src,i);
                result = OpKinds.ExprKind(name, out dst);
                if(result.Fail)
                    result = (false, Msg.ParseFailure.Format(nameof(RuleOpName), src));
            }
            return result;
        }

        Outcome ExtractOpAttributes(string src, out string[] dst)
        {
            var result = Outcome.Success;
            var i = text.index(src,Chars.Eq, Chars.Colon);
            dst = sys.empty<string>();
            if(i > 0)
            {
                var attribs = text.right(src,i);
                if(text.empty(attribs))
                    result = (false, string.Format("No attributes found in {0}", src));
                else
                    dst = text.split(attribs, Chars.Colon).Where(text.nonempty);
            }
            return result;
        }

        Outcome ParseOperand(string src, out RuleOpSpec dst)
        {
            var result = Outcome.Success;
            dst = default;
            var name = RuleOpName.None;
            var attribs = sys.empty<string>();

            result = ParseOpName(src, out name);

            if(result)
                result = ExtractOpAttributes(src, out attribs);

            if(result)
                result = ParseOperand(name, attribs, out dst);

            dst.Expression = src;

            return result;
        }
    }
}