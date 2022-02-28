//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static XedModels;
    using static core;
    using static Root;

    using P = XedRules.InstRulePart;

    partial class XedRules
    {
        class XedInstDefParser
        {
            readonly XedRules Rules;

            ITextBuffer _PatternBuffer;

            public XedInstDefParser(XedRules rules)
            {
                Rules = rules;
                _PatternBuffer = text.buffer();
            }

            [MethodImpl(Inline)]
            ITextBuffer ComponentBuffer()
            {
                _PatternBuffer.Clear();
                return _PatternBuffer;
            }

            string ParseTokens(string src)
            {
                var dst = ComponentBuffer();
                var parts = text.split(text.despace(src), Chars.Space);
                var count = parts.Length;
                for(var i=0; i<count; i++)
                {
                    ref readonly var part = ref skip(parts,i);
                    if(i != 0)
                        dst.Append(Chars.Space);
                    dst.Append(part);
                }

                var parsed = dst.Emit();
                return text.despace(parsed.Replace("MOD[0b11] MOD=3", "MOD[0b11]"));
            }

            public Index<InstDef> ParseInstDefs(FS.FilePath src)
            {
                var buffer = list<InstDef>();
                using var reader = src.Utf8LineReader();
                var def = default(InstDef);
                var result = Outcome.Success;
                while(reader.Next(out var line))
                {
                    if(line.IsEmpty || line.StartsWith(Chars.Hash) || line.EndsWith("::"))
                        continue;

                    if(line.StartsWith(Chars.LBrace))
                    {
                        var dst = default(InstDef);
                        var pattern = EmptyString;
                        var operands = list<InstPatternSpec>();
                        while(!line.StartsWith(Chars.RBrace) && reader.Next(out line))
                        {
                            if(line.IsEmpty)
                                continue;

                            var i = text.index(line.Content, Chars.Colon);
                            if(i > 0)
                            {
                                var name = text.trim(text.left(line.Content,i));
                                var value = text.trim(text.right(line.Content,i));
                                if(empty(value))
                                    continue;

                                if(ClassifyPart(name, out var p))
                                {
                                    switch(p)
                                    {
                                        case P.IForm:
                                            Rules.ParseIForm(value, out dst.Form);
                                        break;
                                        case P.Attributes:
                                            Rules.ParseAttribKinds(value, out dst.Attributes);
                                        break;
                                        case P.Category:
                                            Rules.ParseCategory(value, out dst.Category);
                                        break;
                                        case P.Extension:
                                            Rules.ParseExtension(value, out dst.Extension);
                                        break;
                                        case P.Flags:
                                            dst.Flags = Rules.ParseFlagActions(value);
                                        break;
                                        case P.IClass:
                                            Rules.ParseIClass(value, out dst.Class);
                                        break;
                                        case P.Operands:
                                            result = Rules.ParseOperands(value, out var ops);
                                            if(result)
                                            {
                                                operands.Add(new InstPatternSpec(pattern, ops));
                                                pattern=EmptyString;
                                            }
                                            else
                                            {
                                                Rules.Error(result.Message);
                                                return sys.empty<InstDef>();
                                            }
                                        break;
                                        case P.Pattern:
                                            pattern = ParseTokens(value);
                                        break;
                                        case P.Isa:
                                            Rules.ParseIsaKind(value, out dst.Isa);
                                        break;
                                        case P.Comment:
                                            break;
                                    }
                                }
                            }
                        }

                        dst.PatternSpecs = operands.Array();
                        buffer.Add(dst);
                    }
                }

                return buffer.ToArray().Sort();
            }

            bool ClassifyPart(string src, out InstRulePart part)
            {
                var count = Rules.PartNames.Count;
                var result = false;
                part = default;
                for(var i=0; i<count; i++)
                {
                    var p = (InstRulePart)i;
                    ref readonly var n = ref Rules.PartNames[p];
                    if(n == src)
                    {
                        part = p;
                        result = true;
                        break;
                    }
                }
                return result;
            }

            RuleTokenKind ClassifyToken(string src)
            {
                var dst = RuleTokenKind.None;
                if(text.begins(src, "0x"))
                    dst = RuleTokenKind.HexLiteral;
                else if(text.ends(src, "()"))
                    dst = RuleTokenKind.Nonterminal;
                else if(Rules.MacroNames.Lookup(src, out _))
                    dst = RuleTokenKind.Macro;
                return dst;
            }

        }
    }
}