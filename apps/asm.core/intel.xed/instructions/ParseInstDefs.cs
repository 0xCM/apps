//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedRules;

    using P = XedRules.InstDefPart;

    partial class XedPatterns
    {
        void Parse(uint pattern, IClass @class, IForm form, string rawbody, string ops, out InstPatternSpec dst)
        {
            var buffer = text.buffer();
            var parts = text.split(text.despace(rawbody), Chars.Space);
            for(var i=0; i<parts.Length; i++)
            {
                if(i != 0)
                    buffer.Append(Chars.Space);
                buffer.Append(skip(parts,i));
            }

            XedParsers.parse(RuleMacros.expand(buffer.Emit()), out InstPatternBody pb).Require();
            var parser = OpSpecParser.create(OpWidthsLookup, pb);
            parser.Parse(pattern, ops, out Index<OpSpec> _ops);
            dst = new InstPatternSpec(pattern, 0, @class, form, xedoc(pattern, pb), rawbody, pb, XedRender.format(pb), _ops);
        }

        static bool parse(string src, out InstDefPart part)
        {
            var result = false;
            part = default;
            for(var i=0; i<DefPartNames.Count; i++)
            {
                var p = (InstDefPart)i;
                if(DefPartNames[p] == src)
                {
                    part = p;
                    result = true;
                    break;
                }
            }
            return result;
        }

        static TextLine cleanse(TextLine src)
        {
            var dst = text.despace(src.Content);
            var i = text.index(dst, Chars.Hash);
            if(i==0)
                return TextLine.Empty;

            if(i > 0)
                dst = text.left(dst,i);
            return new TextLine(src.LineNumber, text.trim(dst));
        }

        static bool split(TextLine line, out string name, out string value)
        {
            var input = line;
            var i = text.index(input.Content, Chars.Colon);
            if(i>0)
            {
                name = text.trim(text.left(input.Content, i));
                value = text.trim(text.right(input.Content, i));
            }
            else
            {
                name = EmptyString;
                value = EmptyString;
            }
            return i > 0;
        }

        public Index<InstDef> ParseInstDefs(FS.FilePath src)
        {
            const string LogPattern = "{0,-8} | {1,-8} | {2,-10} | {3}";
            var buffer = list<InstDef>();
            var reader = src.ReadNumberedLines().Select(cleanse).Where(line => line.IsNonEmpty).Reader();
            var seq = 0u;
            var forms = dict<uint,IForm>();
            var logdst = XedPaths.Targets() + FS.file("xed.inst.patterns.log", FS.Csv);
            using var log = logdst.AsciWriter();
            while(reader.Next(out var line))
            {
                if(line.StartsWith(Chars.Hash) || line.EndsWith("::"))
                    continue;

                if(line.StartsWith(Chars.LBrace))
                {
                    var dst = default(InstDef);
                    var body = EmptyString;
                    var specs = list<InstPatternSpec>();
                    var @class = IClass.INVALID;
                    while(!line.StartsWith(Chars.RBrace) && reader.Next(out line))
                    {
                        if(split(line, out var name, out var value))
                        {
                            if(empty(value))
                                continue;

                            if(parse(name, out InstDefPart part))
                            {
                                log.AppendLine(string.Format(LogPattern, line.LineNumber, seq, part, value));

                                switch(part)
                                {
                                    case P.Form:
                                        if(XedParsers.parse(value, out IForm form))
                                            forms.TryAdd(seq,form);
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
                                        XedParsers.parse(value, out dst.FlagEffects);
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
                                                j = text.index(x.Content, Chars.BSlash);

                                                if(j > 0)
                                                {
                                                    var y = text.left(x.Content,j).Trim();
                                                    log.AppendLine(string.Format(LogPattern, x.LineNumber, seq, part, y));
                                                    result = string.Format("{0} {1}", result, y);
                                                }
                                                else
                                                {
                                                    var y = x.Content.Trim();
                                                    log.AppendLine(string.Format(LogPattern, x.LineNumber, seq, part, y));
                                                    value = string.Format("{0} {1}", result, y);
                                                    break;
                                                }
                                            }
                                        }

                                        Parse(seq, @class, IForm.Empty, body, value, out var spec);
                                        specs.Add(spec);
                                    }
                                    break;
                                    case P.Pattern:
                                        body = value;
                                        seq++;
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
                def.InstId = i;
                ref var patterns = ref def.PatternSpecs;
                for(var j=0; j<patterns.Count; j++)
                {
                    ref var pattern = ref patterns[j];
                    pattern = pattern.WithInstId(i);
                    if(forms.TryGetValue(pattern.PatternId, out var form))
                        pattern = pattern.WithForm(form);
                }
            }

            return defs;
        }
    }
}