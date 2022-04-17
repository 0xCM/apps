//-----------------------------------------------------------------------------
// Derivative Work based on https://github.com/intelxed/xed
// Author : Chris Moore
// License: https://github.com/intelxed/xed/blob/main/LICENSE
//-----------------------------------------------------------------------------
namespace Z0
{
    using static core;
    using static XedModels;
    using static XedPatterns;
    using static XedRules.InstRulePartNames;

    using P = XedRules.InstPartKind;

    partial class XedRules
    {
        public struct InstDefParser
        {
            public static Index<InstDef> parse(FS.FilePath src)
            {
                const string LogPattern = "{0,-8} | {1,-8} | {2,-10} | {3}";
                var buffer = list<InstDef>();
                var reader = src.ReadNumberedLines().Select(cleanse).Where(line => line.IsNonEmpty).Reader();
                var seq = 0u;
                var forms = dict<uint,InstForm>();
                var logdst = XedPaths.Service.Targets() + FS.file("xed.inst.patterns.log", FS.Csv);
                var @class = InstClass.Empty;
                var category = Category.Empty;
                var isa = InstIsa.Empty;
                var ext = Extension.Empty;
                var attribs = InstAttribs.Empty;
                var effects = Index<XedFlagEffect>.Empty;
                using var log = logdst.AsciWriter();
                while(reader.Next(out var line))
                {
                    if(line.StartsWith(Chars.Hash) || line.EndsWith("::"))
                        continue;

                    if(line.StartsWith(Chars.LBrace))
                    {
                        var dst = default(InstDef);
                        var rawbody = EmptyString;
                        var specs = list<InstPatternSpec>();
                        while(!line.StartsWith(Chars.RBrace) && reader.Next(out line))
                        {
                            if(split(line, out var name, out var value))
                            {
                                if(empty(value))
                                    continue;

                                if(parse(name, out InstPartKind part))
                                {
                                    log.AppendLine(string.Format(LogPattern, line.LineNumber, seq, part, value));

                                    switch(part)
                                    {
                                        case P.Form:
                                            if(XedParsers.parse(value, out InstForm form))
                                                forms.TryAdd(seq, form);
                                        break;
                                        case P.Attributes:
                                            attribs = XedPatterns.attributes(text.despace(value));
                                        break;
                                        case P.Category:
                                            if(XedParsers.parse(text.despace(value), out Category _category))
                                                category = _category;
                                        break;
                                        case P.Extension:
                                            if(XedParsers.parse(text.despace(value), out Extension _ext))
                                                ext = _ext;
                                        break;
                                        case P.Flags:
                                            XedParsers.parse(text.despace(value), out effects);
                                        break;
                                        case P.Class:
                                        {
                                            if(XedParsers.parse(text.despace(value), out InstClass _class))
                                            {
                                                if(_class != @class)
                                                {
                                                    category = Category.Empty;
                                                    isa = InstIsa.Empty;
                                                    ext = Extension.Empty;
                                                    attribs = InstAttribs.Empty;
                                                    effects = Index<XedFlagEffect>.Empty;
                                                    form = InstForm.Empty;
                                                }
                                                @class = _class;
                                                dst.InstClass = _class;
                                            }
                                        }
                                        break;
                                        case P.Isa:
                                            if(XedParsers.parse(text.despace(value), out InstIsa _isa))
                                                isa = _isa;
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

                                            var opexpr = value;
                                            var spec = InstPatternSpec.Empty;
                                            spec.PatternId = seq;
                                            spec.InstClass = @class;
                                            spec.Attributes = attribs;
                                            spec.Effects = effects;
                                            spec.Category = category;
                                            spec.Extension = ext;
                                            spec.Isa = isa;
                                            InstPatternSpec.FixIsa(ref spec);
                                            spec.RawBody = rawbody;
                                            CellParser.parse(RuleMacros.expand(InstPatternBody.normalize(rawbody)), out spec.Body);
                                            spec.Mode = XedFields.mode(spec.Body.Fields);
                                            PatternOpParser.create(spec.Mode).Parse(spec.PatternId, opexpr, out spec.Ops);
                                            spec.OpCode = XedOpCodes.opcode(spec.Body.Fields);
                                            specs.Add(spec);
                                        }
                                        break;
                                        case P.Pattern:
                                            rawbody = value;
                                            seq++;
                                        break;
                                        case P.Comment:
                                            break;
                                    }
                                }
                            }
                        }

                        dst.PatternSpecs = specs.Array().Sort();
                        buffer.Add(dst);
                    }
                }

                var defs = buffer.ToArray().Sort();
                var pid = 0u;
                for(var i=0u; i<defs.Length; i++)
                {
                    ref var def = ref seek(defs,i);
                    ref var specs = ref def.PatternSpecs;
                    for(var j=0; j<specs.Count; j++,pid++)
                    {
                        ref var spec = ref specs[j];
                        forms.TryGetValue(spec.PatternId, out spec.InstForm);
                        spec.PatternId = pid;
                        spec.Ops = new (pid, spec.Ops);
                        for(var k=0; k<spec.Ops.Count; k++)
                            spec.Ops[k].PatternId = pid;
                    }
                }

                return defs;
            }

            static Index<InstPartKind,string> PartKindNames = new string[]{ICLASS,IFORM,ATTRIBUTES,CATEGORY,EXTENSION,FLAGS,PATTERN,OPERANDS,ISA_SET,COMMENT};

            static bool parse(string src, out InstPartKind kind)
            {
                var result = false;
                kind = default;
                for(var i=0; i<PartKindNames.Count; i++)
                {
                    var p = (InstPartKind)i;
                    if(PartKindNames[p] == src)
                    {
                        kind = p;
                        result = true;
                        break;
                    }
                }
                return result;
            }

            static TextLine cleanse(TextLine src)
            {
                var dst = text.trim(src.Content);
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
        }
    }
}