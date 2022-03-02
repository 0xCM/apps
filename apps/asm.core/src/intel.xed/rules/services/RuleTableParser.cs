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
            const string Call = "()";

            const string Decl = "()::";

            const string Neq = "!=";

            const char Assign = '=';

            const string REXW = "REXW[w]";

            const string REXB = "REXB[b]";

            const string REXR = "REXR[r]";

            const string REXX = "REXX[x]";

            const string EncStep = " -> ";

            const string DecStep = " |";

            const string SeqDecl = "SEQUENCE ";

            public static Outcome parse(string spec, CriterionKind ck, out RuleCriterion dst)
            {
                var result = Outcome.Success;
                var fk = FieldKind.INVALID;
                var op = RuleOperator.None;
                var fv = EmptyString;
                var j = text.index(spec, Assign);
                var k = text.index(spec, Neq);
                var m = text.index(spec, Call);
                var name = EmptyString;

                if(k >= 0)
                {
                    op = RuleOperator.Neq;
                    name = text.left(spec,k);
                    fv = text.right(spec,k + Neq.Length - 1);
                }
                else if(j >=0 )
                {
                    if(ck == CriterionKind.Premise)
                        op = RuleOperator.Eq;
                    else if(ck == CriterionKind.Consequent)
                        op = RuleOperator.Assign;
                    name = text.left(spec,j);
                    fv = text.right(spec,j);
                }
                else if(m >= 0)
                {
                    op = RuleOperator.Call;
                    fv = text.left(spec,m);
                }
                else
                {
                    fv = spec;
                }

                if(nonempty(name) && op != RuleOperator.Call)
                {
                    if(name.Equals(REXW))
                        fk = FieldKind.REXW;
                    else if(name.Equals(REXB))
                        fk = FieldKind.REXB;
                    else if(name.Equals(REXR))
                        fk = FieldKind.REXR;
                    else if(name.Equals(REXX))
                        fk = FieldKind.REXX;
                    else if(!FieldKinds.ExprKind(name, out fk))
                        result = (false,string.Format("Kind for {0} not found in {1}", name, spec));
                }

                if(result)
                    dst = criterion(ck, fk, op, fv);
                else
                    dst = RuleCriterion.Empty;
                return result;
            }

            public static RuleExpr expr(RuleFormKind kind, string premise, string consequent = EmptyString)
            {
                var left = sys.empty<RuleCriterion>();
                var right = sys.empty<RuleCriterion>();

                if(nonempty(premise))
                    left = criteria(premise, CriterionKind.Premise);

                if(nonempty(consequent))
                    right = criteria(consequent, CriterionKind.Consequent);

                return new RuleExpr(kind, left, right);
            }

            public static Index<RuleCriterion> criteria(string src, CriterionKind kind)
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
                    var result = parse(spec, kind, out seek(buffer,i));
                    if(result.Fail)
                        Errors.Throw(result.Message);

                }
                return buffer;
            }

            static EK classify(TextLine src)
            {
                var i = text.index(src.Content, Chars.Hash);
                var content = (i> 0 ? text.left(src.Content,i) : src.Content).Trim();

                if(content.EndsWith(Decl))
                    return EK.RuleDeclaration;
                if(content.Contains(EncStep))
                    return EK.EncodeStep;
                if(content.Contains(DecStep))
                    return EK.DecodeStep;
                if(content.EndsWith(Call))
                    return EK.Invocation;
                if(content.StartsWith(SeqDecl))
                    return EK.SeqDeclaration;
                return 0;
            }

            RuleTable Table;

            List<RuleTable> Tables;

            LineReader Reader;

            Symbols<FieldKind> OperandKinds;

            RuleFormKind Kind;

            TextLine Line;

            HashSet<string> Skip;

            public RuleTableParser()
            {
                OperandKinds = Symbols.index<FieldKind>();
                Table = RuleTable.Empty;
                Reader = default;
                Tables = new();
                Line = TextLine.Empty;
                Kind = 0;
                Skip = hashset("VEXED_REX");
            }

            public Outcome Parse(TextLine src)
            {
                Line = src;
                var result = Outcome.Success;
                Kind = classify(Line);
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

            public Index<RuleTable> Parse(ReadOnlySpan<TextLine> src)
            {
                Tables.Clear();
                for(var i=0; i<src.Length; i++)
                {
                    ref readonly var line = ref skip(src,i);
                    var result = Parse(line);
                    if(result.Fail)
                        Errors.Throw(result.Message);
                }

                return Tables.ToArray();
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
                while(Reader.Next(out var line))
                {
                    if(line.IsEmpty || line.StartsWith(Chars.Hash))
                        continue;

                    Parse(line).Require();
                }
            }

            void ParseSeqTerms()
            {
                while(Reader.Next(out Line))
                {
                    if(Line.IsEmpty || Line.StartsWith(Chars.Hash))
                        continue;

                    Kind = classify(Line);
                    if(Kind == 0 || Kind == EK.Invocation)
                        continue;
                    else
                        break;
                }
            }

            Outcome ParseRuleDeclTerms()
            {
                var result = Outcome.Success;
                var expressions = list<RuleExpr>();
                while(Reader.Next(out Line))
                {
                    if(Line.IsEmpty || Line.StartsWith(Chars.Hash))
                        continue;

                    Kind = classify(Line);
                    if(Kind == 0)
                        continue;

                    var content = normalize(Line.Content);
                    var parts = sys.empty<string>();
                    if(Kind == EK.EncodeStep)
                    {
                        parts = text.split(content, EncStep).Map(x => x.Trim());
                        if(parts.Length == 2)
                            expressions.Add(expr(Kind, parts[0], parts[1]));
                        else
                        {
                            result = (false, StepParseFailed.Format(content));
                            break;
                        }
                    }
                    else if(Kind == EK.DecodeStep)
                    {
                        parts = text.split(content, DecStep).Map(x => x.Trim());
                        if(parts.Length == 1)
                            expressions.Add(expr(Kind, parts[0]));
                        else if(parts.Length == 2)
                            expressions.Add(expr(Kind, parts[0], parts[1]));
                        else
                        {
                            result = (false, StepParseFailed.Format(content));
                            break;
                        }
                    }
                    else
                        break;

                }

                if(result)
                    Table.Expressions = expressions.ToArray();
                return result;
            }

            Outcome ParseRuleDecl()
            {
                var result = Outcome.Success;
                var ruledecl = text.trim(text.left(Line.Content, Decl));
                var i = text.index(ruledecl, Chars.Space);
                var name = EmptyString;
                var ret = EmptyString;
                if(i > 0)
                {
                    name = text.right(ruledecl,i);
                    ret = text.left(ruledecl,i);
                }
                else
                    name = ruledecl;

                result = ParseRuleDeclTerms();

                if(Skip.Contains(name))
                {
                    Table = RuleTable.Empty;
                    return true;
                }

                if(result.Fail)
                    return result;

                Table.Name = name;
                Table.ReturnType = ret;
                Tables.Add(Table);
                Table = RuleTable.Empty;
                return result;
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