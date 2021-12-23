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

        IForm,

        Attributes,

        Category,

        Extension,

        Flags,

        Pattern,

        Operands,

        Isa
    }

    [ApiHost]
    public class XedRules : AppService<XedRules>
    {
        Symbols<IClass> Classes;

        Symbols<CategoryKind> Categories;

        Symbols<ExtensionKind> Extensions;

        Symbols<IsaKind> IsaKinds;

        Symbols<IFormType> Forms;

        Index<XedRulePart,string> PartNames;

        public XedRules()
        {
            Classes = Symbols.index<IClass>();
            Categories = Symbols.index<CategoryKind>();
            Extensions = Symbols.index<ExtensionKind>();
            Forms = Symbols.index<IFormType>();
            IsaKinds = Symbols.index<IsaKind>();
            PartNames = new string[]{ICLASS,IFORM,ATTRIBUTES,CATEGORY,EXTENSION,FLAGS,PATTERN,OPERANDS,ISA_SET};
        }

        public Index<InstDef> ParseEncInstDefs()
            => ParseInstDefs(RuleSource(RuleDocKind.EncInstDef));

        public Index<InstDef> ParseDecInstDefs()
            => ParseInstDefs(RuleSource(RuleDocKind.DecInstDef));

        public FS.FilePath EmitEncInstDefs(ReadOnlySpan<InstDef> src)
            => Emit(src,RuleTarget(RuleDocKind.EncInstDef));

        public FS.FilePath EmitDecInstDefs(ReadOnlySpan<InstDef> src)
            => Emit(src,RuleTarget(RuleDocKind.DecInstDef));

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

        Outcome Parse(string src, out IsaKind dst)
            => IsaKinds.ExprKind(src, out dst);

        Outcome Parse(string src, out Category dst)
        {
            dst = default;
            var result = Categories.ExprKind(src, out var kind);
            if(result)
                dst = kind;
            return result;
        }

        Outcome Parse(string src, out Index<AttributeKind> dst)
        {
            dst = attributes(src,Chars.Space);
            return true;
        }

        Outcome Parse(string src, out Extension dst)
        {
            dst = default;
            var result = Extensions.ExprKind(src, out var kind);
            if(result)
                dst = kind;
            return result;
        }

        Outcome Parse(string src, out IForm dst)
        {
            dst = default;
            var result = Forms.ExprKind(src, out var kind);
            if(result)
                dst = kind;
            return result;
        }

        FS.FilePath Emit(ReadOnlySpan<InstDef> src, FS.FilePath dst)
        {
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var i=0; i<src.Length; i++)
            {
                ref readonly var def = ref skip(src,i);
                writer.WriteLine(RP.PageBreak120);
                writer.WriteLine(string.Format("{0}:{1}", nameof(def.Class), def.Class));
                if(def.Form.IsNonEmpty)
                    writer.WriteLine(string.Format("{0}:{1}", nameof(def.Form), def.Form));
                writer.WriteLine(string.Format("{0}:{1}", nameof(def.Category), def.Category));
                writer.WriteLine(string.Format("{0}:{1}", nameof(def.Extension), def.Extension));
                if(def.Isa != 0)
                    writer.WriteLine(string.Format("{0}:{1}", nameof(def.Isa), def.Isa));
                if(def.Attributes.IsNonEmpty)
                    writer.WriteLine(string.Format("{0}:{1}", nameof(def.Attributes), def.Attributes.Delimit(fence:Fencing.Embraced)));
                iter(def.PatternOps, p => {
                    writer.WriteLine(string.Format("{0}:{1}", "Pattern", p.Pattern));
                    writer.WriteLine(string.Format("{0}:{1}", "Operands", p.Operands.Delimit(fence:Fencing.Embraced)));
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
                 RuleDocKind.EncInstDef => FS.file("xed.rules.encoding", FS.Txt),
                 RuleDocKind.DecInstDef=> FS.file("xed.rules.decoding", FS.Txt),
                 _ => FS.FileName.Empty
            });

        Index<InstDef> ParseInstDefs(FS.FilePath src)
        {
            var buffer = list<InstDef>();
            using var reader = src.Utf8LineReader();
            var def = default(InstDef);
            while(reader.Next(out var line))
            {
                if(line.IsEmpty || line.StartsWith(Chars.Hash) || line.EndsWith("::"))
                    continue;

                if(line.StartsWith(Chars.LBrace))
                {
                    var dst = default(InstDef);
                    var pattern = EmptyString;
                    var operands = list<PatternOperands>();
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
                                    case P.IForm:
                                        Parse(value, out dst.Form);
                                    break;
                                    case P.Attributes:
                                        Parse(value, out dst.Attributes);
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
                                            var ops = text.split(text.despace(value), Chars.Space).Select(x => new RuleOperand(x));
                                            operands.Add(new PatternOperands(pattern, ops));
                                            pattern=EmptyString;
                                        }
                                    break;
                                    case P.Pattern:
                                        pattern = value;
                                    break;
                                    case P.Isa:
                                        Parse(value, out dst.Isa);
                                    break;
                                }
                            }
                        }
                    }

                    dst.PatternOps = operands.Array();
                    buffer.Add(dst);
                }
            }

            return buffer.ToArray();
        }
    }
}