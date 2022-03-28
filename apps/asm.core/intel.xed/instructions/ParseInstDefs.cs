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

    using P = XedPatterns.InstDefPart;

    partial class XedPatterns
    {
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

        public Index<InstDef> ParseInstDefs(FS.FilePath src)
        {
            const string LogPattern = "{0,-8} | {1,-8} | {2,-10} | {3}";
            var buffer = list<InstDef>();
            var reader = src.ReadNumberedLines().Select(cleanse).Where(line => line.IsNonEmpty).Reader();
            var seq = 0u;
            var forms = dict<uint,InstForm>();
            var logdst = XedPaths.Targets() + FS.file("xed.inst.patterns.log", FS.Csv);
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

                            if(parse(name, out InstDefPart part))
                            {
                                log.AppendLine(string.Format(LogPattern, line.LineNumber, seq, part, value));

                                switch(part)
                                {
                                    case P.Form:
                                        if(XedParsers.parse(value, out InstForm form))
                                            forms.TryAdd(seq,form);
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
                                        spec.Attributes = attribs;
                                        spec.Effects = effects;
                                        spec.Category = category;
                                        spec.Extension = ext;
                                        spec.Isa = isa;
                                        spec.InstClass = @class;
                                        InstPatternSpec.FixIsa(ref spec);
                                        spec.PatternId = seq;
                                        spec.RawBody = rawbody;
                                        XedParsers.parse(RuleMacros.expand(InstPatternBody.normalize(rawbody)), out spec.Body).Require();
                                        spec.Mode = mode(spec.Body);
                                        PatternOpParser.create(spec.Mode).Parse(spec.PatternId, opexpr, out spec.Ops);
                                        spec.OpCode = xedoc(spec.Body);
                                        spec.BodyExpr = spec.Body.Format();
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
            var iid = 0u;
            var pid = 0u;
            for(var i=0u; i<defs.Length; i++,iid++)
            {
                ref var def = ref seek(defs,i);
                ref var specs = ref def.PatternSpecs;
                for(var j=0; j<specs.Count; j++, pid++)
                {
                    ref var pattern = ref specs[j];
                    forms.TryGetValue(pattern.PatternId, out pattern.InstForm);
                    pattern.InstId = iid;
                    pattern.PatternId = pid;
                }

                // if(def.Isa.IsEmpty)
                // {
                //     switch(def.Extension.Kind)
                //     {
                //         case ExtensionKind._3DNOW:
                //             def.Isa = IsaKind._3DNOW;
                //             break;
                //         case ExtensionKind.INVPCID:
                //             def.Isa = IsaKind.INVPCID;
                //             break;
                //         case ExtensionKind.PCLMULQDQ:
                //             def.Isa = IsaKind.PCLMULQDQ;
                //             break;
                //         case ExtensionKind.FMA4:
                //             def.Isa = IsaKind.FMA4;
                //         break;
                //         case ExtensionKind.F16C:
                //             def.Isa = IsaKind.F16C;
                //         break;
                //         case ExtensionKind.X87:
                //             def.Isa = IsaKind.X87;
                //         break;
                //         case ExtensionKind.AES:
                //             def.Isa = IsaKind.AES;
                //         break;
                //         case ExtensionKind.AVX:
                //             def.Isa = IsaKind.AVX;
                //         break;
                //         case ExtensionKind.AVX2:
                //             def.Isa = IsaKind.AVX2;
                //         break;
                //         case ExtensionKind.BMI1:
                //             def.Isa = IsaKind.BMI1;
                //         break;
                //         case ExtensionKind.BMI2:
                //             def.Isa = IsaKind.BMI2;
                //         break;
                //         case ExtensionKind.LONGMODE:
                //             def.Isa = IsaKind.LONGMODE;
                //         break;
                //         case ExtensionKind.CLZERO:
                //             def.Isa = IsaKind.CLZERO;
                //         break;
                //         case ExtensionKind.FMA:
                //             def.Isa = IsaKind.FMA;
                //         break;
                //         case ExtensionKind.LZCNT:
                //             def.Isa = IsaKind.LZCNT;
                //             break;
                //         case ExtensionKind.SSE:
                //             def.Isa = IsaKind.SSE;
                //         break;
                //         case ExtensionKind.SSE2:
                //             def.Isa = IsaKind.SSE2;
                //         break;
                //         case ExtensionKind.SSE3:
                //             def.Isa = IsaKind.SSE3;
                //         break;
                //         case ExtensionKind.SSE4:
                //             def.Isa = IsaKind.SSE4;
                //         break;
                //         case ExtensionKind.VTX:
                //             def.Isa = IsaKind.VTX;
                //         break;
                //         case ExtensionKind.SSE4A:
                //             def.Isa = IsaKind.SSE4A;
                //         break;
                //         case ExtensionKind.SSSE3:
                //             def.Isa = IsaKind.SSSE3;
                //         break;
                //         case ExtensionKind.TBM:
                //             def.Isa = IsaKind.TBM;
                //         break;
                //         case ExtensionKind.XSAVE:
                //             def.Isa = IsaKind.XSAVE;
                //         break;
                //         case ExtensionKind.XSAVEC:
                //             def.Isa = IsaKind.XSAVEC;
                //         break;
                //         case ExtensionKind.XSAVEOPT:
                //             def.Isa = IsaKind.XSAVEOPT;
                //         break;
                //         case ExtensionKind.XSAVES:
                //             def.Isa = IsaKind.XSAVES;
                //         break;
                //         default:
                //         {

                //         }
                //         break;
                //     }
                // }
            }

            return defs;
        }
    }
}