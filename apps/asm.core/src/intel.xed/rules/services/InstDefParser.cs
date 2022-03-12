//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static Root;
    using static XedModels;
    using static XedParsers;

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

            string ExpandBody(string src)
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

                return MacroExpander.expand(dst.Emit());
            }

            static TextLine cleanse(TextLine src)
            {
                var dst = text.despace(src.Content);
                var i = text.index(dst, Chars.Hash);
                if(i > 0)
                    dst = text.left(dst,i);
                dst = text.trim(dst);
                return new TextLine(src.LineNumber, dst);
            }

            public Index<InstDef> ParseInstDefs(FS.FilePath src)
            {
                var buffer = list<InstDef>();
                using var reader = src.Utf8LineReader();
                var parser = RuleOpParser.create();
                var seq = 0u;
                while(reader.Next(out var line))
                {
                    if(line.IsEmpty || line.StartsWith(Chars.Hash) || line.EndsWith("::"))
                        continue;

                    line = cleanse(line);

                    if(line.StartsWith(Chars.LBrace))
                    {
                        var dst = default(InstDef);
                        var bodyexpr = EmptyString;
                        var rawbody = EmptyString;
                        var operands = list<InstPatternSpec>();
                        var @class = IClass.INVALID;
                        while(!line.StartsWith(Chars.RBrace) && reader.Next(out line))
                        {
                            if(line.IsEmpty)
                                continue;

                            line = cleanse(line);
                            var i = text.index(line.Content, Chars.Colon);

                            if(i > 0)
                            {
                                var name = text.trim(text.left(line.Content,i));
                                var value = text.trim(text.right(line.Content,i));
                                if(empty(value))
                                    continue;

                                if(ClassifyPart(Rules.PartNames, name, out var p))
                                {
                                    switch(p)
                                    {
                                        case P.Form:
                                            parse(value, out dst.Form);
                                        break;
                                        case P.Attributes:
                                            Rules.ParseAttribKinds(value, out dst.Attributes);
                                        break;
                                        case P.Category:
                                            parse(value, out dst.Category);
                                        break;
                                        case P.Extension:
                                            parse(value, out dst.Extension);
                                        break;
                                        case P.Flags:
                                            dst.Flags = XedRules.CalcFlagActions(value);
                                        break;
                                        case P.Class:
                                        {
                                            if(parse(value, out dst.Class))
                                            {
                                                @class = dst.Class;
                                            }
                                        }
                                        break;
                                        case P.Operands:
                                        {
                                            var j = text.index(line.Content, Chars.BSlash);
                                            if(j > 0)
                                            {
                                                var result = text.left(line.Content, j);
                                                while(reader.Next(out var x))
                                                {
                                                    x = cleanse(x);
                                                    j = text.index(x.Content, Chars.BSlash);
                                                    if(j > 0)
                                                        result = string.Format("{0} {1}", result, text.left(x.Content,j).Trim());
                                                    else
                                                    {
                                                        value = string.Format("{0} {1}", result, x.Content.Trim());
                                                        break;
                                                    }
                                                }
                                            }

                                            XedParsers.parse(bodyexpr, out InstPatternBody body).Require();
                                            operands.Add(new InstPatternSpec(seq++, 0, @class, rawbody, body, parser.ParseOps(value)));
                                            bodyexpr=EmptyString;
                                        }
                                        break;
                                        case P.Pattern:
                                            rawbody = value;
                                            bodyexpr = ExpandBody(rawbody);
                                        break;
                                        case P.Isa:
                                            parse(value, out dst.Isa);
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

                var defs = buffer.ToArray().Sort();
                for(var i=0u; i<defs.Length; i++)
                {
                    ref var def = ref seek(defs,i);
                    def.Seq = i;
                    ref var patterns = ref def.PatternSpecs;
                    for(var j=0; j<patterns.Count; j++)
                        patterns[j] = patterns[j].WithInstId(i);
                }

                return defs;
            }

            static bool ClassifyPart(Index<P,string> names, string src, out InstRulePart part)
            {
                var count = names.Count;
                var result = false;
                part = default;
                for(var i=0; i<count; i++)
                {
                    var p = (InstRulePart)i;
                    ref readonly var n = ref names[p];
                    if(n == src)
                    {
                        part = p;
                        result = true;
                        break;
                    }
                }
                return result;
            }
        }
    }
}