//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;
    using static XedRules.SyntaxLiterals;
    using static XedRules.RuleFormKind;

    using FK = XedRules.FieldKind;
    using RO = XedRules.RuleOperator;

    partial class XedRules
    {
        public struct RuleTableParser
        {
            [MethodImpl(Inline), Op]
            static RuleTerm criterion(bool premise, FieldKind field, RuleOperator op, string value)
                => new RuleTerm(premise, field,op, value);

            [MethodImpl(Inline), Op]
            static RuleTerm criterion(bool premise, FieldKind field, NameResolver resolver)
                => new RuleTerm(premise, field, resolver);

            static Outcome parse(bool premise, string spec,  out RuleTerm dst)
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
                    op = RO.CmpNeq;
                    name = text.left(spec,k);
                    fv = text.right(spec,k + Neq.Length - 1);
                }
                else if(j >=0 )
                {
                    if(premise)
                        op = RO.CmpEq;
                    else
                        op = RO.Assign;
                    name = text.left(spec,j);
                    fv = text.right(spec,j);
                }
                else if(m > 0)
                {
                    name = text.left(spec,m);
                    dst = criterion(premise, fk, NameResolvers.Instance.Create(name));
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
                    dst = criterion(premise, fk, op, fv);
                else
                    dst = RuleTerm.Empty;
                return result;
            }

            static RuleTermExpr expr(RuleFormKind kind, string premise, string consequent = EmptyString)
            {
                var left = sys.empty<RuleTerm>();
                var right = sys.empty<RuleTerm>();

                if(nonempty(premise))
                    left = criteria(true, premise);

                if(nonempty(consequent))
                    right = criteria(false, consequent);

                return new RuleTermExpr(kind, left, right);
            }

            static Index<RuleTerm> criteria(bool premise, string src)
            {
                var parts = text.trim(text.split(src, Chars.Space)).Where(x => nonempty(x) && !Skip.Contains(x));
                var count = parts.Length;
                var buffer = alloc<RuleTerm>(count);
                for(var i=0; i<count; i++)
                {
                    ref readonly var part = ref skip(parts, i);
                    ref var dst = ref seek(buffer,i);
                    var result = parse(premise, part,  out seek(buffer,i));
                    if(result.Fail)
                        Errors.Throw(result.Message);

                }
                return buffer;
            }

            RuleTermTable Table;

            RuleTable Table2;

            List<RuleTermTable> Tables;

            List<RuleTable> Tables2;

            LineReader Reader;

            RuleFormKind Kind;

            TextLine Line;

            public RuleTableParser()
            {
                Table = RuleTermTable.Empty;
                Table2 = RuleTable.Empty;
                Reader = default;
                Tables = new();
                Line = TextLine.Empty;
                Kind = 0;
                Tables2 = new();
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

            public Outcome Parse2(TextLine src)
            {
                Line = src;
                var result = Outcome.Success;
                Kind = RuleParser.classify(Line);
                if(Kind == SeqDeclaration)
                    ParseSeqTerms();

                while(Kind == RuleDeclaration)
                {
                    result = ParseRuleDecl2();
                    if(result.Fail)
                        return result;
                }

                return result;
            }

            public Index<RuleTermTable> Parse(FS.FilePath src)
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

            public Index<RuleTable> Parse2(FS.FilePath src)
            {
                try
                {
                    Reader = src.Utf8LineReader();
                    Parse2();
                    return Tables2.ToArray();
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

            void Parse2()
            {
                while(Reader.Next(out var line))
                {
                    if(line.IsEmpty || line.StartsWith(Chars.Hash))
                        continue;

                    Parse2(line).Require();
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

            Outcome ParseRuleDeclTerms2()
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
                            expressions.Add(RuleTables.expr(Kind, parts[0], parts[1]));
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
                            expressions.Add(RuleTables.expr(Kind, parts[0]));
                        else if(parts.Length == 2)
                            expressions.Add(RuleTables.expr(Kind, parts[0], parts[1]));
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
                    Table2.Expressions = expressions.ToArray();
                return result;
            }

            Outcome ParseRuleDeclTerms()
            {
                var result = Outcome.Success;
                var expressions = list<RuleTermExpr>();
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

            Outcome ParseRuleDecl2()
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

                result = ParseRuleDeclTerms2();

                if(Skip.Contains(name))
                {
                    Table2 = RuleTable.Empty;
                    return true;
                }

                if(result.Fail)
                    return result;

                Table2.Name = name;
                Table2.ReturnType = ret;
                Tables2.Add(Table2);
                Table2 = RuleTable.Empty;
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
                    Table = RuleTermTable.Empty;
                    return true;
                }

                if(result.Fail)
                    return result;

                Table.Name = name;
                Table.ReturnType = ret;
                Tables.Add(Table);
                Table = RuleTermTable.Empty;
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