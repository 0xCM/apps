//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;
    using static XedRules.SyntaxLiterals;
    using static XedRules.RuleFormKind;

    using FK = XedRules.FieldKind;
    using RO = XedRules.RuleOperator;
    using CK = XedRules.CriterionKind;

    partial class XedRules
    {
        public struct RuleTableParser
        {
            public static Outcome parse(string spec, CriterionKind ck, out RuleCriterion dst)
            {
                var result = Outcome.Success;
                var fk = FK.INVALID;
                var op = RO.None;
                var fv = spec;
                var j = text.index(spec, Assign);
                var k = text.index(spec, Neq);
                var m = text.index(spec, Chars.LParen);
                var name = EmptyString;

                if(k >= 0)
                {
                    op = RO.Neq;
                    name = text.left(spec,k);
                    fv = text.right(spec,k + Neq.Length - 1);
                }
                else if(j >=0 )
                {
                    if(ck == CK.Premise)
                        op = RO.Eq;
                    else if(ck == CK.Consequent)
                        op = RO.Assign;
                    name = text.left(spec,j);
                    fv = text.right(spec,j);
                }
                else if(m > 0)
                {
                    name = text.left(spec,m);
                    dst = criterion(ck,fk, NameResolvers.Instance.Create(name));
                    return true;
                }

                if(nonempty(name))
                {
                    if(name.Equals(REXW))
                        fk = FK.REXW;
                    else if(name.Equals(REXB))
                        fk = FK.REXB;
                    else if(name.Equals(REXR))
                        fk = FK.REXR;
                    else if(name.Equals(REXX))
                        fk = FK.REXX;
                    else if(!FieldKinds.ExprKind(name, out fk))
                        result = (false, AppMsg.ParseFailure.Format(name, spec));
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
                    left = criteria(premise, CK.Premise);

                if(nonempty(consequent))
                    right = criteria(consequent, CK.Consequent);

                return new RuleExpr(kind, left, right);
            }

            public static Index<RuleCriterion> criteria(string src, CriterionKind kind)
            {
                var parts = text.trim(text.split(src, Chars.Space)).Where(x => nonempty(x) && !Skip.Contains(x));
                var count = parts.Length;
                var buffer = alloc<RuleCriterion>(count);
                for(var i=0; i<count; i++)
                {
                    ref readonly var part = ref skip(parts, i);
                    ref var dst = ref seek(buffer,i);
                    var result = parse(part, kind, out seek(buffer,i));
                    if(result.Fail)
                        Errors.Throw(result.Message);

                }
                return buffer;
            }

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

            public Outcome Parse(TextLine src)
            {
                Line = src;
                var result = Outcome.Success;
                Kind = RuleParser.classify(Line);
                if(Kind == SeqDeclaration)
                    ParseSeqTerms();

                while(Kind == RuleDeclaration)
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

                    Kind = RuleParser.classify(Line);
                    if(Kind == 0 || Kind == Invocation)
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

                    Kind = RuleParser.classify(Line);
                    if(Kind == 0)
                        continue;

                    var content = normalize(Line.Content);
                    var parts = sys.empty<string>();
                    if(Kind == EncodeStep)
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
                    else if(Kind == DecodeStep)
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
                var ruledecl = text.trim(text.left(Line.Content, TableDeclSyntax));
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

            static HashSet<string> Skip;

            static RuleTableParser()
            {
                Skip = hashset("VEXED_REX", "XED_RESET");
            }
        }
    }
}