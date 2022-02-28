//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;
    using static Root;


    using EK = XedRules.RuleFormKind;

    partial class XedRules
    {
        public struct RuleTableParser
        {
            RuleTable Table;

            List<RuleTable> Tables;

            LineReader Reader;

            Symbols<FieldKind> OperandKinds;

            RuleFormKind Kind;

            TextLine Line;

            public RuleTableParser()
            {
                OperandKinds = Symbols.index<FieldKind>();
                Table = RuleTable.Empty;
                Reader = default;
                Tables = new();
                Line = TextLine.Empty;
                Kind = 0;
            }

            Outcome ParseNext()
            {
                var result = Outcome.Success;
                Kind = ClassifyExpr(Line);
                if(Kind == EK.SeqDeclaration)
                    ParseSeqTerms();

                while(Kind == EK.RuleDeclaration)
                {
                    result = ParseRuleDecl();
                    if(result.Fail)
                        return result;
                }

                return result;
            }

            public Index<RuleTable> Parse(FS.FilePath src)
            {
                try
                {
                    Reader = src.Utf8LineReader();
                    Parse();
                    return Tables.ToArray();
                }
                finally
                {
                    Reader.Dispose();
                }
            }

            void Parse()
            {
                while(Reader.Next(out Line))
                {
                    if(Line.IsEmpty || Line.StartsWith(Chars.Hash))
                        continue;

                    ParseNext().Require();
                }
            }

            Index<RuleCriterion> ParseRuleCriteria(string src)
            {
                var left = text.trim(text.split(src, Chars.Space));
                var count = left.Length;
                var buffer = alloc<RuleCriterion>(count);
                for(var i=0; i<count; i++)
                {
                    ref readonly var spec = ref skip(left, i);
                    if(empty(spec))
                        continue;

                    ref var dst = ref seek(buffer,i);
                    var fk = FieldKind.INVALID;
                    var op = RuleOperator.None;
                    var fv = EmptyString;
                    var j = text.index(spec, Chars.Eq);
                    var k = text.index(spec, "!=");
                    var name = EmptyString;

                    if(k >= 0)
                    {
                        op = RuleOperator.Neq;
                        name = text.left(spec,k);
                        fv = text.right(spec,k + "!=".Length + 1);
                    }
                    else if(j >=0)
                    {
                        op = RuleOperator.Eq;
                        name = text.left(spec,j);
                        fv = text.right(spec,j);
                    }
                    else
                    {
                        fv = spec;
                    }

                    if(nonempty(name))
                    {
                        if(name.Equals("REXW[w]"))
                            fk = FieldKind.REXW;
                        else if(name.Equals("REXB[b]"))
                            fk = FieldKind.REXB;
                        else if(name.Equals("REXR[r]"))
                            fk = FieldKind.REXR;
                        else if(name.Equals("REXX[x]"))
                            fk = FieldKind.REXX;
                        else if(!OperandKinds.ExprKind(name, out fk))
                            Errors.Throw(string.Format("Kind for {0} not found in {1}", name, src));
                    }

                    dst = new RuleCriterion(fk, op, fv);
                }
                return buffer;
            }

            void ParseSeqTerms()
            {
                while(Reader.Next(out Line))
                {
                    if(Line.IsEmpty || Line.StartsWith(Chars.Hash))
                        continue;

                    Kind = ClassifyExpr(Line);
                    if(Kind == 0 || Kind == EK.Invocation)
                        continue;
                    else
                        break;
                }
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
                while(Reader.Next(out Line))
                {
                    if(Line.IsEmpty || Line.StartsWith(Chars.Hash))
                        continue;

                    Kind = ClassifyExpr(Line);
                    if(Kind == 0)
                        continue;

                    var content = normalize(Line.Content);
                    var parts = sys.empty<string>();
                    if(Kind == EK.EncodeStep)
                    {
                        parts = text.split(content, EncStepMarker).Map(x => x.Trim());
                        if(parts.Length == 2)
                            Table.Expressions.Add(CreateRuleExpr(Kind, parts[0], parts[1]));
                        else
                        {
                            result = (false, StepParseFailed.Format(content));
                            break;
                        }
                    }
                    else if(Kind == EK.DecodeStep)
                    {
                        parts = text.split(content, DecStepMarker).Map(x => x.Trim());
                        if(parts.Length == 1)
                            Table.Expressions.Add(CreateRuleExpr(Kind, parts[0]));
                        else if(parts.Length == 2)
                            Table.Expressions.Add(CreateRuleExpr(Kind, parts[0], parts[1]));
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
                var ruledecl = text.trim(text.left(Line.Content, RuleDeclMarker));
                var i = text.index(ruledecl, Chars.Space);
                if(i > 0)
                {
                    Table.Name = text.right(ruledecl,i);
                    Table.ReturnType = text.left(ruledecl,i);
                }
                else
                {
                    Table.Name = ruledecl;
                    Table.ReturnType = EmptyString;
                }
                result = ParseRuleDeclTerms();
                if(result.Fail)
                    return result;
                Tables.Add(Table);
                Table = RuleTable.Empty;
                return result;
            }

            const string RuleDeclMarker = "()::";

            const string InvokeMarker = "()";

            const string EncStepMarker = " -> ";

            const string DecStepMarker = " |";

            const string SeqDeclMarker = "SEQUENCE ";

            static EK ClassifyExpr(TextLine src)
            {
                var i = text.index(src.Content, Chars.Hash);
                var content = (i> 0 ? text.left(src.Content,i) : src.Content).Trim();

                if(content.EndsWith(RuleDeclMarker))
                    return EK.RuleDeclaration;
                if(content.Contains(EncStepMarker))
                    return EK.EncodeStep;
                if(content.Contains(DecStepMarker))
                    return EK.DecodeStep;
                if(content.EndsWith(InvokeMarker))
                    return EK.Invocation;
                if(content.StartsWith(SeqDeclMarker))
                    return EK.SeqDeclaration;
                return 0;
            }

            static string normalize(string src)
            {
                var i = text.index(src, Chars.Hash);
                if(i>0)
                    return text.trim(text.left(src,i));
                else
                    return text.trim(src);
            }
        }
    }
}