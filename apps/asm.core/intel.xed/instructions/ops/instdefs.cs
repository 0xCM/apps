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

    using P = XedRules.InstRulePart;

    partial class XedPatterns
    {
        public static Index<InstDef> instdefs(FS.FilePath src)
        {
            var buffer = list<InstDef>();
            using var reader = src.Utf8LineReader();
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
                                        XedParsers.parse(value, out  dst.FlagEffects);
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

                                        XedParsers.parse(seq++, @class, body, value, out var spec);
                                        specs.Add(spec);
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
                def.InstId = i;
                ref var patterns = ref def.PatternSpecs;
                for(var j=0; j<patterns.Count; j++)
                    patterns[j] = patterns[j].WithInstId(i);
            }

            return defs;


            static TextLine cleanse(TextLine src)
            {
                var dst = text.despace(src.Content);
                var i = text.index(dst, Chars.Hash);
                if(i > 0)
                    dst = text.left(dst,i);
                dst = text.trim(dst);
                return new TextLine(src.LineNumber, dst);
            }
        }
    }
}