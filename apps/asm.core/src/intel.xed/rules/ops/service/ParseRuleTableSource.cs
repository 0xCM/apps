//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;
    using static Root;

    using EK = XedModels.XedRuleExprKind;

    partial class XedRules
    {
        Index<RuleTable> ParseRuleTableSource(FS.FilePath src)
        {
            var tables = list<RuleTable>();
            using var reader = src.Utf8LineReader();
            var table = RuleTable.Empty;
            var expressions = list<XedRuleExpr>();
            var kind = EK.None;
            var line = TextLine.Empty;

            void ParseSeqTerms()
            {
                while(reader.Next(out line))
                {
                    if(line.IsEmpty || line.StartsWith(Chars.Hash))
                        continue;

                    kind = ClassifyExpr(line);
                    if(kind == 0 || kind == EK.Invocation)
                        continue;
                    else
                        break;
                }
            }

            static string Normalize(string src)
            {
                var i = text.index(src, Chars.Hash);
                if(i>0)
                    return text.trim(text.left(src,i));
                else
                    return text.trim(src);
            }

            XedRuleExpr CreateRuleExpr(EK kind, string premise, string consequent = EmptyString)
            {
                var left = sys.empty<RuleCriterion>();
                var right = sys.empty<RuleCriterion>();

                if(nonempty(premise))
                    left = ParseRuleCriteria(premise);

                if(nonempty(consequent))
                    right = ParseRuleCriteria(consequent);

                return new XedRuleExpr(kind, premise, consequent, left, right);
            }


            Outcome ParseRuleDeclTerms()
            {
                var result = Outcome.Success;
                while(reader.Next(out line))
                {
                    if(line.IsEmpty || line.StartsWith(Chars.Hash))
                        continue;

                    kind = ClassifyExpr(line);
                    if(kind == 0)
                        continue;

                    var content = Normalize(line.Content);
                    var parts = sys.empty<string>();
                    if(kind == EK.EncodeStep)
                    {
                        parts = text.split(content, EncStepMarker).Map(x => x.Trim());
                        if(parts.Length == 2)
                            table.Expressions.Add(CreateRuleExpr(kind, parts[0], parts[1]));
                        else
                        {
                            result = (false, StepParseFailed.Format(content));
                            break;
                        }
                    }
                    else if(kind == EK.DecodeStep)
                    {
                        parts = text.split(content, DecStepMarker).Map(x => x.Trim());
                        if(parts.Length == 1)
                            table.Expressions.Add(CreateRuleExpr(kind, parts[0]));
                        else if(parts.Length == 2)
                            table.Expressions.Add(CreateRuleExpr(kind, parts[0], parts[1]));
                        else
                        {
                            result = (false, StepParseFailed.Format(content));
                            break;
                        }
                    }
                    else
                        break;

                }
                return result;
            }

            Outcome ParseRuleDecl()
            {
                var result = Outcome.Success;
                var ruledecl = text.trim(text.left(line.Content, RuleDeclMarker));
                var i = text.index(ruledecl, Chars.Space);
                if(i > 0)
                {
                    table.Name = text.right(ruledecl,i);
                    table.ReturnType = text.left(ruledecl,i);
                }
                else
                {
                    table.Name = ruledecl;
                    table.ReturnType = EmptyString;
                }
                result = ParseRuleDeclTerms();
                if(result.Fail)
                    return result;
                tables.Add(table);
                table = RuleTable.Empty;
                return result;
            }

            Outcome ParseNext()
            {
                var result = Outcome.Success;
                if(kind == EK.SeqDeclaration)
                    ParseSeqTerms();

                while(kind == EK.RuleDeclaration)
                {
                    result = ParseRuleDecl();
                    if(result.Fail)
                        return result;
                }

                return result;
            }

            while(reader.Next(out line))
            {
                if(line.IsEmpty || line.StartsWith(Chars.Hash))
                    continue;

                kind = ClassifyExpr(line);
                var result = ParseNext();
                if(result.Fail)
                {
                    Error(result.Message);
                    break;
                }
            }

            return tables.ToArray();
        }
    }
}