//-----------------------------------------------------------------------------
// Copyright   :  (c) Chris Moore, 2020
// License     :  MIT
//-----------------------------------------------------------------------------
namespace Z0
{
    using System;
    using static XedModels;
    using static core;
    using static Root;

    using static XedModels.RuleNames;

    using P = XedRulePart;

    public enum XedRulePart : byte
    {
        IClass,

        Attributes,

        Category,

        Extension,

        Flags,

        Pattern,

        Operands
    }

    [ApiHost]
    public class XedRules : AppService<XedRules>
    {
        Symbols<IClass> Classes;

        Symbols<CategoryKind> Categories;

        Symbols<ExtensionKind> Extensions;

        Index<XedRulePart,string> PartNames;

        public XedRules()
        {
            Classes = Symbols.index<IClass>();
            Categories = Symbols.index<CategoryKind>();
            Extensions = Symbols.index<ExtensionKind>();
            PartNames = new string[]{ICLASS,ATTRIBUTES,CATEGORY,EXTENSION,FLAGS,PATTERN,OPERANDS};
        }

        bool Part(string src, out XedRulePart part)
        {
            var count = PartNames.Count;
            var result = false;
            part = default;
            for(var i=0; i<count; i++)
            {
                var p = (XedRulePart)i;
                ref readonly var n = ref PartNames[p];
                if(n == src)
                {
                    part = p;
                    result = true;
                    break;
                }
            }
            return result;
        }

        Outcome Parse(string src, out IClass dst)
            => Classes.ExprKind(src, out dst);

        Outcome Parse(string src, out Category dst)
        {
            dst = default;
            var result = Categories.ExprKind(src, out var kind);
            if(result)
                dst = kind;
            return result;
        }

        Outcome Parse(string src, out Extension dst)
        {
            dst = default;
            var result = Extensions.ExprKind(src, out var kind);
            if(result)
                dst = kind;
            return result;
        }

        public FS.FilePath Emit(ReadOnlySpan<EncInstDef> src)
        {
            var dst = RuleTarget(RuleDocKind.EncInstDef);
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var def = ref skip(src,i);
                writer.WriteLine(RP.PageBreak120);
                writer.WriteLine(string.Format("{0}:{1}", nameof(def.Class), def.Class));
                writer.WriteLine(string.Format("{0}:{1}", nameof(def.Category), def.Category));
                writer.WriteLine(string.Format("{0}:{1}", nameof(def.Extension), def.Extension));
                iter(def.PatternOps, p => {
                    writer.WriteLine(string.Format("{0}:{1}", "Pattern", p.Pattern));
                    writer.WriteLine(string.Format("{0}:{1}", "Operands", p.Operands));
                });
                writer.WriteLine();
            }
            EmittedFile(emitting,src.Length);
            return dst;
        }

        FS.FolderPath Sources()
            => ProjectDb.Sources("intel/xed.primary");

        FS.FolderPath Targets()
            => ProjectDb.Subdir("xed");

        FS.FilePath RuleSource(RuleDocKind kind)
            => Sources() + FS.file(Symbols.format(kind), FS.Txt);

        FS.FilePath RuleTarget(RuleDocKind kind)
            => Targets() + ( kind switch{
                 RuleDocKind.EncInstDef => FS.file("xed.rules.instdef", FS.Txt),
                 _ => FS.FileName.Empty
            });

        public Index<EncInstDef> ParseEncInstDefs()
        {
            var src = RuleSource(RuleDocKind.EncInstDef);
            var buffer = list<EncInstDef>();
            using var reader = src.Utf8LineReader();
            var def = default(EncInstDef);
            while(reader.Next(out var line))
            {
                if(line.IsEmpty || line.StartsWith(Chars.Hash) || line.EndsWith("::"))
                    continue;

                if(line.StartsWith(Chars.LBrace))
                {
                    var dst = default(EncInstDef);
                    var pattern = EmptyString;
                    var pops = list<PatternOperands>();
                    while(!line.StartsWith(Chars.RBrace) && reader.Next(out line))
                    {
                        if(line.IsEmpty)
                            continue;

                        ref readonly var content = ref line.Content;
                        var i = text.index(content, Chars.Colon);
                        if(i > 0)
                        {
                            var name = text.trim(text.left(content,i));
                            var value = text.trim(text.right(content,i));
                            if(Part(name, out var p))
                            {
                                switch(p)
                                {
                                    case P.Attributes:
                                    break;
                                    case P.Category:
                                        Parse(value, out dst.Category);
                                    break;
                                    case P.Extension:
                                        Parse(value, out dst.Extension);
                                    break;
                                    case P.Flags:
                                    break;
                                    case P.IClass:
                                        Parse(value, out dst.Class);
                                    break;
                                    case P.Operands:
                                        if(nonempty(pattern))
                                        {
                                            pops.Add(new PatternOperands(pattern, value));
                                            pattern=EmptyString;
                                        }
                                    break;
                                    case P.Pattern:
                                        pattern = value;
                                    break;
                                }
                            }
                        }
                    }

                    dst.PatternOps = pops.Array();
                    buffer.Add(dst);
                }
            }

            return buffer.ToArray();
        }
    }
}