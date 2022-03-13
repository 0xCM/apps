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

    using RF = XedRules.RuleFormKind;

    partial class XedRules
    {
        public struct RuleTableParser
        {
            public static RF RuleForm(TextLine src)
            {
                var i = text.index(src.Content, Chars.Hash);
                var content = (i> 0 ? text.left(src.Content,i) : src.Content).Trim();
                if(IsEncTableDecl(content))
                    return RF.EncodingRuleDecl;
                if(IsTableDecl(content))
                    return RF.RuleDeclaration;
                if(IsEncStep(content))
                    return RF.EncodeStep;
                if(IsDecStep(content))
                    return RF.DecodeStep;
                if(IsCall(content))
                    return RF.Invocation;
                if(IsSeqDecl(content))
                    return RF.SeqDeclaration;
                return 0;
            }

            RuleTable Table;

            List<RuleTable> Tables;

            LineReader Reader;

            RuleFormKind Kind;

            TextLine Line;

            public RuleTableParser()
            {
                Table = RuleTable.Empty;
                Reader = default;
                Line = TextLine.Empty;
                Kind = 0;
                Tables = new();
            }

            public Outcome Parse(TextLine src)
            {
                Line = src;
                var result = Outcome.Success;
                Kind = RuleForm(Line);
                if(Kind == SeqDeclaration)
                    ParseSeqTerms();

                while(Kind == RuleDeclaration)
                {
                    ParseRuleDecl();
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

                    Kind = RuleForm(Line);
                    if(Kind == 0 || Kind == Invocation)
                        continue;
                    else
                        break;
                }
            }

            void ParseRuleExpr()
            {
                var expressions = list<RuleExpr>();
                while(Reader.Next(out Line))
                {
                    if(Line.IsEmpty || Line.StartsWith(Chars.Hash))
                        continue;

                    Kind = RuleForm(Line);
                    if(Kind == 0)
                        continue;

                    if(Kind == RuleFormKind.EncodeStep || Kind == RuleFormKind.DecodeStep)
                    {
                        var content = normalize(Line.Content);
                        var parts =
                            text.contains(content, "->") ? text.split(content, "->")
                            : text.contains(content, "|") ? text.split(content, "|")
                            : sys.empty<string>();

                        if(parts.Length == 2)
                            expressions.Add(RuleTables.expr(parts[0], parts[1]));
                        else if(parts.Length == 1)
                            expressions.Add(RuleTables.expr(parts[1]));
                        else
                            Errors.Throw(AppMsg.ParseFailure.Format(nameof(RuleExpr), content));
                    }
                    else
                        break;
                }

                Table.Expressions = expressions.ToArray();
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

                ParseRuleExpr();

                if(Skip.Contains(name))
                {
                    Table = RuleTable.Empty;
                    return true;
                }

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
                    return text.despace(text.trim(text.left(src,i)));
                else
                    return text.despace(text.trim(src));
            }

            static HashSet<string> Skip;

            static RuleTableParser()
            {
                Skip = hashset("VEXED_REX", "XED_RESET");
            }
        }
    }
}