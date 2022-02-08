//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static XedRecords;
    using static core;

    partial class XedRules
    {
        Outcome ParseOperands(string src, out Index<RuleOpSpec> dst)
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
            dst = new RuleOpSpec(name, attribs);
            var kind = XedRuleOps.kind(name);
            dst.Kind = kind;
            dst.Name = name;
            switch(kind)
            {
                case XedRuleOpKind.Agen:
                break;

                case XedRuleOpKind.Base:
                break;

                case XedRuleOpKind.Disp:
                break;

                case XedRuleOpKind.Imm:
                break;

                case XedRuleOpKind.Index:
                break;

                case XedRuleOpKind.Mem:
                break;

                case XedRuleOpKind.Ptr:
                break;

                case XedRuleOpKind.Reg:
                break;

                case XedRuleOpKind.RelBr:
                break;

                case XedRuleOpKind.Scale:
                break;

                case XedRuleOpKind.Seg:
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
                var _attribs = text.right(src,i);
                if(text.empty(_attribs))
                    result = (false, string.Format("No attributes found in {0}", src));
                else
                    dst = text.split(_attribs, Chars.Colon).Where(text.nonempty);
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