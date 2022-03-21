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
    using static XedPatterns;

    using P = XedRules.InstRulePart;

    partial class XedRules
    {
        internal class InstDefParser
        {
            static TextLine cleanse(TextLine src)
            {
                var dst = text.despace(src.Content);
                var i = text.index(dst, Chars.Hash);
                if(i > 0)
                    dst = text.left(dst,i);
                dst = text.trim(dst);
                return new TextLine(src.LineNumber, dst);
            }

            static void parse(string body, out InstPatternSpec dst)
            {
                var buffer = text.buffer();
                var parts = text.split(text.despace(body), Chars.Space);
                for(var i=0; i<parts.Length; i++)
                {
                    if(i != 0)
                        buffer.Append(Chars.Space);
                    buffer.Append(skip(parts,i));
                }
                parse(RuleMacros.expand(buffer.Emit()), out InstPatternBody pb).Require();

                dst = new InstPatternSpec(0, 0, 0, body, pb, sys.empty<RuleOpSpec>());
            }

            public static Outcome parse(string src, out InstPatternBody dst)
            {
                var result = Outcome.Success;
                var parts = text.trim(text.split(text.despace(src), Chars.Space));
                var count = parts.Length;
                dst = alloc<InstDefPart>(count);
                for(var i=0; i<count; i++)
                {
                    ref var target = ref dst[i];
                    ref readonly var part = ref skip(parts,i);
                    result = parse(part, out target);
                    if(result.Fail)
                    {
                        break;
                    }
                }

                return result;
            }

            public static Outcome parse(string src, out InstDefPart dst)
            {
                dst = InstDefPart.Empty;
                Outcome result = (false, string.Format("Unrecognized segment '{0}'", src));
                if(IsHexLiteral(src))
                {
                    result = XedParsers.parse(src, out Hex8 x);
                    if(result)
                        dst = x;
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(Hex8), src));
                }
                else if(IsBinaryLiteral(src))
                {
                    result = XedParsers.parse(src, out uint5 x);
                    if(result)
                        dst = x;
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(uint5), src));

                }
                else if(IsBfSeg(src))
                {
                    result = XedParsers.parse(src, out BitfieldSeg x);
                    if(result)
                        dst = x;
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(BitfieldSeg), src));
                }
                else if(IsCmpNeq(src))
                {
                    result = XedParsers.parse(src, out FieldConstraint x);
                    if(result)
                        dst = x;
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(FieldConstraint), src));

                }
                else if(IsAssignment(src))
                {
                    result = XedParsers.parse(src, out FieldAssign x);
                    if(result)
                    {
                        dst = x;
                    }
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(FieldAssign), src));

                }
                else if(IsNonterminal(src))
                {
                    result = XedParsers.parse(src, out Nonterminal x);
                    if(result)
                        dst = x;
                    else
                        result = (false, AppMsg.ParseFailure.Format(nameof(Nonterminal), src));
                }
                else if (XedParsers.parse(src, out byte a))
                {
                    result = true;
                    dst = new(a);
                }

                return result;
            }

            public static Index<InstDef> parse(FS.FilePath src)
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
                        var body = EmptyString;
                        var specs = list<InstPatternSpec>();
                        var @class = IClass.INVALID;
                        while(!line.StartsWith(Chars.RBrace) && reader.Next(out line))
                        {
                            if(line.IsEmpty)
                                continue;

                            line = cleanse(line);
                            var i = text.index(line.Content, Chars.Colon);

                            if(i > 0)
                            {
                                var name = text.trim(text.left(line.Content, i));
                                var value = text.trim(text.right(line.Content, i));
                                if(empty(value))
                                    continue;

                                if(classify(PartNames, name, out var rulePart))
                                {
                                    switch(rulePart)
                                    {
                                        case P.Form:
                                            XedParsers.parse(value, out dst.Form);
                                        break;
                                        case P.Attributes:
                                            dst.Attributes = XedPatterns.attributes(value);
                                        break;
                                        case P.Category:
                                            XedParsers.parse(value, out dst.Category);
                                        break;
                                        case P.Extension:
                                            XedParsers.parse(value, out dst.Extension);
                                        break;
                                        case P.Flags:
                                            dst.Flags = CalcFlagActions(value);
                                        break;
                                        case P.Class:
                                        {
                                            if(XedParsers.parse(value, out dst.Class))
                                                @class = dst.Class;
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

                                            parse(body, out InstPatternSpec spec);
                                            specs.Add(
                                                spec.WithClass(@class)
                                                .WithPatternId(seq++)
                                                .WithOps(RuleOpParser.parse(value)));
                                        }
                                        break;
                                        case P.Pattern:
                                            body = value;
                                        break;
                                        case P.Isa:
                                            XedParsers.parse(value, out dst.Isa);
                                        break;
                                        case P.Comment:
                                            break;
                                    }
                                }
                            }
                        }

                        dst.PatternSpecs = specs.Array();
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

            static bool classify(Index<InstRulePart,string> names, string src, out InstRulePart part)
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