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
    using P = XedModels.RulePart;
    using EK = XedModels.RuleExprKind;

    [ApiHost]
    public class XedRules : AppService<XedRules>
    {
        Symbols<IClass> Classes;

        Symbols<CategoryKind> Categories;

        Symbols<ExtensionKind> Extensions;

        Symbols<OperandKind> OperandKinds;

        Symbols<IsaKind> IsaKinds;

        Symbols<IFormType> Forms;

        Index<RulePart,string> PartNames;

        public XedRules()
        {
            Classes = Symbols.index<IClass>();
            Categories = Symbols.index<CategoryKind>();
            Extensions = Symbols.index<ExtensionKind>();
            Forms = Symbols.index<IFormType>();
            IsaKinds = Symbols.index<IsaKind>();
            OperandKinds = Symbols.index<OperandKind>();
            PartNames = new string[]{ICLASS,IFORM,ATTRIBUTES,CATEGORY,EXTENSION,FLAGS,PATTERN,OPERANDS,ISA_SET};
        }

        public void EmitCatalog()
        {
            EmitEncInstDefs();
            EmitDecInstDefs();
            EmitEncRuleTables();
            EmitDecRuleTables();
            EmitEncDecRuleTables();
        }



        public Index<InstDef> EmitEncInstDefs()
        {
            var src = ParseEncInstDefs();
            EmitEncInstDefs(src);
            return src;
        }

        public Index<InstDef> EmitDecInstDefs()
        {
            var src = ParseDecInstDefs();
            EmitDecInstDefs(src);
            return src;
        }

        public Index<RuleTable> EmitEncRuleTables()
        {
            var src = ParseEncRuleTables();
            EmitEncRuleTables(src);
            return src;
        }

        public Index<RuleTable> EmitDecRuleTables()
        {
            var src = ParseDecRuleTables();
            EmitDecRuleTables(src);
            return src;
        }

        public Index<RuleTable> EmitEncDecRuleTables()
        {
            var src = ParseEncDecRuleTables();
            EmitEncDecRuleTables(src);
            return src;
        }

        public Index<InstDef> ParseEncInstDefs()
            => ParseInstDefs(RuleSource(RuleDocKind.EncInstDef));

        public Index<InstDef> ParseDecInstDefs()
            => ParseInstDefs(RuleSource(RuleDocKind.DecInstDef));

        public FS.FilePath EmitEncInstDefs(ReadOnlySpan<InstDef> src)
            => Emit(src, RuleTarget(RuleDocKind.EncInstDef));

        public FS.FilePath EmitDecInstDefs(ReadOnlySpan<InstDef> src)
            => Emit(src, RuleTarget(RuleDocKind.DecInstDef));

        public FS.FilePath EmitEncRuleTables(ReadOnlySpan<RuleTable> src)
            => Emit(src, RuleTarget(RuleDocKind.EncRuleTable));

        public FS.FilePath EmitDecRuleTables(ReadOnlySpan<RuleTable> src)
            => Emit(src, RuleTarget(RuleDocKind.DecRuleTable));

        public FS.FilePath EmitEncDecRuleTables(ReadOnlySpan<RuleTable> src)
            => Emit(src, RuleTarget(RuleDocKind.EncDecRuleTable));

        FS.FilePath Emit(ReadOnlySpan<RuleTable> src, FS.FilePath dst)
        {
            var count = src.Length;
            var emitting = EmittingFile(dst);
            using var writer = dst.AsciWriter();
            for(var i=0; i<count; i++)
            {
                ref readonly var table = ref skip(src,i);
                if(table.ReturnType.IsNonEmpty)
                    writer.WriteLine(string.Format("{0} {1}()", table.ReturnType, table.Name));
                else
                    writer.WriteLine(string.Format("{0}()", table.Name));
                writer.WriteLine("{");
                foreach(var expr in table.Expressions)
                {
                    writer.WriteLine(string.Format("    {0}", expr.Format()));
                }
                writer.WriteLine("}");
                writer.WriteLine();
            }
            EmittedFile(emitting,count);
            return dst;
        }

        bool Part(string src, out RulePart part)
        {
            var count = PartNames.Count;
            var result = false;
            part = default;
            for(var i=0; i<count; i++)
            {
                var p = (RulePart)i;
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
                 RuleDocKind.EncRuleTable => FS.file("xed.rules.encoding.tables", FS.Txt),
                 RuleDocKind.DecRuleTable => FS.file("xed.rules.decoding.tables", FS.Txt),
                 RuleDocKind.EncDecRuleTable => FS.file("xed.rules.encdec.tables", FS.Txt),
                 _ => FS.FileName.Empty
            });


        const string RuleDeclMarker = "()::";

        const string InvokeMarker = "()";

        const string EncStepMarker = " -> ";

        const string DecStepMarker = " |";

        const string SeqDeclMarker = "SEQUENCE ";

        EK ClassifyExpr(TextLine src)
        {
            var i = text.index(src.Content, Chars.Hash);
            var content = (i> 0 ? text.left(src.Content,i) : src.Content).Trim();

            if(content.EndsWith(RuleDeclMarker))
                return EK.RuleDeclaration;
            if(content.Contains(EncStepMarker))
                return EK.EncodeStep;
            if(content.Contains(DecStepMarker))
                return EK.DecodeStep;
            if(content.EndsWith(InvokeMarker))
                return EK.Invocation;
            if(content.StartsWith(SeqDeclMarker))
                return EK.SeqDeclaration;
            return 0;
        }

        static MsgPattern<string> StepParseFailed => "Failed to parse step fromo '{0}'";

        public Index<RuleTable> ParseEncRuleTables()
            => ParseRuleTables(RuleSource(RuleDocKind.EncRuleTable));

        public Index<RuleTable> ParseDecRuleTables()
            => ParseRuleTables(RuleSource(RuleDocKind.DecRuleTable));

        public Index<RuleTable> ParseEncDecRuleTables()
            => ParseRuleTables(RuleSource(RuleDocKind.EncDecRuleTable));

        Index<RuleTable> ParseRuleTables(FS.FilePath src)
        {
            var tables = list<RuleTable>();
            using var reader = src.Utf8LineReader();
            var table = RuleTable.Empty;
            var expressions = list<RuleExpr>();
            var kind = EK.None;
            var line = TextLine.Empty;

            void ParseSeqTerms()
            {
                while(reader.Next(out line))
                {
                    if(line.IsEmpty || line.StartsWith(Chars.Hash))
                        continue;

                    kind = ClassifyExpr(line);
                    if(kind == 0 || kind == EK.Invocation)
                        continue;
                    else
                        break;
                }
            }

            string Normalize(string src)
            {
                var i = text.index(src, Chars.Hash);
                if(i>0)
                    return text.trim(text.left(src,i));
                else
                    return text.trim(src);
            }


            Outcome ParseRuleDeclTerms()
            {
                var result = Outcome.Success;
                while(reader.Next(out line))
                {
                    if(line.IsEmpty || line.StartsWith(Chars.Hash))
                        continue;

                    kind = ClassifyExpr(line);
                    if(kind == 0)
                        continue;

                    var content = Normalize(line.Content);
                    var parts = sys.empty<string>();
                    if(kind == EK.EncodeStep)
                    {
                        parts = text.split(content, EncStepMarker).Map(x => x.Trim());
                        if(parts.Length == 2)
                            table.Expressions.Add(new RuleExpr(kind, parts[0], parts[1]));
                        else
                        {
                            result = (false, StepParseFailed.Format(content));
                            break;
                        }
                    }
                    else if(kind == EK.DecodeStep)
                    {
                        parts = text.split(content, DecStepMarker).Map(x => x.Trim());
                        if(parts.Length == 1)
                            table.Expressions.Add(new RuleExpr(kind, parts[0], EmptyString));
                        else if(parts.Length == 2)
                            table.Expressions.Add(new RuleExpr(kind, parts[0], parts[1]));
                        else
                        {
                            result = (false, StepParseFailed.Format(content));
                            break;
                        }
                    }
                    else
                        break;

                }
                return result;
            }

            Outcome ParseRuleDecl()
            {
                var result = Outcome.Success;
                var ruledecl = text.trim(text.left(line.Content, RuleDeclMarker));
                var i = text.index(ruledecl, Chars.Space);
                if(i > 0)
                {
                    table.Name = text.right(ruledecl,i);
                    table.ReturnType = text.left(ruledecl,i);
                }
                else
                {
                    table.Name = ruledecl;
                    table.ReturnType = EmptyString;
                }
                result = ParseRuleDeclTerms();
                if(result.Fail)
                    return result;
                tables.Add(table);
                table = RuleTable.Empty;
                return result;
            }

            Outcome ParseNext()
            {
                var result = Outcome.Success;
                if(kind == EK.SeqDeclaration)
                    ParseSeqTerms();

                while(kind == EK.RuleDeclaration)
                {
                    result = ParseRuleDecl();
                    if(result.Fail)
                        return result;
                }

                return result;
            }

            while(reader.Next(out line))
            {
                if(line.IsEmpty || line.StartsWith(Chars.Hash))
                    continue;

                kind = ClassifyExpr(line);
                var result = ParseNext();
                if(result.Fail)
                {
                    Error(result.Message);
                    break;
                }
            }

            return tables.ToArray();
        }

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

            return buffer.ToArray().Sort();
        }

        public Outcome ParseAssignment(string src, out OperandAssignment dst)
        {
            var result = Outcome.Success;
            dst = OperandAssignment.Empty;
            var i = text.index(src,Chars.Eq);
            if(i >  0)
            {
                result = OperandKinds.MapExpr(text.trim(text.left(src,i)), out var kind);
                if(result)
                {
                    result = Parse(text.trim(text.right(src,i)),kind, out var value);
                    dst = new OperandAssignment(kind,value);
                }
            }
            else
            {
                result = (false, "Not an assignment");
            }
            return result;
        }

        Outcome Parse(string src, OperandKind kind, out ulong dst)
        {
            var result = Outcome.Success;
            dst = default;
            switch(kind)
            {
                case OperandKind.REG0:
                break;

                default:
                    break;
            }
            return result;
        }
    }
}