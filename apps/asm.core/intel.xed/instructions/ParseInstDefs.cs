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
        void Parse(uint pattern, InstClass @class, InstForm form, string rawbody, string opexpr, out InstPatternSpec dst)
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
            OperandParser.create(XedPatterns.mode(pb)).Parse(pattern, opexpr, out Index<PatternOp> ops);
            dst = new InstPatternSpec(pattern, 0, @class, form, xedoc(pattern, pb), rawbody, pb, XedRender.format(pb), ops);
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
            var forms = dict<uint,InstForm>();
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
                    var @class = InstClass.Empty;
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
                                        dst.Attributes = XedPatterns.attributes(value);
                                    break;
                                    case P.Category:
                                        XedParsers.parse(value, out dst.Category);
                                    break;
                                    case P.Extension:
                                        XedParsers.parse(value, out dst.Extension);
                                    break;
                                    case P.Flags:
                                        XedParsers.parse(value, out dst.Effects);
                                    break;
                                    case P.Class:
                                    {
                                        XedParsers.parse(value, out dst.InstClass);
                                        @class = dst.InstClass;
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

                                        Parse(seq, @class, InstForm.Empty, body, value, out var spec);
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

                if(def.Isa.IsEmpty)
                {
                    switch(def.Extension.Kind)
                    {
                        case ExtensionKind._3DNOW:
                            def.Isa = IsaKind._3DNOW;
                            break;
                        case ExtensionKind.INVPCID:
                            def.Isa = IsaKind.INVPCID;
                            break;
                        case ExtensionKind.PCLMULQDQ:
                            def.Isa = IsaKind.PCLMULQDQ;
                            break;
                        case ExtensionKind.FMA4:
                            def.Isa = IsaKind.FMA4;
                        break;
                        case ExtensionKind.F16C:
                            def.Isa = IsaKind.F16C;
                        break;
                        case ExtensionKind.X87:
                            def.Isa = IsaKind.X87;
                        break;
                        case ExtensionKind.AES:
                            def.Isa = IsaKind.AES;
                        break;
                        case ExtensionKind.AVX:
                            def.Isa = IsaKind.AVX;
                        break;
                        case ExtensionKind.AVX2:
                            def.Isa = IsaKind.AVX2;
                        break;
                        case ExtensionKind.BMI1:
                            def.Isa = IsaKind.BMI1;
                        break;
                        case ExtensionKind.BMI2:
                            def.Isa = IsaKind.BMI2;
                        break;
                        case ExtensionKind.LONGMODE:
                            def.Isa = IsaKind.LONGMODE;
                        break;
                        case ExtensionKind.CLZERO:
                            def.Isa = IsaKind.CLZERO;
                        break;
                        case ExtensionKind.FMA:
                            def.Isa = IsaKind.FMA;
                        break;
                        case ExtensionKind.LZCNT:
                            def.Isa = IsaKind.LZCNT;
                            break;
                        case ExtensionKind.SSE:
                            def.Isa = IsaKind.SSE;
                        break;
                        case ExtensionKind.SSE2:
                            def.Isa = IsaKind.SSE2;
                        break;
                        case ExtensionKind.SSE3:
                            def.Isa = IsaKind.SSE3;
                        break;
                        case ExtensionKind.SSE4:
                            def.Isa = IsaKind.SSE4;
                        break;
                        case ExtensionKind.VTX:
                            def.Isa = IsaKind.VTX;
                        break;
                        case ExtensionKind.SSE4A:
                            def.Isa = IsaKind.SSE4A;
                        break;
                        case ExtensionKind.SSSE3:
                            def.Isa = IsaKind.SSSE3;
                        break;
                        case ExtensionKind.TBM:
                            def.Isa = IsaKind.TBM;
                        break;
                        case ExtensionKind.XSAVE:
                            def.Isa = IsaKind.XSAVE;
                        break;
                        case ExtensionKind.XSAVEC:
                            def.Isa = IsaKind.XSAVEC;
                        break;
                        case ExtensionKind.XSAVEOPT:
                            def.Isa = IsaKind.XSAVEOPT;
                        break;
                        case ExtensionKind.XSAVES:
                            def.Isa = IsaKind.XSAVES;
                        break;
                        default:
                        {

                        }
                        break;
                    }
                }
                def.InstId = iid;
                for(var j=0; j<specs.Count; j++, pid++)
                {
                    ref var pattern = ref specs[j];
                    if(forms.TryGetValue(pattern.PatternId, out var form))
                        pattern = pattern.WithForm(form);
                    pattern = pattern.WithIdentity(pid,iid);
                }
            }

            return defs;
        }
    }
}